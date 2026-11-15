# CSCI 3090 Assignment Two
## OpenGL Lighting
**Due:** November 15, 2026

### Introduction
`Example-8a` introduced the use of uniform blocks for sending lighting information from the C program to the fragment shader. In that example, the properties of the light were passed to the fragment shader. In this assignment, you will extend this example to include material properties, multiple lights and the ability to interactively change the material and light properties. You can copy `example-8a` as the starting point for this assignment.

### Part One (20 marks)
In the first part of this assignment, you will create another uniform block that contains the material properties of the object. The two properties of interest are the object colour and the exponent used in the specular reflection. You will need to create a new uniform block in the shader, and the code in the C program required to set the values in this uniform block.

### Part Two (40 marks)
`Example-8a` has only a single light. For this part of the assignment, extend this to an array of 3 lights. Extend the light struct so it has a state variable that controls whether the light is on or off. Use the `1`, `2`, and `3` keys to toggle the corresponding light on and off.

### Part Three (40 marks)
In this part of the assignment, you will interactively change the lighting parameters given keyboard input. Each time the `c` key is pressed, the colour of the object will change. You can alternate between two different colours. Each time the `l` is pressed, change the light type of the first light from spot light to point light and back again. This will require a change to the uniform block and the fragment shader code.

### Assignment Report
The report for this assignment must include several images produced by your program showing the change in object colour and light type. Also include the parts of the example program that you changed and the revised fragment shader. Produce a zip file that contains your report, your program code, shaders, and anything else required to build your program. Name the zip file as `assign2_lastname_firstname`. Submit the zip file using Canvas.

### Late Submission
A late penalty of 10% per day late will be applied, in the absence of a medical note, to a maximum of 3 days late. (After 3 days, it will not be accepted.)