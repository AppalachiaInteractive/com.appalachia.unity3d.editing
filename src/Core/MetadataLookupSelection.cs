using System;
using Appalachia.Core.Collections;
using Appalachia.Core.Objects.Root;
using Appalachia.Core.Objects.Scriptables;
using Appalachia.Core.Preferences;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Core
{
    [InlineProperty]
    [Serializable]
    [HideDuplicateReferenceBox]
    [HideReferenceObjectPicker]
    public abstract class MetadataLookupSelection<TMLS, TMC, TValue, TL> : AppalachiaObject<TMLS>
        where TMLS : MetadataLookupSelection<TMLS, TMC, TValue, TL>
        where TMC : AppalachiaMetadataCollection<TMC, TValue, TL>
        where TValue : AppalachiaObject<TValue>, ICategorizable
        where TL : AppaList<TValue>, new()
    {
        protected Action<TValue> _selection;
        protected TMC _instance;

        public PREF<Color> ButtonColor { get; set; }
        public PREF<float> ButtonColorDrop { get; set; }
        public Action<TValue> Selection => _selection;

        public TMC Instance => _instance;

        public virtual TMLS Prepare(
            TMC instance,
            Action<TValue> select,
            PREF<Color> buttonColor,
            PREF<float> buttonColorDrop)
        {
            _instance = instance;
            _selection = select;
            ButtonColor = buttonColor;
            ButtonColorDrop = buttonColorDrop;

            return this as TMLS;
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
