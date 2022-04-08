namespace DesApi.Interfaces
{

    /// <summary>
    /// Interface for the Diff logic implementation
    /// </summary>
    public interface IDiffLogic
    {
        /// <summary>
        /// Compares the left and the right strings and returns a result with detailed discrepant points
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        IDiffResult Compare(string left, string right);
    }
}
