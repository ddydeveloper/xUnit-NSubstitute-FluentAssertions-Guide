using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MortgageAdviser.Services;

namespace MortgageAdviser
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton<ILoanInterestService, LoanInterestService>();
                    services.AddSingleton<IPersonValidatorService, PersonValidatorService>();
                    services.AddSingleton<IMortgageService, MortgageService>();
                    services.AddSingleton<ILoanInterestService, LoanInterestService>();
                    services.AddHostedService<Worker>();
                });
        }
    }
}