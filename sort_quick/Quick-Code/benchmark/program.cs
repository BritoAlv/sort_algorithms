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
    [Params(10, 100, 1000, 10000, 20000, 30000, 40000, 50000 , 100000, 1000000, 10000000, 20000000)]
    public int size {get; set ;}
    [GlobalSetup]
    public void Setup()
    {
        array_to_sort0 = random_utils.generate_array(size);
        container0 = new int[size]; 
    }
    [IterationSetup]
    public void IterationSetup()
    {
        container0 = (int[])array_to_sort0.Clone();
    }
    
    [Benchmark]
    public void quick_sort_1()
    {
        container0 = (int[])array_to_sort0.Clone();
        quick_sort_benchmark.quick_sort(container0, 0, array_to_sort0.Length-1);
    }
}
public static class program
{
    public static void Main()
    {
    	BenchmarkRunner.Run<benchmark>();
     	/*int[] array_to_sort = random_utils.generate_array(1000);
    	int[] container = new int[1000];
    	quick_sort_benchmark.quick_sort(array_to_sort, 0, 999);
     	foreach(int num in array_to_sort)
    	{
	       Console.WriteLine(" " + num + " ");    	
    	} */  	 

    }
}

