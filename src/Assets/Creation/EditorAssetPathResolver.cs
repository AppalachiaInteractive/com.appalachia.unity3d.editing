using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Appalachia.Editing.Assets.Creation
{
    public static class EditorAssetPathResolver
    {
        private static StringBuilder _pathBuilder;

        public static AssetPathMetadata GetAssetCreationPath<T>()
        {
            var type = typeof(T);
            var ns = type.Namespace;

            var parts = ns.Split('.');

            var assetPath = Application.dataPath;

            if (_pathBuilder == null)
            {
                _pathBuilder = new StringBuilder();
            }
            else
            {
                _pathBuilder.Clear();
            }

            var fullArray = parts.Prepend(assetPath).ToArray();

            var fullPath = Path.Combine(fullArray);

            var output = new AssetPathMetadata(fullPath, true);

            return output;
        }
    }
}
