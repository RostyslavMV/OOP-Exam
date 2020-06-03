using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
