// implementations of insertion sort.
public static class insertion_sort
{
    public static void sort_swaps_0(int[] source)
    /* 
    The thing is that inside the while there are three constant operations.
    */
    {
        for (int i = 1; i < source.Length; i++) // n-1 iterations, so O(n)
        {
            int j = i;
            // the array from position 0 to j-1 is sorted always, so now insert source[i] in that array, keeping it sorted.
            while((j > 0) && (source[j-1] > source[j]) ) 
            // has to go from i-1 to 0, checking, in each check, it compares and after that do the swap.
            {                
                int temp = source[j-1];
                source[j-1] = source[j];
                source[j] = temp;
                j--;
            }
        }
    }
    public static void sort_swaps_1(int[] read, int[] insert)
    /* this sort is designed to benchmark, the thing about benchmarking is that we take an array as example, and we call the function sort a lot of times with that array (average execution time), but if the function works with the same array, first time function will sort the array, but after that, the function will work with the same sorted array, so recommended solution https://stackoverflow.com/questions/73108219/confused-about-complexity-of-insertion-sort-and-benchmark?noredirect=1#comment129120562_73108219 is read from original array and insert in other array, this will not destroy the original array.
    */ 
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
    public static void sort_binary_search_0(int[] source)
    {
        for (int i = 1; i < source.Length; i++) // n-1 iterations, so O(n)
        {
            // the array from position 0 to j-1 is sorted always, so now insert source[i] in that array, keeping it sorted.
            // binary search to insert source[i] in correct position.
            // find index where to insert, and after that shift indexes.
            
        }        
    }

}

public class insertion{
    public static void Main()
    {
        int[] test_sort = new int[10] {1,3,2,52,4,3,5,6,4,6};
        int[] sorted = new int[10];
        //insertion_sort.sort_swaps_0(test_sort);
        insertion_sort.sort_swaps_1(test_sort, sorted);
        foreach (int num in test_sort)
        {
            Console.Write(" " + num + " ");
        }
        Console.WriteLine("");
        foreach (int num in sorted)
        {
            Console.Write(" " + num + " ");
        }        
    }
}
