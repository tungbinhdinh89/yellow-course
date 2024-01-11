using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Lib
{
    public class GitHubDownloadService
    {
        //public static async Task DownloadFile(string[] args)
        // {
        //     string url = "https://raw.githubusercontent.com/oclockvn/yellow-course/master/YellowCourse.sln";

        //     var httpClient = new HttpClient();
        //     var response = await httpClient.GetAsync(url);

        //     if (response.IsSuccessStatusCode)
        //     {
        //         var content = await response.Content.ReadAsByteArrayAsync();
        //         string folderPath = $"Files/{DateTime.Now.Year}/{DateTime.Now.Month:D2}";
        //         Directory.CreateDirectory(folderPath);

        //         string filePath = Path.Combine(folderPath, "YellowCourse.sln");
        //         File.WriteAllBytes(filePath, content);
        //         Console.WriteLine($"File downloaded and saved successfully: {Path.Combine(Directory.GetCurrentDirectory(), filePath)}");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Failed to download the file.");
        //     }
        // }

        /// <summary>
        /// download file https://raw.githubusercontent.com/oclockvn/yellow-course/master/YellowCourse.sln
        /// </summary>
        /// <param name="url"></param>
        /// <param name="output">files/2024/01/</param>
        public static async Task<string> DownloadFileAsync(string url, string output)
        {
            // download file from url
            using var httpClient = new HttpClient();
            var bytes = await httpClient.GetByteArrayAsync(url);

            // file not found or something
            if (bytes is null || bytes.Length == 0)
            {
                return string.Empty;
            }

            // save file to output folder
            // https://raw.githubusercontent.com/oclockvn/yellow-course/master/YellowCourse.sln
            // YellowCourse.sln
            if (!Directory.Exists(output))
            {
                try
                {
                    Directory.CreateDirectory(output);
                }
                catch (Exception)
                {
                    await Console.Out.WriteLineAsync("Could not create folder");

                    return string.Empty;
                }
            }

            var filename = Path.GetFileName(url); // YellowCourse.sln
            var path = Path.Combine(output, filename); // files/2024/01/YellowCourse.sln
            await File.WriteAllBytesAsync(path, bytes);

            return path;
        }
    }
}
