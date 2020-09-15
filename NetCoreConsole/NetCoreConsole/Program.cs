using NetCoreConsole.LabShop;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                TryQueue();
                // TryException(true).Wait();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void TryQueue()
        {
            OneThreadQueue queue = new OneThreadQueue();

            for (int i = 0; i < 100; i++)
            {
                var delay = new Random(DateTime.Now.Millisecond%100).Next(150);
                Task.Delay(delay*10).Wait();
                queue.AddItem($"#{i+1} : current delay{delay}");
            }
        }

        public static async Task<string> TryException(bool flag)
        {
            string s1 = "some new line 1";
            string s2 = "Some new line 2";

            await Task.Delay(1000);
            if (flag)
            {
                throw new Exception("Exception inside occurs.");
            }


            string result = s1 + s2;
            return result;
        }
    }
}
