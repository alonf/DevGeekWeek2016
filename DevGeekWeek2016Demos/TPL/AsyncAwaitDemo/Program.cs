using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main()
        {
            Task t1 = WithoutAsync();
            Task t2 = WithAsync();
            Task.WaitAll(t1, t2);
        }
        private static Task WithoutAsync()
        {
            var httpClient = new HttpClient();

            var task = httpClient.GetAsync("https://twitter.com/CodeValue")
                .ContinueWith(requestTask =>
                {
                    var httpContent = requestTask.Result.Content;
                    httpContent.ReadAsStringAsync()
                                    .ContinueWith(contentTask =>
                                    {
                                        var fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\webpage1.html";
                                        var file = File.CreateText(fileName);
                                        file.WriteAsync(contentTask.Result).ContinueWith(f =>
                                        {
                                            f.Dispose();
                                            Process.Start(fileName);
                                        });
                                    });
                });
            return task;

        }
        private static async Task WithAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://twitter.com/oz_code");
            var page = await response.Content.ReadAsStringAsync();
            var fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\webpage.html";
            using (var file = File.CreateText(fileName))
            {
                await file.WriteAsync(page);
            }
            Process.Start(fileName);
        }
    }
}
