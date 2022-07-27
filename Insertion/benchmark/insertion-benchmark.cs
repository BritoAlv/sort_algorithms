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
            while((j > 0) && (insert[j-1] > insert[j]) ) 
            // has to go from i-1 to 0, checking, in each check, it compares and after that do the swap.
            {                
                int temp = insert[j-1];
                insert[j-1] = insert[j];
                insert[j] = temp;
                j--;
            }
        }
    }

    public static void swaps_3<T>(T[] read, T[] insert) where T:IComparable<T>  
    {
        for (int i = 0; i < read.Length; i++)
        {
            insert[i] = read[i]; // this increase constant time only.
            int j = i;
            // the array from position 0 to j-1 is sorted always, so now insert
            // source[i] in that array, keeping it sorted.
            while((j > 0) && (insert[j-1].CompareTo(insert[j]) >0 )) 
            // has to go from i-1 to 0, checking, in each check, it compares and after that do the swap.
            {                
                T temp = insert[j-1];
                insert[j-1] = insert[j];
                insert[j] = temp;
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
            int l = 0;
            int r = i-1;
            int mid = 0;
            while(r-l > 1)
            // as long as l-r > 1 we ensure that l < r and that mid is inside
            {
                mid = (l+r)/2;
                if( insert[mid] == insert[i])
                {
                    l = mid;
                    r = mid;
                }
                else if ( insert[mid] > insert[i])
                {
                    r = mid-1;
                }
                else
                {
                    l = mid+1;
                }
            }
            // we have either l = r or r = l+1 bases cases of recursivity.
            int pos;
            if (insert[i] <= insert[l])
            {
                pos = l; //
            }
            else if(insert[i] > insert[r] )
            {
                pos = r+1; // 
            }
            else
            {
                pos = r;
            }
            int temp = insert[i];
            // shift process
            for (int j = i; j >= pos+1; j--)
            {
                insert[j] = insert[j-1];
            }
            insert[pos] = temp;
        }        
    }
    public static void binary_search_3<T>(T[] read, T[] insert) where T:IComparable<T>
    {
        insert[0] = read[0];
        for (int i = 1; i < read.Length; i++)
        {
            insert[i] = read[i];
            int l = 0;
            int r = i-1;
            int mid = 0;
            while(r-l > 1)
            // as long as l-r > 1 we ensure that l < r and that mid is inside
            {
                mid = (l+r)/2;
                if( insert[mid].CompareTo(insert[i]) == 0)
                {
                    l = mid;
                    r = mid;
                }
                else if ( insert[mid].CompareTo(insert[i]) > 0)
                {
                    r = mid-1;
                }
                else
                {
                    l = mid+1;
                }
            }
            // we have either l = r or r = l+1 bases cases of recursivity.
            int pos;
            if (insert[i].CompareTo(insert[l]) <= 0)
            {
                pos = l; //
            }
            else if(insert[i].CompareTo(insert[r]) > 0 )
            {
                pos = r+1; // 
            }
            else
            {
                pos = r;
            }
            T temp = insert[i];
            // shift process
            for (int j = i; j >= pos+1; j--)
            {
                insert[j] = insert[j-1];
            }
            insert[pos] = temp;
        }        
    }                 
}
