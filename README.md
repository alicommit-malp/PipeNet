# PipeNet
PipeNet in .Net core

## Usage

```c#

OrderData result= await new Pipe<OrderData>()
    .Next(new OrderNode())
    .Next(new ProducingNode())
    .Finally(new CheckoutNode())
    .Execute(new OrderData()
    {
        Name = "Coffee",
        State = this.GetType().Name, 
    });


```

### Node 1 in the pipe
```c#
public class OrderNode : Node<OrderData>
{
    public override async Task<OrderData> Execute(OrderData param)
    {
        param.State = GetType().Name;
        return await base.Execute(param);
    }
}
```

### Node 2 in the pipe
```c#
public class ProducingNode : Node<OrderData>
{
    public override async Task<OrderData> Execute(OrderData param)
    {
        param.State = GetType().Name;
        return await base.Execute(param);
    }
}
```

### Node 3 in the pipe
```c#
public class CheckoutNode : Node<OrderData>
{
    public override async Task<OrderData> Execute(OrderData param)
    {
        param.State = GetType().Name;
        return await base.Execute(param);
    }
}
```

### Benchmark Summary

BenchmarkDotNet=v0.12.1, OS=macOS 11.2.3 (20D91) [Darwin 20.3.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.201
[Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


|               Method |     Mean |   Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |---------:|--------:|---------:|-------:|------:|------:|----------:|
|       WithPipeNet | 221.3 ns | 4.37 ns | 10.87 ns | 0.0713 |     - |     - |     448 B |
| RunWithoutPipeNet | 218.0 ns | 4.41 ns | 10.90 ns | 0.0892 |     - |     - |     560 B |



