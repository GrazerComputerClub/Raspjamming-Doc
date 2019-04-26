.data
.balign 4 
@ WiringPi Pin 27 == BCM GPIO 16 == Physical 36
pin: .int 27
delayMs: .int 250

.text
.global main
.extern wiringPiSetup
.extern delay
.extern digitalWrite
.extern pinMode

main:
push  {ip, lr}
bl  wiringPiSetup

@ Set pin to output
ldr r0, =pin
ldr r0, [r0]
mov r1, #1
bl  pinMode

@ Blink 10 times
mov r2, #0
mov r3, #10

loopBegin:
cmp r2, r3
bgt loopExit
@ Save registers
push {r2, r3}

ldr r0, =pin
ldr r0, [r0]
mov r1, #1
bl  digitalWrite

ldr r0, =delayMs
ldr r0, [r0]
bl  delay

ldr r0, =pin
ldr r0, [r0]
mov r1, #0
bl  digitalWrite

ldr r0, =delayMs
ldr r0, [r0]
bl  delay

@ Restore loop state
pop {r2, r3}
add r2, #1
b loopBegin 

loopExit: 
pop {ip, pc} 

