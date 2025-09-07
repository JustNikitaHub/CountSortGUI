namespace CountSort.SortAlgorithm
{
    /// <summary>
    /// Интерфейс для всех алгоритмов
    /// </summary>
    public interface ISortAlgorithm
    {
        string Name { get; init; }
        int[] Sort(int[] arr);
    }
}