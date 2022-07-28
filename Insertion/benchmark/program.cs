using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Columns;

public class config : ManualConfig
{
    public CsvExporter exporter = new CsvExporter(
    CsvSeparator.CurrentCulture,
    new SummaryStyle(
        cultureInfo: System.Globalization.CultureInfo.CurrentCulture,
        printUnitsInHeader: true,
        printUnitsInContent: false,
        timeUnit: Perfolizer.Horology.TimeUnit.Microsecond,
        sizeUnit: SizeUnit.B
    ));
    public config()
    {
        AddExporter(exporter);
    }
}

[Config(typeof(config))]
[MemoryDiagnoser]
public class benchmark
{
    public int[] array_to_sort0;
    public matriz_cuadrada[] array_to_sort1;
    public int[] container0;
    public matriz_cuadrada[] container1;
    [Params(1000,2000,3000,4000,5000,6000,7000,8000,9000,10000)]
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
    public void binary_search_1() => insertion_sort_benchmark.binary_search_1(array_to_sort0, container0);
/*
    [Benchmark]
    public void binary_search_3() => insertion_sort_benchmark.binary_search_3(array_to_sort1, container1);
    [Benchmark]
    public void swap_1() => insertion_sort_benchmark.swaps_1(array_to_sort0, container0);
    [Benchmark]
    public void binary_search_1() => insertion_sort_benchmark.binary_search_1(array_to_sort0, container0);    
*/
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

