using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NightScoutNative
{

	public class EventsViewModel : ViewModelBase
	{
		private HttpClient client;

		private ObservableCollection<NightScoutEvent> _nsEvents;
		public ObservableCollection<NightScoutEvent> NsEvents
		{
			get
			{
				return _nsEvents;
			}
			set
			{
				this.SetProperty(ref _nsEvents, value);
			}
		}

		private NightScoutEvent _nsCurrentSGV;
		public NightScoutEvent NsCurrentSGV
		{
			get
			{
				return _nsCurrentSGV;
			}
			set
			{
				this.SetProperty(ref _nsCurrentSGV, value);
			}
		}

		private NightScoutEvent _nsCurrentPumpStatus;
		public NightScoutEvent NsCurrentPumpStatus
		{
			get
			{
				return _nsCurrentPumpStatus;
			}
			set
			{
				this.SetProperty(ref _nsCurrentPumpStatus, value);
			}
		}

		//public static ObservableCollection<NightScoutEvent> GetNightScoutEventsFromFile()
		//{
		//	var assembly = typeof(SharedPage).GetTypeInfo().Assembly;

		//	using (StreamReader r = new assembly.GetManifestResourceStream("NightscoutNative.iOS.sgv.json"))
		//	{
		//		string json = r.ReadToEnd();
		//		ObservableCollection<NightScoutEvent> items = JsonConvert.DeserializeObject<ObservableCollection<NightScoutEvent>>(json);

		//		return items;
		//	}
		//}

		public async Task PopulateNightScoutSGVEvents()
		{
			//var data = new ObservableCollection<NightScoutEvent>();

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

			ObservableCollection<NightScoutEvent> returnEvents = new ObservableCollection<NightScoutEvent>();

			string sRestUrl = "https://lydia-nightscout.azurewebsites.net/api/v1/entries/sgv.json?[count]=20";
			var uri = new Uri(string.Format(sRestUrl, string.Empty));

			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				returnEvents = JsonConvert.DeserializeObject<ObservableCollection<NightScoutEvent>>(content);

			}

			//Current blood sugar reading
			NsCurrentSGV = returnEvents[0];


			//Populate collection for graph (reverse order so the graph is correct)
			NsEvents = new ObservableCollection<NightScoutEvent>(returnEvents.Reverse());


			//return data;
		}

		public async Task PopulatePumpStatus()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

			string sRestUrl = "https://lydia-nightscout.azurewebsites.net/api/v1/entries.json?[type]=pump_status&[count]=1";

			var uri = new Uri(string.Format(sRestUrl, string.Empty));

			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var nsPumpStatusCollection = JsonConvert.DeserializeObject<ObservableCollection<NightScoutEvent>>(content);

				NsCurrentPumpStatus = nsPumpStatusCollection[0];
			}
		}
	}

	//public class CategoricalData
	//{
	//	public object Category { get; set; }
	//	public double Value { get; set; }
	//}

	//public class CategoricalViewModel
	//{
	//	private static Random random = new Random();
	//	private static string[] categories = new string[] { "Greenings", "Perfecto", "NearBy", "Family", "Fresh" };

	//	public CategoricalViewModel()
	//	{
	//		this.CategoricalData = GetCategoricalData();
	//	}

	//	public ObservableCollection<CategoricalData> CategoricalData { get; set; }

	//	public static ObservableCollection<CategoricalData> GetCategoricalData()
	//	{
	//		var data = new ObservableCollection<CategoricalData>();
	//		for (int i = 0; i < categories.Length; i++)
	//		{
	//			data.Add(new CategoricalData() { Value = random.Next(50, 100), Category = categories[i] });
	//		}

	//		return data;
	//	}
	//}
}


