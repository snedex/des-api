using DesApi.Interfaces;

namespace DesApi.Buisness
{
    /// <summary>
    /// Implementation of our difference logic for two strings
    /// </summary>
    public class DiffLogicImpl : IDiffLogic
    {
        //This is likely far from ideal
        public IDiffResult Compare(string left, string right)
        {
            //first content length test, no match, no good
            if(left?.Length != right?.Length)
            {
                return new DiffResultImpl()
                {
                    DiffResultType = "SizeDoNotMatch"
                };
            }

            var discrepancies = new List<IDiffData>();
            bool inDiscrepancy = false;
            int length = 0;
            int offset = 0;


            for (int i = 0; i < left.Length; i++)
            {
                //Are we matching?
                bool matchingChar = left[i] != right[i];

                //Not in discrepancy, but now discrepant
                if(!inDiscrepancy && !matchingChar)
                {
                    inDiscrepancy = true;
                    offset = i;
                    length = 1;
                }

                //Not in discrepancy, not discrepant
                //Do nothing

                //In discrepancy, now discrepant
                if (inDiscrepancy && !matchingChar)
                {
                    length++;
                }

                //In Discrepancy, (not discrepant OR end of string)
                if (inDiscrepancy && (matchingChar || left.Length == i + 1))
                {
                    discrepancies.Add(new DiffDataImpl()
                    {
                        Length = length,
                        Offset = offset,
                    });

                    inDiscrepancy = false;
                    offset = 0;
                    length = 0;
                }
            }

            if(discrepancies.Count() > 0)
            {
                return new DiffResultImpl()
                {
                    DiffResultType = "ContentDoNotMatch",
                    Discrepancies = discrepancies.ToArray()
                };
            }
            else
            {
                return new DiffResultImpl()
                {
                    DiffResultType = "Equals",
                };
            }

        }
    }
}
