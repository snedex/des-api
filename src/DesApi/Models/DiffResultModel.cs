using DesApi.Interfaces;
using Newtonsoft.Json;

namespace DesApi.Models
{
    /// <summary>
    /// Model that respresents the diff result presented via the API
    /// </summary>
    public class DiffResultModel
    {
        public DiffResultModel()
        {

        }

        public DiffResultModel(IDiffResult result)
        {
            //TODO: AutoMapper
        }

        [JsonProperty("diffResultType")]
        public string DiffResultType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DiffDataModel[] Discrepancies { get; set; } 
    }

    public class DiffDataModel
    {
        public int Offset { get; set; }

        public int Length { get; set; }
    }
}
