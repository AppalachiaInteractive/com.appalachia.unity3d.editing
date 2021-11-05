using System;
using System.Collections;

namespace Appalachia.Editing.Core.Windows
{
    public interface IAppalachiaWindow
    {
        void ExecuteCoroutine(Func<IEnumerator> coroutine);
        void SafeRepaint();
    }
}
