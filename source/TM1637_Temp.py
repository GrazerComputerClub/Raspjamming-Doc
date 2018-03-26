from tm1637 import TM1637
from gpiozero import CPUTemperature
from time import sleep

CLK = 10
DIO = 9

cpuTemp = CPUTemperature()
tm = TM1637(clk=CLK, dio=DIO)
# 0 ... off
# 7 ... max
tm.brightness(3)

while True:
  tm.temperature(round(cpuTemp.temperature))
  sleep(1)
