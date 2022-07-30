#!/usr/bin/env python
# coding: utf-8

# In[21]:

a = input("Pon el nombre de la Imagen")
from PIL import Image

im = Image.open(a+".jpg") # Can be many different formats.
pix = im.load()
print(im.size)  # Get the width and hight of the image for iterating over
print(pix[0,0])  # Get the RGBA Value of the a pixel of an image
for x in range(0, im.size[0]):
    for y in range(0, im.size[1]):
        Y = 0.2126*pix[x,y][0] + 0.7152*pix[x,y][1] + 0.0722*pix[x,y][2]
        if(Y < 128): #color is black
            pix[x,y] = (0,0,0)
        else:
            pix[x,y] = (255,255,255)
im.save(a+".jpg")           


# In[ ]:




