#region

using System;
using Appalachia.CI.Integration.Assets;

#endregion

namespace Appalachia.Editing.Assets
{
    public class AssetEditingScope : IDisposable
    {
        private readonly bool _doEdit;

        public AssetEditingScope(bool doEdit = true)
        {
            _doEdit = doEdit;

            if (_doEdit)
            {
                AssetDatabaseManager.StartAssetEditing();
            }
        }

        void IDisposable.Dispose()
        {
            if (_doEdit)
            {
                AssetDatabaseManager.StopAssetEditing();
            }
        }
    }
}
