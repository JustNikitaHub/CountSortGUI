namespace CountSort.SortAlgorithm
{
    /// <summary>
    /// Алгоритм сортировки подсчетом
    /// </summary>
    public class CountingSort : ISortAlgorithm
    {
        public string Name { get; init; } = "";

        /// <summary>
        /// Получает на вход массив чисел, сортирует и возвращает новый
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public int[] Sort(int[] arr)
        {
            int N = arr.Length;
            int[] count = new int[arr.Max()+1];                     //Создание пустого массива
            for (int i = 0; i < count.Length; i++) count[i] = 0;    //Заполнение его нулями
            for (int i = 0; i < N; i++) count[arr[i]]++;            //Считаем кол-во вхождений чисел
            for(int i=1; i< count.Length; i++)                      //Считаем префикс суммы по массиву
                count[i]=count[i-1]+count[i];

            int[] answer = new int[N];                              //Начинаем с конца, так sort будет стабильным
            for (int i = N-1; i >= 0; i--)
            {
                answer[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;     
            }
            return answer;
        }
    }
}