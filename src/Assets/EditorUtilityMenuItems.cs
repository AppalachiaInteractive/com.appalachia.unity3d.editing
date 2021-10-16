using UnityEditor;

namespace Appalachia.Editing.Assets
{
    public static class EditorUtilityMenuItems
    {
        [MenuItem("Tools/Assembly/Request Script Reload")]
        private static void RequestScriptReload()
        {
            EditorUtility.RequestScriptReload();
        }

        [MenuItem("Tools/Assembly/Unload Unused Assets")]
        private static void UnloadUnusedAssetsImmediate()
        {
            EditorUtility.UnloadUnusedAssetsImmediate();
        }
    }
}
