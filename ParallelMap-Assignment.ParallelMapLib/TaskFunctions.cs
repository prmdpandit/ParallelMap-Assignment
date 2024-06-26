using ParallelMap_Assignment.ParallelMapLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public static class TaskFunctions
{
    public static List<Func<Task<string>>> GetTaskFunctions()
    {
        return new List<Func<Task<string>>>
        {
            async () => await Utility.NetworkResponse("https://openlibrary.org/api/books?bibkeys=ISBN:0201558025,LCCN:93005405&format=json"),// Simulate network work
       
            async () =>await Utility.NetworkResponse("http://universities.hipolabs.com/search?name=middle"),// Simulate network work
            
            async () => await File.ReadAllTextAsync("TestFiles/TestTextFile.txt"), // Simulate disk I/O work with text file
            
            async () => await File.ReadAllTextAsync("TestFiles/TestXmlFile.xml"), // Simulate disk I/O work with xml file
            
            async () =>
            {
                return await Task.Run(() =>
                {
                    // Simulate CPU-intensive work
                    byte[] image = Utility.LoadImage();
                    byte[] processedImage = Utility.ProcessImage(image);
                    return Convert.ToBase64String(processedImage); // Convert to a string representation for this example
                });
            }
        };
    }
}

