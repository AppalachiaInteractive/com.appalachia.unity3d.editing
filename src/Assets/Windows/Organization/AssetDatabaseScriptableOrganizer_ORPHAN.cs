using Appalachia.Core.Assets;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Reflection;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_ORPHANS = "Orphaned Assets";
        private const string ORPHAN_CONTENT = "ORPHAN_CONTENT";

        private static readonly ProfilerMarker _PRF_InitializeOrphans =
            new(_PRF_PFX + nameof(InitializeOrphans));

        private OrphanedAssetContext _oaContext;

        private void InitializeOrphans()
        {
            using (_PRF_InitializeOrphans.Auto())
            {
                if (_oaContext != null)
                {
                    return;
                }

                _fieldManager.Add<ScrollViewUIMetadata>(ORPHAN_CONTENT);

                var assetPaths = AssetDatabaseManager.GetAssetPathsByExtension(".asset");

                if (_oaContext == null)
                {
                    _oaContext = new OrphanedAssetContext();
                }

                _oaContext.Initialize(assetPaths);
            }
        }

        private static readonly ProfilerMarker _PRF_DrawOrphans = new ProfilerMarker(_PRF_PFX + nameof(DrawOrphans));
        private void DrawOrphans()
        {
            using (_PRF_DrawOrphans.Auto())
            {
                var headerLabel = _fieldManager.Get<LabelH2Metadata>("Oprhans");

                headerLabel.Draw();

                SetToggleCollection(ref _oaContext.toggles,        _oaContext.orphans.Count);
                SetToggleCollection(ref _oaContext.togglesFields,  _oaContext.orphans.Count);
                SetToggleCollection(ref _oaContext.togglesResults, _oaContext.orphans.Count);

                using (_fieldManager.Get<ScrollViewUIMetadata>(ORPHAN_CONTENT).GetScope())
                {
                    for (var index = 0; index < _oaContext.orphans.Count; index++)
                    {
                        DrawOrphan(index);
                    }
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawOrphan = new ProfilerMarker(_PRF_PFX + nameof(DrawOrphan));
        private void DrawOrphan(int index)
        {
            using (_PRF_DrawOrphan.Auto())
            {
                var field_osg = _fieldManager.Get<LabelMetadata>("Original Script GUID");

                var orphan = _oaContext.orphans[index];

                _oaContext.toggles[index] = EditorGUILayout.BeginFoldoutHeaderGroup(
                    _oaContext.toggles[index],
                    orphan.assetPathMetadata.name
                );

                try
                {
                    if (_oaContext.toggles[index])
                    {
                        using (new EditorGUI.IndentLevelScope())
                        {
                            using (new EditorGUI.DisabledScope())
                            {
                                orphan.originalScriptGUID = EditorGUILayout.TextField(
                                    field_osg.content,
                                    orphan.originalScriptGUID
                                );
                            }

                            EditorGUILayout.Separator();

                            orphan.assetPathMetadata.Draw(_fieldManager);

                            EditorGUILayout.Separator();

                            DrawOrphanFields(orphan, index);
                            DrawOrphanAnalysisResults(orphan, index);
                        }

                        EditorGUILayout.Separator();
                        AssetUIHelper.HorizontalLineSeparator(AssetUIHelper.LineColorH3);
                    }
                }
                finally
                {
                    EditorGUILayout.EndFoldoutHeaderGroup();
                }
            }
        }

        private void DrawOrphanFields(OrphanedAsset orphan, int index)
        {
            _oaContext.togglesFields[index] = EditorGUILayout.Foldout(
                _oaContext.togglesFields[index],
                $"{orphan.fields.Count} Fields"
            );

            if (_oaContext.togglesFields[index])
            {
                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope())
                {
                    foreach (var field in orphan.fields)
                    {
                        DrawOrphanField(field);
                    }
                }
            }
        }

        private void DrawOrphanField(AssetField field)
        {
            EditorGUILayout.TextField(field.key, field.value);
        }

        private void DrawOrphanAnalysisResults(OrphanedAsset orphan, int index)
        {
            _oaContext.togglesResults[index] = EditorGUILayout.Foldout(
                _oaContext.togglesResults[index],
                $"{orphan.analysisResults.Count} Analysis Results"
            );

            if (_oaContext.togglesResults[index])
            {
                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope())
                {
                    foreach (var result in orphan.analysisResults)
                    {
                        DrawOrphanAnalysisResult(result);
                    }
                }
            }
        }

        private void DrawOrphanAnalysisResult(AppaTypeFinderResult result)
        {
            EditorGUILayout.TextField("Type", result.matchType.Name);
            EditorGUILayout.Slider("Likelihood", result.likelihood, 0f, 1f);

            EditorGUILayout.TextField("Matched Fields", string.Join("\n", result.fieldsMatched));
        }
    }
}
