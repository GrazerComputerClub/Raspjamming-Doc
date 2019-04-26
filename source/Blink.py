# -*- coding: utf-8 -*

from gpiozero import LED
import time

print("Raspberry Pi LED blinking example")
l = LED(16)
while 1:
  l.on()
  print(" on");
  time.sleep(1)
  l.off()
  print(" off");
  time.sleep(1)
