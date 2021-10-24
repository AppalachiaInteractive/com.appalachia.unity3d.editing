namespace Appalachia.Editing.Labels
{
    public struct LabelAssignmentTerm
    {
        public LabelAssignmentTerm(string term, float allowedMagnitude)
        {
            this.term = term;
            this.allowedMagnitude = allowedMagnitude;
        }

        public readonly float allowedMagnitude;

        public readonly string term;

        public override string ToString()
        {
            return $"{term} ({allowedMagnitude:F1}m)";
        }
    }
}
