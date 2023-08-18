using Assistant.Services;
using Assistant.View;
using Assistant.ViewModel;
using Camera.MAUI;
using CommunityToolkit.Maui;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace Assistant
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .UseMauiCommunityToolkit()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(Connectivity.Current);
            builder.Services.AddSingleton(Geolocation.Default);
            builder.Services.AddSingleton(Map.Default);

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<ProfileViewModel>();

            builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();

            builder.Services.AddSingleton<IConversationService, ConversationService>();

            


            return builder.Build();
        }
    }
}