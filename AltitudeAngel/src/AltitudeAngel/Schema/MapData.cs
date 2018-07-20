using System;
using System.Collections.Generic;

public class Geometry
{
    public List<object> coordinates { get; set; }
    public string type { get; set; }
}

public class Filter
{
    public string name { get; set; }
    public string property { get; set; }
    public bool active { get; set; }
}

public class Section
{
    public string iconUrl { get; set; }
    public string title { get; set; }
    public string text { get; set; }
}

public class Display
{
    public string category { get; set; }
    public string detailedCategory { get; set; }
    public string title { get; set; }
    public List<Section> sections { get; set; }
    public List<object> actions { get; set; }
}

public class AltitudeFloor
{
    public string datum { get; set; }
    public double meters { get; set; }
}

public class AltitudeCeiling
{
    public string datum { get; set; }
    public double meters { get; set; }
}

public class Airac
{
    public string to { get; set; }
    public string from { get; set; }
}

public class Properties
{
    public string hazardFactor { get; set; }
    public string hazardFactorName { get; set; }
    public string fillColor { get; set; }
    public string strokeColor { get; set; }
    public string fillOpacity { get; set; }
    public string strokeWidth { get; set; }
    public string strokeOpacity { get; set; }
    public string detailedCategory { get; set; }
    public string iconUrl { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public List<Filter> filters { get; set; }
    public Display display { get; set; }
    public DateTime? operationalTo { get; set; }
    public AltitudeFloor altitudeFloor { get; set; }
    public AltitudeCeiling altitudeCeiling { get; set; }
    public string radius { get; set; }
    public string listOrderHint { get; set; }
    public Airac airac { get; set; }
    public string designator { get; set; }
}

public class Feature
{
    public Geometry geometry { get; set; }
    public string id { get; set; }
    public Properties properties { get; set; }
    public string type { get; set; }
}

/**
   Generated from a MapData JSON response passed through: http://json2csharp.com/
*/
public class MapData
{
    public bool isCompleteData { get; set; }
    public List<object> excludedData { get; set; }
    public List<object> countriesInViewport { get; set; }
    public List<object> nationalFlightRestrictions { get; set; }
    public List<Feature> features { get; set; }
    public List<double> bbox { get; set; }
    public string type { get; set; }
}
