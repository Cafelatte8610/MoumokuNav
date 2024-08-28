using System;

public static class NaviMath
{
    private const double EARTH_RADIUS = 6378.137d; //km

    public static double Deg2Rad { get { return Math.PI / 180.0d; } }

    public static double LatlngDistance(Location a, Location b)
    {
        double dlat1 = a.Latitude * Deg2Rad;
        double dlng1 = a.Longitude * Deg2Rad;
        double dlat2 = b.Latitude * Deg2Rad;
        double dlng2 = b.Longitude * Deg2Rad;

        double d1 = Math.Sin(dlat1) * Math.Sin(dlat2);
        double d2 = Math.Cos(dlat1) * Math.Cos(dlat2) * Math.Cos(dlng2 - dlng1);
        double distance = EARTH_RADIUS * Math.Acos(d1 + d2);
        return distance;
    }
    public static double LatlngDirection(Location from, Location to)
    {
        var dlat1 = to.Latitude * Deg2Rad;
        var dlng1 = to.Longitude * Deg2Rad;
        var dlat2 = from.Latitude * Deg2Rad;
        var dlng2 = from.Longitude * Deg2Rad;

        var deltaX = dlng2 - dlng1;
        var y = Math.Sin(deltaX);
        var x = Math.Cos(dlat1) * Math.Tan(dlat2) - Math.Sin(dlat1) * Math.Cos(deltaX);
        var dir = Math.Atan2(y, x) * 180 / Math.PI;
        if (dir < 0)
        {
            return 360 + dir;
        }
        return dir;
    }
}