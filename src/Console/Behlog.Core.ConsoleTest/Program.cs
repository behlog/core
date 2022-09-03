// See https://aka.ms/new-console-template for more information

using Behlog.Core;
using Behlog.Core.ConsoleTest;
using Behlog.Core.Mediator;
using Behlog.Core.Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddMediator();
services.AddMediatorMiddleware();

var container = services.BuildServiceProvider();
var mediator = container.GetService<IMediator>();

// var mycmd = new MyCommand("iman");
// await mediator.HandleAsync(mycmd);

var _event = new MyEvent();
mediator.PublishAsync(_event);

Console.Read();

