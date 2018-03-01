#include <stdio.h>
#include <wiringPi.h>

const int GPIO17 = 17;

int main (void) {
  if (wiringPiSetupGpio()!=-1) {
    printf("Raspberry Pi LED blinking example\n") ;
    pinMode(GPIO17, OUTPUT);
    for (int loop=0; loop<3; loop++) {
      digitalWrite (GPIO17, HIGH); printf("on\n"); // 3.3 Volt
      delay(500);
      digitalWrite(GPIO17, LOW); printf("off\n"); // 0 Volt
      delay(500);
    }
    pinMode(GPIO17, INPUT);
    return 0;
  }
  printf("wiringPiSetup error"); 
  return 1;
}

