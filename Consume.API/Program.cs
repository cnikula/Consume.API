
using System.Text.Json;

namespace Consume.API
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            /*****************************************************
             * // Retrieve a single post
            *****************************************************/

            JasonPlaceHolder jph = new JasonPlaceHolder();

            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };

            var response = await client.GetAsync("posts/1");
            var content = await response.Content.ReadAsStringAsync();

            jph = JsonSerializer.Deserialize<JasonPlaceHolder>(content);

            Console.WriteLine($"Id: {jph.Id} \n UserId: {jph.UserId} \n Title: {jph.Title} \n Body: {jph.Body}");
            Console.ReadLine();

            /*****************************************************
             * Retrieve a list of posts
            *****************************************************/
            // Retrieve a list of posts
            List<JasonPlaceHolder> jphList = new List<JasonPlaceHolder>();

            var responseList = await client.GetAsync("posts/");
            var contentList = await responseList.Content.ReadAsStringAsync();
            jphList = JsonSerializer.Deserialize<List<JasonPlaceHolder>>(contentList);


            if (jphList.Count >= 1)
            {
                foreach (var item in jphList)
                {
                    Console.WriteLine($"Id: {item.Id} \n UserId: {item.UserId} \n Title: {item.Title} \n Body: {item.Body}");
                }
            }

            Console.ReadLine();

        }
    }
}
