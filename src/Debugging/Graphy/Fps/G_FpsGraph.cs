﻿using Appalachia.Editing.Debugging.Graphy.Graph;
using Appalachia.Editing.Debugging.Graphy.Shader;
using UnityEngine;
using UnityEngine.UI;

namespace Appalachia.Editing.Debugging.Graphy.Fps
{
    public class G_FpsGraph : G_Graph
    {
        #region Methods -> Public

        public void UpdateParameters()
        {
            if (m_shaderGraph == null)
            {
                // TODO: While Graphy is disabled (e.g. by default via Ctrl+H) and while in Editor after a Hot-Swap,
                // the OnApplicationFocus calls this while m_shaderGraph == null, throwing a NullReferenceException
                return;
            }

            switch (m_graphyManager.GraphyMode)
            {
                case GraphyManager.Mode.FULL:
                    m_shaderGraph.ArrayMaxSize = G_GraphShader.ArrayMaxSizeFull;
                    m_shaderGraph.Image.material = new Material(ShaderFull);
                    break;

                case GraphyManager.Mode.LIGHT:
                    m_shaderGraph.ArrayMaxSize = G_GraphShader.ArrayMaxSizeLight;
                    m_shaderGraph.Image.material = new Material(ShaderLight);
                    break;
            }

            m_shaderGraph.InitializeShader();

            m_resolution = m_graphyManager.FpsGraphResolution;

            CreatePoints();
        }

        #endregion

        #region Methods -> Private

        private void Init()
        {
            m_graphyManager = transform.root.GetComponentInChildren<GraphyManager>();

            m_fpsMonitor = GetComponent<G_FpsMonitor>();

            m_shaderGraph = new G_GraphShader {Image = m_imageGraph};

            UpdateParameters();

            m_isInitialized = true;
        }

        #endregion

        #region Methods -> Unity Callbacks

        private void Update()
        {
            UpdateGraph();
        }

        #endregion

        #region Variables -> Serialized Private

        [SerializeField] private Image m_imageGraph;

        [SerializeField] private UnityEngine.Shader ShaderFull;
        [SerializeField] private UnityEngine.Shader ShaderLight;

        // This keeps track of whether Init() has run or not
        [SerializeField] private bool m_isInitialized;

        #endregion

        #region Variables -> Private

        private GraphyManager m_graphyManager;

        private G_FpsMonitor m_fpsMonitor;

        private int m_resolution = 150;

        private G_GraphShader m_shaderGraph;

        private int[] m_fpsArray;

        private int m_highestFps;

        #endregion

        #region Methods -> Protected Override

        protected override void UpdateGraph()
        {
            // Since we no longer initialize by default OnEnable(), 
            // we need to check here, and Init() if needed
            if (!m_isInitialized)
            {
                Init();
            }

            var fps = (short) (1 / Time.unscaledDeltaTime);

            var currentMaxFps = 0;

            for (var i = 0; i <= (m_resolution - 1); i++)
            {
                if (i >= (m_resolution - 1))
                {
                    m_fpsArray[i] = fps;
                }
                else
                {
                    m_fpsArray[i] = m_fpsArray[i + 1];
                }

                // Store the highest fps to use as the highest point in the graph

                if (currentMaxFps < m_fpsArray[i])
                {
                    currentMaxFps = m_fpsArray[i];
                }
            }

            m_highestFps = (m_highestFps < 1) || (m_highestFps <= currentMaxFps)
                ? currentMaxFps
                : m_highestFps - 1;

            m_highestFps = m_highestFps > 0 ? m_highestFps : 1;

            if (m_shaderGraph.ShaderArrayValues == null)
            {
                m_fpsArray = new int[m_resolution];
                m_shaderGraph.ShaderArrayValues = new float[m_resolution];
            }

            for (var i = 0; i <= (m_resolution - 1); i++)
            {
                m_shaderGraph.ShaderArrayValues[i] = m_fpsArray[i] / (float) m_highestFps;
            }

            // Update the material values

            m_shaderGraph.UpdatePoints();

            if (m_fpsMonitor is not null)
            {
                m_shaderGraph.Average = m_fpsMonitor.AverageFPS / (float) m_highestFps;
            }

            m_shaderGraph.UpdateAverage();

            m_shaderGraph.GoodThreshold = (float) m_graphyManager.GoodFPSThreshold / m_highestFps;
            m_shaderGraph.CautionThreshold = (float) m_graphyManager.CautionFPSThreshold / m_highestFps;
            m_shaderGraph.UpdateThresholds();
        }

        protected override void CreatePoints()
        {
            if ((m_shaderGraph.ShaderArrayValues == null) || (m_fpsArray.Length != m_resolution))
            {
                m_fpsArray = new int[m_resolution];
                m_shaderGraph.ShaderArrayValues = new float[m_resolution];
            }

            for (var i = 0; i < m_resolution; i++)
            {
                m_shaderGraph.ShaderArrayValues[i] = 0;
            }

            m_shaderGraph.GoodColor = m_graphyManager.GoodFPSColor;
            m_shaderGraph.CautionColor = m_graphyManager.CautionFPSColor;
            m_shaderGraph.CriticalColor = m_graphyManager.CriticalFPSColor;

            m_shaderGraph.UpdateColors();

            m_shaderGraph.UpdateArray();
        }

        #endregion
    }
}
