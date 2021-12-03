using System;

namespace DictionaryApp
{
    internal class Program
    {
        static void Main()
        {
            MyDictionary<int, string> dictionary = new MyDictionary<int, string>();

            dictionary.Add(1, "Odessa");
            dictionary.Add(2, "Kiev");
            dictionary.Add(3, "Some");

            dictionary.ShowAll();

            dictionary.ShowForIndex(1);
        }
    }

    public class MyDictionary<T, K>
    {
        private T[] _arrayT;
        private  K[] _arrayK;

        public MyDictionary()
        {
            _arrayT = Array.Empty<T>();
            _arrayK = Array.Empty<K>();
        }

        public void Clear()
        {
            _arrayT = Array.Empty<T>();
            _arrayK = Array.Empty<K>();
        }

        public void Add(T tValue, K kValue)
        {
            T[] saveTArray = new T[_arrayT.Length + 1];
            K[] saveKArray = new K[_arrayK.Length + 1];

            for (int i = 0; i < saveTArray.Length; i++)
            {
                if (i < _arrayT.Length)
                {
                    saveTArray[i] = _arrayT[i];
                    saveKArray[i] = _arrayK[i];
                }
                else
                {
                    saveTArray[i] = tValue;
                    saveKArray[i] = kValue;
                }
            }

            _arrayT = saveTArray;
            _arrayK = saveKArray;
        }

        public void ShowAll()
        {
            for (int i = 0; i < _arrayT.Length; i++)
            {
                Console.WriteLine($"{_arrayT[i]} - {_arrayK[i]}");
            }
        }

        public void ShowForIndex(int index)
        {
            Console.WriteLine($"{_arrayT[index]} - {_arrayK[index]}");
        }
    }
}
