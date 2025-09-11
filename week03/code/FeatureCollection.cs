using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Root object for deserializing the USGS earthquake feed
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("mag")]
    public double Mag { get; set; }
}
