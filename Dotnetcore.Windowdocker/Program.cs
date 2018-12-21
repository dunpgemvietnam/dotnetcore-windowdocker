using Newtonsoft.Json;
using System;

namespace Dotnetcore.Windowdocker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new ProcessWithoutBranchStatement()
                .Process(ProcessWithoutBranchStatement.ProcessStatus.Open, new { CreatedDate = DateTime.Now });

            while (true)
            {
                Console.WriteLine("Enter 'quit' to terminate console");
                var cmd = Console.ReadLine();

                if (cmd.Equals("quit")) return;
            }
        }
    }

    public class ProcessWithoutBranchStatement
    {
        public enum ProcessStatus
        {
            Open,
            Begin,
            Pause,
            Resume,
            Abort,
            Published,
            Deleted,
            Try3Times
        }

        public void Process(ProcessStatus status, object data)
        {
            switch (status)
            {
                case ProcessStatus.Open:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Begin:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Pause:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Resume:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Abort:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Published:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                case ProcessStatus.Try3Times:
                    Console.WriteLine($"Processing status: {status}");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
                default:
                    Console.WriteLine($"Default");
                    if (data != null)
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                    break;
            }
        }
    }
}
