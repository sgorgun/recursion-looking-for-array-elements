using System;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            //Implement the method using recursion.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The array to search cannot be null.");
            }

            return GetDecimalsCount(arrayToSearch, ranges, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            // Implement the method using recursion. The method should call itself. DON'T use loops.

            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The array to search cannot be null.");
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges), "The ranges cannot be null.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            // ins

            if (ranges[0] is null)
            {
                throw new ArgumentNullException(nameof(ranges), "The ranges cannot be null.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count cannot be negative.");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "sdfsdfdsf.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "The start index cannot be negative.");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (ranges[0].Length != 2)
            {
                throw new ArgumentException("The range should have exactly two elements.", nameof(ranges));
            }

            if (ranges.

            if (ranges[0][0] > ranges[0][1])
            {
                throw new ArgumentOutOfRangeException(nameof(ranges), "The first element of the range should be less than or equal to the second element of the range.");
            }

            if (count > arrayToSearch.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count cannot be greater than the length of the array minus the start index.");
            }

            if (count == 0)
            {
                return 0;
            }

            if (arrayToSearch[startIndex] >= ranges[0][0] && arrayToSearch[startIndex] <= ranges[0][1])
            {
                return 1 + GetDecimalsCount(arrayToSearch, ranges, startIndex + 1, count - 1);
            }

            return GetDecimalsCount(arrayToSearch, ranges, startIndex + 1, count - 1);
        }
    }
}
