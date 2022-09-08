public static class heap_sort_benchmark
{
    public static void basic_1(int[] read, int[] insert)
    {
        min_heap<int> A = new min_heap<int>(read);
        for (int i = 0; i < read.Length; i++)
        {
            insert[i] = A.extract_min();            
        }
    }
}