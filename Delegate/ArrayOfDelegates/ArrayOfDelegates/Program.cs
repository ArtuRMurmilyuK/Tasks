using System;

namespace ArrayOfDelegates
{
    internal class Program
    {
        delegate int MyDelegate();
        delegate double MyDel(MyDelegate[] a);

        static int GetRandom()
        {
            return new Random().Next(100);
        }

        static void Main(string[] args)
        {
            var array = new MyDelegate[3];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = () => new MyDelegate(GetRandom).Invoke();
            }

            MyDel del = delegate(MyDelegate[] c)
            {
                int sum = 0;
                for (int i = 0; i < c.Length; i++)
                {
                    sum += c[i].Invoke();
                }

                return sum / array.Length;
            };

            Console.WriteLine(del(array));
        }
    }
}
