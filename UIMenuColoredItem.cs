﻿using System.Drawing;
using GTA.UI;

namespace NativeUI
{
    public class UIMenuColoredItem : UIMenuItem
    {
        public Color MainColor { get; set; }
        public Color HighlightColor { get; set; }

        public Color TextColor { get; set; }
        public Color HighlightedTextColor { get; set; }
        
        public UIMenuColoredItem(string label, Color color, Color highlightColor) : base(label)
        {
            MainColor = color;
            HighlightColor = highlightColor;

            TextColor = Color.White;
            HighlightedTextColor = Color.Black;

            Init();
        }

        public UIMenuColoredItem(string label, string description, Color color, Color highlightColor) : base(label, description)
        {
            MainColor = color;
            HighlightColor = highlightColor;

            TextColor = Color.White;
            HighlightedTextColor = Color.Black;

            Init();
        }

        protected void Init()
        {
            _selectedSprite = new Sprite("commonmenu", "gradient_nav", new Size(431, 38), new Point(0, 0), HighlightColor);
            _rectangle = new UIResRectangle(new Point(0, 0), new Size(431, 38), Color.FromArgb(150, 0, 0, 0));
            _text = new UIResText(Text, new Point(8, 0), 0.33f, Color.WhiteSmoke, GTA.UI.Font.ChaletLondon, Alignment.Left);
            Description = Description;

            _badgeLeft = new Sprite("commonmenu", "", new Size(40, 40), new Point(0, 0));
            _badgeRight = new Sprite("commonmenu", "", new Size(40, 40), new Point(0, 0));

            _labelText = new UIResText("", new Point(0, 0), 0.35f) { Alignment = Alignment.Right };
        }
        
        
        public override void Draw()
        {
            _rectangle.Size = new Size(431 + Parent.WidthOffset, 38);
            _selectedSprite.Size = new Size(431 + Parent.WidthOffset, 38);

            if (Hovered && !Selected)
            {
                _rectangle.Color = Color.FromArgb(20, 255, 255, 255);
                _rectangle.Draw();
            }
            if (Selected)
            {
                _selectedSprite.Color = HighlightColor;
                _selectedSprite.Draw();
            }
            else
            {
                _selectedSprite.Color = MainColor;
                _selectedSprite.Draw();
            }

            _text.Color = Enabled ? Selected ? HighlightedTextColor : TextColor : Color.FromArgb(163, 159, 148);

            if (LeftBadge != BadgeStyle.None)
            {
                _text.Position = new PointF(35 + Offset.X, _text.Position.Y);
                // TODO _badgeLeft.TextureDict = BadgeToSpriteLib(LeftBadge);
                // TODO _badgeLeft.TextureName = BadgeToSpriteName(LeftBadge, Selected);
                _badgeLeft.Color = BadgeToColor(LeftBadge, Selected);
                _badgeLeft.Draw();
            }
            else
            {
                _text.Position = new PointF(8 + Offset.X, _text.Position.Y);
            }

            if (RightBadge != BadgeStyle.None)
            {
                _badgeRight.Position = new PointF(385 + Offset.X + Parent.WidthOffset, _badgeRight.Position.Y);
                // TODO _badgeRight.TextureDict = BadgeToSpriteLib(RightBadge);
                // TODO _badgeRight.TextureName = BadgeToSpriteName(RightBadge, Selected);
                _badgeRight.Color = BadgeToColor(RightBadge, Selected);
                _badgeRight.Draw();
            }

            if (!string.IsNullOrWhiteSpace(RightLabel))
            {
                _labelText.Position = new PointF(420 + Offset.X + Parent.WidthOffset, _labelText.Position.Y);
                _labelText.Caption = RightLabel;
                _labelText.Color = _text.Color = Enabled ? Selected ? HighlightedTextColor : TextColor : Color.FromArgb(163, 159, 148);
                _labelText.Draw();
            }
            _text.Draw();
        }
    }
}