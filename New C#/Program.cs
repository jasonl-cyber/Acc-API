using System;
using System.IO;
using System.Security.Cryptography;

public class HashDirectory
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: HashDirectory <directory> <output_file>");
            return;
        }

        string directory = args[0];
        string outputFile = args[1];

        if (Directory.Exists(directory))
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                var dir = new DirectoryInfo(directory);
                FileInfo[] files = dir.GetFiles();
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    foreach (FileInfo fInfo in files)
                    {
                        using (FileStream fileStream = fInfo.Open(FileMode.Open))
                        {
                            try
                            {
                                fileStream.Position = 0;
                                byte[] hashValue = mySHA256.ComputeHash(fileStream);
                                string hashString = BitConverter.ToString(hashValue).Replace("-", "").ToLowerInvariant();
                                
                                // Print to console
                                Console.Write($"{fInfo.Name}: {hashString}");

                                // Write to output file
                                writer.WriteLine($"{fInfo.Name}: {hashString}");
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine($"I/O Exception: {e.Message}");
                            }
                            catch (UnauthorizedAccessException e)
                            {
                                Console.WriteLine($"Access Exception: {e.Message}");
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("The directory specified could not be found.");
        }
    }
}
