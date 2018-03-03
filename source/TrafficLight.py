from gpiozero import TrafficLights
from time import sleep

def SetRYG(red, yellow, green):
  if not green:
    lights.green.off()
  else:
    lights.green.on()
  if not red:
    lights.red.off()
  else:
    lights.red.on()
  if not yellow:
    lights.yellow.off()
  else:
    lights.yellow.on()


lights = TrafficLights(16, 20, 21)

while True:
  sleep(10)
  SetRYG(red=True, yellow=False, green=False)
  sleep(5)
  SetRYG(red=True, yellow=True, green=False)
  sleep(1)
  SetRYG(red=False, yellow=False, green=True)
  sleep(4)
  for i in range(3):
    SetRYG(red=False, yellow=False, green=False)
    sleep(1)
    SetRYG(red=False, yellow=False, green=True)
    sleep(1)
  SetRYG(red=False, yellow=True, green=False)
  sleep(2)
