using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace NightScoutNative
{
	public partial class NightScoutNativePage : ContentPage
	{
		private EventsViewModel _viewModel;
		private RadCartesianChart chart;

		public NightScoutNativePage()
		{
			InitializeComponent();

			this.BindingContext = _viewModel = new EventsViewModel();
			BackgroundColor = Xamarin.Forms.Device.OnPlatform(Xamarin.Forms.Color.White, Xamarin.Forms.Color.White, Xamarin.Forms.Color.Transparent);

			this.Content = CreateChart();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _viewModel.PopulateNightScoutEvents();
		}

		private  RadCartesianChart CreateChart()
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

