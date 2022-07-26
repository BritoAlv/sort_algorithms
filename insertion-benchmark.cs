/* this sort is designed to benchmark, the thing about benchmarking is that we take an array as example, and we call the function sort a lot of times with that array (average execution time), but if the function works with the same array, first time function will sort the array, but after that, the function will work with the same sorted array, so recommended solution https://stackoverflow.com/questions/73108219/confused-about-complexity-of-insertion-sort-and-benchmark?noredirect=1#comment129120562_73108219 is read from original array and insert in other array, this will not destroy the original array.
*/
public static class insertion_sort_benchmark
{
    public static void swaps_1(int[] read, int[] insert)

  
    {
        for (int i = 0; i < read.Length; i++)
        {
            insert[i] = read[i]; // this increase constant time only.
            int j = i;
            // the array from position 0 to j-1 is sorted always, so now insert
            // source[i] in that array, keeping it sorted.
            while((j > 0) && (read[j-1] > read[j]) ) 
            // has to go from i-1 to 0, checking, in each check, it compares and after that do the swap.
            {                
                int temp = read[j-1];
                read[j-1] = read[j];
                read[j] = temp;
                j--;
            }

        }
    }

    public static void binary_search_1(int[] read, int[] insert)
    {
        insert[0] = read[0];
        for (int i = 1; i < read.Length; i++)
        {
            insert[i] = read[i];
            int lookup = read[i];
            int left = 0;
            int right = i-1;
            int mid = 0;
            int pos = 0;
            while(left < right)
            {
                mid = (left+right)/2;
                if(read[mid] == lookup)
                {
                    pos = mid;
                    break;
                }
                else if(read[mid] < lookup)
                {
                    left = mid+1;
                }
                else 
                {
                    right = mid-1;
                }
                pos = right;    
            }
            if (lookup > read[pos])
            // this happens inserting 15 into 2 3 6 8
            {
                pos = pos+1;
            }
            for (int j = i; j >= pos+1; j--)
            {
                read[j] = read[j-1];
            }
            read[pos] = lookup;
        }        
    }            
}
