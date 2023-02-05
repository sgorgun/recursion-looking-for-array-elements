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
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[][]? ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The array to search cannot be null.");
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges), "The array to search cannot be null.");
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
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[][]? ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The array to search cannot be null.");
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges), "The ranges cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "The start index cannot be negative.");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is out of range arrayToSearch.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count cannot be negative.");
            }

            foreach (var t in ranges)
            {
                if (t is null)
                {
                    throw new ArgumentNullException(nameof(ranges), "The ranges cannot be null.");
                }

                if (t.Length != 2 && t.Length != 0)
                {
                    throw new ArgumentException("Check the ranges.", nameof(ranges));
                }
            }

            if (count > arrayToSearch.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count cannot be greater than the length of the array minus the start index.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            return GetCountRecursive(arrayToSearch, ranges, startIndex, count, 0, 0);
        }

        public static int GetIsNumberInRangesRecursive(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int rangeIndex)
        {
#pragma warning disable S3358 // Ternary operators should not be nested
            return rangeIndex < ranges.Length && ranges[rangeIndex].Length > 0 && arrayToSearch[startIndex] >= ranges[rangeIndex][0] && arrayToSearch[startIndex] <= ranges[rangeIndex][1]
                ? 1
                : rangeIndex == ranges.Length - 1
                    ? 0
                    : GetIsNumberInRangesRecursive(arrayToSearch, ranges, startIndex, rangeIndex + 1);
#pragma warning restore S3358 // Ternary operators should not be nested
        }

        public static int GetCountRecursive(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count, int i, int totalCount)
        {
            return count > 0
                ? GetCountRecursive(arrayToSearch, ranges, startIndex + 1, count - 1, i, totalCount + GetIsNumberInRangesRecursive(arrayToSearch, ranges, startIndex, i))
                : totalCount;
        }
    }
}
