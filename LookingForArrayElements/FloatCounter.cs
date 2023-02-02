using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch is empty");
            }

            return GetFloatsCount(arrayToSearch, rangeStart, rangeEnd, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch is empty");
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart), "rangeStart is empty");
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd), "rangeEnd is empty");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("The length of the rangeStart and rangeEnd arrays must be equal.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than 0");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            return CountElements(arrayToSearch!, rangeStart!, rangeEnd, startIndex, count);

            static int CountElements(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
            {
                if (rangeStart.Length == 0)
                {
                    return 0;
                }

                if (rangeEnd.Length == 0)
                {
                    return 0;
                }

                if (rangeStart[0] > rangeEnd[0])
                {
                    throw new ArgumentException("The rangeStart value must be less than or equal to the rangeEnd value.");
                }

                if (count == 0)
                {
                    return 0;
                }

                if (count + startIndex > arrayToSearch.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(count), "count + startIndex is greater than arrayToSearch.Length");
                }

                if (arrayToSearch[startIndex] >= rangeStart[0] && arrayToSearch[startIndex] <= rangeEnd[0])
                {
                    return 1 + CountElements(arrayToSearch, rangeStart, rangeEnd, startIndex + 1, count - 1);
                }

                if (arrayToSearch[startIndex] > rangeEnd[0])
                {
                    return CountElements(arrayToSearch, rangeStart[1..], rangeEnd[1..], startIndex, count);
                }

                if (arrayToSearch[startIndex] < rangeStart[0])
                {
                    return CountElements(arrayToSearch, rangeStart, rangeEnd, startIndex + 1, count - 1);
                }

                return 0;
            }
        }
    }
}
