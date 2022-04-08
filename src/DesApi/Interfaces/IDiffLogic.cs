namespace DesApi.Interfaces
{

    /// <summary>
    /// Interface for the Diff logic implementation
    /// </summary>
    public interface IDiffLogic
    {
        IDiffResult Compare(string left, string right);
    }
}
