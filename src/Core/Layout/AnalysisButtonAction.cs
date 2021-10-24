using System;
using Appalachia.Core.Context.Analysis.Core;
using Appalachia.Editing.Core.Fields;
using UnityEngine;

namespace Appalachia.Editing.Core.Layout
{
    public class AnalysisButtonAction<TA, TT, TE, TB>
        where TA : AnalysisMetadata<TA, TT, TE>, new()
        where TB : EditorUIFieldMetadata<TB>, IButtonMetadata, new()
        where TE : Enum
    {
        public AnalysisButtonAction(
            UIFieldMetadataManager fieldMetadataManager,
            string identifier,
            string labelName,
            bool enabled,
            Color color,
            Action<TA> correction1) : this(enabled, color)
        {
            this.correction1 = correction1;
            button = fieldMetadataManager.Get<TB>(identifier, f => f.AlterContent(c => c.text = labelName));
        }

        public AnalysisButtonAction(
            UIFieldMetadataManager fieldMetadataManager,
            string identifier,
            string labelName,
            bool enabled,
            Color color,
            TE analysisType,
            Action<AnalysisResult> correction2) : this(enabled, color)
        {
            this.analysisType = analysisType;
            this.correction2 = correction2;
            button = fieldMetadataManager.Get<TB>(identifier, f => f.AlterContent(c => c.text = labelName));
        }

        private AnalysisButtonAction(bool enabled, Color color)
        {
            this.enabled = enabled;
            this.color = color;
        }

        public Action<AnalysisResult> correction2;
        public Action<TA> correction1;
        public bool enabled;
        public Color color;

        public TB button;

        public TE analysisType;

        public void Execute(TA analysis)
        {
            if (correction1 != null)
            {
                correction1(analysis);
            }
            else
            {
                var issue = analysis.IssueByType(analysisType);
                correction2(issue);
            }
        }
    }
}
