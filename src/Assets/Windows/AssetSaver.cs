using System.Collections.Generic;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Assets.Context;
using Appalachia.Editing.Core.Windows;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows
{
    public class AssetSaver : AppalachiaEditorWindow
    {
        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true, DraggableItems = false)]
        [InlineProperty]
        public List<AssetComponent> componentsToSave;

        [ListDrawerSettings(HideAddButton = true, DraggableItems = false)]
        public List<GameObject> objectsToSave = new();

        [FolderPath] public string outputFolder;

        [Button]
        public void ReconnectTreeMeshes()
        {
            foreach (var tree in objectsToSave)
            {
                var prefab = PrefabUtility.GetOutermostPrefabInstanceRoot(tree);

                if (prefab == null)
                {
                    Debug.LogWarning($"Was not able to find prefab from tree {tree.name}.");
                    break;
                }

                var assetPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(tree);

                var objs = AssetDatabase.LoadAllAssetsAtPath(assetPath);

                if ((objs == null) || (objs.Length == 0))
                {
                    Debug.LogWarning(
                        $"Was not able to find objects for prefab {prefab.name} at [{assetPath}]."
                    );
                    break;
                }

                Mesh mesh = null;

                foreach (var obj in objs)
                {
                    var objMesh = obj as Mesh;

                    if (objMesh != null)
                    {
                        mesh = objMesh;
                    }
                    else
                    {
                        Debug.LogWarning($"Was not able to find mesh on object {obj.name} at {assetPath}");
                    }
                }

                if (mesh != null)
                {
                    var filter = prefab.GetComponent<MeshFilter>();
                    filter.sharedMesh = mesh;
                    PrefabUtility.ApplyPrefabInstance(prefab, InteractionMode.AutomatedAction);
                }
                else
                {
                    Debug.LogWarning($"Was not able to find mesh on prefab {prefab.name}");
                }
            }
        }

        [Button]
        public void SaveComponents()
        {
        }

        [Button]
        public void SearchForComponents()
        {
            foreach (var obj in objectsToSave)
            {
            }
        }

        [MenuItem("Tools/Asset Saver")]
        private static void OpenWindow()
        {
            var window = GetWindow<AssetSaver>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = window.position.AlignCenter(700, 700);
        }
    }
}
