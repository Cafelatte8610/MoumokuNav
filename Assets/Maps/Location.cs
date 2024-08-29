[System.Serializable]
public struct Location
{
    public double Latitude;
    public double Longitude;

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
