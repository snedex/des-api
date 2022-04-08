using DesApi.Interfaces;

namespace DesApi.Buisness
{
    public class DiffDataImpl : IDiffData
    {
        public int Offset { get; init; }

        public int Length { get; init; }
    }

    public class DiffResultImpl : IDiffResult
    {
        public string DiffResultType {  get; init; }

        public IDiffData[] Discrepancies { get; set; }
    }
}
