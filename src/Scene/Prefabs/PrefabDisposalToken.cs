#region

using UnityEngine;

#endregion

namespace Appalachia.Core.Editing.Prefabs
{
    public struct PrefabDisposalToken
    {
        public PrefabDisposalToken(GameObject prefab, string prefabPath)
        {
            this.prefab = prefab;
            this.prefabPath = prefabPath;
        }

        public GameObject prefab;
        public string prefabPath;
    }
}
