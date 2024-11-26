// See https://aka.ms/new-console-template for more information
Console.WriteLine("Initial Setup");
int[] arrayOne = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
var resultOne = FindMaxSubarraySum(arrayOne);
Console.WriteLine($"MaxSum: {resultOne.sum}, MaxArray: [{string.Join(", ", resultOne.array)}]");

Console.WriteLine("All Negative Setup");
int[] arrayTwo = { -2, -1, -3, -4, -1, -2, -1, -5, -4 };
var resultTwo = FindMaxSubarraySum(arrayTwo);
Console.WriteLine($"MaxSum: {resultTwo.sum}, MaxArray: [{string.Join(", ", resultTwo.array)}]");

Console.WriteLine("Single Item Setup");
int[] arrayThree = { 4 };
var resultThree = FindMaxSubarraySum(arrayThree);
Console.WriteLine($"MaxSum: {resultThree.sum}, MaxArray: [{string.Join(", ", resultThree.array)}]");

(int sum, int[] array) FindMaxSubarraySum(int[] nums)
{
    // Initialize variables
    int maxSumSoFar = nums[0];
    int tempSum = 0;
    int tempStart = 0;
    int start = 0;
    int end = 0;
    for (int i = 1; i < nums.Length; i++)
    {
        // if value at index i is greater than value at index i + tempSum then update maxSoFar & shift start index to i
        if (nums[i] > nums[i] + tempSum)
        {
            tempSum = nums[i];
            tempStart = i;
        }
        else
        {
            // else add num at index i to maxSumSoFar
            tempSum += nums[i];
        }
        // update maxSum if tempSum is greater & shift start & end to retrieve sub array
        if (tempSum > maxSumSoFar)
        {
            maxSumSoFar = tempSum;
            start = tempStart;
            end = i;
        }
    }
    // retrieve & return maxSum & maxSubArray
    int[] maxSubArray = new int[end - start + 1];
    Array.Copy(nums, start, maxSubArray, 0, end - start + 1);
    return (maxSumSoFar, maxSubArray);
}
