using Appalachia.Editing.Core.State;

namespace Appalachia.Editing.Core.Layout
{
    public static partial class APPAGUI
    {
        public static class StateStacks
        {
            public static BackgroundColorStack backgroundColor
            {
                get
                {
                    if (_backgroundColorStack == null)
                    {
                        _backgroundColorStack = new BackgroundColorStack();
                    }

                    return _backgroundColorStack;
                }
            }

            public static ContentColorStack contentColor
            {
                get
                {
                    if (_contentColorStack == null)
                    {
                        _contentColorStack = new ContentColorStack();
                    }

                    return _contentColorStack;
                }
            }

            public static ForegroundColorStack color
            {
                get
                {
                    if (_foregroundColorStack == null)
                    {
                        _foregroundColorStack = new ForegroundColorStack();
                    }

                    return _foregroundColorStack;
                }
            }

            public static GUIEnabledStack guiEnabled
            {
                get
                {
                    if (_guiEnabledStack == null)
                    {
                        _guiEnabledStack = new GUIEnabledStack();
                    }

                    return _guiEnabledStack;
                }
            }

            public static IndentLevelStack indentLevel
            {
                get
                {
                    if (_indentLevelStack == null)
                    {
                        _indentLevelStack = new IndentLevelStack();
                    }

                    return _indentLevelStack;
                }
            }

            public static LabelWidthStack labelWidth
            {
                get
                {
                    if (_labelWidthStack == null)
                    {
                        _labelWidthStack = new LabelWidthStack();
                    }

                    return _labelWidthStack;
                }
            }

            private static BackgroundColorStack _backgroundColorStack;
            private static ContentColorStack _contentColorStack;
            private static ForegroundColorStack _foregroundColorStack;
            private static GUIEnabledStack _guiEnabledStack;
            private static IndentLevelStack _indentLevelStack;
            private static LabelWidthStack _labelWidthStack;

        }
        
        
        public static UIStackScope<int> Auto(this IndentLevelStack indent)
        {
            var current = UnityEditor.EditorGUI.indentLevel;
            indent.Push(current + 1);
            return new UIStackScope<int>(indent);
        }

        public static void Push(this IndentLevelStack indent)
        {
            var current = UnityEditor.EditorGUI.indentLevel;
            indent.Push(current + 1);
        }
    }
}
