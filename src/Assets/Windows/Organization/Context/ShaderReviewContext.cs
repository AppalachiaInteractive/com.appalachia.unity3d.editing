using System.Collections.Generic;
using Appalachia.CI.Integration.Assets;
using Appalachia.Editing.Assets.Windows.Organization.Metadata;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class ShaderReviewContext : AppalachiaWindowPaneContext,
                                       IAppalachiaOneMenuWindowPaneContext<ShaderReviewMetadata>
    {
        private const string _PRF_PFX = nameof(ShaderReviewContext) + ".";

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));

        public List<ShaderReviewMetadata> menuItems;

        public override int RequiredMenuCount => 1;

        public IList<ShaderReviewMetadata> MenuOneItems => menuItems;

        protected override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                if (menuItems == null)
                {
                    menuItems = new List<ShaderReviewMetadata>();
                }

                menuItems.Clear();

                var shaders = AssetDatabaseManager.FindAssets<Shader>();

                foreach (var shader in shaders)
                {
                    var shaderError = ShaderUtil.ShaderHasError(shader);
                    var shaderWarning = ShaderUtil.ShaderHasWarnings(shader);

                    var error = new ShaderReviewMetadata
                    {
                        isError = shaderError,
                        isWarning = shaderWarning,
                        shader = shader,
                        data = ShaderUtil.GetShaderData(shader),
                        info = ShaderUtil.GetShaderInfo(shader),
                        messages = ShaderUtil.GetShaderMessages(shader)
                    };

                    menuItems.Add(error);
                }
            }
        }

        protected override void OnReset()
        {
            using (_PRF_OnReset.Auto())
            {
                menuItems?.Clear();
            }
        }
    }
}
