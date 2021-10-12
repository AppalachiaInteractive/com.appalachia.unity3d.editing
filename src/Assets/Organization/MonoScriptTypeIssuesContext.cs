using System;
using System.Collections.Generic;
using Appalachia.Core.Assets;
using Appalachia.Utility.Reflection.Extensions;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Organization
{
    internal class MonoScriptTypeIssuesContext
    {
        private const string _PRF_PFX = nameof(MonoScriptTypeIssuesContext) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public List<Type> issueTypes;

        public void Initialize(IEnumerable<Type> soInheritors)
        {
            using (_PRF_Initialize.Auto())
            {
                if (issueTypes == null)
                {
                    issueTypes = new List<Type>();
                }

                foreach (var soInheritor in soInheritors)
                {
                    if (soInheritor == null)
                    {
                        continue;
                    }

                    var script = AssetDatabaseManager.GetScriptFromType(soInheritor);

                    if (script == null)
                    {
                        var ns = soInheritor.Namespace;

                        if (ns != null)
                        {
                            if (ns.StartsWith("Unity") ||
                                ns.StartsWith("TreeEditor") ||
                                ns.StartsWith("Packages.Rider") ||
                                ns.StartsWith("TMPro") ||
                                ns.StartsWith("TestRunner"))
                            {
                                continue;
                            }
                        }

                        if (soInheritor.InheritsFrom(typeof(EditorWindow)))
                        {
                            continue;
                        }

                        if (soInheritor.InheritsFrom(typeof(Editor)))
                        {
                            continue;
                        }

                        issueTypes.Add(soInheritor);
                    }
                }
            }
        }
    }
}
