namespace CountSort.Service
{
    public class RangeCalc
    {
        public PointF[] Rangify(PointF[] toRangify, float calcErrorTolerance = 1.5f)
        {
            if (toRangify.Length <= 3) return toRangify;
            List<PointF> answer = new();
            for (int i = 1; i < toRangify.Length - 1; i++)
            {
                float prevP = toRangify[i - 1].Y;
                float cur = toRangify[i].Y;
                float nextP = toRangify[i + 1].Y;

                float medium = (prevP + nextP) / 2;
                float range = Math.Abs(nextP - prevP) * calcErrorTolerance;
                if (Math.Abs(cur - medium) > range) answer.Add(new PointF(toRangify[i].X, medium));
                else answer.Add(toRangify[i]);
            }
            answer.Add(toRangify[^1]);
            return answer.ToArray();
        }
    }
}