using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithms
{
    class SearchArray
    {
        //Declare class variable which is an array of any data type

        private int[] arr;
        private int key;
        public SearchArray(int[] arr, int key)
        {
            this.arr = arr;
            this.key = key;
        }

        public int binarySearch()
        {
            int low = 0;
            int high = arr.Length;
            Array.Sort(arr);

            while (low < high)
            {

                int mid = (high + low) / 2;  //compute the mid index

                if (arr[mid] == key)  //if the mid element matches the key, return the index
                    return mid;

                //look to the right - upper region if the middle element is less
                //than the search key
                else if (arr[mid] < key)
                    low = mid + 1;

                //the only place the key can be found is the lower region
                else
                    high = mid - 1;
            }

            return -1;
        }



        public int sequentialSearch()
        {
            Array.Sort(arr);
            int len = arr.Length;
            if (len == 0 || key < arr[0] || key > arr[len - 1])  //array is empty or the element is not found
                return -1;
            for (int i = 0; i < len; i++)
            {
                if (arr[i] == key)
                    return i;
            }
            return -1;
        }

        public int SeqSearchComparisons()
        {
            int count = 0;
            int len = arr.Length;
            if (len == 0)  //array is empty
                return 0;
            if (key < arr[0] || key > arr[len - 1]) // if the element does not exist, it should only take one comparison since the array is sorted
                return 1;
            for (int i = 0; i < len; i++)
            {
                count++;
                if (arr[i] == key)
                    return count;
            }
            //array will search all the elements if the number to be found is missing and it is in the range 1-n
            return count;
        }

        public int binarySearchComparisons()
        {
            int count = 0;
            int low = 0;
            int high = arr.Length;
            Array.Sort(arr);

            while (low < high)
            {
                count++;
                int mid = (high + low) / 2;  //compute the mid index

                if (arr[mid] == key)  //if the mid element matches the key, return the index
                                      //  return mid;
                    return count;

                //look to the right - upper region if the middle element is less
                //than the search key
                else if (arr[mid] < key)
                    low = mid + 1;

                //the only place the key can be found is the lower region
                else
                    high = mid - 1;
            }

            return count;
        }

    }
}
