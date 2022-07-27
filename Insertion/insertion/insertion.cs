// implementations of insertion sort.
public static class insertion_sort
{
    public static void swaps_0(int[] source)
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
    public static void swaps_2<T>(T[] source) where T : IComparable<T>
    //Esto significa que este metodo funcionara para todo tipo T tal que implemente el metodo CompareTo() con objetos de su mismo tipo
    {
        for (int i = 1; i < source.Length; i++)
        {
            int j = i;
            while((j > 0) && (source[j-1].CompareTo(source[j]) > 0))
            //Por convenio, decir que a.CompareTo(b) > 0 es analogo a decir a > b 
            {                
                T temp = source[j-1];
                source[j-1] = source[j];
                source[j] = temp;
                j--;
            }
        }
    }

    public static void binary_search_0(int[] source)
    {
        for (int i = 1; i < source.Length; i++) // n-1 iterations, so O(n)
        {
            // the array from position 0 to j-1 is sorted always, so now insert source[i] in that array, keeping it sorted.
            // binary search to insert source[i] in correct position.
            // find index where to insert, and after that shift indexes.
            int lookup = source[i];
            int left = 0;
            int right = i-1;
            int mid = 0;
            int pos = 0;
            while(left < right)
            {
                mid = (left+right)/2;
                if(source[mid] == lookup)
                {
                    pos = mid;
                    break;
                }
                else if(source[mid] < lookup)
                {
                    left = mid+1;
                }
                else 
                {
                    right = mid-1;
                }
                pos = right;    
            }
            if (lookup > source[pos])
            // this happens inserting 15 into 2 3 6 8
            {
                pos = pos+1;
            }
            for (int j = i; j >= pos+1; j--)
            {
                source[j] = source[j-1];
            }
            source[pos] = lookup;
        }        
    }

}

public class insertion{
    public static void Main()
    {
        int[] test_sort = new int[10] {1,2,2,2,4,3,90,90,91,600};
        int[] sorted = new int[10];
        //insertion_sort.binary_search_0(test_sort);
        //insertion_sort.binary_search_0(test_sort, sorted);
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
