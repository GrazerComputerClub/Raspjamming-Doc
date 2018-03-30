# -*- coding: utf-8 -*
from time import sleep
from dhtxx import DHT22

dht = DHT22(4)
while True:
  try:
    res = dht.get_result_once()
    print('Temp: ' + '{:.2f}'.format(res[0]) + '°C, Hum: ' + '{:.2f}'.format(res[1]))
  except Exception as e:
    print(e)
  sleep(1)

