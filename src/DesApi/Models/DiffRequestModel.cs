using Newtonsoft.Json;

namespace DesApi.Models
{
    /// <summary>
    /// Model class for inbound JSON for adding a Diff Left or Right
    /// </summary>
    public class DiffRequestModel
    {
        [JsonProperty("data")]
        public string Data {  get; set; }   
    }
}
