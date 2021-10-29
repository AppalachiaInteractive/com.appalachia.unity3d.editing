using System.IO;
using Appalachia.Core.Assets;
using UnityEditor;

namespace Appalachia.Editing.Assets.Context
{
    public static class AssetSubfolders
    {
        private const string _MATERIALS_FOLDER = "Materials";
        private const string _MESHES_FOLDER = "Meshes";
        private const string _PREFABS_FOLDER = "Prefabs";
        private const string _TEXTURES_FOLDER = "Textures";

        private static bool _assetsSaved;

        [UnityEditor.MenuItem(PKG.Menu.Assets.Base + "Make/Asset Subfolders")]
        public static void CreateFolders(MenuCommand c)
        {
            if (_assetsSaved)
            {
                return;
            }

            var folders = Selection.GetFiltered<DefaultAsset>(SelectionMode.Assets);

            for (var i = 0; i < folders.Length; i++)
            {
                var folder = folders[i];

                var main = AssetDatabase.GetAssetPath(folder);

                var textures = Path.Combine(main,  _TEXTURES_FOLDER);
                var materials = Path.Combine(main, _MATERIALS_FOLDER);
                var meshes = Path.Combine(main,    _MESHES_FOLDER);
                var prefabs = Path.Combine(main,   _PREFABS_FOLDER);

                Directory.CreateDirectory(textures);
                Directory.CreateDirectory(materials);
                Directory.CreateDirectory(meshes);
                Directory.CreateDirectory(prefabs);

                MoveAssetsToSubfolder(main, "t:Texture2D", textures);
                MoveAssetsToSubfolder(main, "t:Material",  materials);
                MoveAssetsToSubfolder(main, "t:Mesh",      meshes);
                MoveAssetsToSubfolder(main, "t:Model",     meshes);
                MoveAssetsToSubfolder(main, "t:Prefab",    prefabs);
            }

            AssetDatabaseSaveManager.SaveAssetsNextFrame("SUBFOLDERS", () => { _assetsSaved = false; });
        }

        private static void MoveAssetsToSubfolder(
            string baseDirectory,
            string searchFilter,
            string targetDirectory)
        {
            var assetGuids = AssetDatabase.FindAssets(searchFilter, new[] {baseDirectory});

            for (var j = 0; j < assetGuids.Length; j++)
            {
                var textureSubasset = assetGuids[j];
                var assetPath = AssetDatabase.GUIDToAssetPath(textureSubasset);

                var filePath = Path.GetFileName(assetPath);

                var newFilePath = Path.Combine(targetDirectory, filePath);

                AssetDatabase.MoveAsset(assetPath, newFilePath);
            }
        }
    }
}
