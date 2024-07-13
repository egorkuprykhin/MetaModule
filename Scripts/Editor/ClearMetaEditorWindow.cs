using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class ClearMetaEditorWindow
    {
        private static List<string> SkipFolders = new List<string> { "Sprites", "Fonts", "Scenes" };

        [MenuItem("Tools/Process Meta Files")]
        private static void ProcessFolder()
        {
            var fullPath = $"{Application.dataPath}";
            
            var metaFiles = Directory.GetFiles(fullPath, "*.meta", SearchOption.AllDirectories);
            for (var index = 0; index < metaFiles.Length; index++)
            {
                
                if (NeedSkipFolder(metaFiles[index]))
                    continue;
                
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

        private static bool NeedSkipFolder(string metaFile)
        {
            foreach (var folder in SkipFolders)
            {
                if (metaFile.Contains(folder))
                    return true;
            }

            return false;
        }

        private static string GenerateMd5(string source)
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