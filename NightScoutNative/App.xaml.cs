using System.Diagnostics;
using Plugin.AzurePushNotifications;
using Xamarin.Forms;

namespace NightScoutNative
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new NightScoutNativePage());

			//PushNotificationCredentials.Tags = new string[] {"evaroo.azurewebsites.net" };
			//PushNotificationCredentials.GoogleApiSenderId = "google sender id";
			//PushNotificationCredentials.AzureNotificationHubName = "Push-Notification-Hub";
			//PushNotificationCredentials.AzureListenConnectionString = "Endpoint=sb://nspush.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=zAp47KnaK0SguPp+gCp0dgY9RVmqm2wI/51lBg4Nw8w=";

			//CrossAzurePushNotifications.Current.RegisterForAzurePushNotification();

			//CrossAzurePushNotifications.Current.OnMessageReceived += (sender, ev) =>
			//{
			//	Debug.WriteLine(ev.Content);
			//};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}


	}
}

