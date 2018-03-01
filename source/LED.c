// Raspberry Pi LED program, CC0
#include <stdio.h>
#include <error.h>
#include <wiringPi.h>
#include <stdlib.h>
#include <signal.h>
#include <string.h>


static sig_atomic_t end = 0;
const int GPIO17 = 17;

static void sighandler(int signo) {
  end = 1;
}

int main (void) {
  struct sigaction sa;

  setbuf(stdout, NULL); // deactivate stdout buffering 
  printf("Raspberry Pi LED program using GPIO17 (press ctrl+c to quit)\n");
  if (wiringPiSetupGpio() == -1) { // Init with BCM GPIO numering
    perror("wiringPiSetup failed");
    exit(1);
  }
  memset(&sa, 0, sizeof(struct sigaction)); //Handling stop events, like ctrl+c 
  sa.sa_handler = sighandler;
  sigaction(SIGINT, &sa, NULL);
  sigaction(SIGQUIT,&sa, NULL);
  sigaction(SIGTERM,&sa, NULL);

  pinMode(GPIO17, OUTPUT);
  printf("LED blinking...\n");
  while(!end) {
    printf(" on");
    digitalWrite(GPIO17, HIGH);
    delay(500);
    printf(" off");
    digitalWrite(GPIO17, LOW);
    delay(500);
  }
  printf("\nLED off\n");
  digitalWrite(GPIO17, LOW);
  pinMode(GPIO17, INPUT);
  return 0;
}

