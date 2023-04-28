using Newtonsoft.Json;

namespace Proiect_TWM.Model.ApiResponse
{
    public class ApiPlantInfoResponseModel
    {
        [JsonProperty(PropertyName ="Latin name")]
        public string LatinName { get; set; }
        public string Id { get; set; }
        public string Img { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public string Climat { get; set; }
    }
}


