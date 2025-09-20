using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST. Only unique values are allowed.
    /// Author: Reagan Otema
    /// </summary>
    public void Insert(int value)
    {
        if (_root is null)
        {
            _root = new Node(value);
        }
        else
        {
            _root.Insert(value); // Node.Insert handles uniqueness
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// Author: Reagan Otema
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Iterate forward through the BST (in-order traversal).
    /// Author: Reagan Otema
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST (reverse in-order traversal).
    /// Author: Reagan Otema
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            // Reverse in-order: Right → Root → Left
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Get the height of the tree.
    /// Author: Reagan Otema
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

/// <summary>
/// Extension methods for converting arrays/enumerables to string.
/// Author: Reagan Otema
/// </summary>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
