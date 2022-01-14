#region

using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public struct PrefabDisposalToken
    {
        public PrefabDisposalToken(GameObject prefab, string prefabPath)
        {
            this.prefab = prefab;
            this.prefabPath = prefabPath;
        }

        #region Fields and Autoproperties

        public GameObject prefab;
        public string prefabPath;

        #endregion
    }
}
