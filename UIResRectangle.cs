﻿using System.Drawing;
using GTA;
using GTA.Native;
using UIRectangle = GTA.UI.Rectangle;

namespace NativeUI
{
    /// <summary>
    /// A rectangle in 1080 pixels height system.
    /// </summary>
    public class UIResRectangle : UIRectangle
    {
        public UIResRectangle()
        { }

        public UIResRectangle(Point pos, Size size) : base(pos, size)
        { }

        public UIResRectangle(Point pos, Size size, Color color) : base(pos, size, color)
        { }
        
        public override void Draw(SizeF offset)
        {
            if (!Enabled) return;
            float screenw = GTA.UI.Screen.Width;
            float screenh = GTA.UI.Screen.Height;
            const float height = 1080f;
            float ratio = (float)screenw / screenh;
            var width = height * ratio;

            float w = Size.Width/width;
            float h = Size.Height/height;
            float x = ((Position.X + offset.Width)/width) + w*0.5f;
            float y = ((Position.Y + offset.Height)/height) + h*0.5f;

            Function.Call(Hash.DRAW_RECT, x, y, w, h, Color.R, Color.G, Color.B, Color.A);
        }
    }
}