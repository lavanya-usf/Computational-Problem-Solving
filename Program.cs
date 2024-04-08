/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace Computational_Problem_Solving
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine("Uniques Values count in a given array is" + " " + numberOfUniqueNumbers);

           //Question 2:
              Console.WriteLine("Question 2:");
              int[] nums2 = { 0, 1, 0, 3, 12 };
              IList<int> resultAfterMovingZero = MoveZeroes(nums2);
              string combinationsString = (ConvertIListToArray(resultAfterMovingZero));
              Console.WriteLine("Resultant array after moving all 0's to end: " + " " + combinationsString);

            //Question 3:
             Console.WriteLine("Question 3:");
             int[] nums3 = { -1, 0, 1, 2, -1, -4 };
             IList<IList<int>> triplets = ThreeSum(nums3);
             string tripletResult = ConvertIListToNestedList(triplets);
             Console.WriteLine("Triplets: " + " " + tripletResult);

             //Question 4:
             Console.WriteLine("Question 4:");
             int[] nums4 = { 1, 1, 0, 1, 1, 1 };
             int maxOnes = FindMaxConsecutiveOnes(nums4);
             Console.WriteLine("Maximum consecutive Ones in a given array are:" + " " + maxOnes);

           //Question 5:
             Console.WriteLine("Question 5:");
             int binaryInput = 101010;
             int decimalResult = BinaryToDecimal(binaryInput);
             Console.WriteLine("Decimal Equivalent" + " " + decimalResult);

           //Question 6:
             Console.WriteLine("Question 6:");
             int[] nums5 = { 3, 6, 9, 1 };
             int maxGap = MaximumGap(nums5);
             Console.WriteLine("maximum difference:" + " " + maxGap);

           //Question 7:
             Console.WriteLine("Question 7:");
             int[] nums6 = { 2, 1, 2 };
             int largestPerimeterResult = LargestPerimeter(nums6);
             Console.WriteLine("Largest Perimeter of a triangle: " + " " +largestPerimeterResult);

            //Question 8:
             Console.WriteLine("Question 8:");
             string result = RemoveOccurrences("daabcbaabcbc", "abc");
             Console.WriteLine("String after removing all substrings: " + " " + result); 
        }

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is empty
                if (nums.Length == 0)
                {
                    return 0; // If array is empty, no duplicates found
                }
                else
                {
                    int uniqueCount = 1;
                    for (int i = 1; i < nums.Length; i++)
                    {
                        if (nums[i] != nums[i - 1]) // checks current element is not euals to previous element
                        {
                            nums[uniqueCount] = nums[i];  // If the current element is unique, move it to the next position where unique elements are stored
                            uniqueCount++;   // Increment the unique element count
                        }
                    }
                    return uniqueCount;  // return the unique elements count
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IList<int> MoveZeroes(int[] nums)
          {
              try
              {
                  int nonZeroIndex = 0; // Index to place the next non-zero element
                  for (int i = 0; i < nums.Length; i++)
                  {
                      if (nums[i] != 0)
                      {
                          nums[nonZeroIndex] = nums[i]; // Move non-zero element to the front
                          nonZeroIndex++; // Increment nonZeroIndex
                      }
                  }

                  // Fill the remaining elements with zeros
                  while (nonZeroIndex < nums.Length)
                  {
                      nums[nonZeroIndex] = 0;
                      nonZeroIndex++;
                  }

                  // Convert the modified array to IList<int> for output
                  IList<int> resultList = new List<int>(nums);
                  return resultList;
              }
              catch (Exception)
              {
                  throw;
              }
          }


        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>();

                // Sort the array to simplify the process
                Array.Sort(nums);

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicate elements
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        if (sum == 0)
                        {
                            // Found a triplet with sum = 0
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicate elements
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Check if the array is empty
                if (nums.Length == 0)
                {
                    return 0; // If the array is empty, there are no consecutive ones
                }
                else
                {
                    int consecutiveOnes = 0;
                    int maxOnes = 0;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] == 1) // If the current element is 1
                        {
                            consecutiveOnes++; // Increment the count of consecutive ones
                            maxOnes = Math.Max(maxOnes, consecutiveOnes); // Update the maximum consecutive ones found
                        }
                        else // If the current element is not 1 (i.e., 0)
                        {
                            consecutiveOnes = 0; // Reset the count of consecutive ones
                        }
                    }
                    return maxOnes; // Return the maximum consecutive ones found
                }
            }
            catch (Exception)
            {
                throw; // If an exception occurs during execution, rethrow it
            }
        }


        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalNum = 0;
                int baseValue = 1; // Represents the current position's value (1, 2, 4, 8, 16, ...)

                while (binary > 0)
                {
                    int remainder = binary % 10; // Extract the rightmost digit
                    binary /= 10; // Remove the rightmost digit
                    decimalNum += remainder * baseValue; // Add the current digit's contribution to the decimal number
                    baseValue *= 2; // Update the base value for the next position
                }

                return decimalNum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                {
                    return 0;
                }

                // Step 1: Sort the array
                Array.Sort(nums);

                // Step 2: Find the maximum difference between successive elements
                int maxDifference = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    int difference = nums[i] - nums[i - 1];
                    maxDifference = Math.Max(maxDifference, difference);
                }

                return maxDifference;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums);

                // Step 2: Iterate through the sorted array from end to beginning
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Step 3: Check if the triplet forms a valid triangle
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                    {
                        // Step 4: Return the perimeter of the valid triangle
                        return nums[i - 2] + nums[i - 1] + nums[i];
                    }
                }

                // No valid triangle found, return 0
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Loop until the substring 'part' is found in the string 's'
                while (s.Contains(part))
                {
                    // Remove the substring 'part' starting from the found index
                    int index = s.IndexOf(part);
                    s = s.Remove(index, part.Length);
                }
                return s; // returning resultant string after removing all substrings
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConvertIListToArray(IList<int> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in list)
            {
                sb.Append(item).Append(",");
            }
            sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
            sb.Append("]");
            return sb.ToString();
        }

        // Convert IList<IList<int>> to string
        public static string ConvertIListToNestedList(IList<IList<int>> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var innerList in list)
            {
                sb.Append("[");
                foreach (var item in innerList)
                {
                    sb.Append(item).Append(",");
                }
                sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
                sb.Append("],");
            }
            sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
            sb.Append("]");
            return sb.ToString();
        }

    }
}