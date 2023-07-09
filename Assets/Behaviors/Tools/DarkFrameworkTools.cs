#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace DarkFramework
{
    public static class DarkFrameworkTools
    {
        #if UNITY_EDITOR
    
        [MenuItem("Tools/Recompile")]
        public static void Recompile()
        {
            EditorUtility.RequestScriptReload();
        }

        [MenuItem("Tools/Open data folder")]
        public static void OpenDataFolder()
        {
            EditorUtility.RevealInFinder($"{Application.persistentDataPath}/{Application.productName}");
        }
    
        #endif
    }
}
