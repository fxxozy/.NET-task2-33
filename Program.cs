using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input fileName: ");
            string fileName = Console.ReadLine();
            List<int> list = ReadDataFromFile(fileName);

            list.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();

            Console.WriteLine("Input indexes of the elements whose values you want see: ");
            int[] array = readArray();
            showResult(fileName, list, array);
        }

        private static List<int> ReadDataFromFile(string fileName)
        {
            List<int> list = new List<int>();
            try
            {
                string path = "D:/Users/Public/C#/task2/inputFiles/" + fileName;
                using (StreamReader streamReader = new StreamReader(path, System.Text.Encoding.Default))
                {
                    char[] separator = {',', ' '};
                    string[] strings = streamReader.ReadLine().Split(separator);
                    for (int i = 0; i < strings.Length; i++)
                    {
                        list.Add(int.Parse(strings[i]));
                    }
                    streamReader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File {0} is not found!", fileName);
                Environment.Exit(0);
            }
            return list;
        }

        private static int GetInt(string fileName, int k)
        {
            List<int> list = null;
            try
            {
                list = ReadDataFromFile(fileName);
                return list[k];
            }
            catch (Exception e)
            {
                Console.WriteLine("Element with index {0} is not found!", k);
            }
            return 0;
        }

        private static void showResult(string fileName, List<int> list, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element with index {0} is {1}\n", array[i], GetInt(fileName, array[i]));
            }
        }

        private static int[] readArray()
        {
            string[] arr = Console.ReadLine().Split(' ', ',');
            int[] array = new int[arr.GetLength(0)];

            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = int.Parse(arr[i]);
            }
            return array;
        }

        private static void printArray(int[] array)
        {
            foreach (int e in array)
            {
                Console.Write(e + " ");
            }
        }

    }
}