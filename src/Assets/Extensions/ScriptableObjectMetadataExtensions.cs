using Appalachia.CI.Integration.Paths;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Extensions
{

    public static class ScriptableObjectMetadataExtensions
    {
        private const string _PRF_PFX = nameof(ScriptableObjectMetadataExtensions) + ".";

        private static readonly ProfilerMarker _PRF_Draw = new ProfilerMarker(_PRF_PFX + nameof(Draw));
        public static void Draw(
            this AssetTypeMetadata metadata,
            UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var field_tl = fieldManager.Get<LabelH2Metadata>("Type Location");
                var field_dsl = fieldManager.Get<LabelH2Metadata>("Data Save Location");

                var field_type = fieldManager.Get<HelpBoxMetadata>("Type Is Not A User Script.");

                field_tl.Draw();

                if (metadata.typeMetadata == null)
                {
                    field_type.Draw(MessageType.Info);
                }
                else
                {
                    metadata.typeMetadata?.Draw(fieldManager);
                }

                field_dsl.Draw();

                metadata.saveLocationMetadata.Draw(fieldManager);
            }
        }
    }
}
