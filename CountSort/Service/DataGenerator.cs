namespace CountSort.Service
{
    public class DataGenerator
    {
        public int[] GenerateData(int size, int min, int max)
        {
            Random rnd = new();
            int[] generatedArr = new int[size];
            for (int i = 0; i < size; i++) generatedArr[i] = rnd.Next(min, max);
            return generatedArr;
        }
        public void FillData(int[] toFill, int min, int max)
        {
            Random rnd = new();
            for (int i = 0; i<toFill.Length; i++) toFill[i]=rnd.Next(min, max);
        }
    }
}