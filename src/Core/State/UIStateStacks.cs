namespace Appalachia.Editing.Core.State
{
    public static class UIStateStacks
    {
        private static BackgroundColorStack _backgroundColorStack;
        private static ContentColorStack _contentColorStack;
        private static ForegroundColorStack _foregroundColorStack;
        private static GUIEnabledStack _guiEnabledStack;
        private static IndentLevelStack _indentLevelStack;
        private static LabelWidthStack _labelWidthStack;

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

        public static ForegroundColorStack foregroundColor
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
    }
}
