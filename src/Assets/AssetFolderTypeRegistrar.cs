using AmplifyImpostors;
using Appalachia.CI.Integration.Assets;
using UnityEditor;

namespace Appalachia.Editing.Assets
{
    public static class AssetFolderTypeRegistrar
    {
        [InitializeOnLoadMethod]
        public static void RegisterAssetTypesToFolders()
        {
            AssetDatabaseManager.RegisterAdditionalAssetTypeFolders(
                typeof(AmplifyShaderFunction),
                (_, _) => "AmplifyShaderFunctions"
            );
            AssetDatabaseManager.RegisterAdditionalAssetTypeFolders(
                typeof(AmplifyImpostorBakePreset),
                (_, _) => "AmplifyImpostorBakePresets"
            );
        }
    }
}
