using Appalachia.Core.Extensions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class PreviewObjectField<TF, TT> : PrefixLabelFieldBase<TF>
        where TT : Object
        where TF : PreviewObjectField<TF, TT>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.objectField;

        private TT _previewValue;
        private Texture2D _preview;
        
        public TT Draw(TT value) 
        {
            using (new GUILayout.HorizontalScope())
            {
                DrawPrefixLabel();
            
                var newValue = (TT) EditorGUILayout.ObjectField(value, typeof(TT), false);
            
                if (_preview == null)
                {
                    _previewValue = newValue;
                }
                else if (_previewValue != newValue)
                {   
                    _previewValue = newValue;
                }

                return newValue;
            }
        }

        public void DrawPreview()
        {
            _preview = AssetPreview.GetAssetPreview(_previewValue);
            GUILayout.Label(_preview);
            _preview.DestroySafely();
        }
    }
}
