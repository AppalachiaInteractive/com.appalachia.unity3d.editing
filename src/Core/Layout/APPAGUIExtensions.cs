using System;

namespace Appalachia.Editing.Core.Layout
{
    public static class APPAGUIExtensions
    {
        public static void MAKE(this APPAGUI.SPACE.SIZE size)
        {
            APPAGUI.SPACE.MAKE(size);
        }
        
        public static float GET(this APPAGUI.SPACE.SIZE size)
        {
            return (float)(int)APPAGUI.SPACE.GET(size);
        }
        
        public static float MAKE_GET(this APPAGUI.SPACE.SIZE size)
        {
            size.MAKE();
            return size.GET();
        }
    }
}
