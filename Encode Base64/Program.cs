using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Specify the input file path
        string inputFilePath = "C:/Users/TP/Documents/Encode Base64/Input/invoice.txt"; // Update this to your file path

        // Read the file bytes
        byte[] fileBytes = File.ReadAllBytes(inputFilePath);
        
        // Convert to Base64 string
        string base64String = Convert.ToBase64String(fileBytes);

        // Specify the output file path
        string outputFilePath = "output_base64.txt"; // Change this to your desired output file path

        // Save the Base64 string to the output file
        File.WriteAllText(outputFilePath, base64String);

        Console.WriteLine($"Base64 string has been saved to {outputFilePath}");
        Console.WriteLine(base64String);
    }
}
