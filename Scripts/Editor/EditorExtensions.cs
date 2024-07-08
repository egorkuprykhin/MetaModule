using UnityEngine.SceneManagement;

namespace Editor
{
    public static class EditorExtensions
    {
        public static T Find<T>(this Scene scene)
        {
            foreach (var rootGameObject in scene.GetRootGameObjects())
                if (rootGameObject.TryGetComponent(out T component))
                    return component;
            
            foreach (var rootGameObject in scene.GetRootGameObjects())
            {
                var component = rootGameObject.GetComponentInChildren<T>();
                if (component != null)
                    return component;
            }

            return default;
        }
    }
}