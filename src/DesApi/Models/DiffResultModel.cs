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

    /// <summary>
    /// Represents a single difference in a line
    /// </summary>
    public class DiffDataModel
    {
        /// <summary>
        /// Zero based Offset for the start of the difference
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The length of the difference
        /// </summary>
        public int Length { get; set; }
    }
}
