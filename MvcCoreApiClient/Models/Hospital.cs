
using Newtonsoft.Json;

namespace MvcCoreApiClient.Models
{
    public class Hospital
    {
        [JsonProperty("idHospital")]
        public int idHospital { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("camas")]
        public string Camas { get; set; }

    }
}
