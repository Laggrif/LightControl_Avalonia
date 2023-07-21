using System.IO;
using System.Linq;

namespace LightControl;

public static class FileConsole
{
    private const string FilePath = "C:\\Users\\Laggrif\\Documents\\Coding_Projects\\LightControl_Avalonia\\";
    private static int _maxLength = 500;

    public static void WriteLine(string line)
    {
        using var writer = new StreamWriter(FilePath + "Console.txt", true);
        writer.WriteLine(line);
        writer.Close();
        
        if (File.ReadLines(FilePath + "Console.txt").Count() > _maxLength){ ClearStart(); }
    }

    private static void ClearStart()
    {
        var filePath = FilePath + "input.txt";
        var tempFilePath = FilePath + "temp.txt";

        try
        {
            // Create a new temporary file
            using (var tempWriter = new StreamWriter(tempFilePath))
            {
                // Read the input file
                using (var reader = new StreamReader(filePath))
                {
                    //Skip 50 first lines
                    for (var j = 0; j < 50; j++) { reader.ReadLine(); }

                    // Copy the remaining lines to the temporary file
                    while (reader.ReadLine() is { } line)
                    {
                        tempWriter.WriteLine(line);
                    }
                }
            }

            // Replace the original file with the temporary file
            File.Replace(tempFilePath, filePath, null);
        }
        finally
        {
            // Delete the temporary file if it exists
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
    }

    public static void Purge()
    {
        File.WriteAllText(FilePath + "Console.txt", string.Empty);
    }

    public static void SetMaxLength(int newLength) { _maxLength = newLength; }
}