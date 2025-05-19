namespace Travelport.Domain.Constants;

public static class Airports
{
    public static readonly string[] Codes = new[]
    {
        "MAD", // Adolfo Suárez Madrid–Barajas Airport
        "BCN", // Barcelona–El Prat Airport
        "AGP", // Málaga Airport
        "PMI", // Palma de Mallorca Airport
        "ALC", // Alicante–Elche Airport
        "LPA", // Gran Canaria Airport
        "TFS", // Tenerife South Airport
        "VLC", // Valencia Airport
        "SVQ", // Seville Airport
        "BIO", // Bilbao Airport
        "IBZ", // Ibiza Airport
        "MAH", // Menorca Airport
        "SCQ", // Santiago de Compostela Airport
        "OVD", // Asturias Airport
        "GRO"  // Girona–Costa Brava Airport
    };

    public static bool IsValid(string code) => Codes.Contains(code);
}
