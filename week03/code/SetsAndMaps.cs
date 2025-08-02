using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var w in words)
        {
            // 同一文字（aa 等）は無視
            if (w[0] == w[1]) continue;

            var rev = new string(new[] { w[1], w[0] });

            // 逆語が存在し、重複追加を避けるため一方だけ追加
            if (set.Contains(rev) && string.Compare(w, rev, StringComparison.Ordinal) < 0)
            {
                result.Add($"{w} & {rev}");
            }
        }
        return result.ToArray();
    }

    // Problem 2
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var fields = line.Split(',');
            if (fields.Length < 4) continue; // 念のため防御

            var degree = fields[3].Trim();
            if (degree.Length == 0) continue;

            if (!degrees.TryAdd(degree, 1))
            {
                degrees[degree]++;
            }
        }

        return degrees;
    }

    // Problem 3
    public static bool IsAnagram(string word1, string word2)
    {
        // スペース無視・大小無視
        string a = new string(word1.Where(c => c != ' ').Select(char.ToLowerInvariant).ToArray());
        string b = new string(word2.Where(c => c != ' ').Select(char.ToLowerInvariant).ToArray());

        if (a.Length != b.Length) return false;

        var counts = new Dictionary<char, int>();
        foreach (var c in a)
        {
            counts[c] = counts.TryGetValue(c, out var v) ? v + 1 : 1;
        }
        foreach (var c in b)
        {
            if (!counts.TryGetValue(c, out var v)) return false;
            if (v == 1) counts.Remove(c);
            else counts[c] = v - 1;
        }
        return counts.Count == 0;
    }

    // Problem 5
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // features が無いときの安全策
        if (featureCollection?.Features == null) return Array.Empty<string>();

        var list = new List<string>();
        foreach (var f in featureCollection.Features)
        {
            var place = f?.Properties?.Place ?? "Unknown place";
            var mag = f?.Properties?.Mag;
            var magText = mag.HasValue ? mag.Value.ToString("0.0") : "N/A";
            list.Add($"{place} - Mag {magText}");
        }
        return list.ToArray();
    }
}
