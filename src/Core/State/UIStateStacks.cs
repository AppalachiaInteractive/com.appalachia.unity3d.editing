namespace Appalachia.Editing.Core.State
{
    public static class UIStateStacks
    {
        private static LabelWidthStack _labelWidthStack;
        private static BackgroundColorStack _backgroundColorStack;
        private static ContentColorStack _contentColorStack;
        private static ForegroundColorStack _foregroundColorStack;

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
    }
}
