using DesApi.Interfaces;

namespace DesApi.Buisness
{
    /// <summary>
    /// Implementation class of the diff data showing the discrepancies in a string
    /// </summary>
    public class DiffDataImpl : IDiffData
    {
        /// <summary>
        /// Zero based Offset for the start of the difference
        /// </summary>
        public int Offset { get; init; }

        /// <summary>
        /// this length of the difference
        /// </summary>
        public int Length { get; init; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiffResultImpl : IDiffResult
    {
        /// <summary>
        /// The result from the diff logic
        /// </summary>
        public string DiffResultType {  get; init; }

        /// <summary>
        /// Collection of differences in the string
        /// </summary>
        public IDiffData[] Discrepancies { get; set; }
    }
}
