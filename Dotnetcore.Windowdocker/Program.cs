using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnetcore.Windowdocker
{
    class Program
    {
       static AutoResetEvent _closing = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new ProcessWithoutBranchStatement()
                .Process(ProcessWithoutBranchStatement.ProcessStatus.Open, new { CreatedDate = DateTime.Now });

            while (true)
            {
                Console.WriteLine("Enter 'quit' to terminate console");
                var cmd = Console.ReadLine();

                if ((cmd ?? string.Empty).Equals("quit"))
                {
                    return;
                }
            }

            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();
        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            _closing.Set();
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

        static ConcurrentDictionary<ProcessStatus, Action<object>> _map = new ConcurrentDictionary<ProcessStatus, Action<object>>();

        static ProcessWithoutBranchStatement()
        {
            _map[ProcessStatus.Open] = HandleOpen;
            _map[ProcessStatus.Begin] = HandleBegin;
            _map[ProcessStatus.Pause] = HandlePause;
        }

        private static void HandlePause(object data)
        {
            var status = ProcessStatus.Pause;

            Console.WriteLine($"Processing status: {status}");
            if (data != null)
                Console.WriteLine(JsonConvert.SerializeObject(data));
        }

        private static void HandleBegin(object data)
        {
            var status = ProcessStatus.Begin;

            Console.WriteLine($"Processing status: {status}");
            if (data != null)
                Console.WriteLine(JsonConvert.SerializeObject(data));
        }

        private static void HandleOpen(object data)
        {
            var status = ProcessStatus.Open;

            Console.WriteLine($"Processing status: {status}");
            if (data != null)
                Console.WriteLine(JsonConvert.SerializeObject(data));
        }


        public void Process(ProcessStatus status, object data)
        {
            Action<object> a = null;

            if (_map.TryGetValue(status, out a) && a != null)
            {
                a(data);
            }
            else
            {
                throw new NotImplementedException($"{status} have no handle medthod");
            }

            //switch (status)
            //{
            //    case ProcessStatus.Open:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Begin:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Pause:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Resume:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Abort:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Published:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    case ProcessStatus.Try3Times:
            //        Console.WriteLine($"Processing status: {status}");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //    default:
            //        Console.WriteLine($"Default");
            //        if (data != null)
            //            Console.WriteLine(JsonConvert.SerializeObject(data));
            //        break;
            //}
        }
    }
}
