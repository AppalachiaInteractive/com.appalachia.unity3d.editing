using Appalachia.Core.Assets;
using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_SHADER = "Shader Issues";
        private const string SHADER_CONTENT = "SHADER_CONTENT";

        private static readonly ProfilerMarker _PRF_InitializeShaderIssues =
            new(_PRF_PFX + nameof(InitializeShaderIssues));

        
        private ShaderIssuesContext _shaderContext;
        private void InitializeShaderIssues()
        {
            using (_PRF_InitializeShaderIssues.Auto())
            {
                _fieldManager.Add<ScrollViewUIMetadata>(SHADER_CONTENT);
                
                if (_shaderContext == null)
                {
                    _shaderContext = new ShaderIssuesContext();

                    _shaderContext.Initialize();
                }
            }
        }

        private void DrawShaderIssues()
        {
            var headerLabel = _fieldManager.Get<LabelH2Metadata>(TAB_SHADER);
            var rescanButton = _fieldManager.Get<ButtonMetadata>("Rescan Issues");
            var shaderErrorLabel = _fieldManager.Get<LabelH3Metadata>("Shader Errors");
            var shaderWarningLabel = _fieldManager.Get<LabelH3Metadata>("Sahder Warnings");

            headerLabel.Draw();

            if (rescanButton.Button())
            {
                _shaderContext = null;
                InitializeShaderIssues();
            }
            
            using (_fieldManager.Get<ScrollViewUIMetadata>(CLEANUP_CONTENT).GetScope())
            {
                shaderErrorLabel.Draw();
                
                for (var index = 0; index < _shaderContext.shaderErrors.Count; index++)
                {
                    var error = _shaderContext.shaderErrors[index];

                    DrawShaderError(error, true);
                };

                shaderWarningLabel.Draw();
                
                for (var index = 0; index < _shaderContext.shaderWarnings.Count; index++)
                {
                    var error = _shaderContext.shaderWarnings[index];

                    DrawShaderError(error, false);
                }
            }
        }

        private void DrawShaderError(ShaderErrorMetadata error, bool isError)
        {                        
            var label = _fieldManager.Get<LabelH4Metadata>(error.shader.name);
            
            var show = _fieldManager.Get<MiniButtonMetadata>("Show");

            using (new GUILayout.HorizontalScope())
            {
                label.Draw();
                
                if (show.Button(true))
                {
                    AssetDatabaseManager.SetSelection(error.shader);                    
                }
            }
        }
    }
}
