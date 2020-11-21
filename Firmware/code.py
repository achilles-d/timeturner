import time
import usb_hid
from adafruit_circuitplayground.express import cpx
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keycode import Keycode

def face1(x, y, z):
    return (x >= -0.25 and x <= 0.4) and (y >= -0.35 and y<= 0.05) and (z >=8.5 and z<=9.9)

def face2(x, y, z):
    return (x >= -5.1 and x <= -0.46) and (y >= 6.3 and y<= 6.6) and (z >=4.17 and z<=4.8)

def face3(x, y, z):
    return (x >= 4.9 and x <= 5.2) and (y >= 6.1 and y<= 6.6) and (z >=4.1 and z<=4.7)


# Set up the keyboard device.
kbd = Keyboard(usb_hid.devices)

# Main loop gets x, y and z axis acceleration, prints the values, and turns on
# red, green and blue, at levels related to the x, y and z values.

# Variables used to keep track of face.
prev_face = 0
face = 0

while True:
    if cpx.switch:
        print("Slide switch off!")
        cpx.pixels.fill((0, 0, 0))
        continue
    else:
        R = 0
        G = 0
        B = 0
        x, y, z = cpx.acceleration
        #print((x, y, z))
        if x:
            R = abs(int(x))
        if y:
            G = abs(int(y))
        if z:
            B = abs(int(z))
        cpx.pixels.fill((R, G, B))

        # Determine which face
        if face1(x,y,z):
            face = 1
        elif face2(x,y,z):
            face = 2
        elif face3(x,y,z):
            face = 3
        else:
            face = prev_face


        # If the face is new...
        if face != prev_face:
            cpx.play_tone(294, 0.2)

        prev_face = face

        print(face)


        # Sleep to eliminate some jitter
        time.sleep(0.1)