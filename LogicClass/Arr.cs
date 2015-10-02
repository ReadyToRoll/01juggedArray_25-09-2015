using System;

namespace JaggedArray
{
    public enum sortType { byMaxValueOfLine, byMinValueOfLine, bySumOfValuesOfLine };
    public static class Arr
    {
        public static void sorting(int[][] work_arr, int n, bool ascending, sortType ST)
        {
            int max_dimension_1 = 0;
            int max_dimension_2 = 0;
            int first_value = 0, second_value = 0;
            for (int k = 0; k < n; k++)
                for (int i = n - 1; i > 0; i--)
                {
                    max_dimension_1 = work_arr[i].Length;
                    max_dimension_2 = work_arr[i - 1].Length;
                    switch (ST)
                    {
                        case sortType.byMaxValueOfLine:
                            {
                                if (ascending)
                                {
                                    if (max_value_in_array(work_arr[i]) > max_value_in_array(work_arr[i - 1]))
                                        swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                }
                                else if (max_value_in_array(work_arr[i]) < max_value_in_array(work_arr[i - 1]))
                                    swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                break;
                            }
                        case sortType.byMinValueOfLine:
                            {
                                if (ascending)
                                {
                                    if (min_value_in_array(work_arr[i]) > min_value_in_array(work_arr[i - 1]))
                                        swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                }
                                else if (min_value_in_array(work_arr[i]) < min_value_in_array(work_arr[i - 1]))
                                    swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                break;
                            }
                        case sortType.bySumOfValuesOfLine:
                            {
                                for (int j = 0; j < max_dimension_1; j++)
                                    first_value += work_arr[i][j];
                                for (int j = 0; j < max_dimension_2; j++)
                                    second_value += work_arr[i - 1][j];
                                if (ascending)
                                {
                                    if (second_value < first_value)
                                        swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                }
                                else if (second_value > first_value)
                                    swap_lines(work_arr, max_dimension_1, max_dimension_2, i);
                                first_value = 0;
                                second_value = 0;
                                break;
                            }
                    }

                }
        }

        public static void swap_lines(int[][] work_arr, int max_dimension_1, int max_dimension_2, int i)
        {
            int temporary_dimension;
            int[] first_mass = new int[1];
            int[] second_mass = new int[1];
            Array.Resize(ref first_mass, max_dimension_1);
            Array.Resize(ref second_mass, max_dimension_2);
            for (int j = 0; j < max_dimension_1; j++)
                first_mass[j] = work_arr[i][j];
            for (int j = 0; j < max_dimension_2; j++)
                second_mass[j] = work_arr[i - 1][j];
            temporary_dimension = work_arr[i].Length;
            Array.Resize(ref work_arr[i], work_arr[i - 1].Length);
            Array.Resize(ref work_arr[i - 1], temporary_dimension);
            for (int j = 0; j < max_dimension_1; j++)
                work_arr[i - 1][j] = first_mass[j];
            for (int j = 0; j < max_dimension_2; j++)
                work_arr[i][j] = second_mass[j];
        }

        public static int max_value_in_array(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
                if (max < arr[i])
                    max = arr[i];
            return max;
        }

        public static int min_value_in_array(int[] arr)
        {
            int min = max_value_in_array(arr);
            for (int i = 0; i < arr.Length; i++)
                if (min > arr[i])
                    min = arr[i];
            return min;
        }
    }
}
