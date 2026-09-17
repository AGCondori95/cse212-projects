using System.Text.Json.Serialization;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; } = [];
}

public class Feature
{
    public Properties Properties { get; set; } = new();
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; } = "";
}