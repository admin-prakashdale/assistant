using Assistant.Services;
using Assistant.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net;

namespace Assistant.View;

public partial class HomePage : ContentPage
{

	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

		//ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

		//hubConnection = new HubConnectionBuilder()
		//	.WithUrl("http://desktop-saa638v:5172/chathub")
		//	.Build();

		//hubConnection.On<string>("MessageReceived", (message) =>
		//{
		//	Console.WriteLine(message);
		//});

		//Task.Run(() =>
		//{
		//	Dispatcher.Dispatch(async () => await hubConnection.StartAsync());
		//});

	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var vm = BindingContext as HomePageViewModel;
		await vm.GetConversationsAsync();


	}
}

    