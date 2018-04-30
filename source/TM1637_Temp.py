# -*- coding: utf-8 -*

from tm1637 import TM1637
from gpiozero import CPUTemperature
from time import sleep

CLK = 23
DIO = 24

cpuTemp = CPUTemperature()
tm = TM1637(clk=CLK, dio=DIO)
# 0 ... off
# 7 ... max
tm.brightness(5)

while True:
  tm.temperature(round(cpuTemp.temperature))
  sleep(1)
