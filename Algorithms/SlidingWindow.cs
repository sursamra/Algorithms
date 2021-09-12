using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
  public class SlidingWindow
  {

    //            0 , 1,  2 , 3 , 4 , 5 , 6 , 7 , 8 , 9
    int[] arr = { 4 , 2 , 1 , 7 , 8 , 1 , 2 , 8 , 1 , 0 };
    public static int findMaxSumArray(int[] arr, int k)
    {
      int maxValue = int.MinValue;
      int currentRunningSum = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        currentRunningSum += arr[i];
        if (i >= k - 1) // work on window 1. wait for its size 2. maintain it
        {
          maxValue = Math.Max(maxValue, currentRunningSum);
          currentRunningSum -= arr[i - (k - 1)];

        }
      }
      return maxValue;
    }

    //             0  , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 
    //int[] arr = {4  , 2 , 2 , 7 , 8 , 1 , 2 , 8 , 10}
    public static int findSmallestSubarray(int[] arr,int targetSum )
    {
      int minWindowSize = int.MaxValue;
      int currentWindowSum = 0;
      int windowStart = 0;
      for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
      {
        currentWindowSum += arr[windowEnd];
        while (currentWindowSum >= targetSum)
        {
          minWindowSize = Math.Min(minWindowSize, windowEnd - windowStart + 1);
          currentWindowSum -= arr[windowStart];
          windowStart++;
        }
      }
      return minWindowSize == int.MaxValue ? 0 : minWindowSize;
    }
  
    
  }
}
