using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Fields;
using Appalachia.Utility.Reflection.Extensions;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_MONOSCRIPT = "MonoScripts";
        private const string MONOSCRIPT_CONTENT = "MONOSCRIPT_CONTENT";

        private static readonly ProfilerMarker _PRF_InitializeMonoScriptTypeIssues =
            new(_PRF_PFX + nameof(InitializeMonoScriptTypeIssues));

        private MonoScriptTypeIssuesContext _mstiContext;
        
        private void InitializeMonoScriptTypeIssues()
        {
            using (_PRF_InitializeMonoScriptTypeIssues.Auto())
            {
                _fieldManager.Add<ScrollViewUIMetadata>(MONOSCRIPT_CONTENT);
                
                if (_mstiContext == null)
                {
                    _mstiContext = new MonoScriptTypeIssuesContext();
                    
                    var soInheritors = ReflectionExtensions.GetAllConcreteInheritors<ScriptableObject>();

                    _mstiContext.Initialize(soInheritors);
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawMonoScriptTypeIssues = new ProfilerMarker(_PRF_PFX + nameof(DrawMonoScriptTypeIssues));
        private void DrawMonoScriptTypeIssues()
        {
            using (_PRF_DrawMonoScriptTypeIssues.Auto())
            {
                var headerLabel = _fieldManager.Get<LabelH2Metadata>(TAB_MONOSCRIPT);
                var rescanButton = _fieldManager.Get<ButtonMetadata>("Rescan Issues");

                headerLabel.Draw();

                if (rescanButton.Button())
                {
                    _mstiContext = null;
                    InitializeMonoScriptTypeIssues();
                }
            
                using (_fieldManager.Get<ScrollViewUIMetadata>(MONOSCRIPT_CONTENT).GetScope())
                {
                    for (var index = 0; index < _mstiContext.issueTypes.Count; index++)
                    {
                        DrawScriptTypeIssue(index);
                    }
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawScriptTypeIssue = new ProfilerMarker(_PRF_PFX + nameof(DrawScriptTypeIssue));
        private void DrawScriptTypeIssue(int index)
        {
            using (_PRF_DrawScriptTypeIssue.Auto())
            {
                var scriptIssueType = _mstiContext.issueTypes[index];

                var label = _fieldManager.Get<LabelMetadata>(scriptIssueType.GetReadableName());

                using (new GUILayout.HorizontalScope())
                {
                    label.Draw();
                }
            }
            
        }

    }
}
