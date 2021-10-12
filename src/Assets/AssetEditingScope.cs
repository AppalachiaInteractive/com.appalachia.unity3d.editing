#region

using System;
using UnityEditor;

#endregion

namespace Appalachia.Editing.Assets
{
    public class AssetEditingScope : IDisposable
    {
        private bool _doEdit;
        
        public AssetEditingScope(bool doEdit = true)
        {
            _doEdit = doEdit;
            
            if (_doEdit)
            {
                AssetDatabase.StartAssetEditing();                
            }
            
        }

        void IDisposable.Dispose()
        {
            if (_doEdit)
            {
                AssetDatabase.StopAssetEditing();                
            }            
        }
    }
}
