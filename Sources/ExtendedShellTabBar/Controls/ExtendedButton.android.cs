using System;
using System.Drawing;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using static Android.Graphics.Paint;
using static Android.Graphics.PorterDuff;
using Color = Android.Graphics.Color;

namespace ExtendedShellTabBar.Controls.Droid
{
    public class ExtendedButton : Button
    {
        public Android.Graphics.Color BorderColor { get; set; }
        public int BorderThickness { get; set; }
        public float CornerRadius { get; set; }

        public ExtendedButton(Context context) : base(context)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {

            if (CornerRadius > 0)
            {
                Rect rc = new Rect();
                GetDrawingRect(rc);

                Rect interior = rc;
                interior.Inset((int)BorderThickness, (int)BorderThickness);

                Paint p = new Paint()
                {
                    Color = Color.Transparent,
                    AntiAlias = true,
                };

                canvas.DrawRoundRect(new RectF(interior), (float)CornerRadius, (float)CornerRadius, p);

                p.Color = BorderColor;
                p.StrokeWidth = (float)BorderThickness;
                p.SetStyle(Style.Stroke);

                canvas.DrawRoundRect(new RectF(rc), (float)CornerRadius, (float)CornerRadius, p);

                canvas.ClipRect(interior);
            }
            else
            {
                base.OnDraw(canvas);
            }
        }
    }
}
