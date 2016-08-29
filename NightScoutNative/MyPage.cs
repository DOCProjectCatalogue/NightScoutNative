using System;
using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace NightScoutNative
{
	public class MyPage : ContentPage
	{
		public MyPage()
		{

			var chart = new RadCartesianChart
			{
				HorizontalAxis = new CategoricalAxis(),
				VerticalAxis = new NumericalAxis(),
				BindingContext = new EventsViewModel()
			};

			var series = new LineSeries();
			series.SetBinding(LineSeries.ItemsSourceProperty, new Binding("nsEvents"));
			series.ValueBinding = new PropertyNameDataPointBinding("sgv");
			series.CategoryBinding = new PropertyNameDataPointBinding("dateString");

			chart.Series.Add(series);

			Content = chart;
		}
	}
}


