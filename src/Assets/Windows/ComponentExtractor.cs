using System;
using System.Collections.Generic;
using System.IO;
using Appalachia.Core.Assets;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Common;
using Appalachia.Editing.Core.Windows;
using Sirenix.OdinInspector;
using TreeEditor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Windows
{
    public class ComponentExtractor : AppalachiaEditorWindow
    {
        [InlineProperty]
        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true, DraggableItems = false)]
        public List<CheckboxListElement<Type>> eligibleComponents = new();

        [ListDrawerSettings(HideAddButton = true, DraggableItems = false)]
        public List<GameObject> objectsToExtractFrom = new();

        [FolderPath] public string outputDirectory;

        [Button]
        public void Extract()
        {
            AssetDatabase.Refresh();

            if (!AssetDatabaseSaveManager.RequestSuspendImport(out var scope))
            {
                return;
            }

            using (scope)
            {
                var eligible = new Dictionary<Type, CheckboxListElement<Type>>();

                foreach (var componentType in eligibleComponents)
                {
                    if (componentType.include)
                    {
                        eligible.Add(componentType.element, componentType);
                    }
                }

                foreach (var obj in objectsToExtractFrom)
                {
                    var foundComponents = obj.GetComponents<Component>();

                    foreach (var component in foundComponents)
                    {
                        var meshFilter = component as MeshFilter;
                        var meshRenderer = component as MeshRenderer;
                        var skinnedMeshRenderer = component as SkinnedMeshRenderer;
                        var tree = component as Tree;

                        if ((meshFilter != null) &&
                            eligible.ContainsKey(typeof(Mesh)) &&
                            eligible[typeof(Mesh)].include)
                        {
                            var newName = $"{obj.name}_mesh.mesh";
                            var path = Path.Combine(outputDirectory, newName);

                            SaveAsset(Instantiate(meshFilter.sharedMesh), path);
                        }

                        if (((meshRenderer != null) || (skinnedMeshRenderer != null)) &&
                            eligible.ContainsKey(typeof(Material)) &&
                            eligible[typeof(Material)].include)
                        {
                            var renderer = meshRenderer ?? (Renderer) skinnedMeshRenderer;

                            var count = 0;
                            foreach (var sharedMaterial in renderer.sharedMaterials)
                            {
                                var newName = $"{obj.name}_mat_{count}_{sharedMaterial.name}.mat";

                                var path = Path.Combine(outputDirectory, newName);
                                SaveAsset(Instantiate(sharedMaterial), path);

                                count++;
                            }
                        }

                        if (((meshRenderer != null) || (skinnedMeshRenderer != null)) &&
                            eligible.ContainsKey(typeof(Texture2D)) &&
                            eligible[typeof(Texture2D)].include)
                        {
                            var renderer = meshRenderer ?? (Renderer) skinnedMeshRenderer;

                            var count = 0;
                            foreach (var sharedMaterial in renderer.sharedMaterials)
                            {
                                var textureNames = sharedMaterial.GetTexturePropertyNames();

                                foreach (var textureName in textureNames)
                                {
                                    var texture = (Texture2D) sharedMaterial.GetTexture(textureName);

                                    var bytes = texture.EncodeToPNG();

                                    var newName =
                                        $"{obj.name}_mat_{count}_{sharedMaterial.name}_{texture.name}";
                                    var path = Path.Combine(outputDirectory, newName);

                                    File.WriteAllBytes(path, bytes);
                                }

                                count++;
                            }
                        }

                        if ((tree != null) &&
                            eligible.ContainsKey(typeof(TreeData)) &&
                            eligible[typeof(TreeData)].include)
                        {
                            var newName = $"{obj.name}_treedata";
                            var path = Path.Combine(outputDirectory, newName);

                            SaveAsset(Instantiate(tree.data as TreeData), path);
                        }
                    }
                }
            }
        }

        [Button]
        public void GetComponentMetadata()
        {
            eligibleComponents.Clear();

            var components = new HashSet<Type>();
            foreach (var obj in objectsToExtractFrom)
            {
                var foundComponents = obj.GetComponents<Component>();

                foreach (var component in foundComponents)
                {
                    var meshFilter = component as MeshFilter;
                    var meshRenderer = component as MeshRenderer;
                    var skinnedMeshRenderer = component as SkinnedMeshRenderer;
                    var tree = component as Tree;

                    if (meshFilter != null)
                    {
                        components.Add(typeof(Mesh));
                    }

                    if ((meshRenderer != null) || (skinnedMeshRenderer != null))
                    {
                        components.Add(typeof(Material));
                        components.Add(typeof(Texture2D));
                    }

                    if (tree != null)
                    {
                        components.Add(typeof(TreeData));
                    }
                }
            }

            foreach (var comp in components)
            {
                eligibleComponents.Add(new CheckboxListElement<Type> {element = comp, include = true});
            }
        }

        private void SaveAsset(Object objectToSave, string path)
        {
            Debug.Log($"Saving {objectToSave.name} at [{path}].");

            try
            {
                AssetDatabase.CreateAsset(objectToSave, path);
            }
            catch (UnityException)
            {
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.CreateAsset(objectToSave, path);
            }
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Component Extractor")]
        private static void OpenWindow()
        {
            var window = GetWindow<ComponentExtractor>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = window.position.AlignCenter(700, 700);
        }
    }
}
