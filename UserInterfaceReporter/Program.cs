namespace UserInterfaceReporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var manager = new RunManager())
            {
                manager.Run();
            }
        }
    }
}
