using System;
using Appalachia.Editing.Core.State;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ObjectFieldMetadata : LabelledFieldMetadataBase<ObjectFieldMetadata>
    {
        private GUIStyle _backupStyle;

        protected override GUIStyle DefaultStyle
        {
            get
            {
                if (_defaultStyle == null)
                {
                    _defaultStyle = new GUIStyle(EditorStyles.objectField);
                }

                return _defaultStyle;
            }
        }

        public T Draw<T>(T obj, bool allowSceneObjects = false)
            where T : Object
        {
            hasBeenDrawn = true;
            UIStateStacks.labelWidth.Push(prefixLabelWidth);

            var result = EditorGUILayout.ObjectField(content, obj, typeof(T), allowSceneObjects);

            UIStateStacks.labelWidth.Pop();

            return (T) result;
        }

        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true)};
        }
    }
}
