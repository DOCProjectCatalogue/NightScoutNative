using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NightScoutNative
{
	public partial class MasterPage : ContentPage
	{
		NightScout nsWebsite;
		List<NightScout> nsList;// = new List<NightScout>();

		public MasterPage()
		{
			InitializeComponent();
			nsWebsite = new NightScout();

			BindingContext = nsWebsite;

			NightScout n = new NightScout();
			n.T1DName = "Lydia";
			n.NSURL = "evaroo.azurewebsites.net";

			nsList = new List<NightScout>();
			nsList.Add(n);
			lvWebsites.ItemsSource = nsList;

			lvWebsites.ItemSelected += LvWebsites_ItemSelected;

			//MessagingCenter.Subscribe<MasterPage>(this,"Add", (obj) => lvWebsites.ItemsSource = nsList);
			btnAdd.Clicked += BtnAdd_Clicked;
		}

		void BtnAdd_Clicked(object sender, EventArgs e)
		{
			nsList.Add(nsWebsite);

			lvWebsites.ItemsSource = nsList;

		}

		async void LvWebsites_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}

			NightScout nsItem = (NightScout)e.SelectedItem;

			MessagingCenter.Send<MasterPage, NightScout>(this, "NightScout", nsItem);
			await Navigation.PushAsync(new DetailPage());



			((ListView)sender).SelectedItem = null;
		}
	}
}

