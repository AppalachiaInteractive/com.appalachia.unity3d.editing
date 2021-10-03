#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Unity.Profiling;

#endregion

namespace Appalachia.Core.Editing.Attributes.Drawers
{
    [ResolverPriority(10.0)]
    public class AppaListPropertyResolver<TElement, TList> : BaseOrderedCollectionResolver<TList>
        where TList : AppaList<TElement>
    {
        private const string _PRF_PFX = nameof(AppaListPropertyResolver<TElement,TList>) + ".";
        private readonly Dictionary<int, InspectorPropertyInfo> childInfos = new Dictionary<int, InspectorPropertyInfo>();

        public override Type ElementType => typeof(TElement);

        public bool MaySupportPrefabModifications => true;

        private static readonly ProfilerMarker _PRF_GetChildInfo = new ProfilerMarker(_PRF_PFX + nameof(GetChildInfo));
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
                        Property.Attributes.Where(attr => !attr.GetType().IsDefined(typeof(DontApplyToListElementsAttribute), true)).ToArray()
                    );
                    childInfos[childIndex] = inspectorPropertyInfo;
                }

                return inspectorPropertyInfo;
            }
        }

        private static readonly ProfilerMarker _PRF_ChildPropertyRequiresRefresh = new ProfilerMarker(_PRF_PFX + nameof(ChildPropertyRequiresRefresh));
        public override bool ChildPropertyRequiresRefresh(int index, InspectorPropertyInfo info)
        {
            using (_PRF_ChildPropertyRequiresRefresh.Auto())
            {
                return false;
            }
        }

        private static readonly ProfilerMarker _PRF_ChildNameToIndex = new ProfilerMarker(_PRF_PFX + nameof(ChildNameToIndex));
        public override int ChildNameToIndex(string name)
        {
            using (_PRF_ChildNameToIndex.Auto())
            {
                return CollectionResolverUtilities.DefaultChildNameToIndex(name);
            }
        }

        private static readonly ProfilerMarker _PRF_GetChildCount = new ProfilerMarker(_PRF_PFX + nameof(GetChildCount));
        protected override int GetChildCount(TList value)
        {
            using (_PRF_GetChildCount.Auto())
            {
                return value.Count;
            }
        }

        private static readonly ProfilerMarker _PRF_Add = new ProfilerMarker(_PRF_PFX + nameof(Add));
        protected override void Add(TList collection, object value)
        {
            using (_PRF_Add.Auto())
            {
                collection.Add((TElement) value);
            }
        }

        private static readonly ProfilerMarker _PRF_InsertAt = new ProfilerMarker(_PRF_PFX + nameof(InsertAt));
        protected override void InsertAt(TList collection, int index, object value)
        {
            using (_PRF_InsertAt.Auto())
            {
                collection.Insert(index, (TElement) value);
            }
        }

        private static readonly ProfilerMarker _PRF_Remove = new ProfilerMarker(_PRF_PFX + nameof(Remove));
        protected override void Remove(TList collection, object value)
        {
            using (_PRF_Remove.Auto())
            {
                collection.Remove((TElement) value);
            }
        }

        private static readonly ProfilerMarker _PRF_RemoveAt = new ProfilerMarker(_PRF_PFX + nameof(RemoveAt));
        protected override void RemoveAt(TList collection, int index)
        {
            using (_PRF_RemoveAt.Auto())
            {
                collection.RemoveAt(index);
            }
        }

        private static readonly ProfilerMarker _PRF_Clear = new ProfilerMarker(_PRF_PFX + nameof(Clear));
        protected override void Clear(TList collection)
        {
            using (_PRF_Clear.Auto())
            {

                collection.Clear();
            }
        }

        private static readonly ProfilerMarker _PRF_CollectionIsReadOnly = new ProfilerMarker(_PRF_PFX + nameof(CollectionIsReadOnly));
        protected override bool CollectionIsReadOnly(TList collection)
        {
            using (_PRF_CollectionIsReadOnly.Auto())
            {
                return false;
            }
        }
    }
}
