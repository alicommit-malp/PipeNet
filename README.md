# PipeNet
PipeNet in .Net core

## Usage

```c#

OrderData result = await new Pipe<OrderData>()
    .Add(new OrderNode())
    .Add(new ProducingNode())
    .Add(new CheckoutNode())
    .Run(new OrderData()
    {
        Name = "Coffee",
        State = "None",
    });


```

### Node 1 in the pipe
```c#
public class OrderNode : Node<OrderData>
{
    public override Task InvokeAsync(OrderData data)
    {
        data.State = nameof(OrderNode);
        return Task.CompletedTask;
    }
}
```

### Node 2 in the pipe
```c#
public class ProducingNode : Node<OrderData>
{
    public override Task InvokeAsync(OrderData data)
    {
        data.State = nameof(ProducingNode);
        return Task.CompletedTask;
    }
}
```

### Node 3 in the pipe
```c#
public class CheckoutNode : Node<OrderData>
{
    public override Task InvokeAsync(OrderData data)
    {
        data.State = nameof(CheckoutNode);
        return Task.CompletedTask;
    }
}
```

### Benchmark Summary

BenchmarkDotNet=v0.12.1, OS=macOS 11.2.3 (20D91) [Darwin 20.3.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.201
[Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


|            Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----------:|---------:|---------:|-------:|------:|------:|----------:|
|    RunWithPipeNet | 176.09 ns | 3.264 ns | 2.726 ns | 0.0470 |     - |     - |     296 B |
| RunWithoutPipeNet |  31.00 ns | 0.651 ns | 1.069 ns | 0.0051 |     - |     - |      32 B |

As it can be seen in the table above the PipeNet has a slight overhead, if you prefer readability over the performance so go for it :) 

