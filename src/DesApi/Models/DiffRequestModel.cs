using Newtonsoft.Json;

namespace DesApi.Models
{
    public class DiffRequestModel
    {
        [JsonProperty("data")]
        public string Data {  get; set; }   
    }
}
