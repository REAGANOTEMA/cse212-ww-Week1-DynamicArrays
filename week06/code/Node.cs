using System;

/// <summary>
/// Node class for Binary Search Tree (BST)
/// Author: Reagan Otema
/// </summary>
public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Insert a unique value into the BST.
    /// Author: Reagan Otema
    /// </summary>
    /// <param name="value">Value to insert</param>
    public void Insert(int value)
    {
        if (value == Data)
        {
            // Duplicate value, do nothing
            return;
        }
        else if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Check if the BST contains a specific value.
    /// Author: Reagan Otema
    /// </summary>
    /// <param name="value">Value to search for</param>
    /// <returns>True if found, otherwise false</returns>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data && Left != null)
            return Left.Contains(value);
        else if (value > Data && Right != null)
            return Right.Contains(value);
        else
            return false;
    }

    /// <summary>
    /// Get the height of this node's subtree.
    /// Author: Reagan Otema
    /// </summary>
    /// <returns>Height of the tree rooted at this node</returns>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
