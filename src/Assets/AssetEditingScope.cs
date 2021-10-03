#region

using System;
using UnityEditor;

#endregion

namespace Appalachia.Core.Editing.AssetDB
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
