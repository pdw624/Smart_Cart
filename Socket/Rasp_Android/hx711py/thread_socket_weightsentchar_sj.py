import time
import sys
import requests
import json
import threading
import socket

import Adafruit_GPIO.SPI as SPI
import Adafruit_SSD1306

from PIL import Image
from PIL import ImageDraw
from PIL import ImageFont

import subprocess

barcode_value = ""
state = 0


host = '192.168.0.154' 
port = 9999 


server_sock = socket.socket(socket.AF_INET)
server_sock.bind((host, port))
server_sock.listen(1)

print("기다리는 중")
client_sock, addr = server_sock.accept()
                                                                                                                         
print('Connected by', addr)

def server():
    data2 = client_sock.recv(1024)
    print(data2.decode("utf-8"), len(data2))

    while(True):
        data= input("보낼 값 : ")
        data = data + "+"
        data=data.encode('utf-8')
        
        client_sock.send(data)
        
    closesoket(client_sock)
    closesoket(server_sock)

def weight():
    EMULATE_HX711=False

    referenceUnit = 1

    if not EMULATE_HX711:
        import RPi.GPIO as GPIO
        from hx711 import HX711
    else:
        from emulated_hx711 import HX711

    def cleanAndExit():
        print("Cleaning...")

        if not EMULATE_HX711:
            GPIO.cleanup()
            
        print("Bye!")
        sys.exit()

    hx = HX711(20, 16)

    hx.set_reading_format("MSB", "MSB")
    
    hx.set_reference_unit(395)

    hx.reset()

    hx.tare()

    ##print("Tare done! Add weight now...")

    p=-3
    
    while True:
        try:
            
            val = hx.get_weight(5)
            global barcode_value
            global state
            global state_name
            #global num
            #num=0
            
            if barcode_value != "":
                #.sleep(5)
                if val <= (p+2):
                    print("drop the things")
                    
                    p=val
                    #num=1
                 
                else :             
                    if val>=(p-2):
                        print("ok")
                        
                        p=val
                        #num=1
                            
                    else :
                        print("no")
                        
                        p=val
                        #num =1
                state = 1
                    
                while state ==1:
                    time.sleep(1)
                    
            hx.power_down()
            hx.power_up()
            time.sleep(0.1)
          
        except (KeyboardInterrupt, SystemExit):
            cleanAndExit()
    

def bar():
    
    def barcode_reader():
       
        hid = {4: 'a', 5: 'b', 6: 'c', 7: 'd', 8: 'e', 9: 'f', 10: 'g', 11: 'h', 12: 'i', 13: 'j', 14: 'k', 15: 'l', 16: 'm',
               17: 'n', 18: 'o', 19: 'p', 20: 'q', 21: 'r', 22: 's', 23: 't', 24: 'u', 25: 'v', 26: 'w', 27: 'x', 28: 'y',
               29: 'z', 30: '1', 31: '2', 32: '3', 33: '4', 34: '5', 35: '6', 36: '7', 37: '8', 38: '9', 39: '0', 44: ' ',
               45: '-', 46: '=', 47: '[', 48: ']', 49: '\\', 51: ';', 52: '\'', 53: '~', 54: ',', 55: '.', 56: '/'}

        hid2 = {4: 'A', 5: 'B', 6: 'C', 7: 'D', 8: 'E', 9: 'F', 10: 'G', 11: 'H', 12: 'I', 13: 'J', 14: 'K', 15: 'L', 16: 'M',
                17: 'N', 18: 'O', 19: 'P', 20: 'Q', 21: 'R', 22: 'S', 23: 'T', 24: 'U', 25: 'V', 26: 'W', 27: 'X', 28: 'Y',
                29: 'Z', 30: '!', 31: '@', 32: '#', 33: '$', 34: '%', 35: '^', 36: '&', 37: '*', 38: '(', 39: ')', 44: ' ',
                45: '_', 46: '+', 47: '{', 48: '}', 49: '|', 51: ':', 52: '"', 53: '~', 54: '<', 55: '>', 56: '?'}

        fp = open('/dev/hidraw0', 'rb')
        global barcode_value
        
        ss = ""
        shift = False

        done = False

        while not done:

          
            buffer = fp.read(8)
            for c in buffer:
                #if ord(c) > 0:
                if c > 0:
                    
                    #if int(ord(c)) == 40:
                    if c == 40:
                        done = True
                        break;

                    
                    if shift:

                        
                        #if int(ord(c)) == 2:
                        if c == 2:
                            shift = True

                      
                        else:
                            #ss += hid2[int(ord(c))]
                            ss += hid2[c]
                            shift = False

                

                    else:

                        
                        #if int(ord(c)) == 2:
                        if c == 2:
                            shift = True

                        
                        else:
                            #ss += hid[int(ord(c))]
                            ss += hid[c]
        barcode_value=ss
        print(ss)
        return ss
    
    time.sleep(0.1)
    #weight()
    return barcode_reader()

def oled():


    # Raspberry Pi pin configuration:
    RST = None     # on the PiOLED this pin isnt used
    # Note the following are only used with SPI:
    DC = 23
    SPI_PORT = 0
    SPI_DEVICE = 0


    # 128x32 display with hardware I2C:
    disp = Adafruit_SSD1306.SSD1306_128_32(rst=RST)


    # Initialize library.
    disp.begin()

    # Clear display.
    disp.clear()
    disp.display()

    # Create blank image for drawing.
    # Make sure to create image with mode '1' for 1-bit color.
    width = disp.width
    height = disp.height
    image = Image.new('1', (width, height))

    # Get drawing object to draw on image.
    draw = ImageDraw.Draw(image)

    # Draw a black filled box to clear the image.
    draw.rectangle((0,0,width,height), outline=0, fill=0)

    # Draw some shapes.
    # First define some constants to allow easy resizing of shapes.
    padding = -2
    top = padding
    bottom = height-padding
    # Move left to right keeping track of the current x position for drawing shapes.
    x = 0


    # Load default font.
    font = ImageFont.load_default()

    # Alternatively load a TTF font.  Make sure the .ttf font file is in the same directory as the python script!
    # Some other nice fonts to try: http://www.dafont.com/bitmap.php
    # font = ImageFont.truetype('Minecraftia.ttf', 8)
    
    global barcode_value
    barcode_value=""
    barcode_total=0
    barcode_price=0
    barcode_name=""
    while True:

        # Draw a black filled box to clear the image.
        draw.rectangle((0,0,width,height), outline=0, fill=0)

        # Write two lines of text.
        barcode_value=bar()
          
        if barcode_value =='8801500102500':
            barcode_name = 'Banana'
            barcode_price =2500
            
        if barcode_value =='2638200200900':
            barcode_name ='LESBI Coffe'
            barcode_price =900
            
        if barcode_value =='7593200304500':
            barcode_name ='Bread'
            barcode_price =4500
            
        if barcode_value =='1838200402800':
            barcode_name ='SEOUL Milk'
            barcode_price =2800
            
        if barcode_value =='8382900501050':
            barcode_name ='SHIN Ramen'
            barcode_price =1050
            
        if barcode_value =='3462000601200':
            barcode_name ='Shrimp Cracker'
            barcode_price =1200
        
        
        barcode_total = int(barcode_total) + int(barcode_price)
        
        print (barcode_total)
        
        barcode_price_text=str(barcode_price)
        barcode_total_text = str(barcode_total)
        
        draw.text((x, top),       "CART :  1",  font=font, fill=255)
        if barcode_value =="":
            draw.text((x, top+8),     "GOODS : ", font=font, fill=255)
        else :
            draw.text((x, top+8),     "GOODS : "+barcode_name, font=font, fill=255)
        draw.text((x, top+16),    "PRICE : "+barcode_price_text+' won',  font=font, fill=255)
        draw.text((x, top+25),    "TOTAL : "+barcode_total_text+' won',  font=font, fill=255)
  
        global state
        # Display image.
        disp.image(image)
        disp.display()
        time.sleep(.1)
        
        while state == 0 :
            time.sleep(1)
            barcode_value=""
        
        state=0

    
while True:
    
    try:
        sender = threading.Thread(target=bar)
        receiver=threading.Thread(target=weight)
        seoled = threading.Thread(target=oled)
        sesocket = threading.Thread(target=server)
        
        sender.start()
        seoled.start()
        receiver.start()
        sesocket.start()
        
        sender.join()
        seoled.join()
        receiver.join()
        #sesocket.join()
        
        time.sleep(0.1)
        
    except KeyboardInterrupt as e:
        
        print(e)
        #conn.close()
        break








