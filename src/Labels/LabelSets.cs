#if UNITY_EDITOR
using Appalachia.Core.Labels;
using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Async;
using UnityEngine;

namespace Appalachia.Editing.Labels
{
    public class LabelSets : SingletonAppalachiaObject<LabelSets>
    {
        #region Fields and Autoproperties

        public LabelAssignmentCollection assemblies;
        public LabelAssignmentCollection objects;
        public LabelAssignmentCollection trees;
        public LabelAssignmentCollection vegetations;

        #endregion

        protected override async AppaTask Initialize(Initializer initializer)
        {
            await base.Initialize(initializer);

            await initializer.Do(
                this,
                LABELS.LABEL_BASE_Vegetation,
                vegetations == default,
                () =>
                {
                    vegetations = new LabelAssignmentCollection(
                        LABELS.LABEL_BASE_Vegetation,
                        Vector3.up,
                        new LabelAssignmentTerm(LABELS.LABEL_VegetationVerySmall, 0.15f),
                        new LabelAssignmentTerm(LABELS.LABEL_VegetationSmall,     .3f),
                        new LabelAssignmentTerm(LABELS.LABEL_VegetationMedium,    0.6f),
                        new LabelAssignmentTerm(LABELS.LABEL_VegetationLarge,     1.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_VegetationVeryLarge, 1024.0f)
                    );
                }
            );

            await initializer.Do(
                this,
                LABELS.LABEL_BASE_Tree,
                trees == default,
                () =>
                {
                    trees = new LabelAssignmentCollection(
                        LABELS.LABEL_BASE_Tree,
                        Vector3.up,
                        new LabelAssignmentTerm(LABELS.LABEL_TreeSmall,  12.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_TreeMedium, 24.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_TreeLarge,  1024.0f)
                    );
                }
            );

            await initializer.Do(
                this,
                LABELS.LABEL_BASE_Assembly,
                objects == default,
                () =>
                {
                    objects = new LabelAssignmentCollection(
                        LABELS.LABEL_BASE_Object,
                        Vector3.one,
                        new LabelAssignmentTerm(LABELS.LABEL_ObjectVerySmall, 0.2f),
                        new LabelAssignmentTerm(LABELS.LABEL_ObjectSmall,     2.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_ObjectMedium,    5.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_ObjectLarge,     24.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_ObjectHuge,      1024.0f)
                    );
                }
            );

            await initializer.Do(
                this,
                LABELS.LABEL_BASE_Assembly,
                assemblies == default,
                () =>
                {
                    assemblies = new LabelAssignmentCollection(
                        LABELS.LABEL_BASE_Assembly,
                        Vector3.one,
                        new LabelAssignmentTerm(LABELS.LABEL_AssemblySmall,  2.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_AssemblyMedium, 5.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_AssemblyLarge,  24.0f),
                        new LabelAssignmentTerm(LABELS.LABEL_AssemblyHuge,   1024.0f)
                    );
                }
            );
        }
    }
}

#endif
