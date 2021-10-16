using System;
using Appalachia.Editing.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Drawers
{
    public abstract class ContextualPropertyDrawer<TAttribute, TContext> : OdinAttributeDrawer<TAttribute>
        where TAttribute : Attribute
        where TContext : PropertyDrawerContextCollection<TAttribute>, new()
    {
        public TContext context;

        protected override void Initialize()
        {
            context = new TContext();
            context.Initialize(Property, Attribute, null);
        }
    }

    public abstract class
        ContextualPropertyDrawer<TAttribute, TContext, TValue> : OdinAttributeDrawer<TAttribute, TValue>
        where TAttribute : Attribute
        where TContext : PropertyDrawerContextCollection<TAttribute>, new()
    {
        public TContext context;

        protected override void Initialize()
        {
            context = new TContext();
            context.Initialize(Property, Attribute, ValueEntry);
        }
    }
}
