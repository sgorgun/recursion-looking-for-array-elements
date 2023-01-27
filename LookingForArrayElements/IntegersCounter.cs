using System;
using System.Xml.Linq;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor)
        {
            return CountElements(arrayToSearch!, elementsToSearchFor!);

            static int CountElements(int[] array, int[] elements)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array), "array is empty");
                }

                if (elements is null)
                {
                    throw new ArgumentNullException(nameof(elements), "elements is empty");
                }

                if (array.Length == 0)
                {
                    return 0;
                }

                int count = elements.Contains(array[0]) ? 1 : 0;
                return count + CountElements(array[1..], elements);
            }
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified elements and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting elements of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor, int startIndex, int count)
        {
            return CountElements(arrayToSearch!, elementsToSearchFor!, startIndex, count);

            static int CountElements(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
            {
                if (arrayToSearch == null)
                {
                    throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch is empty");
                }

                if (elementsToSearchFor == null)
                {
                    throw new ArgumentNullException(nameof(elementsToSearchFor), "elementsToSearch is empty");
                }

                if (startIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
                }

                if (startIndex > arrayToSearch.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
                }

                if (count < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
                }

                if (startIndex + count > arrayToSearch.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
                }

                if (count == 0)
                {
                    return 0;
                }

                int countElements = elementsToSearchFor.Contains(arrayToSearch[startIndex]) ? 1 : 0;
                return countElements + CountElements(arrayToSearch, elementsToSearchFor, startIndex + 1, count - 1);
            }
        }
    }
}
