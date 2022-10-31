using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

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
    //[Params(1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000)]
    [Params(1)]
    public int size { get; set; }
    [Benchmark]
    public void quick_sort_1()
    {
        int[] array_sort = random_utils.generate_array(size);
        quick_sort.basic_0(array_sort, 0, size - 1);
    }

    /*     [Benchmark]
        public void merge_sort_1()
        {
            int[] array_sort = random_utils.generate_array(size);
            merge_sort.basic_0(array_sort, 0, size - 1);
        }

        [Benchmark]
        public void insertion_sort_1()
        {
            int[] array_sort = random_utils.generate_array(size);
            insertion_sort.basic_0(array_sort);
        }

        [Benchmark]
        public void insertion_sort_2()
        {
            int[] array_sort = random_utils.generate_array(size);
            insertion_sort.basic_1(array_sort);
        }

        [Benchmark]
        public void heap_sort_1()
        {
            int[] array_sort = random_utils.generate_array(size);
            heap_sort.basic_0(array_sort);
        } */

    public static void Main()
    {
        BenchmarkRunner.Run<benchmark>();
    }

}