using Appalachia.CI.Integration.Paths;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class ScriptableObjectMetadataExtensions
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(ScriptableObjectMetadataExtensions) + ".";

        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

#endregion

        public static void Draw(this AssetSaveLocation metadata, UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var field_tl = fieldManager.Get<LabelH2Metadata>("Type Location");
                var field_dsl = fieldManager.Get<LabelH2Metadata>("Data Save Location");

                var field_type = fieldManager.Get<HelpBoxMetadata>("Type Is Not A User Script.");

                field_tl.Draw();

                if (metadata.typePath == null)
                {
                    field_type.Draw(MessageType.Info);
                }
                else
                {
                    metadata.typePath?.Draw(fieldManager);
                }

                field_dsl.Draw();

                metadata.saveLocationPath.Draw(fieldManager);
            }
        }
    }
}
