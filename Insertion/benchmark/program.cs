using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class benchmark
{
    public int[] array_to_sort0;
    public matriz_cuadrada[] array_to_sort1;
    public int[] container0;
    public matriz_cuadrada[] container1;
    [Params(100)]
    public int size {get; set ;}
    [GlobalSetup]
    public void Setup()
    {
        array_to_sort0 = random_utils.generate_array(size);
        container0 = new int[size]; 
        array_to_sort1 = matriz_cuadrada.generate_array(size);
        container1 = new matriz_cuadrada[size];
    }
    [Benchmark]
    public void swap_3() => insertion_sort_benchmark.swaps_3(array_to_sort1, container1);
    [Benchmark]
    public void binary_search_3() => insertion_sort_benchmark.binary_search_3(array_to_sort1, container1);
  [Benchmark]
    public void swap_1() => insertion_sort_benchmark.swaps_1(array_to_sort0, container0);
    [Benchmark]
    public void binary_search_1() => insertion_sort_benchmark.binary_search_1(array_to_sort0, container0);    

}
public static class program
{
    public static void Main()
    {
    	BenchmarkRunner.Run<benchmark>();
/*     	int[] array_to_sort = random_utils.generate_array(1000);
    	int[] container = new int[1000];
    	insertion_sort_benchmark.binary_search_1(array_to_sort, container);
     	foreach(int num in array_to_sort)
    	{
	    Console.WriteLine(" " + num + " ");    	
    	}
         Console.WriteLine(" ");
    	foreach(int num in container)
    	{
	    Console.WriteLine(" " + num + " ");    	
    	}     	 */

    }
}
