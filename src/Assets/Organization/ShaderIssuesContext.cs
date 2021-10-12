using System.Collections.Generic;
using Appalachia.Core.Assets;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Organization
{
    internal class ShaderIssuesContext
    {
        private const string _PRF_PFX = nameof(ShaderIssuesContext) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public List<ShaderErrorMetadata> shaderErrors;
        public List<ShaderErrorMetadata> shaderWarnings;

        public void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                if (shaderErrors == null)
                {
                    shaderErrors = new List<ShaderErrorMetadata>();
                }
                if (shaderWarnings == null)
                {
                    shaderWarnings = new List<ShaderErrorMetadata>();
                }
                

                var shaders = AssetDatabaseManager.FindAssets<Shader>();
               
                foreach(var shader in shaders)
                {
                    var shaderError = ShaderUtil.ShaderHasError(shader);
                    var shaderWarning = ShaderUtil.ShaderHasWarnings(shader);
                    
                    if (!shaderError && !shaderWarning)
                    {
                        continue;
                    }

                    var error = new ShaderErrorMetadata
                    {
                        shader = shader,
                        data = ShaderUtil.GetShaderData(shader),
                        info = ShaderUtil.GetShaderInfo(shader),
                        messages = ShaderUtil.GetShaderMessages(shader)
                    };

                    if (shaderError)
                    {
                        shaderErrors.Add(error);                        
                    }
                    else if (shaderWarning)
                    {
                        shaderWarnings.Add(error);
                    }
                }
            }
        }
    }
}
