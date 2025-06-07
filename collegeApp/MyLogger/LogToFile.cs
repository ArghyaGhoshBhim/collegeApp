namespace collegeApp.MyLogger
{
    public class LogToFile : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogTo File");
        }
    }
}
