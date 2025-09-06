// Author: Reagan Otema
using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Produces an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// Example: MultiplesOf(7, 5) -> {7, 14, 21, 28, 35}.
    /// Assumes 'length' is a positive integer > 0.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // ---------------------------------------------------------
        // PLAN:
        // 1) Create an array of doubles of size 'length'.
        // 2) Loop from i = 0 to length - 1.
        // 3) For each i, calculate number * (i + 1) and store in array[i].
        // 4) Return the filled array.
        // ---------------------------------------------------------

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the 'data' list to the right by 'amount' in place.
    /// Example: {1,2,3,4,5,6,7,8,9}, amount=3 -> {7,8,9,1,2,3,4,5,6}.
    /// Amount is between 1 and data.Count inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // ---------------------------------------------------------
        // PLAN:
        // 1) If data is empty or null, do nothing.
        // 2) Normalize amount: amount %= data.Count (full rotations have no effect).
        // 3) If amount == 0 after normalization, do nothing.
        // 4) Save the last 'amount' elements (tail) using GetRange.
        // 5) Remove the last 'amount' elements from data.
        // 6) Insert the saved tail at the beginning of data.
        // ---------------------------------------------------------

        if (data == null || data.Count == 0) return;

        amount %= data.Count;
        if (amount == 0) return;

        List<int> tail = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, tail);
    }
}
