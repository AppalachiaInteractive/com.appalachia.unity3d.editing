using System.Collections;
using System.Collections.Generic;
using Appalachia.Editing.Core.Windows;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows
{
    public class ShaderSearch : AppalachiaEditorWindow
    {
        [ReadOnly]
        [PropertyOrder(175)]
        public int found;

        [ReadOnly]
        [PropertyOrder(150)]
        public int searched;

        [ListDrawerSettings]
        [PropertyOrder(200)]
        public List<Material> foundMaterials = new();

        [TabGroup("Shader")]
        [PropertyOrder(1)]
        [ShowInInspector]
        public Shader shader;

        [TabGroup("Material")]
        [PropertyOrder(1)]
        [ShowInInspector]
        public Texture2D texture;

        private bool _canSearchShader => shader != null;

        private bool _canSearchTexture => texture != null;

        [TabGroup("Shader")]
        [PropertyOrder(100)]
        [Button]
        [EnableIf(nameof(_canSearchShader))]
        public void SearchForMaterialsUtilizingShader()
        {
            foundMaterials.Clear();
            searched = 0;
            found = 0;
            var materialGuids = AssetDatabase.FindAssets("t: Material");

            ExecuteCoroutine(() => MaterialStep(materialGuids, true));
        }

        [TabGroup("Material")]
        [PropertyOrder(100)]
        [Button]
        [EnableIf(nameof(_canSearchTexture))]
        public void SearchForMaterialsUtilizingTexture()
        {
            foundMaterials.Clear();
            searched = 0;
            found = 0;
            var materialGuids = AssetDatabase.FindAssets("t: Material");

            ExecuteCoroutine(() => MaterialStep(materialGuids, false));
        }

        private IEnumerator MaterialStep(IEnumerable<string> materialGuids, bool byShader)
        {
            foreach (var materialGuid in materialGuids)
            {
                searched += 1;

                var material =
                    AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(materialGuid));

                if (byShader)
                {
                    if (material.shader == shader)
                    {
                        found += 1;
                        foundMaterials.Add(material);
                    }
                }
                else
                {
                    var nameIDs = material.GetTexturePropertyNameIDs();
                    foreach (var nameId in nameIDs)
                    {
                        var tex = material.GetTexture(nameId) as Texture2D;

                        if (tex == null)
                        {
                            continue;
                        }

                        if (texture == tex)
                        {
                            found += 1;
                            foundMaterials.Add(material);
                        }
                    }
                }

                yield return null;
            }
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Materials/Shader Search")]
        private static void OpenWindow()
        {
            OpenWindow<ShaderSearch>();
        }
    }
}
