/* this sort is designed to benchmark, the thing about benchmarking is that we take an array as example, and we call the function sort a lot of times with that array (average execution time), but if the function works with the same array, first time function will sort the array, but after that, the function will work with the same sorted array, so recommended solution https://stackoverflow.com/questions/73108219/confused-about-complexity-of-insertion-sort-and-benchmark?noredirect=1#comment129120562_73108219 is read from original array and insert in other array, this will not destroy the original array.
*/
public static class merge_sort_benchmark
{
    // becnhmark s resul show that this is (nlgn), time in ns, constant = 12.
    public static void basic_1(List<int> read, List<int> insert, int start, int end)  
    // start and end both included.
    {
        if (start < end)
        {
            // sort halve of the array using recursion
            basic_1(read, insert,  start, (start+end)/2);  
            basic_1(read, insert, (start+end)/2+1, end );

            // join halves using two-finger-algorithm
            List<int> result = new List<int>(end-start+1);
            int finger1 = start;
            int finger2 = (start+end)/2+1;
            while (finger1 <= (start+end)/2 && finger2 <= end)
            {
                if(read[finger1] <  read[finger2])
                {
                    result.Add(read[finger1]);
                    finger1 = finger1 + 1;
                }
                else
                {
                    result.Add(read[finger2]);
                    finger2 = finger2 + 1;
                }                
            }

            // when this process ends there are two options either finger1 = finger2 or finger2 = end but not both happen at the same time.
            while (finger1 <= (start+end)/2)
            {
                result.Add(read[finger1]);
                finger1 = finger1 + 1;
            }
            while (finger2 <= end)
            {
                result.Add(read[finger2]);
                finger2 = finger2 + 1;
            }
            for (int i = start; i <= end; i++)
            {
                insert[i] = result[i-start];
            }            
        }    
    }                         
}
