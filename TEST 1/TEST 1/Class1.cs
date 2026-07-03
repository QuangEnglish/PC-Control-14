
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class DenBaoTron : Control
{
    public bool TrangThai { get; set; } = false;   // false = OFF, true = ON

    public DenBaoTron()
    {
        this.Size = new Size(60, 60);
        this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        // Màu khi ON/OFF
        Color mauChinh = TrangThai ? Color.LimeGreen : Color.DarkRed;

        // Gradient cho hiệu ứng bóng
        using (LinearGradientBrush brush = new LinearGradientBrush(
            rect,
            Color.White,
            mauChinh,
            45f))
        {
            g.FillEllipse(brush, rect);
        }

        // Vẽ viền ngoài
        using (Pen pen = new Pen(Color.Black, 3))
        {
            g.DrawEllipse(pen, rect);
        }
    }

    public void Bat()
    {
        TrangThai = true;
        this.Invalidate();   // vẽ lại
    }

    public void Tat()
    {
        TrangThai = false;
        this.Invalidate();
    }
}