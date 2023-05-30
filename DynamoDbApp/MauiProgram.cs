using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using CommunityToolkit.Maui;
using DynamoDbApp.Repositories;
using DynamoDbApp.UI.Views.Login;
using DynamoDbApp.UI.Views.Register;
using Microsoft.Extensions.Logging;

namespace DynamoDbApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var region = RegionEndpoint.USEast1;
            var credentials = new BasicAWSCredentials(
                        accessKey: "INSERT YOUR ACCESS KEY HERE",
                        secretKey: "INSERT YOUR SECRET KEY HERE");
            builder.Services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(credentials, region));
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterViewModel>();

            return builder.Build();
        }
    }
}




