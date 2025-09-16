// Author: Reagan Otema
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// Base case: if n <= 0, return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; // Base case
        // Recursive call: sum of squares of (n-1) plus n^2
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Generate all permutations of length 'size' from 'letters'
    /// Insert results into the 'results' list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb s stairs using 1, 2, or 3 steps at a time
    /// Use memoization to handle large values of s.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (s < 0) return 0;
        if (s == 0) return 1;

        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand a binary string pattern with '*' wildcards into all possible strings.
    /// Insert all results into 'results'.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Recursively find all paths through a maze from (0,0) to the end.
    /// Add each complete path to 'results' using currPath.AsString()
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        currPath ??= new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore all 4 directions: up, down, left, right
        SolveMaze(results, maze, x + 1, y, currPath); // right
        SolveMaze(results, maze, x - 1, y, currPath); // left
        SolveMaze(results, maze, x, y + 1, currPath); // down
        SolveMaze(results, maze, x, y - 1, currPath); // up

        currPath.RemoveAt(currPath.Count - 1); // backtrack
    }
}
