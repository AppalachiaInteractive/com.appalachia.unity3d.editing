using System.Collections.Generic;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Scene.Windows
{
    public class TransformRandomizer : AppalachiaEditorWindow
    {
        public List<GameObject> objectsToRandomize = new();

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 25)]
        public CheckboxField<float> positionX;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 25)]
        public CheckboxField<float> positionY;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 25)]
        public CheckboxField<float> positionZ;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 360)]
        public CheckboxField<float> rotationX;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 360)]
        public CheckboxField<float> rotationY;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 360)]
        public CheckboxField<float> rotationZ;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 10)]
        public CheckboxField<float> scaleX;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 10)]
        public CheckboxField<float> scaleY;

        [InlineProperty]
        [CheckboxEnabled(EnableIf = true, Min = 0, Max = 10)]
        public CheckboxField<float> scaleZ;

        public TransformRandomizer()
        {
            Reset();
        }

        [Button]
        public void Randomize()
        {
            foreach (var obj in objectsToRandomize)
            {
                var pos = obj.transform.localPosition;
                var rot = obj.transform.localRotation.eulerAngles;
                var scale = obj.transform.localScale;

                if (positionX.enabled)
                {
                    pos.x += Random.Range(-positionX.value, positionX.value);
                }

                if (positionY.enabled)
                {
                    pos.y += Random.Range(-positionY.value, positionY.value);
                }

                if (positionZ.enabled)
                {
                    pos.z += Random.Range(-positionZ.value, positionZ.value);
                }

                if (rotationX.enabled)
                {
                    rot.x += Random.Range(-rotationX.value, rotationX.value);
                }

                if (rotationY.enabled)
                {
                    rot.y += Random.Range(-rotationY.value, rotationY.value);
                }

                if (rotationZ.enabled)
                {
                    rot.z += Random.Range(-rotationZ.value, rotationZ.value);
                }

                if (scaleX.enabled)
                {
                    scale.x += Random.Range(-scaleX.value, scaleX.value);
                }

                if (scaleY.enabled)
                {
                    scale.y += Random.Range(-scaleY.value, scaleY.value);
                }

                if (scaleZ.enabled)
                {
                    scale.z += Random.Range(-scaleZ.value, scaleZ.value);
                }

                obj.transform.localPosition = pos;
                obj.transform.localRotation = Quaternion.Euler(rot);
                obj.transform.localScale = scale;
            }
        }

        [Button]
        public void Reset()
        {
            objectsToRandomize = new List<GameObject>();

            positionX.enabled = false;
            positionX.value = 0f;
            positionY.enabled = false;
            positionY.value = 0f;
            positionZ.enabled = false;
            positionZ.value = 0f;

            rotationX.enabled = false;
            rotationX.value = 0f;
            rotationY.enabled = false;
            rotationY.value = 0f;
            rotationZ.enabled = false;
            rotationZ.value = 0f;

            scaleX.enabled = false;
            scaleX.value = 0f;
            scaleY.enabled = false;
            scaleY.value = 0f;
            scaleZ.enabled = false;
            scaleZ.value = 0f;
        }

        [MenuItem("Tools/Transform Randomizer")]
        private static void OpenWindow()
        {
            OpenWindow<TransformRandomizer>();
        }
    }
}
