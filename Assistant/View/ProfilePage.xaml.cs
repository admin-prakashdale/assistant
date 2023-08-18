using Assistant.ViewModel;

namespace Assistant.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}