#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Unity.Profiling;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    [ResolverPriority(500.0)]
    public class AppaLookupValuePropertyResolver<T, TKey, TValue, TKList, TVList> : BaseOrderedCollectionResolver<T>
        where T : AppaLookup<TKey, TValue, TKList, TVList>
        where TKList : AppaList<TKey>, new()
        where TVList : AppaList<TValue>, new()
    {
        private const string _PRF_PFX = nameof(AppaLookupValuePropertyResolver<T,TKey,TValue,TKList,TVList>) + ".";
        private readonly Dictionary<int, InspectorPropertyInfo> childInfos = new Dictionary<int, InspectorPropertyInfo>();

        public bool MaySupportPrefabModifications => true;

        public override Type ElementType => typeof(AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper);

        private static readonly ProfilerMarker _PRF_GetChildInfo = new ProfilerMarker(_PRF_PFX + nameof(GetChildInfo));
        public override InspectorPropertyInfo GetChildInfo(int childIndex)
        {
            using (_PRF_GetChildInfo.Auto())
            {
                if ((childIndex < 0) || (childIndex >= ChildCount))
                {
                    throw new IndexOutOfRangeException();
                }

                if (!childInfos.TryGetValue(childIndex, out var inspectorPropertyInfo))
                {
                    inspectorPropertyInfo = InspectorPropertyInfo.CreateValue(
                        CollectionResolverUtilities.DefaultIndexToChildName(childIndex),
                        childIndex,
                        Property.BaseValueEntry.SerializationBackend,
                        new GetterSetter<T, AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper>(
                            (ref T list) => list.GetKeyValuePair(childIndex),
                            (ref T list, AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper element) => list[element.Key] = element.Value
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
        protected override int GetChildCount(T value)
        {
            using (_PRF_GetChildCount.Auto())
            {
                return value.Count;
            }
        }

        private static readonly ProfilerMarker _PRF_Add = new ProfilerMarker(_PRF_PFX + nameof(Add));
        protected override void Add(T collection, object value)
        {
            using (_PRF_Add.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Add(cast.Key, cast.Value);
            }
        }

        private static readonly ProfilerMarker _PRF_InsertAt = new ProfilerMarker(_PRF_PFX + nameof(InsertAt));
        protected override void InsertAt(T collection, int index, object value)
        {
            using (_PRF_InsertAt.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Insert(index, cast.Key, cast.Value);
            }
        }

        private static readonly ProfilerMarker _PRF_Remove = new ProfilerMarker(_PRF_PFX + nameof(Remove));
        protected override void Remove(T collection, object value)
        {
            using (_PRF_Remove.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Remove(cast.Key);
            }
        }

        private static readonly ProfilerMarker _PRF_RemoveAt = new ProfilerMarker(_PRF_PFX + nameof(RemoveAt));
        protected override void RemoveAt(T collection, int index)
        {
            using (_PRF_RemoveAt.Auto())
            {
                collection.RemoveAt(index);
            }
        }

        private static readonly ProfilerMarker _PRF_Clear = new ProfilerMarker(_PRF_PFX + nameof(Clear));
        protected override void Clear(T collection)
        {
            using (_PRF_Clear.Auto())
            {
                collection.Clear();
            }
        }

        private static readonly ProfilerMarker _PRF_CollectionIsReadOnly = new ProfilerMarker(_PRF_PFX + nameof(CollectionIsReadOnly));
        protected override bool CollectionIsReadOnly(T collection)
        {
            using (_PRF_CollectionIsReadOnly.Auto())
            {
                return collection.IsReadOnly;
            }
        }
    }
}
