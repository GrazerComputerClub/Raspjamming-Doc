namespace Raspjamming
{
	using System.Runtime.InteropServices;

	public class WiringPi
	{
		public const int Low = 0;
		public const int High = 1;
		public const int Input = 0;
		public const int Output = 1;

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupGpio")]
		public static extern int WiringPiSetupGpio();

		[DllImport("libwiringPi.so", EntryPoint = "pinMode")]
		public static extern void PinMode(int pin, int mode);

		[DllImport("libwiringPi.so", EntryPoint = "digitalWrite")]
		public static extern void DigitalWrite(int pin, int value);
	}
}