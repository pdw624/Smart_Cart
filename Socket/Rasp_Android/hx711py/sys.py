import sys

fp=open('/dev/hidraw0','rb')

while True:
    buffer1= fp.read(8)
    for c in buffer1:
        if ord(c) > 0:
            print("number : %s" % c)

