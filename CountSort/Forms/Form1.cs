namespace CountSort;
using CountSort.SortAlgorithm;
using CountSort.Service;

public partial class Form1 : Form
{
    Button? btnCalculate;
    Button? btnDemo;
    NumericUpDown? npdListSize;
    NumericUpDown? npdMaxValue;
    NumericUpDown? npdMinValue;
    TextBox? txtArrShow;
    TextBox? txtArrSorted;
    Label? lblArrShow;
    Label? lblArrSorted;
    Label? lblMin;
    Label? lblMax;
    Label? lblSize;
    Label? lblInfo;
    public Form1()
    {
        InitializeComponent();
        InitializeMyControls();
        Text = "Сортировка подсчетом";
    }

    public void InitializeMyControls()
    {
        int borderOffset = 10;  //расстояние между элементами рядом
        //Инициализация
        btnCalculate = new()
        {
            Text = "Запуск",
            Location = new(25, 400),
            AutoSize = true,
        };
        btnDemo = new()
        {
            Text = "Режим демонстрации",
            Location = new(570,400),
            AutoSize = true,
        };
        npdListSize = new()
        {
            Minimum = 2,
            Maximum = 50000,
            AutoSize = true,
            Value = 100,
        };
        npdMinValue = new()
        {
            Minimum = 0,
            Maximum = 1000,
            AutoSize = true,
            Value = 0,
        };
        npdMaxValue = new()
        {
            Minimum = 0,
            Maximum = 10000,
            AutoSize = true,
            Value = 100
        };
        txtArrShow = new()
        {
            Text = "Здесь будет созданный массив для сортировки",
            ReadOnly = true,
            Multiline = true,
            Size = new(350, 160),
            Visible = true,
            ScrollBars = ScrollBars.Vertical
        };
        txtArrSorted = new()
        {
            Text = "Здесь будут отсортированные данные",
            ReadOnly = true,
            Multiline = true,
            Size = new(350, 160),
            Visible = true,
            ScrollBars = ScrollBars.Vertical
        };
        lblArrShow = new()
        {
            Text = "Исходный массив",
            AutoSize = true,
        };
        lblArrSorted = new()
        {
            Text = "Отсортированный массив",
            AutoSize = true,
        };
        lblMax = new()
        {
            Text = "Максимум",
            AutoSize = true,
        };
        lblMin = new()
        {
            Text = "Минимум",
            AutoSize = true
        };
        lblSize = new()
        {
            Text = "Размер",
            AutoSize = true
        };
        lblInfo = new()
        {
            Text = "Сортировка подсчетом:\nСложность во всех случаях: O(N+M)\n    N - размер начального массива\n    M - размер вспомогательного массива",
            AutoSize = true,
        };
        //Настройка
        npdListSize.Location = new(btnCalculate.Location.X, btnCalculate.Location.Y - npdListSize.Height-borderOffset);
        npdMinValue.Location = new(npdListSize.Location.X+npdListSize.Width+borderOffset,npdListSize.Location.Y);
        npdMaxValue.Location = new(npdMinValue.Location.X+npdMaxValue.Width+borderOffset,npdMinValue.Location.Y);
        lblSize.Location = new(npdListSize.Location.X, npdListSize.Location.Y-lblSize.Height-borderOffset);
        lblMin.Location = new(npdMinValue.Location.X, npdMinValue.Location.Y-lblMin.Height-borderOffset);
        lblMax.Location = new(npdMaxValue.Location.X, npdMaxValue.Location.Y-lblMax.Height-borderOffset);
        txtArrShow.Location = new(npdListSize.Location.X, npdListSize.Location.Y-txtArrShow.Height-borderOffset-npdListSize.Height);
        txtArrSorted.Location = new(txtArrShow.Location.X+txtArrSorted.Width+borderOffset, txtArrShow.Location.Y);
        lblArrShow.Location = new(txtArrShow.Location.X, txtArrShow.Location.Y-lblArrShow.Height-borderOffset);
        lblArrSorted.Location = new(txtArrSorted.Location.X, txtArrSorted.Location.Y-lblArrSorted.Height-borderOffset);
        Controls.AddRange(btnDemo, btnCalculate, npdListSize, npdMinValue, npdMaxValue, txtArrShow, txtArrSorted, lblArrShow, lblArrSorted, lblSize, lblMin, lblMax, lblInfo);
        //Запуск сортировки
        btnCalculate.Click += (o, e) =>
        {
            CountingSort sort = new();
            DataGenerator generator = new();
            int size = (int)npdListSize.Value;
            int min = (int)npdMinValue.Value;
            int max = (int)npdMaxValue.Value;
            if(min>=max) max=min+2;
            int[] toSort = generator.GenerateData(size, min, max);
            txtArrShow.Text = string.Join(" ", toSort);
            int[] sorted = sort.Sort(toSort);
            txtArrSorted.Text = string.Join(" ", sorted);
        };
        //Переход к отрисовке графика
        btnDemo.Click += (o, e) =>
        {
            FormDemo demodemo = new FormDemo();
            demodemo.ShowDialog();
        };
    }
}
