using Appalachia.CI.Integration.Assemblies;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class AssemblyDefinitionReferenceMetadataExtensions
    {
        private const int prefixLabelWidth = 175;
        private const string _PRF_PFX = nameof(AssemblyDefinitionReferenceMetadataExtensions) + ".";
        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

        public static void Draw(
            this AssemblyDefinitionReferenceMetadata metadata,
            UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var palette = ColorPalettes.Editing;
                var field_header = fieldManager.Get<LabelH5Metadata>(metadata.guid);
                field_header.SetPrefixLabelWidth(prefixLabelWidth);

                var color = Color.clear;

                if (metadata.assembly == null)
                {
                    color = palette.warning;
                }
                else if (!metadata.IsGuidReference)
                {
                    color = palette.warning2;
                }
                else if (metadata.outOfSorts)
                {
                    color = palette.notable;
                }

                field_header.Draw(metadata.assembly?.assembly_current ?? metadata.guid, color);
            }
        }
    }
}
