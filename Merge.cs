using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Merge
{
	static int MAXVALUE = 50000;
	static int MINVALUE = -50000;
	static int MININPUT = 1;
	static int MAXINPUT = Convert.ToInt32(Math.Pow(2, 10));
	static int numberOfTrials = 10000;
	Random random = new Random();


	static string resultsFolderPath = "C:\\Users\\Adria\\School Stuff\\CSC482\\Lab4";
	public int[] Sort(int[] arrayToSort)
    {
        int[] left;
        int[] right;
        int[] result = new int[arrayToSort.Length];

        if(arrayToSort.Length <= 1)
        {
            return arrayToSort;
        }

        int midPoint = arrayToSort.Length / 2;
        left = new int[midPoint];

        if(arrayToSort.Length % 2 == 0)
        {
            right = new int[midPoint];
        }
        else
        {
            right = new int[midPoint + 1];
        }

        for(int i = 0; i < midPoint; i++)
        {
            left[i] = arrayToSort[i];
        }

        int x = 0;

        for(int i = midPoint; i < arrayToSort.Length; i++)
        {
            right[x] = arrayToSort[i];
            x++;
        }

        left = Sort(left);
        right = Sort(right);
        result = Combine(left, right);
        return result;
    }

    public int[] Combine(int[] left, int[] right)
    {
        int resultLength = right.Length + left.Length;
        int[] result = new int[resultLength];

        int indexLeft = 0, indexRight = 0, indexResult = 0;

        while(indexLeft < left.Length || indexRight < right.Length)
        {
            if(indexLeft < left.Length && indexRight < right.Length)
            {
                if(left[indexLeft] <= right[indexRight])
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
					indexResult++;
                }
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            else if(indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else if(indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }
        return result;
    }

	public int[] CreateRandomListOfInts(int size)
	{
		
		int[] newList = new int[size];
		for (int i = 0; i < size; i++)
		{
			newList[i] = random.Next(MINVALUE, MAXVALUE);
		}
		return newList;
	}

	public void checkSortCorrect()
	{
		Console.WriteLine("Testing merge sort...");

		int[] testList1 = CreateRandomListOfInts(5);

		Console.WriteLine("Test list 1 pre sort:");
		foreach (int x in testList1)
		{
			Console.Write("{0} ", x);
		}
		Console.WriteLine();

		int[] sortedList1 = Sort(testList1);

		Console.WriteLine("Sorted list 1:");
		foreach (int y in sortedList1)
		{
			Console.Write("{0} ", y);
		}
		Console.WriteLine();

		int[] testList2 = CreateRandomListOfInts(10);

		Console.WriteLine("Test list 2 pre sort:");
		foreach (int x in testList2)
		{
			Console.Write("{0} ", x);
		}
		Console.WriteLine();

		int[] sortedList2 = Sort(testList2);

		Console.WriteLine("Sorted list 2:");
		foreach (int y in sortedList2)
		{
			Console.Write("{0} ", y);
		}
		Console.WriteLine();

		int[] testList3 = CreateRandomListOfInts(15);

		Console.WriteLine("Test list 3 pre sort:");
		foreach (int x in testList3)
		{
			Console.Write("{0} ", x);
		}
		Console.WriteLine();

		int[] sortedList3 = Sort(testList3);

		Console.WriteLine("Sorted list 3:");
		foreach (int y in sortedList3)
		{
			Console.Write("{0} ", y);
		}
		Console.WriteLine();

	}

	public void RunFullMerge(string resultFile)
	{
		Stopwatch stopwatch = new Stopwatch();

		double previousTime = 0;
		double doubleRatio = 0;
		Console.WriteLine("Input Size\tAvg Time (ns)\tDoubling Ratio");

		for (int inputSize = MININPUT; inputSize <= MAXINPUT; inputSize += inputSize)
		{
			double nanoSecs = 0;

			//System.GC.Collect();

			for (long trial = 0; trial < numberOfTrials; trial++)
			{
				int[] testList = CreateRandomListOfInts(inputSize);
				stopwatch.Restart();
				Sort(testList);
				stopwatch.Stop();
				nanoSecs += stopwatch.Elapsed.TotalMilliseconds * 1000000;

			}
			double averageTrialTime = nanoSecs / numberOfTrials;

			if (previousTime > 0)
			{
				doubleRatio = averageTrialTime / previousTime;
			}
			previousTime = averageTrialTime;

			Console.WriteLine("{0,-10} {1,16} {2,10:N2}", inputSize, averageTrialTime, doubleRatio);

			using (StreamWriter outputFile = new StreamWriter(Path.Combine(resultsFolderPath, resultFile), true))
			{
				outputFile.WriteLine("{0,-10} {1,16} {2,10:N2}", inputSize, averageTrialTime, doubleRatio);
			}
		}
	}
}