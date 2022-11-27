namespace DatabaseBenchmark;

public class BenchmarkResultModel
{
    public ConcreteResultModel Regular { get; set; }
    public ConcreteResultModel Parallel { get; set; }
    public ConcreteResultModel TplRegular { get; set; }
    public ConcreteResultModel TplParallel { get; set; }

}

public class ConcreteResultModel
{
    public long TwentyRows { get; set; }
    public long HundredThousandsRows { get; set; }
}
