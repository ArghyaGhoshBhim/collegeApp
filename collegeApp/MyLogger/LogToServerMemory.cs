﻿namespace collegeApp.MyLogger
{
    public class LogToServerMemory : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogTo Server Memory");
        }
    }
}
