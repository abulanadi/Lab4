using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	class Program
	{
		static void Main(string[] args)
		{
			Insertion insertion = new Insertion();
			NaiveQuick naiveQuick = new NaiveQuick();
			Merge merge = new Merge();
			Bubble bubble = new Bubble();
			Quick quick = new Quick();

			/*naiveQuick.checkSortCorrect();
			Console.WriteLine();
			insertion.checkSortCorrect();
			Console.WriteLine();
			merge.checkSortCorrect();
			Console.WriteLine();
			bubble.checkSortCorrect();
			Console.WriteLine();
			quick.checkSortCorrect();*/
			//bubble.RunFullBubble("BubbleTest1.txt");
			//naiveQuick.RunFullNaiveQuick("NaiveQuickTest2.txt");
			//merge.RunFullMerge("MergeTest2.txt");
			//quick.RunFullQuick("QuickTest1.txt");
			//insertion.RunFullInsertion("InsertionTest1.txt");
			//naiveQuick.RunFullNaiveQuickSorted("NaiveSorted.txt");
			//quick.RunFullQuickSorted("QuickSorted.txt");
		}
	}
}
