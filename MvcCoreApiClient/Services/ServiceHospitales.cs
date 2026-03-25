using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospitales
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceHospitales (IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales";
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);

                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return hospitales;
                }
                else
                {
                    return null;
                }
            } 
        }

        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales/" + idHospital;
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);

                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    Hospital hospital = await response.Content.ReadAsAsync<Hospital>();
                    return hospital;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
