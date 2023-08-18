using Assistant.Model;
using Assistant.Services;
using Assistant.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;

namespace Assistant.ViewModel;
public partial class HomePageViewModel : BaseViewModel
{
    private readonly IDialogService dialogServce;
    private readonly ISettingsService settingService;
    private readonly IConversationService conversationService;
    

    public ObservableCollection<Conversation> Conversations { get; } = new();

    public HomePageViewModel(
        IDialogService dialogServce, 
        ISettingsService settingService,
        IConversationService conversationService)
    {
        Title = "Assistant";
        this.dialogServce = dialogServce;
        this.settingService = settingService;
        this.conversationService = conversationService;
        
        this.Conversations.Clear();
    }

    void MessageReceived(string msg)
    {
        Console.WriteLine(msg);
    }

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    bool showRefreshButton;

    [ObservableProperty]
    bool showUpdateProfileButton;

    


    [RelayCommand]
    public async Task GetConversationsAsync()
    {
        if (IsBusy) return;
        var profile = await settingService.Get<Profile>(nameof(Profile), null);
        if (profile == null) return;

        try
        {
            IsBusy = true;
            IsRefreshing = true;
            //var data = await this.conversationService.GetConversationsAsync();

            //if (data == null) return;
            //this.Conversations.Clear();
            //foreach (var conversation in data)
            //{
            //    this.Conversations.Add(conversation);
            //}

            if (this.Conversations.Count() == 0)
            {
                ShowRefreshButton = true;
                ShowUpdateProfileButton = false;
            }

            
        }
        catch { }
        finally { 
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand(CanExecute =nameof(CanGotoProfilePage))]
    public async Task GotoProfleAsync()
    {
        var profile = await settingService.Get<Profile>(nameof(Profile), null);
        if (profile == null)
        {
            var shortName = await dialogServce.DisplayPromptAsync("New Profile", "Enter User Code");
            if (shortName == null) { return; }

            profile = new Profile
            {
                ShortName = shortName
            };
            await settingService.Set<Profile>(nameof(Profile), profile);
        }

        await Shell.Current.GoToAsync("ProfilePage", true,
            new Dictionary<string, object> {
                {nameof(Profile), profile }
            }
            );
    }

    public bool CanGotoProfilePage()
    {
        return true;
    }




}
