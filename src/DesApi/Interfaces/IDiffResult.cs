namespace DesApi.Interfaces
{
    /// <summary>
    /// Represents a result from the Diff logic processing
    /// </summary>
    public interface IDiffResult
    {
        string DiffResultType { get; }

        IDiffData[] Discrepancies { get; } 
    }

    /// <summary>
    /// Represents a segment of data that does not match the comparison string
    /// </summary>
    public interface IDiffData
    {
        /// <summary>
        /// Zero based Offset for the start of the difference
        /// </summary>
        int Offset { get; }

        /// <summary>
        /// The length of the difference
        /// </summary>
        int Length { get; }
    }
}
