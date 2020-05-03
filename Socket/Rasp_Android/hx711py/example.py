
import time
import sys
import json
import threading
import time

import Adafruit_GPIO.SPI as SPI
import Adafruit_SSD1306
import RPi.GPIO as GPIO

import subprocess

barcode_value = ""
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

    print("Tare done! Add weight now...")



    while True:
        try:
       
            val = hx.get_weight(5)
            print(val)

       

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
                if ord(c) > 0:

                    
                    if int(ord(c)) == 40:
                        done = True
                        break;

                    
                    if shift:

                        
                        if int(ord(c)) == 2:
                            shift = True

                      
                        else:
                            ss += hid2[int(ord(c))]
                            shift = False

                

                    else:

                        
                        if int(ord(c)) == 2:
                            shift = True

                        
                        else:
                            ss += hid[int(ord(c))]
        barcode_value=ss
        return ss
    
    return barcode_reader()
    
    
def oled():
    
    RST = None    
    
    DC = 23
    SPI_PORT = 0
    SPI_DEVICE = 0

    disp = Adafruit_SSD1306.SSD1306_128_32(rst=RST)


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


    global barcode_value
    barcode_value=""
    while True:

    # Draw a black filled box to clear the image.
        draw.rectangle((0,0,width,height), outline=0, fill=0)

    # Write two lines of text.
        
        barcode_value=bar()
        
        draw.text((x, top), "CART: ", font=font, fill=255)
        if barcode_value == "":
            draw.text((x, top+8), "GOODS: ", font=font, fill=255)
        else :
            draw.text((x, top+8), "GOODS: "+barcode_value, font=font, fill=255)
        draw.text((x, top+16), "PRICE: ",  font=font, fill=255)
        draw.text((x, top+25), "TOTAL: ",  font=font, fill=255)
            

        # Display image.
        disp.image(image)
        disp.display()
        time.sleep(.1)

    
while True:
    
    try:
       
        receiver=threading.Thread(target=weight)
        seoled = threading.Thread(target=oled)
        
        seoled.start()
        receiver.start()
        
        seoled.join()
        receiver.join()
        
        time.sleep(0.5)
        
    except KeyboardInterrupt as e:
        
        print(e)
        break






