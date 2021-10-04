#region

using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public interface IPrefabSaveable
    {
        GameObject Prefab { get; set; }
    }
}
