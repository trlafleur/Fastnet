

// Converts B&G 213 MHU to degrees...
// The MHU uses a 3-phase synchro, so we have three values that are 120 degrees apart
// B&G unit runs on 6.5vdc, so we need to scale to 3.3v with a 2/1 divider
// We will see a slight error as we sample ATD in sequence, but, it's just not a real issue
/*
      CHANGE LOG:

      DATE         REV  DESCRIPTION
      -----------  ---  ----------------------------------------------------------
      07-Jun-2012  1.0  TRL - First Build    
      19-Feb-2024  2.0  TRL - Code clean up, update algorithm, added references
      

      Notes:  1)  Tested with https://www.onlinegdb.com/online_c_compiler
              2)  Function tested with ESP32 with external ATD converter
              3)  Tested with SAMD21G18 on Arduino
*/

// https://www.hisse-et-oh.com/store/medias/sailing/5dd/2c3/af3/original/5dd2c3af39819f3668e93b13.pdf
// https://electronics.stackexchange.com/questions/160215/how-to-get-the-angle-from-a-3-phases-synchro-signal
// https://bikerglen.com/blog/building-a-synchro-to-digital-converter/

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

// ************************************************ //
// 213 B&G x = Red, y = Green, z = Blue
// B&G MHU is offset by 270 deg
void getAngle( float  x, float  y, float z)
{
     float  rad_angle = 0.0;
     float  angle = 0.0;
     float  deg_angle = 0.0;
     int    int_angle = 0;
     float  M_Sin = 0.0;
     float  M_Cos = 0.0;

     M_Sin = (z-x);
     M_Cos = (y - ( (x+z) / 2)) * ( 2 / sqrt(3) );            // 2 / sqrt(3) =  1.15470054       
     rad_angle = atan2 (M_Cos, M_Sin);
     deg_angle = (rad_angle * (180.0/3.14159265));            // 180.0/3.14159265 = 57.29577958
     deg_angle = (deg_angle + 270.0);
     if (deg_angle >= 360) deg_angle = deg_angle - 360;
     int_angle = (int) round (deg_angle) % 360;
     
     printf("Angle in degree   = %8.2f , %d \n", deg_angle, int_angle);
} 


// Test program for 213 MHU based on voltage values from B&G
// ************************************************ //
int main()
{
    printf("B&G MHU Test...\n");

    getAngle(0.19,	4.74,	4.74);      // 0
    getAngle(0.53,	3.24,	5.89);      // 30
    getAngle(1.64,	1.68,	6.33);      // 60
    getAngle(3.25,	0.47,	5.93);      // 90
    getAngle(4.77,	0.10,	4.78);      // 120
    getAngle(5.87,	0.53,	3.25);      // 150
    getAngle(6.28,	1.67,	1.69);      // 180
    getAngle(5.87,	3.25,	0.53);      // 210
    getAngle(4.77,	4.78,	0.10);      // 240
    getAngle(3.25,	5.93,	0.47);      // 270
    getAngle(1.64,	6.33,	1.68);      // 300
    getAngle(0.53,	5.89,	3.24);      // 330

    return 0;
}


