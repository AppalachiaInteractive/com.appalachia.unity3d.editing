/* ---------------------------------------
 * Author:          Martin Pane (martintayx@gmail.com) (@tayx94)
 * Contributors:    https://github.com/Tayx94/graphy/graphs/contributors
 * Project:         Graphy - Ultimate Stats Monitor
 * Date:            20-Dec-17
 * Studio:          Tayx
 *
 * Git repo:        https://github.com/Tayx94/graphy
 *
 * This project is released under the MIT license.
 * Attribution is not required, but it is always welcomed!
 * -------------------------------------*/

using Appalachia.CI.Integration.Assets;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Graphy
{
    public class GraphyMenuItem
    {
        [MenuItem("Tools/Graphy/Create Prefab Variant")]
        private static void CreatePrefabVariant()
        {
            // Directory checking
            if (!AssetDatabaseManager.IsValidFolder("Assets/Graphy - Ultimate Stats Monitor"))
            {
                AssetDatabaseManager.CreateFolder("Assets", "Graphy - Ultimate Stats Monitor");
            }

            if (!AssetDatabaseManager.IsValidFolder("Assets/Graphy - Ultimate Stats Monitor/Prefab Variants"))
            {
                AssetDatabaseManager.CreateFolder(
                    "Assets/Graphy - Ultimate Stats Monitor",
                    "Prefab Variants"
                );
            }

            var graphyPrefabGuid = AssetDatabaseManager.FindAssets("[Graphy]")[0];

            Object originalPrefab = (GameObject) AssetDatabaseManager.LoadAssetAtPath(
                AssetDatabaseManager.GUIDToAssetPath(graphyPrefabGuid),
                typeof(GameObject)
            );
            var objectSource = PrefabUtility.InstantiatePrefab(originalPrefab) as GameObject;

            var prefabVariantCount = AssetDatabaseManager.FindAssets(
                                                              "Graphy_Variant",
                                                              new[]
                                                                  {
                                                                      "Assets/Graphy - Ultimate Stats Monitor/Prefab Variants"
                                                                  }
                                                          )
                                                         .Length;

            var prefabVariant = PrefabUtility.SaveAsPrefabAsset(
                objectSource,
                $"Assets/Graphy - Ultimate Stats Monitor/Prefab Variants/Graphy_Variant_{prefabVariantCount}.prefab"
            );

            Object.DestroyImmediate(objectSource);

            foreach (SceneView scene in SceneView.sceneViews)
            {
                scene.ShowNotification(
                    new GUIContent(
                        "Prefab Variant Created at \"Assets/Graphy - Ultimate Stats Monitor/Prefab\"!"
                    )
                );
            }
        }

        [MenuItem("Tools/Graphy/Import Graphy Customization Scene")]
        private static void ImportGraphyCustomizationScene()
        {
            var customizationSceneGuid = AssetDatabaseManager.FindAssets("Graphy_CustomizationScene")[0];

            AssetDatabaseManager.ImportPackage(
                AssetDatabaseManager.GUIDToAssetPath(customizationSceneGuid),
                true
            );
        }
    }
}
