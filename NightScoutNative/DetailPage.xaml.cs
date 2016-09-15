using System;
using System.Collections.Generic;
using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace NightScoutNative
{
	public partial class DetailPage : ContentPage
	{
		private EventsViewModel _viewModel;
		private RadCartesianChart chart;

		public DetailPage()
		{
			InitializeComponent();

			this.BindingContext = _viewModel = new EventsViewModel();
			BackgroundColor = Xamarin.Forms.Device.OnPlatform(Xamarin.Forms.Color.White, Xamarin.Forms.Color.White, Xamarin.Forms.Color.Transparent);

		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _viewModel.PopulateNightScoutSGVEvents();
			await _viewModel.PopulatePumpStatus();
		}

		private RadCartesianChart CreateChart()
		{

			chart = new RadCartesianChart
			{
				HorizontalAxis = new CategoricalAxis(),
				VerticalAxis = new NumericalAxis(),
				BindingContext = _viewModel
			};
			var series = new LineSeries();
			series.SetBinding(LineSeries.ItemsSourceProperty, new Binding("NsEvents") { Mode = BindingMode.OneWay });
			series.ValueBinding = new PropertyNameDataPointBinding("sgv");
			series.CategoryBinding = new PropertyNameDataPointBinding("timeString");

			chart.Series.Add(series);


			return chart;
		}
	}
}

