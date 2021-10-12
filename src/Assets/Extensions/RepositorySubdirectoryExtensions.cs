using Appalachia.CI.Integration.Repositories;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class RepositorySubdirectoryExtensions
    {
        private const string _PRF_PFX = nameof(RepositorySubdirectoryExtensions) + ".";
        private static readonly ProfilerMarker _PRF_Draw = new ProfilerMarker(_PRF_PFX + nameof(Draw));
        public static void Draw(
            this RepositorySubdirectory metadata,
            UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var field_path = fieldManager.Get<FilePathMetadata>("Path");
                var field_directory = fieldManager.Get<ObjectFieldMetadata>("Directory");
                var field_inst_count = fieldManager.Get<LabelMetadata>("Instance Count");
                var field_instances = fieldManager.Get<FoldoutMetadata>("Instances");

                if (!metadata.isConventional)
                {
                    field_path.Draw(
                        metadata.relativePath,
                        ColorPalettes.Editing.error
                    );
                }
                else
                {
                    field_path.Draw(metadata.relativePath);
                }

                field_directory.Draw(metadata.directory);
                field_inst_count.Draw(metadata.instances.Count.ToString());

                if (field_instances.Foldout(ref metadata.showInstances))
                {
                    using (new EditorGUI.IndentLevelScope())
                    using (new EditorGUI.DisabledScope())
                    {
                        foreach (var instance in metadata.instances)
                        {
                            var obj = fieldManager.Get<ObjectFieldMetadata>(instance.name);

                            obj.Draw(instance);
                        }
                    }
                }
            }
        }
    }
}