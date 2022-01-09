namespace CalcDelegate
{
    internal class Program
    {
        public delegate int MyDelegate(int a, int b);
        static void Main()
        {
            MyDelegate addDelegate = (a, b) => a + b;
            MyDelegate subDelegate = (a, b) => a - b;
            MyDelegate mulDelegate = (a, b) => a * b;
            MyDelegate divDelegate = (a, b) =>
            {
                if (b != 0)
                {
                    return a / b;
                }

                return 0;
            };

            addDelegate.Invoke(2, 3);
            subDelegate.Invoke(2, 3);
            mulDelegate.Invoke(2, 3);
            divDelegate.Invoke(2, 3);
        }
    }
}
