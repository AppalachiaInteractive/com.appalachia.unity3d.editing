using Appalachia.CI.Integration.Analysis;
using Appalachia.CI.Integration.Assemblies;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Drawers
{
    public class AnalysisButtonAction
    {
        public AnalysisButtonAction(string labelName, bool hasIssue, Color color, AssemblyDefinitionAnalysisMetadata metadata)
        {
            this.labelName = labelName;
            this.hasIssue = hasIssue;
            this.color = color;
            this.metadata = metadata;
        }
            
        public AnalysisButtonAction(string labelName, bool hasIssue, Color color, AnalysisResult analysis)
        {
            this.labelName = labelName;
            this.hasIssue = hasIssue;
            this.color = color;
            this.analysis = analysis;
        }
            
        public string labelName;
        public bool hasIssue;
        public Color color;
        public AssemblyDefinitionAnalysisMetadata metadata;
        public AnalysisResult analysis;

        public void Correct(bool useTestFiles, bool reimport)
        {
            if (metadata != null)
            {
                metadata.CorrectAllIssues(useTestFiles, reimport);
            }
            else
            {
                analysis.Correct(useTestFiles, reimport);
            }
        }
    }
}
