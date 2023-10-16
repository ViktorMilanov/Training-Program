using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Filmify.Services
{
    public class PosterService
    {
        public static async Task<Bitmap?> LoadFromWebAsync(Uri getPosterQuery)
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(getPosterQuery);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                return new Bitmap(new MemoryStream(data));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while downloading poster : {ex.Message}");
                return null;
            }
        }
    }
}
