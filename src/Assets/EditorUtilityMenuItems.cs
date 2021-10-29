using UnityEditor;

namespace Appalachia.Editing.Assets
{
    public static class EditorUtilityMenuItems
    {
        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Assembly/Unload Unused Assets")]
        private static void UnloadUnusedAssetsImmediate()
        {
            EditorUtility.UnloadUnusedAssetsImmediate();
        }
    }
}
