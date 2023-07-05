namespace MagicSquare
{
    /// <summary>
    /// Generate all permutations by a recursive algorithm.
    /// </summary>
    /// <remarks>
    /// Very slow.
    /// 3x3 - 0.1 sec
    /// 4x4 - ? sec
    /// </remarks>
    static internal class RecursivePermutations
    {
        static public IEnumerable<IList<int>> Generate(int[] nums) => GetPermutations(nums, 0, nums.Length - 1);


        static private IEnumerable<IList<int>> GetPermutations(int[] nums, int start, int end)
        {
            if (start == end)
            {
                // Trivial solution
                yield return new List<int>(nums);
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    (nums[start], nums[i]) = (nums[i], nums[start]);

                    foreach (var p in GetPermutations(nums, start + 1, end))
                        yield return p;

                    (nums[start], nums[i]) = (nums[i], nums[start]);
                }
            }
        }

    }
}
