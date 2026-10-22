using System;

namespace DSA.Lab01
{
    public static class SortAlgorithms
    {
        public static void InsertionSort(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                int valueToBeInserted = values[i];
                int j = i;
                
                while (j > 0 && values[j-1] > valueToBeInserted)
                {
                    values[j] = values[j-1];
                    --j;
                }
                values[j] = valueToBeInserted;
            }
            // TODO: Sort the array in ascending order using insertion sort.
            //
            // Think of values[0..i-1] as the already-sorted part.
            // For each next value:
            // 1. Store the value you want to insert.
            // 2. Shift larger values one position to the right.
            // 3. Put the stored value into the gap.
        }
    }
}
