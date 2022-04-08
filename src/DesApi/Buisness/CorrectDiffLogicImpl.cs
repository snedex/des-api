using DesApi.Interfaces;
using System.Text;

namespace DesApi.Buisness
{
    /// <summary>
    /// Implementation of our difference logic for two base64 strings
    /// </summary>
    public class CorrectDiffLogicImpl : IDiffLogic
    {
        //This is likely far from ideal
        public IDiffResult Compare(string left, string right)
        {
            var leftData = Convert.FromBase64String(left);
            var rightData = Convert.FromBase64String(right);

            //first content length test, no match, no good
            if (leftData.Length != rightData.Length)
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


            for (int i = 0; i < leftData.Length; i++)
            {
                //Are we matching?
                bool matchingChar = leftData[i] == rightData[i];

                //Not in discrepancy, but now discrepant
                if(!inDiscrepancy && !matchingChar)
                {
                    inDiscrepancy = true;
                    offset = i;
                    length = 1;
                    continue;
                }

                //Not in discrepancy, not discrepant
                //Do nothing

                //In discrepancy, now discrepant
                if (inDiscrepancy && !matchingChar)
                {
                    length++;
                }

                //In Discrepancy, (not discrepant OR end of string)
                if (inDiscrepancy && (matchingChar || leftData.Length == i + 1))
                {
                    discrepancies.Add(new DiffDataImpl()
                    {
                        Length = length,
                        Offset = offset,
                    });

                    inDiscrepancy = false;
                    offset = 0;
                    length = 0;
                    continue;
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
