namespace Raspjamming
{
	using System.Runtime.InteropServices;

	public class WiringPi
	{
		public const int Low = 0;
		public const int High = 1;
		public const int Input = 0;
		public const int Output = 1;

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void WiringPiISRDelegate();

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetup")]
		public static extern int WiringPiSetup();

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupSys")]
		public static extern int WiringPiSetupSys();

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupGpio")]
		public static extern int WiringPiSetupGpio();

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupPhys")]
		public static extern int WiringPiSetupPhys();

		[DllImport("libwiringPi.so", EntryPoint = "pinModeAlt")]
		public static extern void PinModeAlt(int pin, int mode);

		[DllImport("libwiringPi.so", EntryPoint = "pinMode")]
		public static extern void PinMode(int pin, int mode);

		[DllImport("libwiringPi.so", EntryPoint = "pullUpDnControl")]
		public static extern void PullUpDnControl(int pin, int pud);

		[DllImport("libwiringPi.so", EntryPoint = "digitalRead")]
		public static extern int DigitalRead(int pin);

		[DllImport("libwiringPi.so", EntryPoint = "digitalWrite")]
		public static extern void DigitalWrite(int pin, int value);

		[DllImport("libwiringPi.so", EntryPoint = "pwmWrite")]
		public static extern void PwmWrite(int pin, int value);

		[DllImport("libwiringPi.so", EntryPoint = "analogRead")]
		public static extern int AnalogRead(int pin);

		[DllImport("libwiringPi.so", EntryPoint = "analogWrite")]
		public static extern void AnalogWrite(int pin, int value);

		[DllImport("libwiringPi.so", EntryPoint = "piBoardRev")]
		public static extern int PiBoardRev();

		[DllImport("libwiringPi.so", EntryPoint = "wpiPinToGpio")]
		public static extern int WpiPinToGpio(int wpiPin);

		[DllImport("libwiringPi.so", EntryPoint = "physPinToGpio")]
		public static extern int PhysPinToGpio(int physPin);

		[DllImport("libwiringPi.so", EntryPoint = "setPadDrive")]
		public static extern void SetPadDrive(int group, int value);

		[DllImport("libwiringPi.so", EntryPoint = "getAlt")]
		public static extern int GetAlt(int pin);

		[DllImport("libwiringPi.so", EntryPoint = "pwmToneWrite")]
		public static extern void PwmToneWrite(int pin, int freq);

		[DllImport("libwiringPi.so", EntryPoint = "digitalWriteByte")]
		public static extern void DigitalWriteByte(int value);

		[DllImport("libwiringPi.so", EntryPoint = "pwmSetMode")]
		public static extern void PwmSetMode(int mode);

		[DllImport("libwiringPi.so", EntryPoint = "pwmSetRange")]
		public static extern void PwmSetRange(uint range);

		[DllImport("libwiringPi.so", EntryPoint = "pwmSetClock")]
		public static extern void PwmSetClock(int divisor);

		[DllImport("libwiringPi.so", EntryPoint = "gpioClockSet")]
		public static extern void GpioClockSet(int pin, int freq);

		[DllImport("libwiringPi.so", EntryPoint = "waitForInterrupt")]
		public static extern int WaitForInterrupt(int pin, int mS);

		[DllImport("libwiringPi.so", EntryPoint = "wiringPiISR")]
		public static extern int WiringPiISR(int pin, int mode, [MarshalAs(UnmanagedType.FunctionPtr)]WiringPiISRDelegate callback);

		[DllImport("libwiringPi.so", EntryPoint = "piHiPri")]
		public static extern int PiHiPri(int pri);

		[DllImport("libwiringPi.so", EntryPoint = "delay")]
		public static extern void Delay(uint howLong);

		[DllImport("libwiringPi.so", EntryPoint = "delayMicroseconds")]
		public static extern void DelayMicroseconds(uint howLong);

		[DllImport("libwiringPi.so", EntryPoint = "millis")]
		public static extern uint Millis();

		[DllImport("libwiringPi.so", EntryPoint = "micros")]
		public static extern uint Micros();
	}
}