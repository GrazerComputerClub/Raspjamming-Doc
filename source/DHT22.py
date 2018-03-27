# -*- coding: utf-8 -*

dht = DHT22(4)
tm = TM1637 (clk=10, dio=9)
tm.brightness(3)
while True:
  try:
    res = dht.get_result_once()
    tm.number(round(res[0]))
    print('Temp: ' + '{:.2f}'.format(res[0]) + '°C, Hum: ' + '{:.2f}'.format(res[1]))
  except Exception as e:
    print(e)
  sleep(1)

