using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string fileName = Environment.CurrentDirectory + @"\log.txt";
            using (StreamWriter sw = new StreamWriter(fileName))
            {


                List<int> numbers = new List<int>();
                List<int> foundSearches = new List<int>();
                List<int> unfoundSearches = new List<int>();
                int found = 0;
                int unfound = 0;
                int total_n_member = 0;
                int total_n_not_member = 0;
                double total_seq_cmp_member = 0;
                double total_seq_cmp_not_member = 0;
                double total_bin_cmp_member = 0;
                double total_bin_cmp_not_member = 0;




                //Run a 100 sample of test cases
                for (int i = 0; i < 100; i++)
                {
                    numbers.Clear();

                    //Generate n numbers as the sample size for each test case 
                    //n ranges from 1 - 49 where n is an odd number
                    int n = random.Next(1, 50);
                    if (n % 2 == 0)
                        n++;
                    //Generate n random numbers 
                    for (int j = 0; j < n; j++)
                    {
                        //Numbers range from 1 to n
                        int val = random.Next(1, n + 1);
                        numbers.Add(val);
                    }
                    //sort the numbers
                    numbers.Sort();
                    //Generate a number x between 1 to n and search for it
                    int x = random.Next(1, n + 1);

                    //Convert the list of numbers to an array of numbers
                    int[] arr = new int[n];
                    arr = numbers.ToArray();
                    sw.WriteLine("Sorted Array");
                    for (int k = 0; k < arr.Length; k++)
                    {
                        sw.Write(arr[k] + " ");
                    }
                    sw.WriteLine();

                    SearchArray searchArray = new SearchArray(arr, x);
                    int bin_comp = searchArray.binarySearchComparisons();
                    int seq_com = searchArray.SeqSearchComparisons();
                    sw.WriteLine("Parameters:      \t" + "n\t" + "x\t" + "comparisons");

                    if (numbers.Contains(x))
                    {
                        found++;
                        total_n_member += n;
                        total_seq_cmp_member += seq_com;
                        total_bin_cmp_member += bin_comp;

                    }
                    else
                    {
                        unfound++;
                        total_n_not_member += n;
                        total_seq_cmp_not_member += seq_com;
                        total_bin_cmp_not_member += bin_comp;
                    }

                    sw.WriteLine("Sequetial Search:\t" + n + "\t" + x + "\t" + searchArray.SeqSearchComparisons());
                    sw.WriteLine("Binary Search:    \t" + n + "\t" + x + "\t" + searchArray.binarySearchComparisons());
                    sw.WriteLine();
                }
                sw.WriteLine();
                sw.WriteLine("Summary");
                sw.WriteLine("Total Run:\t" + "100");
                sw.WriteLine("Found:  \t" + found);
                sw.WriteLine("UnFound: \t" + unfound);
                sw.WriteLine();
                sw.WriteLine("Average Case Analysis of Sequential Search");
                sw.WriteLine();

                sw.WriteLine("Assumption:      \t" + "n(Avg)" + "\t" + "Avg.Comparison");
                sw.WriteLine("Member of:       \t" + (total_n_member / found) + " \t" + (total_seq_cmp_member) / found);
                sw.WriteLine("Not Member of:       \t" + (total_n_not_member / unfound) + " \t" + (total_seq_cmp_not_member) / unfound);

                sw.WriteLine();
                sw.WriteLine("Average Case Analysis of Binary Search");
                sw.WriteLine();
                sw.WriteLine("Assumption:      \t" + "n(Avg)" + "\t" + "Avg.Comparison");
                sw.WriteLine("Member of:       \t" + (total_n_member / found) + " \t" + total_bin_cmp_member / found);
                sw.WriteLine("Not Member of:       \t" + (total_n_not_member / unfound) + " \t" + total_bin_cmp_not_member / unfound);

            }
        }
}
}
