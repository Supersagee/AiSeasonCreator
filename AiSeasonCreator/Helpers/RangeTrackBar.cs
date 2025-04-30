using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AiSeasonCreator.Helpers
{
    public class RangeTrackBar : Control
    {
        [Category("Behavior")]
        public int Minimum { get; set; } = 0;
        [Category("Behavior")]
        public int Maximum { get; set; } = 100;
        private int _lowerValue = 0;
        [Category("Behavior")]
        public int LowerValue
        {
            get => _lowerValue;
            set
            {
                _lowerValue = Math.Min(Math.Max(value, Minimum), UpperValue);
                Invalidate();
                RangeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private int _upperValue = 100;
        [Category("Behavior")]
        public int UpperValue
        {
            get => _upperValue;
            set
            {
                _upperValue = Math.Max(Math.Min(value, Maximum), LowerValue);
                Invalidate();
                RangeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool _hoveringLower, _hoveringUpper;
        private const int BarThickness = 6;
        private const int ThumbWidth = 8;
        private const int ThumbHeight = 24;
        [Category("Appearance")]
        public Color ThumbHoverColor { get; set; } = Color.LightGray;
        [Category("Appearance")]
        public Color TrackColor { get; set; } = Color.LightGray;
        [Category("Appearance")]
        public Color RangeColor { get; set; } = Color.SkyBlue;
        [Category("Appearance")]
        public Color ThumbColor { get; set; } = Color.DodgerBlue;

        public event EventHandler RangeChanged;

        // internal state
        private const int ThumbSize = 10;
        private bool _draggingLower, _draggingUpper;

        public RangeTrackBar()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
            Height = 30;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int usableWidth = Width - ThumbWidth;
            float pct = usableWidth / (float)(Maximum - Minimum);
            int xLo = (int)Math.Round((LowerValue - Minimum) * pct);
            int xHi = (int)Math.Round((UpperValue - Minimum) * pct);

            int trackY = Height / 2 - (BarThickness / 2);
            int trackCenterY = trackY + (BarThickness / 2);
            int thumbY = trackCenterY - (ThumbHeight / 2);

            using (var tb = new SolidBrush(TrackColor))
                g.FillRectangle(tb, ThumbWidth / 2, trackY, usableWidth, BarThickness);

            using (var rb = new SolidBrush(RangeColor))
                g.FillRectangle(rb, ThumbWidth / 2 + xLo, trackY, xHi - xLo, BarThickness);

            var lowerThumb = new Rectangle(
                ThumbWidth / 2 + xLo - ThumbWidth / 2,
                thumbY,
                ThumbWidth, ThumbHeight);
            var upperThumb = new Rectangle(
                ThumbWidth / 2 + xHi - ThumbWidth / 2,
                thumbY,
                ThumbWidth, ThumbHeight);

            using (var brushL = new SolidBrush(_hoveringLower ? ThumbHoverColor : ThumbColor))
                g.FillRectangle(brushL, lowerThumb);
            using (var brushU = new SolidBrush(_hoveringUpper ? ThumbHoverColor : ThumbColor))
                g.FillRectangle(brushU, upperThumb);

            SetStyle(ControlStyles.SupportsTransparentBackColor |
             ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.ResizeRedraw, true);
            //BackColor = Color.Transparent;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var pct = (float)(Width - ThumbSize) / (Maximum - Minimum);
            var xLo = ThumbSize / 2 + (int)((LowerValue - Minimum) * pct);
            var xHi = ThumbSize / 2 + (int)((UpperValue - Minimum) * pct);

            if (Math.Abs(e.X - xLo) <= ThumbSize) _draggingLower = true;
            else if (Math.Abs(e.X - xHi) <= ThumbSize) _draggingUpper = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _draggingLower = _draggingUpper = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            UpdateHoverState(e.Location);

            if (!_draggingLower && !_draggingUpper) return;

            float pct = (float)(Width - ThumbSize) / (Maximum - Minimum);
            int val = (int)Math.Round((e.X - ThumbSize / 2) / pct) + Minimum;
            val = Math.Min(Math.Max(val, Minimum), Maximum);

            if (_draggingLower)
            {
                if (val <= UpperValue)
                {
                    LowerValue = val;
                }
                else
                {
                    UpperValue = val;
                    LowerValue = val;
                }
            }
            else if (_draggingUpper)
            {
                if (val >= LowerValue)
                {
                    UpperValue = val;
                }
                else
                {
                    LowerValue = val;
                    UpperValue = val;
                }
            }
        }

        private void UpdateHoverState(Point pt)
        {
            int usableWidth = Width - ThumbWidth;
            float pct = usableWidth / (float)(Maximum - Minimum);
            int xLo = (int)Math.Round((LowerValue - Minimum) * pct);
            int xHi = (int)Math.Round((UpperValue - Minimum) * pct);

            int trackY = Height / 2 - (BarThickness / 2);
            int trackCenter = trackY + (BarThickness / 2);
            int thumbY = trackCenter - (ThumbHeight / 2);

            var lowerRect = new Rectangle(
                ThumbWidth / 2 + xLo - ThumbWidth / 2,
                thumbY,
                ThumbWidth, ThumbHeight);
            var upperRect = new Rectangle(
                ThumbWidth / 2 + xHi - ThumbWidth / 2,
                thumbY,
                ThumbWidth, ThumbHeight);

            bool nowLower = lowerRect.Contains(pt);
            bool nowUpper = upperRect.Contains(pt);

            if (nowLower != _hoveringLower || nowUpper != _hoveringUpper)
            {
                _hoveringLower = nowLower;
                _hoveringUpper = nowUpper;
                Invalidate();
            }
        }

    }

}
