using Appalachia.CI.Integration.Paths;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class AssetPathMetadataExtensions
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AssetPathMetadataExtensions) + ".";
        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

#endregion

        public static void Draw(this AssetPath metadata, UIFieldMetadataManager fieldMetadataManager)
        {
            using (_PRF_Draw.Auto())
            {
                var field_apm = fieldMetadataManager.Get<LabelH3Metadata>("Asset Path Metadata");

                var field_name = fieldMetadataManager.Get<LabelMetadata>("Name");
                field_name.SetPrefixLabelWidth(70);

                var field_type = fieldMetadataManager.Get<SmallLabelMetadata>("Type");
                field_type.SetPrefixLabelWidth(1);
                field_type.AlterContent(c => c.text = null);
                field_type.AlterStyle(s => s.alignment = TextAnchor.MiddleRight);

                var field_cre = fieldMetadataManager.Get<ButtonMetadata>("Create");

                //field_cre.AddLayoutOption(GUILayout.MaxWidth(120));

                var field_sel = fieldMetadataManager.Get<ButtonMetadata>("Select");

                //field_sel.AddLayoutOption(GUILayout.MaxWidth(60));

                var field_isdir = fieldMetadataManager.Get<ToggleFieldMetadata>("Is Directory");
                field_isdir.SetPrefixLabelWidth(105);

                //field_isdir.AddLayoutOption(GUILayout.Width(15));

                var field_exist = fieldMetadataManager.Get<ToggleFieldMetadata>("Does Exist");
                field_exist.SetPrefixLabelWidth(100);

                //field_exist.AddLayoutOption(GUILayout.Width(15));

                var field_abs = fieldMetadataManager.Get<FilePathMetadata>("Absolute Path");
                field_abs.SetPrefixLabelWidth(120);

                var field_rel = fieldMetadataManager.Get<FilePathMetadata>("Relative Path");
                field_rel.SetPrefixLabelWidth(120);

                var field_par = fieldMetadataManager.Get<ObjectFieldMetadata>("Parent Directory");
                field_par.SetPrefixLabelWidth(130);
                field_par.AddLayoutOption(GUILayout.MinWidth(120));

                var field_ass = fieldMetadataManager.Get<ObjectFieldMetadata>("Asset");
                field_ass.SetPrefixLabelWidth(80);
                field_ass.AddLayoutOption(GUILayout.MinWidth(120));

                using (new EditorGUI.DisabledScope())
                using (new EditorGUI.IndentLevelScope())
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        field_name.Draw(metadata.name, true);

                        //GUILayout.FlexibleSpace();
                        field_type.Draw(
                            metadata.pathType.ToString(),
                            ColorPalettes.Default.notable.Middle,
                            true
                        );

                        APPAGUI.SPACE.SIZE.FieldPaddingRight.MAKE();
                    }

                    field_rel.Draw(metadata.relativePath, ColorPalettes.Default.good.Middle, true);

                    //field_abs.Draw(absolutePath);

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        field_ass.Draw(metadata.asset);
                        field_par.Draw(metadata.parentDirectory);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        field_isdir.Toggle(metadata.isDirectory);
                        field_exist.Toggle(
                            metadata.doesExist,
                            metadata.doesExist ? Color.clear : ColorPalettes.Default.bad.Middle
                        );

                        APPAGUI.SPACE.SIZE.FieldPaddingMid.MAKE();

                        if (field_cre.Button(!metadata.doesExist && metadata.isDirectory))
                        {
                            metadata.CreateDirectoryStructure();
                        }

                        if (field_sel.Button(metadata.doesExist))
                        {
                            Selection.activeObject = metadata.asset ?? metadata.parentDirectory;
                            EditorUtility.FocusProjectWindow();
                        }

                        GUILayout.FlexibleSpace();
                    }

                    APPAGUI.SPACE.SIZE.SectionEndVertical.MAKE();
                }
            }
        }
    }
}
