namespace Behlog.Core.ConsoleTest;

public class MyCommand : ICommand
{
    public MyCommand(string title)
    {
        Title = title;
    }
    
    public string Title { get; }
}

public class MyCommandResult
{
    public string Message { get; set; }
}

public class MyCommandWithResult : ICommand<MyCommandResult>
{
    public MyCommandWithResult(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}

public class MyCommandHandler : ICommandHandler<MyCommand>
{
    
    public async Task HandleAsync(MyCommand message, CancellationToken cancellationToken)
    {
        
        Console.WriteLine($"Hello from '{message.Title}'");
    }
}

public class MyCommandWithResultHandler : ICommandHandler<MyCommandWithResult, MyCommandResult>
{
    
    public async Task<MyCommandResult> HandleAsync(
        MyCommandWithResult message, 
        CancellationToken cancellationToken)
    {
        var result = $"Hello, {message.Name}. Welcome to my world.";

        return new MyCommandResult { Message = result };
    }
}