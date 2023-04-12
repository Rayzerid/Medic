using Medic.Core;
using System;
using Medic.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Medic.Model
{
    //Класс с методами запросов на сервер
    public class HttpRequests
    {
        public async Task<string> SendCode(string UserMail)
        {
            string response;
            using (var client = new HttpClient())
            {
                string url = "https://medic.madskill.ru/api/sendCode";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("accept", "application/json");
                request.Headers.Add("email", UserMail);

                response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async Task<string> SignIn(string UserMail, string Code)
        {
            string response;
            using (var client = new HttpClient())
            {
                string url = "https://medic.madskill.ru/api/signin";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("accept", "application/json");
                request.Headers.Add("email", UserMail);
                request.Headers.Add("code", Code);

                response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async void GetNews(AnalyzesVM analyzesVM)
        {
            string response;
            using (var client = new HttpClient())
            {
                string url = "https://medic.madskill.ru/api/news";
                response = await client.GetAsync(url).Result.Content.ReadAsStringAsync();
            }
            ObservableCollection<NewItem> newsItems = JsonConvert.DeserializeObject<ObservableCollection<NewItem>>(response);
            analyzesVM.NewsCollection = newsItems;
        }
        public async void GetCatalog(AnalyzesVM analyzesVM)
        {
            string response;
            using (var client = new HttpClient())
            {
                string url = "https://medic.madskill.ru/api/catalog";
                response = await client.GetAsync(url).Result.Content.ReadAsStringAsync();
            }
            ObservableCollection<CatalogMenu> catalogItem = JsonConvert.DeserializeObject<ObservableCollection<CatalogMenu>>(response);

            analyzesVM.CatalogCollection = catalogItem;
        }
    }
}
