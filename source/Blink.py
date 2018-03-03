from gpiozero import LED
import time
l = LED(17)
while 1:
  l.on()
  time.sleep(1)
  l.off()
  time.sleep(1)
