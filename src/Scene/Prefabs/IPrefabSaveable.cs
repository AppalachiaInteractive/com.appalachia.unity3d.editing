#region

using UnityEngine;

#endregion

namespace Appalachia.Core.Editing.Prefabs
{
    public interface IPrefabSaveable
    {
        GameObject Prefab { get; set; }
    }
}
