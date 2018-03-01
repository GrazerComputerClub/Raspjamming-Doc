#include <stdio.h>
#include <wiringPi.h>
#include <signal.h>
#include <string.h>


//BCM GPIO connection
const int RED    = 16;
const int YELLOW = 20;
const int GREEN  = 21;
static sig_atomic_t end = 0;

static void sighandler(int signo) {
  end = 1;
}

void SetRYG(int Red, int Yellow, int Green) {
	digitalWrite(RED,    Red   );
	digitalWrite(YELLOW, Yellow);
	digitalWrite(GREEN,  Green );	
}

void WaitMS(int MS) {
	if (!end)	delay(MS);
}

int main(void) {
	struct sigaction sa;

	setbuf(stdout, NULL); // deactivate stdout buffering 
	if (wiringPiSetupGpio() == -1) { // Init with BCM GPIO numbers
		perror("wiringPiSetup failed");
		return 1;
	}
	memset(&sa, 0, sizeof(struct sigaction)); //Handling stop events, like ctrl+c 
	sa.sa_handler = sighandler;
	sigaction(SIGINT, &sa, NULL);
	sigaction(SIGQUIT,&sa, NULL);
	sigaction(SIGTERM,&sa, NULL);

	printf("Raspberry Pi traffic light (press ctrl+c to quit)\n");
	pinMode(RED,    OUTPUT);
	pinMode(YELLOW, OUTPUT);
	pinMode(GREEN,  OUTPUT);
	SetRYG(LOW, LOW, LOW);
	while(!end) {
		SetRYG(HIGH, LOW, LOW);
		WaitMS(5000);
		SetRYG(HIGH, HIGH, LOW);
		WaitMS(1000);
		SetRYG(LOW, LOW, HIGH);
		WaitMS(4000);
		for (int nBlinkCount=0; nBlinkCount<3; nBlinkCount++) { 
			if (end) break;
			SetRYG(LOW, LOW, LOW);
			WaitMS(1000);
			SetRYG(LOW, LOW, HIGH);
			WaitMS(1000);
		}
		SetRYG(LOW, HIGH, LOW);
		WaitMS(2000);
	}
	SetRYG(LOW, LOW, LOW);
	pinMode(RED,    INPUT);
	pinMode(YELLOW, INPUT);
	pinMode(GREEN,  INPUT);
	return 0;
}

