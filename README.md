# Pipe.Net
Pipe line in .Net core (Chain of responsibility) 

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
