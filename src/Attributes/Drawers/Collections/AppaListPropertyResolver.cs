#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Unity.Profiling;

#endregion

namespace Appalachia.Editing.Attributes.Drawers.Collections
{
    [ResolverPriority(10.0)]
    public class AppaListPropertyResolver<TElement, TList> : BaseOrderedCollectionResolver<TList>
        where TList : AppaList<TElement>
    {
        private const string _PRF_PFX = nameof(AppaListPropertyResolver<TElement, TList>) + ".";

        private static readonly ProfilerMarker _PRF_GetChildInfo =
            new(_PRF_PFX + nameof(GetChildInfo));

        private static readonly ProfilerMarker _PRF_ChildPropertyRequiresRefresh =
            new(_PRF_PFX + nameof(ChildPropertyRequiresRefresh));

        private static readonly ProfilerMarker _PRF_ChildNameToIndex =
            new(_PRF_PFX + nameof(ChildNameToIndex));

        private static readonly ProfilerMarker _PRF_GetChildCount =
            new(_PRF_PFX + nameof(GetChildCount));

        private static readonly ProfilerMarker _PRF_Add = new(_PRF_PFX + nameof(Add));

        private static readonly ProfilerMarker _PRF_InsertAt = new(_PRF_PFX + nameof(InsertAt));

        private static readonly ProfilerMarker _PRF_Remove = new(_PRF_PFX + nameof(Remove));

        private static readonly ProfilerMarker _PRF_RemoveAt = new(_PRF_PFX + nameof(RemoveAt));

        private static readonly ProfilerMarker _PRF_Clear = new(_PRF_PFX + nameof(Clear));

        private static readonly ProfilerMarker _PRF_CollectionIsReadOnly =
            new(_PRF_PFX + nameof(CollectionIsReadOnly));

        private readonly Dictionary<int, InspectorPropertyInfo> childInfos = new();

        public override Type ElementType => typeof(TElement);

        public bool MaySupportPrefabModifications => true;

        public override InspectorPropertyInfo GetChildInfo(int childIndex)
        {
            using (_PRF_GetChildInfo.Auto())
            {
                if ((childIndex < 0) || (childIndex >= ChildCount))
                {
                    throw new IndexOutOfRangeException();
                }

                InspectorPropertyInfo inspectorPropertyInfo;
                if (!childInfos.TryGetValue(childIndex, out inspectorPropertyInfo))
                {
                    inspectorPropertyInfo = InspectorPropertyInfo.CreateValue(
                        CollectionResolverUtilities.DefaultIndexToChildName(childIndex),
                        childIndex,
                        Property.BaseValueEntry.SerializationBackend,
                        new GetterSetter<TList, TElement>(
                            (ref TList list) => list[childIndex],
                            (ref TList list, TElement element) => list[childIndex] = element
                        ),
                        Property.Attributes.Where(
                                     attr => !attr.GetType()
                                                  .IsDefined(
                                                       typeof(DontApplyToListElementsAttribute),
                                                       true
                                                   )
                                 )
                                .ToArray()
                    );
                    childInfos[childIndex] = inspectorPropertyInfo;
                }

                return inspectorPropertyInfo;
            }
        }

        public override bool ChildPropertyRequiresRefresh(int index, InspectorPropertyInfo info)
        {
            using (_PRF_ChildPropertyRequiresRefresh.Auto())
            {
                return false;
            }
        }

        public override int ChildNameToIndex(string name)
        {
            using (_PRF_ChildNameToIndex.Auto())
            {
                return CollectionResolverUtilities.DefaultChildNameToIndex(name);
            }
        }

        protected override int GetChildCount(TList value)
        {
            using (_PRF_GetChildCount.Auto())
            {
                return value.Count;
            }
        }

        protected override void Add(TList collection, object value)
        {
            using (_PRF_Add.Auto())
            {
                collection.Add((TElement) value);
            }
        }

        protected override void InsertAt(TList collection, int index, object value)
        {
            using (_PRF_InsertAt.Auto())
            {
                collection.Insert(index, (TElement) value);
            }
        }

        protected override void Remove(TList collection, object value)
        {
            using (_PRF_Remove.Auto())
            {
                collection.Remove((TElement) value);
            }
        }

        protected override void RemoveAt(TList collection, int index)
        {
            using (_PRF_RemoveAt.Auto())
            {
                collection.RemoveAt(index);
            }
        }

        protected override void Clear(TList collection)
        {
            using (_PRF_Clear.Auto())
            {
                collection.Clear();
            }
        }

        protected override bool CollectionIsReadOnly(TList collection)
        {
            using (_PRF_CollectionIsReadOnly.Auto())
            {
                return false;
            }
        }
    }
}
