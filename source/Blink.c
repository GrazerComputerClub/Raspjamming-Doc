#include <stdio.h>
#include <wiringPi.h>

const int LED = 16;

int main (void) {
  if (wiringPiSetupGpio()!=-1) {
    printf("Raspberry Pi LED blinking example\n") ;
    pinMode(LED, OUTPUT);
    for (int loop=0; loop<3; loop++) {
      digitalWrite (LED, HIGH); printf("on\n"); // 3.3 Volt
      delay(500);
      digitalWrite(LED, LOW); printf("off\n"); // 0 Volt
      delay(500);
    }
    pinMode(LED, INPUT);
    return 0;
  }
  printf("wiringPiSetup error"); 
  return 1;
}

