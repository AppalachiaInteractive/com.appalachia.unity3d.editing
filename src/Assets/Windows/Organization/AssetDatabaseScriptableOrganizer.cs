using Appalachia.Core.Constants;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer : BaseAssetEditorWindow
    {
        private const string DELIM = "|";

        private const string TABS = TAB_ASSEMBLIES + 
                                    DELIM +
                                    TAB_SCRIPTABLE +
                                    DELIM +
                                    TAB_ASSET +
                                    DELIM +
                                    TAB_MONOSCRIPT +
                                    DELIM +
                                    TAB_ORPHANS +
                                    DELIM +
                                    TAB_CLEANUP +
                                    DELIM + 
                                    TAB_SHADER;

        private const float TAB_HEIGHT = 22f;

        private const string _PRF_PFX = nameof(AssetDatabaseScriptableOrganizer) + ".";

        private static string[] _tabsArray;
        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + nameof(OnEnable));
        private UIFieldMetadataManager _fieldManager;

        private int _tab;

        private void OnEnable()
        {
            using (_PRF_OnEnable.Auto())
            {
                _fieldManager = new UIFieldMetadataManager();
                PREF_STATES.Awake();

                minSize = new Vector2(640, 320);

                _slContext = null;
                _oaContext = null;
            }
        }

        private static readonly ProfilerMarker _PRF_OnGUI = new ProfilerMarker(_PRF_PFX + nameof(OnGUI));
        private void OnGUI()
        {
            using (_PRF_OnGUI.Auto())
            {
                if (_fieldManager == null)
                {
                    OnEnable();
                }

                //ColorPalettes.AssetDatabaseScriptableOrganizer.Configure();

                if (_tabsArray == null)
                {
                    _tabsArray = TABS.Split(DELIM[0]);
                }

                InitializeAllAssetLocations();
                InitializeOrphans();
                InitializeMonoScriptTypeIssues();
                InitializeAssemblyDefinitionIssues();
                InitializeDirectoryCleanup();
                InitializeShaderIssues();

                var toolbar = _fieldManager.Get<ToolbarMetadata>();

                toolbar.AddLayoutOption(GUILayout.Height(TAB_HEIGHT));

                _tab = toolbar.Toolbar(_tab, _tabsArray);

                var selectedTab = _tabsArray[_tab];

                if (selectedTab == TAB_ASSET)
                {
                    DrawAssetLocations(_assetContent);
                }
                else if (selectedTab == TAB_SCRIPTABLE)
                {
                    DrawAssetLocations(_slContext);
                }
                else if (selectedTab == TAB_ORPHANS)
                {
                    DrawOrphans();
                }
                else if (selectedTab == TAB_MONOSCRIPT)
                {
                    DrawMonoScriptTypeIssues();
                }
                else if (selectedTab == TAB_ASSEMBLIES)
                {
                    DrawAssemblyDefinitionAssetIssues();
                }
                else if (selectedTab == TAB_CLEANUP)
                {
                    DrawDirectoryCleanup();
                }
                else if (selectedTab == TAB_SHADER)
                {
                    DrawShaderIssues();
                }

                if (GUILayout.Button("Close"))
                {
                    CloseWindow();
                }
            }
        }

        [MenuItem(
            APPA_MENU.BASE_AppalachiaWindows +
            APPA_MENU.ASM_AppalachiaEditingAssets +
            nameof(AssetDatabaseScriptableOrganizer)
        )]
        internal static void OrganizeAssets()
        {
            GetWindow<AssetDatabaseScriptableOrganizer>(false, "Organize Assets", true);
        }
    }
}
