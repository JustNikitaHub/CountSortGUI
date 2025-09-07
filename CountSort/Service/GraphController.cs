using System.Drawing.Drawing2D;

namespace CountSort.Service
{
    public class GraphController
    {
        private Graphics g;
        private PictureBox pic;
        public void DrawSpace()
        {
            using (Pen pen = new Pen(Color.Black, 4))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(pen, 0, 0, 0, pic.Height-3); //Ось Y
                g.DrawLine(pen, 0, pic.Height-3, pic.Width, pic.Height-3);  //Ось X
            }
        }
        public void DrawGraph(PointF[] scaledPoints)
        {
            g.Clear(Color.White);
            DrawSpace();
            // Рисуем график
            if (scaledPoints.Length > 1)
            {
                using (Pen graphPen = new Pen(Color.Blue, 2))
                {
                    g.DrawLines(graphPen, scaledPoints);
                }
                
                // Рисуем точки
                using (Brush pointBrush = new SolidBrush(Color.Red))
                {
                    foreach (var point in scaledPoints)
                    {
                        g.FillEllipse(pointBrush, point.X - 3, point.Y - 3, 6, 6);
                    }
                }
            }
        }
        public GraphController(Graphics G, PictureBox P)
        {
            g = G;
            pic = P;
        }
    }
}