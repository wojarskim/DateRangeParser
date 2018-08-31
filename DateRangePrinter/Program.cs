using Microsoft.Extensions.DependencyInjection;

namespace DateRangePrinter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDateRangeService, DateRangeService>()
                .AddSingleton<IInputArgumentsService, InputArgumentsService>()
                .AddSingleton<IDateRangePrinter, DateRangeConsolePrinter>()
                .BuildServiceProvider();

            var dateRangePrinter = serviceProvider.GetService<IDateRangePrinter>();
            dateRangePrinter.Run(args);
        }

        //windows build exe
        //dotnet publish -c Release -r win10-x64
    }
}