using Sirenix.OdinInspector;

namespace Appalachia.Editing.Assets.Context
{
    public class AssetComponent
    {
        [HorizontalGroup] public bool shouldSave;

        [HorizontalGroup]
        [ReadOnly]
        public string assetType;

        [HorizontalGroup]
        [EnableIf(nameof(shouldSave))]
        public string postfix;
    }
}
