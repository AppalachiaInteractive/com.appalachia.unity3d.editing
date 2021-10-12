using Appalachia.Editing.Drawers.Contexts;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Drawers
{
    public abstract class ContextualGroupDrawer<TAttribute, TContext> : OdinGroupDrawer<TAttribute>
        where TAttribute : PropertyGroupAttribute
        where TContext : GroupDrawerContextCollection<TAttribute>, new()
    {
        public TContext context;

        protected override void Initialize()
        {
            context = new TContext();
            context.Construct(Property, Attribute);
        }
    }
}
