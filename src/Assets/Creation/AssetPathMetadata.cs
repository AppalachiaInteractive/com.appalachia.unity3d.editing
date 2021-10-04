using System;
using System.IO;
using UnityEditor;

namespace Appalachia.Editing.Assets.Creation
{
    [Serializable]
    public class AssetPathMetadata
    {
        public bool isDirectory;
        public bool doesExist;
        public string absolutePath;
        public string relativePath;

        public AssetPathMetadata(string fullPath, bool isDirectory)
        {
            absolutePath = fullPath;
            this.isDirectory = isDirectory;

            var assetStringIndex = absolutePath.IndexOf("Assets", StringComparison.Ordinal);

            relativePath = absolutePath.Substring(assetStringIndex);

            doesExist = this.isDirectory
                ? Directory.Exists(absolutePath)
                : File.Exists(absolutePath);
        }

        public void CreateDirectoryStructure()
        {
            var di = new DirectoryInfo(absolutePath);

            if (di.Exists)
            {
                doesExist = true;
                return;
            }

            di.Create();

            AssetDatabase.ImportAsset(relativePath);
            doesExist = true;
        }
    }
}
