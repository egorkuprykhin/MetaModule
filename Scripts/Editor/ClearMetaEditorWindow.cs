using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    public class ClearMetaEditorWindow : EditorWindow
    {
        private Object _dotween;
        private Object _unitask;
        private Object _uiparticle;
        private Object _scriptsMeta;
        private Object _scriptsCore;

        [MenuItem("Tools/Regenerate Meta Window")]
        public new static void Show()
        {
            EditorWindow window = GetWindow<ClearMetaEditorWindow>("Regenerate Meta Window");
            window.Show();
        }

        private void OnGUI()
        {
            _dotween = EditorGUILayout.ObjectField("Dotween", _dotween, typeof(Object), false);
            _unitask = EditorGUILayout.ObjectField("Unitask", _unitask, typeof(Object), false);
            _uiparticle = EditorGUILayout.ObjectField("Uiparticle", _uiparticle, typeof(Object), false);
            _scriptsMeta = EditorGUILayout.ObjectField("Scripts meta", _scriptsMeta, typeof(Object), false);
            _scriptsCore = EditorGUILayout.ObjectField("Scripts core", _scriptsCore, typeof(Object), false);

            if (GUILayout.Button("Process")) 
                Process();
        }

        private void Process()
        {
            ProcessFolder(_dotween);
            ProcessFolder(_unitask);
            ProcessFolder(_uiparticle);
            ProcessFolder(_scriptsMeta);
            ProcessFolder(_scriptsCore);
            
            Debug.Log("Done");
        }

        private void ProcessFolder(Object folder)
        {
            var path = AssetDatabase.GetAssetPath(folder);
            if (!AssetDatabase.IsValidFolder(path))
                return;
            path = path.Replace("Assets/", "");

            var fullPath = $"{Application.dataPath}/{path}";
            
            var metaFiles = Directory.GetFiles(fullPath, "*.meta", SearchOption.AllDirectories);
            for (var index = 0; index < metaFiles.Length; index++)
            {
                var file = metaFiles[index];
                string newGuid;

                var lines = new List<string>();
                
                using (var input = new StreamReader(file))
                {
                    while (input.ReadLine() is { } line)
                    {
                        if (line.Contains("guid"))
                        {
                            var oldGuid = line.Substring(line.IndexOf(" ", StringComparison.Ordinal));
                            Debug.Log("Old guid: " + oldGuid);

                            newGuid = GenerateMd5(oldGuid).ToLowerInvariant();
                            Debug.Log("New guid: " + newGuid);

                            var newLine = line.Replace(oldGuid, " " + newGuid);
                            lines.Add(newLine);
                        }
                        else
                            lines.Add(line);
                    }
                }

                using (var output = new StreamWriter(file))
                {
                    for (int i = 0; i < lines.Count - 1; i++) 
                        output.WriteLine(lines[i]);
                    
                    var lastLine = lines[lines.Count - 1];
                    if (lastLine.Contains("assetBundleVariant"))
                        output.WriteLine(lastLine);
                    else output.Write(lastLine);
                }
            }
        }

        private string GenerateMd5(string source)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(source);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("X2"));

            var generated = sb.ToString();
                                
            return generated;
        }
    }
}