using System;
using Appalachia.Core.Collections;
using Appalachia.Core.Preferences;
using Appalachia.Core.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Core
{
    [InlineProperty]
    [Serializable]
    [HideDuplicateReferenceBox]
    [HideReferenceObjectPicker]
    public abstract class MetadataLookupSelection<TS, T, TValue, TL> : AppalachiaObject
        where TS : MetadataLookupSelection<TS, T, TValue, TL>
        where T : AppalachiaMetadataCollection<T, TValue, TL>
        where TValue : AppalachiaObject, ICategorizable
        where TL : AppaList<TValue>, new()
    {
        protected Action<TValue> _selection;
        protected T _instance;

        public PREF<Color> ButtonColor { get; set; }
        public PREF<float> ButtonColorDrop { get; set; }
        public Action<TValue> Selection => _selection;

        public T Instance => _instance;

        public virtual TS Initialize(
            T instance,
            Action<TValue> select,
            PREF<Color> buttonColor,
            PREF<float> buttonColorDrop)
        {
            _instance = instance;
            _selection = select;
            ButtonColor = buttonColor;
            ButtonColorDrop = buttonColorDrop;

            return this as TS;
        }

        public Color GetButtonRowColor(int row, float drop, Color color)
        {
            for (var i = 0; i < row; i++)
            {
                color.r *= drop;
                color.g *= drop;
                color.b *= drop;
            }

            return color;
        }
    }
}
