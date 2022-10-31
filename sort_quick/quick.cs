public class quick_sort
{
    public static void basic_0(int[] A, int start, int end)
    {
        Random x = new Random();
        void swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        int partition(int[] A, int start, int end)
        {
            int pivot = x.Next(start, end+1); // generate a random position to select pivot.
            int final_position = start; // final position where will end the pivot
            for (int i = start; i <= end; i++)
            {
                if( A[i] < A[pivot] )
                {
                    swap(A , i , final_position);
                    final_position++;
                }   
            }
            swap(A, final_position, pivot);
            return final_position;
        }
        void quick_sort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int p = partition(A, start, end);
                quick_sort(A, start, p-1);
                quick_sort(A, p+1, end);
            }
        }

        quick_sort(A, start, end);        


    }
    public static void Main()
    {
        int[] test_sort = random_utils.generate_array(1000);
        quick_sort.basic_0(test_sort, 0, test_sort.Length-1);
        foreach (int num in test_sort)
        {
            Console.WriteLine(" " + num + " ");
        } 

         
    }
}
