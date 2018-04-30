#!/bin/sh

upSeconds="$(/usr/bin/cut -d. -f1 /proc/uptime)"
secs=$((${upSeconds}%60))
mins=$((${upSeconds}/60%60))
hours=$((${upSeconds}/3600%24))
days=$((${upSeconds}/86400))
UPTIME=`printf "%d days, %02dh%02dm%02ds" "$days" "$hours" "$mins" "$secs"`
MEM_TOTAL=`cat /proc/meminfo | grep MemTotal | awk {'print $2'}` 
MEM_FREE=`cat /proc/meminfo | grep MemFree | awk {'print $2'}` 
MEM_AVAI=`cat /proc/meminfo | grep MemAvailable | awk {'print $2'}` 
MEM_TOTAL_MB=$((${MEM_TOTAL}/1024))
MEM_FREE_MB=$((${MEM_FREE}/1024))
MEM_AVAI_MB=$((${MEM_AVAI}/1024))
RPI_TYPE=`gpio -v | grep Type | cut -c 9-`
CPU_TEMP=`cat /sys/class/thermal/thermal_zone0/temp`
SD_SIZE=`df -h  | grep  /dev/root | awk {'print $2}'`
SD_FREE=`df -h  | grep  /dev/root | awk {'print $4}'`


echo "\033[0;32m
    .~~.   .~~.
   '. \ ' ' / .'\033[0;31m
    .~ .~~~..~.    \033[0;37m     ___                  _                  _            \033[0;31m
   : .~.'~'.~. :   \033[0;37m    / _ \___ ____ ___    (_)__  __ _  __ _  (_)__  ___    \033[0;31m
  ~ (   ) (   ) ~  \033[0;37m   / , _/ _ (_-< / _ \  / / _ \/  ' \/  ' \/ / _ \/ _ \   \033[0;31m
( : '~'.~.'~' : )  \033[0;37m  /_/|_|\_._/___/ .__/_/ /\_,_/_/_/_/_/_/_/_/_//_/\_, /   \033[0;31m
  ~ .~ (   ) ~. ~  \033[0;37m               /_/  |___/                        /___/    \033[0;31m
   (  : '~' :  )
    '~ .~~~. ~'
        '~'
"
echo -n "\033[0;37m"
echo "Datum:          `date +"%A, %e %B %Y, %r"`"
echo "System:         `uname -srmo`"
echo "Type:           ${RPI_TYPE}"
echo "CPU Temperatur: $((${CPU_TEMP}/1000))*C"
echo "Speicher frei:  ${MEM_AVAI_MB}MB von ${MEM_TOTAL_MB}MB"
echo "SD Karte frei:  ${SD_FREE}B von ${SD_SIZE}"B
echo "Laufzeit:       ${UPTIME}"
