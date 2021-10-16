using System.Collections.Generic;
using UnityEngine;

namespace Appalachia.Editing.Core.Utilities
{
    public class TextureHelper
    {
        private static Dictionary<Color, Texture2D> _backgrounds;

        public static Texture2D GetBackground(Color color)
        {
            if (_backgrounds == null)
            {
                _backgrounds = new Dictionary<Color, Texture2D>();
            }

            if (_backgrounds.ContainsKey(color))
            {
                return _backgrounds[color];
            }

            return MakeTex(1, 1, color);
        }

        public static Texture2D MakeTex(int width, int height, Color col)
        {
            var result = new Texture2D(width, height);

            return PaintTex(result, col);
        }

        public static Texture2D PaintTex(Texture2D texture, Color col)
        {
            if (texture == null)
            {
                texture = new Texture2D(1, 1);
            }

            var pix = texture.GetPixels();

            for (var i = 0; i < pix.Length; i++)
            {
                pix[i] = col;
            }

            texture.SetPixels(pix);
            texture.Apply();

            return texture;
        }
    }
}
