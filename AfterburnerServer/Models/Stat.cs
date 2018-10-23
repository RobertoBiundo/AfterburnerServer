using MSI.Afterburner;

namespace AfterburnerServer.Models
{
    class Stat
    {
        public string Name { get; set; }
        public string Units { get; set; }
        public float Value { get; set; }
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public float Gpu { get; set; }

        public Stat(HardwareMonitorEntry hardwareMonitorEntry)
        {
            Name = hardwareMonitorEntry.SrcName;
            Units = hardwareMonitorEntry.SrcUnits;
            Value = hardwareMonitorEntry.Data;
            MinValue = hardwareMonitorEntry.MinLimit;
            MaxValue = hardwareMonitorEntry.MaxLimit;
            Gpu = hardwareMonitorEntry.GPU;
        }
    }
}
