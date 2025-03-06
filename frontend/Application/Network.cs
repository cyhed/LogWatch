using Newtonsoft;
using Newtonsoft.Json;
using System.Text;



namespace App
{
    public class Network
    {
        public static string? SerializeToJson<T>(T item)
        {
            if (typeof(T) == typeof(string) || typeof(T).IsValueType)
            {
                return Convert.ToString(item);
            }
            var jsonString = JsonConvert.SerializeObject(item);
            return jsonString;
        }
        public static T? DeserializeStringJson<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<HttpResponseMessage> PostAsJson(string uri, string json, HttpClient client)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri)
            };
            return await client.SendAsync(request);
        }
    }
}
