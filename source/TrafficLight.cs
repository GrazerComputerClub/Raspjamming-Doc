namespace Raspjamming
{
	using System;
	using System.Threading;

	static class TrafficLight
	{
		const int Red = 16;
		const int Yellow = 20;
		const int Green = 21;
		private static volatile bool _end = false;

		static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			e.Cancel = true;
			_end = true;
		}

		static void SetRYG(int red, int yellow, int green)
		{
			WiringPi.DigitalWrite(Red, red);
			WiringPi.DigitalWrite(Yellow, yellow);
			WiringPi.DigitalWrite(Green, green);
		}

		static void WaitMS(int ms)
		{
			if (!_end)
			{
				Thread.Sleep(ms);
			}
		}

		static int Main()
		{
			Console.CancelKeyPress += Console_CancelKeyPress;
			// Init with BCM GPIO numbers
			if (WiringPi.WiringPiSetupGpio() == -1)
			{
				Console.WriteLine("wiringPiSetup failed");
				return 1;
			}
			Console.WriteLine("Raspberry Pi traffic light (press ctrl+c to quit)");
			WiringPi.PinMode(Red, WiringPi.Output);
			WiringPi.PinMode(Yellow, WiringPi.Output);
			WiringPi.PinMode(Green, WiringPi.Output);
			SetRYG(WiringPi.Low, WiringPi.Low, WiringPi.Low);
			while (!_end)
			{
				SetRYG(WiringPi.High, WiringPi.Low, WiringPi.Low);
				WaitMS(5000);
				SetRYG(WiringPi.High, WiringPi.High, WiringPi.Low);
				WaitMS(1000);
				SetRYG(WiringPi.Low, WiringPi.Low, WiringPi.High);
				WaitMS(4000);
				for (int blinkCount = 0; blinkCount < 3; blinkCount++)
				{
					if (_end)
					{
						break;
					}
					SetRYG(WiringPi.Low, WiringPi.Low, WiringPi.Low);
					WaitMS(1000);
					SetRYG(WiringPi.Low, WiringPi.Low, WiringPi.High);
					WaitMS(1000);
				}
				SetRYG(WiringPi.Low, WiringPi.High, WiringPi.Low);
				WaitMS(2000);
			}
			SetRYG(WiringPi.Low, WiringPi.Low, WiringPi.Low);
			WiringPi.PinMode(Red, WiringPi.Input);
			WiringPi.PinMode(Yellow, WiringPi.Input);
			WiringPi.PinMode(Green, WiringPi.Input);
			return 0;
		}
	}
}
