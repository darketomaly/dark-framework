#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace DarkEngine
{
    public static class DarkEngineTools
    {
        #if UNITY_EDITOR
    
        [MenuItem("Tools/Recompile")]
        public static void Test()
        {
            EditorUtility.RequestScriptReload();
        }
    
        #endif
    }
}
