using System;

namespace JaggedArray
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Please input number of lines");
            int number_of_lines = Convert.ToInt32(Console.In.ReadLine());

            int[][] work_arr = new int[number_of_lines][];
            init_arr(number_of_lines, work_arr);
            input_array(number_of_lines, work_arr);

            sortType ST = sortType.bySumOfValuesOfLine;
            Console.Out.WriteLine("Your standard array:");
            show_array(number_of_lines, work_arr);

            Arr.sorting(work_arr, number_of_lines, true, ST);
            Console.Out.WriteLine("Array is sorted by sum of values of line:");
            show_array(number_of_lines, work_arr);

            ST = sortType.byMinValueOfLine;
            Arr.sorting(work_arr, number_of_lines, true, ST);
            Console.Out.WriteLine("Array is sorted by min value of line:");
            show_array(number_of_lines, work_arr);

            ST = sortType.byMaxValueOfLine;
            Arr.sorting(work_arr, number_of_lines, true, ST);
            Console.Out.WriteLine("Array is sorted by max value of line:");
            show_array(number_of_lines, work_arr);

            Console.Out.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void init_arr(int n, int[][] work_arr)
        {
            int a;
            Console.Out.WriteLine("Please input dimension of first line");
            for (int i = 0; i < n; i++)
            {
                a = Convert.ToInt32(Console.In.ReadLine());
                work_arr[i] = new int[a];
                if (i == n - 1)
                    break;
                Console.Out.WriteLine("Please input dimension of next line");
            }
        }

        static void input_array(int n, int[][] work_arr)
        {
            Random rand_value;
            int max_scd_dimension = 0;
            for (int i = 0; i < n; i++)
            {
                max_scd_dimension = work_arr[i].Length;
                for (int j = 0; j < max_scd_dimension; j++)
                {
                    rand_value = new Random(DateTime.Now.Millisecond);
                    work_arr[i][j] = rand_value.Next(0, 25);
                    System.Threading.Thread.Sleep(50);
                }

            }

        }

        static void show_array(int n, int[][] work_arr)
        {
            int max_scd_dimension = 0;
            for (int i = 0; i < n; i++)
            {
                max_scd_dimension = work_arr[i].Length;
                for (int j = 0; j < max_scd_dimension; j++)
                {
                    Console.Out.Write(work_arr[i][j] + " ");
                }
                Console.Out.WriteLine("");
            }
            Console.Out.WriteLine("");
            Console.Out.WriteLine("");
        }
    }
}
