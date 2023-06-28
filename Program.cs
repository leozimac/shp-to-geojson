using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

string sphFilePath = "";

Console.WriteLine("=== Shapefile to GeoJSON ===");

if (!args.Any())
{
    while (string.IsNullOrEmpty(sphFilePath))
    {
        Console.WriteLine("Please enter the .shp file path: ");
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
            sphFilePath = input;
    }
}
else{
    sphFilePath = args[0];
}

if (!Path.GetExtension(sphFilePath).Equals(".shp"))
{
    Console.WriteLine("File not supported.");
    return;
}

Console.WriteLine("Getting the file full path...");
string fullPath = Path.GetFullPath(sphFilePath);

if (string.IsNullOrEmpty(fullPath))
{
    Console.WriteLine($"Couldn't get the full path for: {sphFilePath}");
    return;
}

var geoFactory = new GeometryFactory();
ShapefileReader shpFileReader;

try
{
    shpFileReader = new ShapefileReader(fullPath, geoFactory);
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Couldn't find the file {fullPath} in the current directory.");
    return;
}

Console.WriteLine("Reading the shapefile...");
GeometryCollection geoCollection = shpFileReader.ReadAll();

if (!geoCollection.Any())
{
    Console.WriteLine("Something went wrong while getting the geometry collection.");
    return;
}
Console.WriteLine("Writing the geo collection data to GeoJSON...");

var geoJsonWriter = new GeoJsonWriter();
string geoJson = geoJsonWriter.Write(geoCollection);

var directory = Path.GetDirectoryName(fullPath);
if (string.IsNullOrEmpty(directory))
{
    Console.WriteLine("Error getting the directory to save GeoJSON.");
    return;
}

var fileName = Path.GetFileNameWithoutExtension(fullPath);
if (string.IsNullOrEmpty(fileName))
{
    Console.WriteLine("Error while getting the file name to save GeoJSON.");
    return;
}

var newFilePath = Path.Combine(directory, $"{fileName}.json");

Console.WriteLine("Creating GeoJSON file...");
File.WriteAllText(newFilePath, geoJson);
Console.WriteLine($"GeoJSON created at: {newFilePath}");
Console.ReadKey();