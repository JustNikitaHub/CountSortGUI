namespace CountSort;

using CountSort.SortAlgorithm;
using CountSort.Service;
using System.Diagnostics;

public partial class FormDemo : Form
{
    CheckBox? ckbSmooth;
    PictureBox? pctGraph;
    Button? btnStart;
    NumericUpDown? npdStep;
    NumericUpDown? npdRounds;
    NumericUpDown? npdMaxValue;
    NumericUpDown? npdMinValue;
    Label? lblStep;
    Label? lblRounds;
    Label? lblMaxValue;
    Label? lblMinValue;
    public FormDemo()
    {
        InitializeComponent();
        Size = new(800, 600);
        InitializeMyControls();
        Text = "Функция сложности";
    }
    public void InitializeMyControls()
    {
        int borderOffset = 10;  //расстояние между элементами рядом
        //Инициализация
        npdRounds = new()
        {
            Minimum = 5,
            Maximum = 100,
            AutoSize = true,
            Value = 10,
        };
        npdStep = new()
        {
            Minimum = 10,
            Maximum = 10000,
            AutoSize = true,
            Value = 1000,
        };
        npdMaxValue = new()
        {
            Minimum = 0,
            Maximum = 10000,
            AutoSize = true,
            Value = 100
        };
        npdMinValue = new()
        {
            Minimum = 0,
            Maximum = 1000,
            AutoSize = true,
            Value = 0,
        };
        btnStart = new()
        {
            Text = "Начать построение",
            AutoSize = true,
        };
        pctGraph = new()
        {
            Size = new(400, 400),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.White,
        };
        lblStep = new()
        {
            Text = "Шаг",
            AutoSize = true,
        };
        lblRounds = new()
        {
            Text = "Повторы",
            AutoSize = true,
        };
        lblMinValue = new()
        {
            Text = "Минимум",
            AutoSize = true,
        };
        lblMaxValue = new()
        {
            Text = "Максимум",
            AutoSize = true,
        };
        ckbSmooth = new()
        {
            Checked = true,
            Text = "Применить расчет размаха для сглаживания",
            AutoSize = true,
        };
        btnStart.Location = new(20, Height - btnStart.Height * 5);
        npdStep.Location = new(btnStart.Location.X, btnStart.Location.Y - npdStep.Height - borderOffset);
        npdRounds.Location = new(npdStep.Location.X + npdRounds.Width + borderOffset, npdStep.Location.Y);
        npdMaxValue.Location = new(npdRounds.Location.X + npdMaxValue.Width + borderOffset, npdRounds.Location.Y);
        npdMinValue.Location = new(npdMaxValue.Location.X + npdMinValue.Width + borderOffset, npdMaxValue.Location.Y);
        lblStep.Location = new(npdStep.Location.X, npdStep.Location.Y - lblStep.Height - borderOffset);
        lblRounds.Location = new(npdRounds.Location.X, npdRounds.Location.Y - lblRounds.Height - borderOffset);
        lblMaxValue.Location = new(npdMaxValue.Location.X, npdMaxValue.Location.Y - lblMaxValue.Height - borderOffset);
        lblMinValue.Location = new(npdMinValue.Location.X, npdMinValue.Location.Y - lblMinValue.Height - borderOffset);
        ckbSmooth.Location = new(btnStart.Location.X + btnStart.Width + ckbSmooth.Width + borderOffset, btnStart.Location.Y+borderOffset);
        pctGraph.Location = new(pctGraph.Width/2, borderOffset);
        Controls.AddRange(npdStep, npdRounds, npdMaxValue, npdMinValue, btnStart, pctGraph, lblStep, lblRounds, lblMinValue, lblMaxValue, ckbSmooth);

        btnStart.Click += (o, e) =>
        {
            Bitmap bmp = new Bitmap(pctGraph.Width, pctGraph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                GraphController graph = new(g, pctGraph);
                graph.DrawSpace();
                pctGraph.Image = bmp;
            }

            List<PointF> points = new();
            DataGenerator generator = new();
            CountingSort sort = new();
            Stopwatch sw = new();
            int step = (int)npdStep.Value;
            int rounds = (int)npdRounds.Value;
            int min = (int)npdMinValue.Value;
            int max = (int)npdMaxValue.Value;

            for (int r = 0; r < rounds; r++)
            {
                int curSize = step * (r + 1);
                int[] toSort = generator.GenerateData(curSize, min, max);
                sw.Restart();
                sort.Sort(toSort);
                sw.Stop();
                points.Add(new PointF(curSize, (float)sw.Elapsed.TotalSeconds)); //X-размер, Y-время
            }
            float maxX = points.Max(p => p.X);  //максимальный размер массива
            float maxY = points.Max(p => p.Y);  //максимальное время
            PointF[] scaledPoints = points.Select(p =>
    new PointF(
        (p.X / maxX) * pctGraph.Width,
        pctGraph.Height - (p.Y / maxY) * pctGraph.Height
    )).ToArray();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                GraphController graph = new(g, pctGraph);
                if (ckbSmooth.Checked)
                {
                    RangeCalc calc = new();
                    PointF[] ranged = calc.Rangify(scaledPoints);
                    graph.DrawGraph(ranged);
                }
                else
                {
                    graph.DrawGraph(scaledPoints);
                }
                pctGraph.Image = bmp;
            }
        };
        
    }
}