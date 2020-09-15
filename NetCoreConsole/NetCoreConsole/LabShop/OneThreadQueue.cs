using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreConsole.LabShop
{
    public class OneThreadQueue
    {
        public ConcurrentQueue<string> CurrentQueue = new ConcurrentQueue<string>();

        public OneThreadQueue()
        {
            StartProcess();
        }

        public void AddItem(string item)
        {
            CurrentQueue.Enqueue(item);
        }

        public void StartProcess()
        {
            Task.Factory.StartNew(HandleQueue);
        }

        public void HandleQueue()
        {
            while (true)
            {
                string currentItem = string.Empty;
                if (CurrentQueue.TryDequeue(out currentItem))
                {
                    Console.WriteLine("Processing");
                    Task.Delay(1000).Wait();
                    Console.WriteLine(currentItem);
                }

                Console.WriteLine("Starting wait empty!!");
                Task.Delay(200).Wait();
            }
        }

    }
}
