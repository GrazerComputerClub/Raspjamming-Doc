# -*- coding: utf-8 -*

from time import sleep
from gpiozero import DistanceSensor
# Be aware not to use a GPIO with a physical pull-up resistor 
# like GPIO3, otherwise gpiozero will raise an exception because
# it can't deactivate the pull-up
ds = DistanceSensor(echo=18, trigger=17)

# Measure and print distance periodically
while True:
  print(str(round(ds.distance*100)) + ' cm')
  sleep(1)

# ... Or print distance on 7-segment display
from tm1637 import TM1637
tm = TM1637(clk = 10, dio = 9)
tm.brightness(3)
while True:
  dist = str(round(ds.distance*100))
  tm.write(tm.encode_string(' '*(4-len(dist))+dist))
  sleep(1)
