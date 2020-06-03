using System.Runtime.CompilerServices;

namespace OOP_Exam.BPlusTree
{
    /// <summary>
    /// provides some mathematic and numeric extensions.
    /// </summary>
    internal static class NumericExtensions
    {
        /// <summary>
        /// fast sign function that uses bitwise operations instead of branches.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this int x) => (x >> 31) | 1;
    }
}
