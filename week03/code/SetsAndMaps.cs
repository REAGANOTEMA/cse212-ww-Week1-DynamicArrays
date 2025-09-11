using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Find symmetric pairs in O(n) time
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> set = new HashSet<string>(words);
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip same letters
            string reversed = new string(new char[] { word[1], word[0] });
            if (set.Contains(reversed) && string.Compare(word, reversed) < 0)
            {
                result.Add($"{reversed} & {word}");
            }
        }

        return result.ToArray();
    }

    // Summarize degrees from file
    public static Dictionary<string, int> SummarizeDegrees(string path)
    {
        var dict = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(path))
        {
            var parts = line.Split(',');
            if (parts.Length < 4) continue;
            var degree = parts[3].Trim();
            if (!dict.ContainsKey(degree)) dict[degree] = 0;
            dict[degree]++;
        }
        return dict;
    }

    // Determine if two words are anagrams
    public static bool IsAnagram(string a, string b)
    {
        a = Regex.Replace(a.ToLower(), @"\s+", "");
        b = Regex.Replace(b.ToLower(), @"\s+", "");

        if (a.Length != b.Length) return false;

        var count = new Dictionary<char, int>();
        foreach (char c in a)
        {
            if (!count.ContainsKey(c)) count[c] = 0;
            count[c]++;
        }

        foreach (char c in b)
        {
            if (!count.ContainsKey(c) || count[c] == 0) return false;
            count[c]--;
        }

        return true;
    }

    // Fetch and parse earthquake JSON (synchronous for tests)
    public static string[] EarthquakeDailySummary()
    {
        using HttpClient client = new HttpClient();
        var json = client.GetStringAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson").Result;

        var doc = JsonDocument.Parse(json);
        var features = doc.RootElement.GetProperty("features");
        var result = new List<string>();

        foreach (var feature in features.EnumerateArray())
        {
            var prop = feature.GetProperty("properties");
            string place = prop.GetProperty("place").GetString();
            double mag = prop.GetProperty("mag").GetDouble();
            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}
