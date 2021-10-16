using Appalachia.Core.Constants;
using Appalachia.Editing.Core.Windows.PaneBased;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public class AssetDatabaseOrganizerWindow : AppalachiaPaneBasedWindow<AssetDatabaseOrganizerWindow,
        AssetDatabaseOrganizerPane>
    {
        private const string _PRF_PFX = nameof(AssetDatabaseOrganizerWindow) + ".";

        private static readonly ProfilerMarker _PRF_OrganizeAssets = new(_PRF_PFX + nameof(OrganizeAssets));

        [MenuItem(
            APPA_MENU.BASE_AppalachiaWindows +
            APPA_MENU.ASM_AppalachiaEditingAssets +
            AssetDatabaseOrganizerPane.PANE_NAME
        )]
        internal static void OrganizeAssets()
        {
            using (_PRF_OrganizeAssets.Auto())
            {
                Get(AssetDatabaseOrganizerPane.PANE_NAME);
            }
        }
    }
}
