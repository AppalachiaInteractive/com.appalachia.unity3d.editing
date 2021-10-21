using System.Collections.Generic;
using Appalachia.Editing.Core.Windows.PaneBased.Context;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class GeneralAssetReviewContext : AppalachiaWindowPaneContext,
                                             IAppalachiaOneMenuWindowPaneContext<
                                                 GeneralAssetReviewContext.AssetType>
    {
        private const string _PRF_PFX = nameof(GeneralAssetReviewContext) + ".";

        private List<AssetType> menuItems;

        public override int RequiredMenuCount => 1;

        public IList<AssetType> MenuOneItems => menuItems;

        public override void ValidateMenuSelection(int menuIndex)
        {
            var menuSelection = GetMenuSelection(menuIndex);

            if (menuSelection.length != MenuOneItems.Count)
            {
                menuSelection.SetLength(MenuOneItems.Count);
            }
        }

        protected override void OnInitialize()
        {
            if (menuItems == null)
            {
                menuItems = new List<AssetType>();
            }

            menuItems.Clear();

            menuItems.Add(AssetType.Directory);
            menuItems.Add(AssetType.MonoScript);
            menuItems.Add(AssetType.Shader);
        }

        protected override void OnReset()
        {
            menuItems?.Clear();
        }

        public enum AssetType
        {
            Directory,
            MonoScript,
            Shader
        }
    }
}
