#region

using UnityEditor;

#endregion

namespace Appalachia.Core.Editing.Attributes
{
    public class EditorOnlyInitializeOnLoadAttribute
#if UNITY_EDITOR
        : InitializeOnLoadAttribute
#else
        : Attribute
#endif
    {
    }
}
