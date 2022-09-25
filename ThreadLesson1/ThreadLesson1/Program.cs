using System;
using System.Threading;

namespace ThreadLesson1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Для запуска нажмите любую кнопку");
            Console.ReadKey();

            ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(new Action<object>(StarWriter));
            threadPoolWorker.Start('*');

            for(int i = 0; i < 40; i++)
            {
                Console.Write('-');
                Thread.Sleep(50);
            }

            threadPoolWorker.Wait();

            Console.WriteLine("Метод Main закончил свою работу");
        }

        private static void StarWriter(object arg)
        {
            char item = (char)arg;

            for(int i = 0; i < 120; i++)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }
    }
    
    public class ThreadPoolWorker
    {
        private readonly Action<object> _action;

        public ThreadPoolWorker(Action<object> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public bool IsCompleted { get; private set; } = false;
        public bool IsSuccess { get; private set; } = false;
        public bool IsFaulted { get;private set; } = false;
        public Exception Exception { get; private set; } = null;

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        public void Wait()
        {
            while(IsCompleted == false)
            {
                Thread.Sleep(150);
            }

            if(Exception != null)
            {
                throw Exception;
            }
        }

        private void ThreadExecution(object state)
        {
            try
            {
                _action.Invoke(state);
                IsSuccess = true;
            }
            catch(Exception ex)
            {
                Exception = ex;
                IsSuccess = false;
                IsFaulted = true;
            }
            finally
            {
                IsCompleted = true;
            }
        }
    }
}
