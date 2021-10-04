#region

using System;
using UnityEditor;

#endregion

namespace Appalachia.Editing.Assets
{
    public class AssetEditingScope : IDisposable
    {
        public AssetEditingScope()
        {
            AssetDatabase.StartAssetEditing();
        }

        void IDisposable.Dispose()
        {
            AssetDatabase.StopAssetEditing();
        }
    }
}
