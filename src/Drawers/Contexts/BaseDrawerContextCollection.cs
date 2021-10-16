using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Drawers.Contexts
{
    [Serializable]
    public abstract class BaseDrawerContextCollection<TAttribute>
        where TAttribute : Attribute
    {
        [SerializeField] public bool hasError;
        [SerializeField] protected TAttribute _attribute;
        [SerializeField] protected InspectorProperty _property;

        public void DrawErrors()
        {
            var args = GetValueResolvers();

            foreach (var arg in args)
            {
                if (arg.HasError)
                {
                    arg.DrawError();
                }
            }
        }

        public bool HasError()
        {
            var args = GetValueResolvers();

            foreach (var arg in args)
            {
                if (arg.HasError)
                {
                    return true;
                }
            }

            return false;
        }

        protected abstract ValueResolver[] GetValueResolvers();
    }
}
