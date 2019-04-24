# -*- coding: utf-8 -*
from time import sleep
#from dhtxx import DHT22
from dhtxx import DHT11


#dht = DHT22(22)
dht = DHT11(22)
while True:
  try:
    res = dht.get_result_once()
    print('Temp: ' + '{:.1f}'.format(res[0]) + '°C, Hum: ' + '{:.1f}'.format(res[1]))
  except Exception as e:
    print(e)
  sleep(1)

