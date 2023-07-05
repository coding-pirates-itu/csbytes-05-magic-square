namespace MagicSquare
{
    /// <summary>
    /// Generate all permutations by using Lehmer codes.
    /// 
    /// See https://www.keithschwarz.com/interesting/code/?dir=factoradic-permutation.
    /// </summary>
    /// <remarks>
    /// 3x3 - 0.08 sec
    /// 4x4 - 27 min
    /// </remarks>
    internal class LehmerPermutations
    {
        private readonly int mSize;

        private readonly int[] mIdentity;


        public LehmerPermutations(int size)
        {
            mSize = size;
            mIdentity = Enumerable.Range(0, size).ToArray();
        }


        public IEnumerable<IList<int>> Generate(int[] nums)
        {
            var nofPermutations = Factorial((uint) nums.Length);

            for (var i = 0uL; i < nofPermutations; i++)
            {
                yield return NumberToLehmer(nums, i);
            }
        }


        private ulong Factorial(uint n) => n <= 1 ? 1 : n * Factorial(n - 1);


        private int[] NumberToLehmer(int[] nums, ulong number)
        {
            var m = number;
            var size = (uint)nums.Length;
            var elems = nums.ToArray();
            var permuted = new int[size];

            for (var i = 0uL; i < size; i++)
            {
                var ind = m % (size - i);
                m = m / (size - i);
                permuted[i] = elems[ind];
                elems[ind] = elems[size - i - 1];
            }

            return permuted;


            //var sequence = new int[mSize];
            //sequence[0] = 0;
            //var currentBase = 2;

            //for (var k = 0; k < sequence.Length; k++)
            //{
            //    sequence[k + 1] = number % currentBase;
            //    number /= currentBase;
            //    currentBase++;
            //}
        }


        int[] LehmerToIndices(int[] original, int[] indices)
        {
            var normal = new int[indices.Length];

            for (int i = 0; i < indices.Length; i++)
            {
                normal[mIdentity[i]] = original[i];
            }

            return normal;
        }
    }
}
