#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Unity.Profiling;

#endregion

namespace Appalachia.Editing.Drawers.Collections
{
    [ResolverPriority(500.0)]
    public class
        AppaLookupValuePropertyResolver<T, TKey, TValue, TKList, TVList> : BaseOrderedCollectionResolver<T>
        where T : AppaLookup<TKey, TValue, TKList, TVList>
        where TKList : AppaList<TKey>, new()
        where TVList : AppaList<TValue>, new()
    {
        private const string _PRF_PFX =
            nameof(AppaLookupValuePropertyResolver<T, TKey, TValue, TKList, TVList>) + ".";

        private static readonly ProfilerMarker _PRF_GetChildInfo = new(_PRF_PFX + nameof(GetChildInfo));

        private static readonly ProfilerMarker _PRF_ChildPropertyRequiresRefresh =
            new(_PRF_PFX + nameof(ChildPropertyRequiresRefresh));

        private static readonly ProfilerMarker _PRF_ChildNameToIndex =
            new(_PRF_PFX + nameof(ChildNameToIndex));

        private static readonly ProfilerMarker _PRF_GetChildCount = new(_PRF_PFX + nameof(GetChildCount));

        private static readonly ProfilerMarker _PRF_Add = new(_PRF_PFX + nameof(Add));

        private static readonly ProfilerMarker _PRF_InsertAt = new(_PRF_PFX + nameof(InsertAt));
        private static readonly ProfilerMarker _PRF_Remove = new(_PRF_PFX + nameof(Remove));
        private static readonly ProfilerMarker _PRF_RemoveAt = new(_PRF_PFX + nameof(RemoveAt));
        private static readonly ProfilerMarker _PRF_Clear = new(_PRF_PFX + nameof(Clear));

        private static readonly ProfilerMarker _PRF_CollectionIsReadOnly =
            new(_PRF_PFX + nameof(CollectionIsReadOnly));

        private readonly Dictionary<int, InspectorPropertyInfo> childInfos = new();

        public override Type ElementType =>
            typeof(AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper);

        public bool MaySupportPrefabModifications => true;

        public override int ChildNameToIndex(string name)
        {
            using (_PRF_ChildNameToIndex.Auto())
            {
                return CollectionResolverUtilities.DefaultChildNameToIndex(name);
            }
        }

        public override bool ChildPropertyRequiresRefresh(int index, InspectorPropertyInfo info)
        {
            using (_PRF_ChildPropertyRequiresRefresh.Auto())
            {
                return false;
            }
        }

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
                            (
                                    ref T list,
                                    AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper element) =>
                                list[element.Key] = element.Value
                        ),
                        Property.Attributes.Where(
                                     attr => !attr.GetType()
                                                  .IsDefined(typeof(DontApplyToListElementsAttribute), true)
                                 )
                                .ToArray()
                    );
                    childInfos[childIndex] = inspectorPropertyInfo;
                }

                return inspectorPropertyInfo;
            }
        }

        protected override void Add(T collection, object value)
        {
            using (_PRF_Add.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Add(cast.Key, cast.Value);
            }
        }

        protected override void Clear(T collection)
        {
            using (_PRF_Clear.Auto())
            {
                collection.Clear();
            }
        }

        protected override bool CollectionIsReadOnly(T collection)
        {
            using (_PRF_CollectionIsReadOnly.Auto())
            {
                return collection.IsReadOnly;
            }
        }

        protected override int GetChildCount(T value)
        {
            using (_PRF_GetChildCount.Auto())
            {
                return value.Count;
            }
        }

        protected override void InsertAt(T collection, int index, object value)
        {
            using (_PRF_InsertAt.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Insert(index, cast.Key, cast.Value);
            }
        }

        protected override void Remove(T collection, object value)
        {
            using (_PRF_Remove.Auto())
            {
                var cast = (AppaLookup<TKey, TValue, TKList, TVList>.KVPDisplayWrapper) value;

                collection.Remove(cast.Key);
            }
        }

        protected override void RemoveAt(T collection, int index)
        {
            using (_PRF_RemoveAt.Auto())
            {
                collection.RemoveAt(index);
            }
        }
    }
}
