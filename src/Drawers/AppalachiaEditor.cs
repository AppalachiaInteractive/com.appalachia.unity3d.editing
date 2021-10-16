using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Appalachia.Editing.Drawers
{
    public class AppalachiaEditor<T> : OdinEditor
        where T : Object
    {
        private T m_target;

        protected T Target
        {
            get
            {
                if (m_target != null)
                {
                    return m_target;
                }

                m_target = (T) target;
                return m_target;
            }
        }
    }
}
