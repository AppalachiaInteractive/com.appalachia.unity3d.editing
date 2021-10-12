using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class FoldoutMetadata : LabelledFieldMetadataBase<FoldoutMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.foldoutHeader;

        public bool Foldout(ref bool isOpen)
        {
            isOpen = EditorGUILayout.Foldout(isOpen, content, style);

            return isOpen;
        }
    }
}
