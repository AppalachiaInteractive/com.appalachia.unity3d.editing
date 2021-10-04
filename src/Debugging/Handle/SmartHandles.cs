#if UNITY_EDITOR

#region

using System;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

#endregion

namespace Appalachia.Editing.Debugging.Handle
{
    public static class SmartHandles
    {
        private static readonly ProfilerMarker _PRF_DrawHandleLine =
            new(_PRF_PFX + nameof(DrawHandleLine));

        private static readonly ProfilerMarker _PRF_DrawLine = new(_PRF_PFX + nameof(DrawLine));

        private static readonly ProfilerMarker _PRF_DrawLineMasked =
            new(_PRF_PFX + nameof(DrawLineMasked));

        private static readonly ProfilerMarker _PRF_DrawSolidDisc =
            new(_PRF_PFX + nameof(DrawSolidDisc));

        private static readonly ProfilerMarker _PRF_DrawSolidDiscMasked =
            new(_PRF_PFX + nameof(DrawSolidDiscMasked));

        private static readonly ProfilerMarker _PRF_DrawSphere = new(_PRF_PFX + nameof(DrawSphere));

        private static readonly ProfilerMarker _PRF_DrawSphereMasked =
            new(_PRF_PFX + nameof(DrawSphereMasked));

        private static readonly ProfilerMarker _PRF_DrawWireArcMasked =
            new(_PRF_PFX + nameof(DrawWireArcMasked));

        private static readonly ProfilerMarker _PRF_DrawWireCube =
            new(_PRF_PFX + nameof(DrawWireCube_Internal));

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked =
            new(_PRF_PFX + nameof(DrawWireCubeMasked));

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked_Color =
            new(_PRF_PFX + nameof(DrawWireCubeMasked) + ".Color");

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked_HandleState =
            new(_PRF_PFX + nameof(DrawWireCubeMasked) + ".HandleState");

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked_InternalDraw =
            new(_PRF_PFX + nameof(DrawWireCubeMasked) + ".InternalDraw");

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked_Vector3s =
            new(_PRF_PFX + nameof(DrawWireCubeMasked) + ".Vector3s");

        private static readonly ProfilerMarker _PRF_DrawWireCubeMasked_ZTest =
            new(_PRF_PFX + nameof(DrawWireCubeMasked) + ".ZTest");

        private static readonly ProfilerMarker _PRF_DrawWireCube_HandleState =
            new(_PRF_PFX + nameof(DrawWireCube_Internal) + ".HandleState");

        private static readonly ProfilerMarker _PRF_DrawWireCube_InternalDraw =
            new(_PRF_PFX + nameof(DrawWireCube_Internal) + ".InternalDraw");

        private static readonly ProfilerMarker _PRF_DrawWireDisc =
            new(_PRF_PFX + nameof(DrawWireDisc));

        private static readonly ProfilerMarker _PRF_DrawWireDiscMasked =
            new(_PRF_PFX + nameof(DrawWireDiscMasked));

        private static readonly ProfilerMarker _PRF_DrawWireMatrix =
            new(_PRF_PFX + nameof(DrawWireMatrix));

        private static readonly ProfilerMarker _PRF_DrawWireMesh =
            new(_PRF_PFX + nameof(DrawWireMesh));

        private static readonly ProfilerMarker _PRF_DrawWireSphere =
            new(_PRF_PFX + nameof(DrawWireSphere));

        private static readonly ProfilerMarker _PRF_DrawWireSphereMasked =
            new(_PRF_PFX + nameof(DrawWireSphereMasked));

        public static float zFailAmount = .2f;

        private static Vector3[] _drawWireCubeArray;
        private static Vector3[] _drawWireCubeLines;

        private static Mesh s_CubeMesh;
        private static Mesh s_SphereMesh;
        private static Mesh s_ConeMesh;
        private static Mesh s_CylinderMesh;
        private static Mesh s_QuadMesh;
        private static Vector3 s_InitialScale;

        private static readonly ProfilerMarker _PRF_DrawWireCube_Internal =
            new(_PRF_PFX + nameof(DrawWireCube_Internal));

        private static readonly GUIContent s_Text = new();
        private static readonly GUIContent s_Image = new();
        private static readonly GUIContent s_TextImage = new();

        private static GUIStyle _baseLabelStyle;
        private static readonly int HandleColor = Shader.PropertyToID("_HandleColor");
        private static readonly int HandleSize = Shader.PropertyToID("_HandleSize");
        private static readonly int ObjectToWorld = Shader.PropertyToID("_ObjectToWorld");
        private static readonly int HandleZTest = Shader.PropertyToID("_HandleZTest");

        public static GUIStyle BaseLabelStyle
        {
            get
            {
                if (_baseLabelStyle == null)
                {
                    _baseLabelStyle = new GUIStyle(GUI.skin.label);

                    _baseLabelStyle.normal.background = Texture2D.whiteTexture;
                    _baseLabelStyle.border = new RectOffset(1, 1, 1, 1);
                }

                return _baseLabelStyle;
            }
        }

        public static void DrawLineMasked(Vector3 pos1, Vector3 pos2, Color color)
        {
            using (_PRF_DrawLineMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.DrawLine(pos1, pos2);
                    Handles.zTest = CompareFunction.Greater;
                    Handles.color = color * zFailAmount;

                    //Handles.DrawLine(pos1, pos2);
                }
            }
        }

        public static void DrawLine(Vector3 pos1, Vector3 pos2, Color color)
        {
            using (_PRF_DrawLine.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Gizmos.DrawLine(pos1, pos2);
                }
            }
        }

        public static void DrawRay(Ray ray, Color color)
        {
            using (_PRF_DrawLine.Auto())
            {
                using (GizmoState.New(color, false))
                {
                    Gizmos.DrawRay(ray);
                }
            }
        }

        public static void DrawWireDiscMasked(
            Vector3 center,
            Vector3 normal,
            float radius,
            Color color,
            bool ignoreZFail = true)
        {
            using (_PRF_DrawWireDiscMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.DrawWireDisc(center, normal, radius);
                    if (ignoreZFail)
                    {
                        Handles.zTest = CompareFunction.Greater;
                        Handles.color = color * zFailAmount;
                        Handles.DrawWireDisc(center, normal, radius);
                    }
                }
            }
        }

        public static void DrawWireDiscMasked(
            Vector3 position,
            Quaternion rotation,
            float radius,
            Color color,
            bool ignoreZFail = true)
        {
            using (_PRF_DrawWireDiscMasked.Auto())
            {
                DrawWireDiscMasked(position, rotation.eulerAngles, radius, color, ignoreZFail);
            }
        }

        public static void DrawWireDisc(Vector3 center, Vector3 normal, float radius, Color color)
        {
            using (_PRF_DrawWireDisc.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Handles.DrawWireDisc(center, normal, radius);
                }
            }
        }

        public static void DrawWireDisc(
            Vector3 position,
            Quaternion rotation,
            float radius,
            Color color)
        {
            using (_PRF_DrawWireDisc.Auto())
            {
                DrawWireDisc(position, rotation.eulerAngles, radius, color);
            }
        }

        public static void DrawSolidDiscMasked(
            Vector3 center,
            Vector3 normal,
            float radius,
            Color color,
            bool ignoreZFail = true)
        {
            using (_PRF_DrawSolidDiscMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.DrawSolidDisc(center, normal, radius);

                    if (ignoreZFail)
                    {
                        Handles.zTest = CompareFunction.Greater;
                        Handles.color = color * zFailAmount;
                        Handles.DrawSolidDisc(center, normal, radius);
                    }
                }
            }
        }

        public static void DrawSolidDiscMasked(
            Vector3 position,
            Quaternion rotation,
            float radius,
            Color color,
            bool ignoreZFail = true)
        {
            using (_PRF_DrawSolidDiscMasked.Auto())
            {
                DrawSolidDiscMasked(position, rotation.eulerAngles, radius, color, ignoreZFail);
            }
        }

        public static void DrawSolidDisc(Vector3 center, Vector3 normal, float radius, Color color)
        {
            using (_PRF_DrawSolidDisc.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Handles.DrawSolidDisc(center, normal, radius);
                }
            }
        }

        public static void DrawSolidDisc(
            Vector3 position,
            Quaternion rotation,
            float radius,
            Color color)
        {
            using (_PRF_DrawSolidDisc.Auto())
            {
                DrawSolidDisc(position, rotation.eulerAngles, radius, color);
            }
        }

        public static void DrawWireArcMasked(
            Vector3 center,
            Vector3 normal,
            Vector3 from,
            float angle,
            float radius,
            Color color)
        {
            using (_PRF_DrawWireArcMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.DrawWireArc(center, normal, from, angle, radius);
                    Handles.zTest = CompareFunction.Greater;
                    Handles.color = color * zFailAmount;
                    Handles.DrawWireArc(center, normal, from, angle, radius);
                }
            }
        }

        public static void DrawWireCubeMasked(Bounds bounds, Color color)
        {
            using (_PRF_DrawWireCube.Auto())
            {
                Vector3 center;
                Vector3 size;

                using (_PRF_DrawWireCubeMasked_Vector3s.Auto())
                {
                    center = bounds.center;
                    size = bounds.size;
                }

                DrawWireCubeMasked(center, size, color);
            }
        }

        public static void DrawWireCubeMasked(Vector3 center, Vector3 size, Color color)
        {
            using (_PRF_DrawWireCubeMasked.Auto())
            {
                HandleState handleState;

                using (_PRF_DrawWireCubeMasked_HandleState.Auto())
                {
                    handleState = HandleState.New(color, false, CompareFunction.LessEqual);
                }

                using (handleState)
                {
                    using (_PRF_DrawWireCubeMasked_InternalDraw.Auto())
                    {
                        DrawWireCube_Internal(center, size);
                    }

                    using (_PRF_DrawWireCubeMasked_ZTest.Auto())
                    {
                        Handles.zTest = CompareFunction.Greater;
                    }

                    using (_PRF_DrawWireCubeMasked_Color.Auto())
                    {
                        Handles.color = color * zFailAmount;
                    }

                    using (_PRF_DrawWireCubeMasked_InternalDraw.Auto())
                    {
                        DrawWireCube_Internal(center, size);
                    }
                }
            }
        }

        public static void DrawWireCube(Bounds b, Color color)
        {
            using (_PRF_DrawWireCube.Auto())
            {
                DrawWireCube(b.center, b.size, color);
            }
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Color color)
        {
            using (_PRF_DrawWireCube.Auto())
            {
                HandleState handleState;

                using (_PRF_DrawWireCube_HandleState.Auto())
                {
                    handleState = HandleState.New(color, false);
                }

                using (handleState)
                {
                    _PRF_DrawWireCube_InternalDraw.Begin();
                    {
                        DrawWireCube_Internal(center, size);
                    }
                    _PRF_DrawWireCube_InternalDraw.End();
                }
            }
        }

        public static void DrawWireCube(Vector3 center, Vector3 size)
        {
            using (_PRF_DrawWireCube.Auto())
            {
                DrawWireCube_Internal(center, size);
            }
        }

        public static void DrawWireCube(Vector3 center, float size)
        {
            using (_PRF_DrawWireCube.Auto())
            {
                DrawWireCube_Internal(center, Vector3.one * size);
            }
        }

        /// <summary>
        ///     <para>Draw a wireframe box with center and size.</para>
        /// </summary>
        /// <param name="center"></param>
        /// <param name="size"></param>
        public static void DrawWireCube_Internal(Vector3 center, Vector3 size)
        {
            using (_PRF_DrawWireCube_Internal.Auto())
            {
                Gizmos.DrawWireCube(center, size);
            }
        }

        public static void DrawCube(Vector3 center, float radius)
        {
            using (_PRF_DrawSphere.Auto())
            {
                Graphics.DrawMeshNow(cubeMesh, StartDraw(center, Quaternion.identity, radius));
            }
        }

        public static void DrawCube(Vector3 center, float radius, Color color)
        {
            using (_PRF_DrawSphere.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Graphics.DrawMeshNow(cubeMesh, StartDraw(center, Quaternion.identity, radius));
                }
            }
        }

        public static void DrawWireMesh(
            Mesh mesh,
            Vector3 position,
            Quaternion rotation,
            Vector3 scale,
            Color color)
        {
            using (_PRF_DrawWireMesh.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Gizmos.DrawWireMesh(mesh, -1, position, rotation, scale);
                }
            }
        }

        public static void DrawWireSphere(Vector3 center, float radius, Color color)
        {
            using (_PRF_DrawWireSphere.Auto())
            {
                using (new UnifiedDrawingScope(color))
                {
                    DrawWireSphere(center, radius);

                    //Handles.DrawWireDisc(center, Vector3.up,      radius);
                    //Handles.DrawWireDisc(center, Vector3.right,   radius);
                    //Handles.DrawWireDisc(center, Vector3.forward, radius);
                }
            }
        }

        public static void DrawWireSphere(Vector3 center, float radius)
        {
            using (_PRF_DrawWireSphere.Auto())
            {
                Gizmos.DrawWireSphere(center, radius);
            }
        }

        public static void DrawWireSphereMasked(Vector3 center, float radius, Color color)
        {
            using (_PRF_DrawWireSphereMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.DrawWireDisc(center, Vector3.up,      radius);
                    Handles.DrawWireDisc(center, Vector3.right,   radius);
                    Handles.DrawWireDisc(center, Vector3.forward, radius);
                    Handles.zTest = CompareFunction.Greater;
                    Handles.color = color * zFailAmount;
                    Handles.DrawWireDisc(center, Vector3.up,      radius);
                    Handles.DrawWireDisc(center, Vector3.right,   radius);
                    Handles.DrawWireDisc(center, Vector3.forward, radius);
                }
            }
        }

        public static void DrawSphereMasked(Vector3 center, float radius, Color color)
        {
            using (_PRF_DrawSphereMasked.Auto())
            {
                using (HandleState.New(color, false, CompareFunction.LessEqual))
                {
                    Handles.SphereHandleCap(
                        0,
                        center,
                        Quaternion.identity,
                        radius,
                        EventType.Layout
                    );
                    Handles.zTest = CompareFunction.Greater;
                    Handles.color = color * zFailAmount;
                    Handles.SphereHandleCap(
                        0,
                        center,
                        Quaternion.identity,
                        radius,
                        EventType.Layout
                    );
                }
            }
        }

        public static void DrawSphere(Vector3 center, float radius, Color color)
        {
            using (_PRF_DrawSphere.Auto())
            {
                using (HandleState.New(color, false))
                {
                    Graphics.DrawMeshNow(
                        sphereMesh,
                        StartDraw(center, Quaternion.identity, radius)
                    );
                }
            }
        }

        public static void DrawSphere(Vector3 center, float radius)
        {
            using (_PRF_DrawSphere.Auto())
            {
                Graphics.DrawMeshNow(sphereMesh, StartDraw(center, Quaternion.identity, radius));
            }
        }

        public static void DrawWireMatrix(
            Vector3 position,
            Matrix4x4 matrix,
            float scale = 1f,
            float sphereScale = .5f,
            float alpha = 1f,
            float worldAlpha = .35f,
            int steps = 10,
            float distanceStep = .5f)
        {
            using (_PRF_DrawWireMatrix.Auto())
            {
                var sphere = Color.white;
                sphere.a = alpha;
                DrawWireSphere(position + matrix.MultiplyPoint(Vector3.zero), sphereScale, sphere);

                var directions = new[]
                {
                    Vector3.up,
                    Vector3.forward,
                    Vector3.right,
                    Vector3.up,
                    Vector3.forward,
                    Vector3.right
                };

                var colors = new[]
                {
                    Color.green,
                    Color.blue,
                    Color.red,
                    Color.green * Color.grey,
                    Color.blue * Color.grey,
                    Color.red * Color.grey
                };

                for (var i = 0; i < colors.Length; i++)
                {
                    var color = colors[i];
                    color.a = alpha;
                    colors[i] = color;
                }

                var matrices = new[]
                {
                    matrix,
                    Matrix4x4.TRS(
                        matrix.MultiplyPoint(Vector3.zero),
                        Quaternion.identity,
                        Vector3.one
                    )
                };

                colors[3].a = worldAlpha;
                colors[4].a = worldAlpha;
                colors[5].a = worldAlpha;

                for (var i = 0; i < (steps * 6); i++)
                {
                    var direction = directions[i / steps];
                    var color = colors[i / steps];
                    var m = matrices[i / (steps * 3)];
                    var scaleTime = ((i % steps) + 1) * distanceStep;
                    var radius = scale * .05f * scaleTime;
                    var center = position + m.MultiplyPoint(direction * scaleTime);

                    DrawWireSphere(center, radius, color);
                }
            }
        }

        public static void DrawHandleLine(
            Vector3 start,
            Vector3 end,
            HandleCapType capType,
            Vector3 up,
            Vector3 forward,
            float capSize,
            Color color)
        {
            using (_PRF_DrawHandleLine.Auto())
            {
                var capID = GUIUtility.GetControlID(FocusType.Passive);
                var handleSize = HandleUtility.GetHandleSize(end) * capSize;
                var handleRotation = Quaternion.LookRotation(forward, up);

                var originalColor = Handles.color;

                Handles.color = color;

                DrawLine(start, end, color);

                switch (capType)
                {
                    case HandleCapType.Arrow:
                        Handles.ArrowHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Circle:
                        Handles.CircleHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Cone:
                        Handles.ConeHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Cube:
                        Handles.CubeHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Cylinder:
                        Handles.CylinderHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Dot:
                        Handles.DotHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Rectangle:
                        Handles.RectangleHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    case HandleCapType.Sphere:
                        Handles.SphereHandleCap(
                            capID,
                            end,
                            handleRotation,
                            handleSize,
                            EventType.Repaint
                        );
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(capType), capType, null);
                }

                Handles.color = originalColor;
            }
        }

        public static void Label(
            Vector3 position,
            string text,
            Color textColor,
            Color backgroundColor)
        {
            var bg = GUI.backgroundColor;
            var cc = GUI.contentColor;

            GUI.contentColor = textColor;
            GUI.backgroundColor = backgroundColor;

            Handles.Label(position, TempContent(text), BaseLabelStyle);

            GUI.backgroundColor = bg;
            GUI.contentColor = cc;
        }

        public static void Label(
            Vector3 position,
            Texture image,
            Color textColor,
            Color backgroundColor)
        {
            var bg = GUI.backgroundColor;
            var cc = GUI.contentColor;

            GUI.contentColor = textColor;
            GUI.backgroundColor = backgroundColor;

            Handles.Label(position, TempContent(image), BaseLabelStyle);

            GUI.backgroundColor = bg;
            GUI.contentColor = cc;
        }

        public static GUIContent TempContent(string t)
        {
            s_Text.image = null;
            s_Text.text = t;
            s_Text.tooltip = null;
            return s_Text;
        }

        public static GUIContent TempContent(Texture i)
        {
            s_Image.image = i;
            s_Image.text = null;
            s_Image.tooltip = null;
            return s_Image;
        }

        public static GUIContent TempContent(string t, Texture i)
        {
            s_TextImage.image = i;
            s_TextImage.text = t;
            s_TextImage.tooltip = null;
            return s_TextImage;
        }

        public static GUIContent[] TempContent(string[] texts)
        {
            var guiContentArray = new GUIContent[texts.Length];
            for (var index = 0; index < texts.Length; ++index)
            {
                guiContentArray[index] = new GUIContent(texts[index]);
            }

            return guiContentArray;
        }

        public static GUIContent[] TempContent(string[] texts, string[] tooltips)
        {
            var guiContentArray = new GUIContent[texts.Length];
            for (var index = 0; index < texts.Length; ++index)
            {
                guiContentArray[index] = new GUIContent(texts[index], tooltips[index]);
            }

            return guiContentArray;
        }

#region UnifiedDrawingScope

        /// <summary>
        ///     <para>Disposable helper struct for automatically setting and reverting Gizmos and UnityEditor.Handles properties.</para>
        /// </summary>
        public class UnifiedDrawingScope : IDisposable
        {
            private readonly Color _originalGizmosColor;
            private readonly Matrix4x4 _originalGizmosMatrix;
            private readonly Color _originalHandlesColor;
            private readonly Matrix4x4 _originalHandlesMatrix;

            private Color _currentUnifiedColor;
            private Matrix4x4 _currentUnifiedMatrix;
            private bool _isDisposed;

            /// <summary>
            ///     <para>Create a new DrawingScope and set UnityEditor.Handles.color and/or UnityEditor.Handles.matrix to the specified values.</para>
            /// </summary>
            /// <param name="matrix">The matrix to use for displaying UnityEditor.Handles inside the scope block.</param>
            /// <param name="color">The color to use for displaying UnityEditor.Handles inside the scope block.</param>
            public UnifiedDrawingScope(Color color) : this(color, Handles.matrix)
            {
            }

            /// <summary>
            ///     <para>Create a new DrawingScope and set UnityEditor.Handles.color and/or UnityEditor.Handles.matrix to the specified values.</para>
            /// </summary>
            /// <param name="matrix">The matrix to use for displaying UnityEditor.Handles inside the scope block.</param>
            /// <param name="color">The color to use for displaying UnityEditor.Handles inside the scope block.</param>
            public UnifiedDrawingScope(Matrix4x4 matrix) : this(Handles.color, matrix)
            {
            }

            /// <summary>
            ///     <para>Create a new DrawingScope and set UnityEditor.Handles.color and/or UnityEditor.Handles.matrix to the specified values.</para>
            /// </summary>
            /// <param name="matrix">The matrix to use for displaying UnityEditor.Handles inside the scope block.</param>
            /// <param name="color">The color to use for displaying UnityEditor.Handles inside the scope block.</param>
            public UnifiedDrawingScope(Color color, Matrix4x4 matrix)
            {
                _isDisposed = false;
                _originalHandlesColor = Handles.color;
                _originalHandlesMatrix = Handles.matrix;
                _originalGizmosColor = Handles.color;
                _originalGizmosMatrix = Handles.matrix;
                Handles.matrix = matrix;
                Handles.color = color;
                Gizmos.matrix = matrix;
                Gizmos.color = color;
                _currentUnifiedMatrix = matrix;
                _currentUnifiedColor = color;
            }

            /// <summary>
            ///     <para>The value of UnityEditor.Handles.color at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Color originalHandlesColor => _originalHandlesColor;

            /// <summary>
            ///     <para>The value of UnityEditor.Handles.matrix at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Matrix4x4 originalHandlesMatrix => _originalHandlesMatrix;

            /// <summary>
            ///     <para>The value of Gizmos.color at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Color originalGizmosColor => _originalGizmosColor;

            /// <summary>
            ///     <para>The value of Gizmos.matrix at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Matrix4x4 originalGizmosMatrix => _originalGizmosMatrix;

            /// <summary>
            ///     <para>The value of Gizmos.color at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Color color
            {
                get => _currentUnifiedColor;
                set
                {
                    if (Handles.color != value)
                    {
                        Handles.color = value;
                    }

                    if (Gizmos.color != value)
                    {
                        Gizmos.color = value;
                    }

                    _currentUnifiedColor = value;
                }
            }

            /// <summary>
            ///     <para>The value of Gizmos.matrix at the time this UnifiedDrawingScope was created.</para>
            /// </summary>
            public Matrix4x4 matrix
            {
                get => _currentUnifiedMatrix;
                set
                {
                    Handles.matrix = value;
                    Gizmos.matrix = value;
                    _currentUnifiedMatrix = value;
                }
            }

            /// <summary>
            ///     <para>
            ///         Automatically reverts UnityEditor.Handles.color and UnityEditor.Handles.matrix to their values prior to entering the scope, when the scope
            ///         is exited. You do not need to call this method manually.
            ///     </para>
            /// </summary>
            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                _isDisposed = true;
                Handles.color = _originalHandlesColor;
                Handles.matrix = _originalHandlesMatrix;
                Gizmos.color = _originalGizmosColor;
                Gizmos.matrix = _originalGizmosMatrix;
            }
        }

#endregion

#region ProfileMarkers

        private const string _PRF_PFX = nameof(SmartHandles) + ".";

#endregion

#region Handle Meshes

        private static Mesh cubeMesh
        {
            get
            {
                if (s_CubeMesh == null)
                {
                    Init();
                }

                return s_CubeMesh;
            }
        }

        private static Mesh coneMesh
        {
            get
            {
                if (s_ConeMesh == null)
                {
                    Init();
                }

                return s_ConeMesh;
            }
        }

        private static Mesh cylinderMesh
        {
            get
            {
                if (s_CylinderMesh == null)
                {
                    Init();
                }

                return s_CylinderMesh;
            }
        }

        private static Mesh sphereMesh
        {
            get
            {
                if (s_SphereMesh == null)
                {
                    Init();
                }

                return s_SphereMesh;
            }
        }

        internal static void Init()
        {
            if ((bool) s_CubeMesh)
            {
                return;
            }

            var gameObject = (GameObject) EditorGUIUtility.Load("SceneView/HandlesGO.fbx");
            if (!(bool) gameObject)
            {
                Debug.Log("Couldn't find SceneView/HandlesGO.fbx");
            }

            gameObject.SetActive(false);
            foreach (Transform transform in gameObject.transform)
            {
                var component = transform.GetComponent<MeshFilter>();
                var name = transform.name;

                if (name != "Cube")
                {
                    if (name != "Sphere")
                    {
                        if (name != "Cone")
                        {
                            if (name != "Cylinder")
                            {
                                if (name == "Quad")
                                {
                                    s_QuadMesh = component.sharedMesh;
                                    Debug.AssertFormat(
                                        s_QuadMesh != null,
                                        "mesh is null. A problem has occurred with `SceneView/HandlesGO.fbx`"
                                    );
                                }
                            }
                            else
                            {
                                s_CylinderMesh = component.sharedMesh;
                                Debug.AssertFormat(
                                    s_CylinderMesh != null,
                                    "mesh is null. A problem has occurred with `SceneView/HandlesGO.fbx`"
                                );
                            }
                        }
                        else
                        {
                            s_ConeMesh = component.sharedMesh;
                            Debug.AssertFormat(
                                s_ConeMesh != null,
                                "mesh is null. A problem has occurred with `SceneView/HandlesGO.fbx`"
                            );
                        }
                    }
                    else
                    {
                        s_SphereMesh = component.sharedMesh;
                        Debug.AssertFormat(
                            s_SphereMesh != null,
                            "mesh is null. A problem has occurred with `SceneView/HandlesGO.fbx`"
                        );
                    }
                }
                else
                {
                    s_CubeMesh = component.sharedMesh;
                    Debug.AssertFormat(
                        s_CubeMesh != null,
                        "mesh is null. A problem has occurred with `SceneView/HandlesGO.fbx`"
                    );
                }
            }
        }

        internal static Matrix4x4 StartDraw(Vector3 position, Quaternion rotation, float size)
        {
            Shader.SetGlobalColor(HandleColor, realHandleColor);
            Shader.SetGlobalFloat(HandleSize, size);
            var matrix4x4 = Handles.matrix * Matrix4x4.TRS(position, rotation, Vector3.one);
            Shader.SetGlobalMatrix(ObjectToWorld, matrix4x4);
            HandleUtility.handleMaterial.SetInt(HandleZTest, (int) Handles.zTest);
            HandleUtility.handleMaterial.SetPass(0);
            return matrix4x4;
        }

        internal static Color realHandleColor =>
            (Handles.color * new Color(1f, 1f, 1f, 0.5f)) +
            (Handles.lighting
                ? new Color(0.0f, 0.0f, 0.0f, 0.5f)
                : new Color(0.0f, 0.0f, 0.0f, 0.0f));

#endregion
    }
}

#endif
