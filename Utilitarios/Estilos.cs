using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ButtonRounded : Button
{
    public int RaioBorda = 20;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
        using (GraphicsPath path = CriarBordaArredondada(bounds, RaioBorda))
        {
            this.Region = new Region(path);

            using (Pen pen = new Pen(this.FlatAppearance.BorderColor, 1))
            {
                g.DrawPath(pen, path);
            }
        }
    }

    private GraphicsPath CriarBordaArredondada(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        int diam = radius * 2;

        
        path.AddArc(bounds.X, bounds.Y, diam, diam, 180, 90);

        
        path.AddLine(bounds.X + radius, bounds.Y, bounds.Right - radius, bounds.Y);

        
        path.AddArc(bounds.Right - diam, bounds.Y, diam, diam, 270, 90);

        
        path.AddLine(bounds.Right, bounds.Y + radius, bounds.Right, bounds.Bottom - radius);

        
        path.AddArc(bounds.Right - diam, bounds.Bottom - diam, diam, diam, 0, 90);

        
        path.AddLine(bounds.Right - radius, bounds.Bottom, bounds.X + radius, bounds.Bottom);

        
        path.AddArc(bounds.X, bounds.Bottom - diam, diam, diam, 90, 90);

        
        path.AddLine(bounds.X, bounds.Bottom - radius, bounds.X, bounds.Y + radius);

        path.CloseFigure();
        return path;
    }
}
