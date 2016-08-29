using System;
namespace NightScoutNative
{
	public class NightScoutEvent
	{
		public string _id { get; set; }
		public string type { get; set; }
		public bool conduitInRange { get; set; }
		public bool conduitMedicalDeviceInRange { get; set; }
		public bool conduitSensorInRange { get; set; }
		public int conduitBatteryLevel { get; set; }
		public int reservoirLevelPercent { get; set; }
		public int reservoirAmount { get; set; }
		public int medicalDeviceBatteryLevelPercent { get; set; }
		public int sensorDurationHours { get; set; }
		public int timeToNextCalibHours { get; set; }
		public string sensorState { get; set; }
		public string calibStatus { get; set; }
		public double activeInsulin { get; set; }
		public object date { get; set; }
		public DateTime dateString { get; set; }
		public string timeString => dateString.ToString("hh:mm");
		public string device { get; set; }
		public int? sgv { get; set; }
		public int? trend { get; set; }
		public string direction { get; set; }

		public NightScoutEvent()
		{
		}
	}
}

