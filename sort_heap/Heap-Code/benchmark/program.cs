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
    public int[] list_to_sort0;
    // public matriz_cuadrada[] array_to_sort1;
    public int[] container0;
    // public matriz_cuadrada[] container1;
    [Params(10000,100000, 200000, 1000000)]
    public int size {get; set ;}
    [GlobalSetup]
    public void Setup()
    {
        list_to_sort0 = random_utils.generate_array(size);
        container0 = (new int[size]); 
        //array_to_sort1 = matriz_cuadrada.generate_array(size);
        //container1 = new matriz_cuadrada[size];
    }
    
    [Benchmark]
    public void heap_1() => heap_sort_benchmark.basic_1(list_to_sort0, container0);
}
public static class program
{
    public static void Main()
    {
    	BenchmarkRunner.Run<benchmark>();

     	/* List<int> list_to_sort = random_utils.generate_array(1000).ToList();
    	List<int> container = (new int[1000]).ToList();
    	merge_sort_benchmark.basic_1(list_to_sort, container, 0, list_to_sort.Count-1);
     	foreach(int num in list_to_sort)
    	{
	    Console.WriteLine(" " + num + " ");    	
    	}
         Console.WriteLine(" ");
    	foreach(int num in container)
    	{
	    Console.WriteLine(" " + num + " ");    	
    	}     	  */

    }
}

