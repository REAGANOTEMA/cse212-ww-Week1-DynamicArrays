using System;

/// <summary>
/// Utility class for creating balanced Binary Search Trees (BST) from sorted arrays.
/// Author: Reagan Otema
/// </summary>
public static class Trees
{
    /// <summary>
    /// Given a sorted array, create a balanced BST.
    /// If the values were inserted sequentially, the tree would be unbalanced (like a linked list).
    /// This function uses InsertMiddle to build a balanced tree recursively.
    /// Author: Reagan Otema
    /// </summary>
    /// <param name="sortedNumbers">Input numbers, already sorted in ascending order</param>
    /// <returns>A balanced BinarySearchTree containing all numbers</returns>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively insert the middle element of the current range into the BST.
    /// Then recursively insert the middle elements of the left and right subranges.
    /// Author: Reagan Otema
    /// </summary>
    /// <param name="sortedNumbers">Input sorted array</param>
    /// <param name="first">Start index of current range</param>
    /// <param name="last">End index of current range</param>
    /// <param name="bst">BinarySearchTree to insert into</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return; // Base case: no elements in this range

        int mid = (first + last) / 2;

        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert left and right halves
        InsertMiddle(sortedNumbers, first, mid - 1, bst); // Left half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);  // Right half
    }
}
