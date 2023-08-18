using Assistant.Model;
using Assistant.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.ViewModel;

[QueryProperty(nameof(Profile), "Profile")]
public partial class ProfileViewModel: BaseViewModel
{
    private readonly ISecureStorageService secureStorageService;

    public ProfileViewModel(ISecureStorageService secureStorageService)
    {
        Title = "Profile";
        this.secureStorageService = secureStorageService;
        
    }

    [ObservableProperty]
    Profile profile;    
}
