using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Utility.Colors;
using Unity.Profiling;
using UnityEditor.Rendering;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class ShaderReviewPane : AppalachiaMenuWindowPane<ShaderReviewContext>,
                                    IAppalachiaTabbedWindowPane
    {
        private const string _PRF_PFX = nameof(ShaderReviewPane) + ".";

        private static readonly ProfilerMarker _PRF_ShouldDrawMenuItem =
            new(_PRF_PFX + nameof(ShouldDrawMenuItem));

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private PREF<bool> onlyErrors;

        private PREF<bool> onlyIssues;
        private PREF<bool> onlyWarnings;
        public override bool ContentInScrollView => true;

        public override string PaneName => TabName;


        public int DesiredTabIndex => 10;

        public string TabName => "Shaders";

        public override void OnDrawPaneMenuItem(int menuIndex, int menuItemIndex, out bool isSelected)
        {
            using (_PRF_OnDrawPaneMenuItem.Auto())
            {
                var item = context.MenuOneItems[menuItemIndex];

                var itemName = item.info.name;
                var field = fieldMetadataManager.Get<MenuItemField>(itemName);

                isSelected = field.Draw(itemName);
            }
        }

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            using (_PRF_ShouldDrawMenuItem.Auto())
            {
                var item = context.MenuOneItems[menuItemIndex];

                if (onlyIssues.v)
                {
                    return !item.isError;
                }

                return true;
            }
        }

        public override void OnDrawPaneContent()
        {
            var selectedIndex = context.GetMenuSelection(0).currentIndex;

            var item = context.MenuOneItems[selectedIndex];
            var itemName = item.info.name;

            var label = fieldMetadataManager.Get<LabelH3Metadata>(itemName);
            var show = fieldMetadataManager.Get<MiniButtonMetadata>("Show");

            label.Draw();

            using (new GUILayout.HorizontalScope())
            {
                label.Draw();

                if (show.Button())
                {
                    AssetDatabaseManager.SetSelection(item.shader);
                }
            }

            var messages = fieldMetadataManager.Get<LabelH4Metadata>(itemName + " Messages");

            foreach (var shaderMessage in item.messages)
            {
                var color = shaderMessage.severity switch
                {
                    ShaderCompilerMessageSeverity.Error   => Colors.CadmiumOrange,
                    ShaderCompilerMessageSeverity.Warning => Colors.CadmiumYellow,
                    _                                     => Color.clear
                };

                messages.Draw(shaderMessage.messageDetails, color);
            }
        }

        public override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref onlyIssues,
                    "Asset Review",
                    "Only Shader Issues",
                    true
                );

                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref onlyIssues,
                    "Asset Review",
                    "Only Shader Errors",
                    false
                );

                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref onlyIssues,
                    "Asset Review",
                    "Only Shader Warnings",
                    false
                );
            }
        }
    }
}
