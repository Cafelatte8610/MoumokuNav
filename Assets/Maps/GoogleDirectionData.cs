using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;

[DataContract]
public class GoogleDirectionData
{
    // DataMemberを付けたオブジェクトは、同じ名前のパラメータが入ったときに自動でマッピングされる（[DataMember (name="hoge")]で明示的にマッピングも可能）
    [DataMember]
    public List<GeocodedWaypoints> geocoded_waypoints;

    [DataMember]
    public List<Route> routes;

    [DataMember]
    public string status;

    public class GeocodedWaypoints
    {
        [DataMember]
        public string geocoder_status;
        [DataMember]
        public string place_id;
        [DataMember]
        public ArrayList types;
    }

    public class Route
    {
        [DataMember]
        public List<Bound> bounds;
        [DataMember]
        public string copyrights;
        [DataMember]
        public List<Legs> legs;
        [DataMember]
        public List<OverviewPolyline> overview_polyline;
        [DataMember]
        public string summary;
        [DataMember]
        public List<string> warnings;
        [DataMember]
        public List<string> waypoint_order;
    }

    public class Bound
    {
        [DataMember]
        public Location northeast;
        [DataMember]
        public Location southwest;
    }

    public class Legs
    {
        [DataMember]
        public Distance distance;
        [DataMember]
        public Duration duration;
        [DataMember]
        public string start_address;
        [DataMember]
        public string end_address;
        [DataMember]
        public Location start_location;
        [DataMember]
        public Location end_location;
        [DataMember]
        public List<Step> steps;
    }

    public class OverviewPolyline
    {
        [DataMember]
        public string points;
    }

    public class Distance
    {
        [DataMember]
        public string text;
        [DataMember]
        public string value;
    }

    public class Duration
    {
        [DataMember]
        public string text;
        [DataMember]
        public string value;
    }

    public class Location
    {
        [DataMember]
        public string lat;
        [DataMember]
        public string lng;
    }

    public class Step
    {
        [DataMember]
        public Distance distance;
        [DataMember]
        public Duration duration;
        [DataMember]
        public Location start_location;
        [DataMember]
        public Location end_location;
        [DataMember]
        public string html_instructions;
        [DataMember]
        public Polyline polyline;
        [DataMember]
        public string travel_mode;
    }

    public class Polyline
    {
        [DataMember]
        public string points;
    }
}