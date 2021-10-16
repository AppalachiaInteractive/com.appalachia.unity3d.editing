using UnityEditor;

namespace Appalachia.Editing.Core.State
{
    public sealed class IndentLevelStack : UIStateStack<int>
    {
        protected override int GetCurrent()
        {
            return EditorGUI.indentLevel;
        }

        protected override void SetNew(int value, bool pushing)
        {
            EditorGUI.indentLevel = value;
        }
    }
}
