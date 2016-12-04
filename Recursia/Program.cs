using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursia
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine("Factorial "+ n);
            Console.WriteLine(Factorial(n));

            Console.WriteLine("Find max");
            Console.WriteLine(FindMaxRecurs(int.MinValue, 0, new int[] { 1, 4, 3, 6, 7, 3 }));
            
            Console.WriteLine("Reverse array");
            int[] arr2 = Reverse(new int[] {1,2,3,4,5});
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i]+" ");
            }

            Console.WriteLine("\nMove zeroz");
            int[] arr3 = MoveZero(new int[] {1,0,0,0,6,5});
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write(arr3[i]+" ");
            }

            Console.WriteLine("\nSimple numbers");
            bool[] arr4 = Simple(31);
            for (int i = 0; i < arr4.Length; i++)
            {
                if (arr4[i] == true)
                {
                    Console.Write((i+1) + " ");
                }                
            }
        }

        public static int Factorial(int n) {
            if (n == 1)
            {
                return 1;
            }
            return n*Factorial(n-1);
        }

        public static int FindMax(params int [] arr) {
            int max = int.MinValue;

            if (arr.Length == 0)
            {
                return max;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public static int FindMaxRecurs(int max, int startIndex, params int[] arr)
        {
            if (startIndex >= arr.Length)
                return max;
            return FindMaxRecurs(max < arr[startIndex] ? arr[startIndex] : max, startIndex + 1, arr);
        }

        public static int [] Reverse(params int [] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length / 2; i++)
            {
                arr[i] = arr[i] + arr[length - i-1];
                arr[length - i-1] = arr[i] - arr[length - i-1];
                arr[i] = arr[i] - arr[length - i-1];
            }
            return arr;
        }

        public static int[] MoveZero(params int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }

            int[] arr2 = new int[arr.Length];
            int j = 0;   
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr2[j++] = arr[i];                    
                }
            }
            return arr2;
        }

        static bool[] Simple(int n)
        {
            bool[] arr = new bool[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = true;
            }            
            for (int i = 2; i * i - 1 < n; i++)
            {
                if (arr[i-1])
                {
                    for (int j = i * i - 1; j < n; j += i)
                    {
                        arr[j] = false;
                    }                        
                }                   
            }
            return arr;
        }
    }
}
