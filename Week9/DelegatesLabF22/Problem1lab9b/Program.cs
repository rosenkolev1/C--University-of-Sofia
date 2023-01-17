namespace Problem1lab9b
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var subjectEN = new Subject(new int[] { 100, 75 }, "English");
            var subjectCS = new Subject(new int[] { 66, 88 , 80}, "CS");
            var subjectMath = new Subject(new int[] { 60, 68, 80 , 90}, "Math");

            var list = new List<Subject>() { subjectCS, subjectEN, subjectMath};
            var report = new StudentCardReport(list);
            report.Passing += CardReportHandler!;
            report.ProcessReport();

        }

        public static void CardReportHandler(Object o, EventArgs subject)
        {
            Console.WriteLine($"Passed: {subject}");
        }
    }
}