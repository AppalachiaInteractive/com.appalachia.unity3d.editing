using Appalachia.CI.Integration.Paths;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class AssetPathMetadataExtensions
    {
        private const string _PRF_PFX = nameof(AssetPathMetadataExtensions) + ".";
        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

        public static void Draw(this AssetPathMetadata metadata, UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var field_apm = fieldManager.Get<LabelH3Metadata>("Asset Path Metadata");

                var field_name = fieldManager.Get<LabelMetadata>("Name");
                field_name.SetPrefixLabelWidth(70);

                var field_type = fieldManager.Get<SmallLabelMetadata>("Type");
                field_type.SetPrefixLabelWidth(1);
                field_type.AlterContent(c => c.text = null);
                field_type.AlterStyle(s => s.alignment = TextAnchor.MiddleRight);

                var field_cre = fieldManager.Get<ButtonMetadata>("Create");

                //field_cre.AddLayoutOption(GUILayout.MaxWidth(120));

                var field_sel = fieldManager.Get<ButtonMetadata>("Select");

                //field_sel.AddLayoutOption(GUILayout.MaxWidth(60));

                var field_isdir = fieldManager.Get<ToggleFieldMetadata>("Is Directory");
                field_isdir.SetPrefixLabelWidth(105);

                //field_isdir.AddLayoutOption(GUILayout.Width(15));

                var field_exist = fieldManager.Get<ToggleFieldMetadata>("Does Exist");
                field_exist.SetPrefixLabelWidth(100);

                //field_exist.AddLayoutOption(GUILayout.Width(15));

                var field_abs = fieldManager.Get<FilePathMetadata>("Absolute Path");
                field_abs.SetPrefixLabelWidth(120);

                var field_rel = fieldManager.Get<FilePathMetadata>("Relative Path");
                field_rel.SetPrefixLabelWidth(120);

                var field_par = fieldManager.Get<ObjectFieldMetadata>("Parent Directory");
                field_par.SetPrefixLabelWidth(130);
                field_par.AddLayoutOption(GUILayout.MinWidth(120));

                var field_ass = fieldManager.Get<ObjectFieldMetadata>("Asset");
                field_ass.SetPrefixLabelWidth(80);
                field_ass.AddLayoutOption(GUILayout.MinWidth(120));

                using (new EditorGUI.DisabledScope())
                using (new EditorGUI.IndentLevelScope())
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        field_name.Draw(metadata.name);

                        //GUILayout.FlexibleSpace();
                        field_type.Draw(metadata.pathType.ToString(), ColorPalettes.Editing.notable);
                        EditorGUILayout.Space(6f, false);
                    }

                    field_rel.Draw(metadata.relativePath, ColorPalettes.Editing.good);

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
                            metadata.doesExist ? Color.clear : ColorPalettes.Editing.error
                        );

                        EditorGUILayout.Space(6f, false);

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

                    EditorGUILayout.Space(6f, false);
                }
            }
        }
    }
}
