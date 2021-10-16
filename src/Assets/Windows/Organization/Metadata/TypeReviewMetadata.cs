using System;
using System.Collections.Generic;
using Appalachia.CI.Integration.Paths;
using Appalachia.CI.Integration.Repositories;

namespace Appalachia.Editing.Assets.Windows.Organization.Metadata
{
    [Serializable]
    public class TypeReviewMetadata
    {
        public int issues;
        public List<string> locations;
        public List<RepositoryAssetSaveDirectories> repositories;
        public AssetSaveLocationMetadata saveLocation;
        public Type type;

        public bool HasIssues => issues > 0;
    }
}
