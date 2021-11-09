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
                var headerField = fieldMetadataManager.Get<LabelH3Metadata>("Asset Path Metadata");

                var nameField = fieldMetadataManager.Get<LabelMetadata>("Name");
                nameField.SetPrefixLabelWidth(70);

                var typeField = fieldMetadataManager.Get<SmallLabelMetadata>("Type");
                typeField.SetPrefixLabelWidth(1);
                typeField.AlterContent(c => c.text = null);
                typeField.AlterStyle(s => s.alignment = TextAnchor.MiddleRight);

                var createButton = fieldMetadataManager.Get<ButtonMetadata>("Create");

                //field_cre.AddLayoutOption(GUILayout.MaxWidth(120));

                var selectButton = fieldMetadataManager.Get<ButtonMetadata>("Select");

                //field_sel.AddLayoutOption(GUILayout.MaxWidth(60));

                var isDirectoryField = fieldMetadataManager.Get<ToggleFieldMetadata>("Is Directory");
                isDirectoryField.SetPrefixLabelWidth(105);

                //field_isdir.AddLayoutOption(GUILayout.Width(15));

                var doesExistField = fieldMetadataManager.Get<ToggleFieldMetadata>("Does Exist");
                doesExistField.SetPrefixLabelWidth(100);

                //field_exist.AddLayoutOption(GUILayout.Width(15));

                var absolutePathField = fieldMetadataManager.Get<FilePathMetadata>("Absolute Path");
                absolutePathField.SetPrefixLabelWidth(120);

                var relativePathField = fieldMetadataManager.Get<FilePathMetadata>("Relative Path");
                relativePathField.SetPrefixLabelWidth(120);
                relativePathField.SetLabelHeight(APPAGUI.SPACE.SIZE.LineHeight);

                var parentDirectoryField = fieldMetadataManager.Get<ObjectFieldMetadata>("Parent Directory");
                parentDirectoryField.SetPrefixLabelWidth(130);
                parentDirectoryField.AddLayoutOption(GUILayout.MinWidth(120));

                var assetField = fieldMetadataManager.Get<ObjectFieldMetadata>("Asset");
                assetField.SetPrefixLabelWidth(80);
                assetField.AddLayoutOption(GUILayout.MinWidth(120));

                using (APPAGUI.Indent())
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        nameField.Draw(metadata.name, true);

                        //GUILayout.FlexibleSpace();
                        typeField.Draw(
                            metadata.pathType.ToString(),
                            ColorPalettes.Default.notable.Middle,
                            true
                        );

                        APPAGUI.SPACE.SIZE.FieldPaddingRight.MAKE();
                    }

                    relativePathField.Draw(metadata.relativePath, true);

                    //field_abs.Draw(absolutePath);

                    using (APPAGUI.Horizontal())
                    using (APPAGUI.Disabled())
                    {
                        assetField.Draw(metadata.asset);
                        parentDirectoryField.Draw(metadata.parentDirectory);
                    }

                    using (APPAGUI.Horizontal())
                    {
                        using (APPAGUI.Disabled())
                        {
                            isDirectoryField.Toggle(metadata.isDirectory);
                            doesExistField.Toggle(
                                metadata.doesExist,
                                metadata.doesExist ? Color.clear : ColorPalettes.Default.bad.Middle
                            );
                        }

                        APPAGUI.SPACE.SIZE.FieldPaddingMid.MAKE();

                        if (createButton.Button(!metadata.doesExist && metadata.isDirectory))
                        {
                            metadata.CreateDirectoryStructure();
                        }

                        if (selectButton.Button(metadata.doesExist))
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
