using UnityEngine;

namespace Appalachia.Editing.Attributes
{
    public class MinMaxAttribute : PropertyAttribute
    {
        public bool colorize;
        public float max;
        public float min;

        public MinMaxAttribute(float mv, float nv)
        {
            min = mv;
            max = nv;
        }
    }
}
