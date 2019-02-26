using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace AlfrescoAddGroup {
    class Program {

        /// <param name="endpoint">http://localhost:8080</param>
        /// <param name="groups">A1 A2 A3</param>
        /// <param name="user">admin</param>
        /// <param name="password">admin</param>
        static async System.Threading.Tasks.Task Main(
                string endpoint,
                string[] groups,
                string user = "admin",
                string password = "admin") {

            var api = $"{endpoint}/alfresco/api/-default-/public/alfresco/versions/1/groups";
            var client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes($"{user}:{password}");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            foreach (var item in groups) {
                var obj = new {
                    id = item,
                    displayName = item,
                    parentIds = new string[0] { }
                };
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8);
                var response = await client.PostAsync(api, content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.Created) {
                    Console.WriteLine($"- {response.StatusCode} -");
                }

                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
