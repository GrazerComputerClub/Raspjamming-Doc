namespace Raspjamming
{
	using System;
	using System.Threading;

	static class Blink
	{
		const int GPIO17 = 17;

		static int Main()
		{
			if (WiringPi.WiringPiSetupGpio() != -1)
			{
				Console.WriteLine("Raspberry Pi LED blinking example");
				WiringPi.PinMode(GPIO17, WiringPi.Output);
				for (int loop = 0; loop < 3; loop++)
				{
					WiringPi.DigitalWrite(GPIO17, WiringPi.High);
					Console.WriteLine("on");
					Thread.Sleep(500);
					WiringPi.DigitalWrite(GPIO17, WiringPi.Low);
					Console.WriteLine("off");
					Thread.Sleep(500);
				}
				return 0;
			}
			Console.WriteLine("wiringPiSetup error");
			return 1;
		}
	}
}