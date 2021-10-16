using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Metadata
{
    [Serializable]
    public class ShaderReviewMetadata
    {
        public ShaderInfo info;
        public bool isError;
        public bool isWarning;
        public Shader shader;
        public ShaderData data;
        public ShaderMessage[] messages;
    }
}
