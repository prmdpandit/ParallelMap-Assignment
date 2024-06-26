using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMap_Assignment.ParallelMapLib
{
    public static class Utility
    {
        // Simulate Network-bound url processing function

        public static async Task<string> NetworkResponse(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }


        // Simulate CPU-bound image processing functions
        public static byte[] LoadImage()
        {
            var rand = new Random();
            var image = new byte[1024]; // 1 KB image
            rand.NextBytes(image);
            return image;
        }

        public static byte[] ProcessImage(byte[] image)
        {
            var processedImage = new byte[image.Length];
            for (int i = 0; i < image.Length; i++)
            {
                processedImage[i] = (byte)(255 - image[i]);
            }
            return processedImage;
        }
    }

}
