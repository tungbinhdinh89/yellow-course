using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Lib
{
    public class DownloadFileFromInternet
    {
       public static async Task DownloadFile(string[] args)
        {
            string url = "https://raw.githubusercontent.com/oclockvn/yellow-course/master/YellowCourse.sln";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                string folderPath = $"Files/{DateTime.Now.Year}/{DateTime.Now.Month:D2}";
                Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, "YellowCourse.sln");
                File.WriteAllBytes(filePath, content);
                Console.WriteLine($"File downloaded and saved successfully: {Path.Combine(Directory.GetCurrentDirectory(), filePath)}");
            }
            else
            {
                Console.WriteLine("Failed to download the file.");
            }
        }
    }
}
