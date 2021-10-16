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
            hasBeenDrawn = true;
            isOpen = EditorGUILayout.Foldout(isOpen, content, style);

            return isOpen;
        }
    }
}
