/*

   PanTiltScannerThermalMLX90615



*/


#include <Servo.h>

#include <I2cMaster.h>
#include <MLX90615.h>
#include <TwiMap.h>

#define LEDPIN 13

#define SDA_PIN 3   //define the SDA pin for software I2C library
#define SCL_PIN 2   //define the SCL pin for software I2C library

#define PAN 9
#define TILT 10

#define INLENGTH 3          //Needed for input with termination
#define INTERMINATOR 255     //Needed for input with termination
char inString[INLENGTH + 1]; //Needed for input with termination
int inCount;                //Needed for input with termination
boolean received;

Servo pan_servo;
Servo tilt_servo;
int pan_angle;
int tilt_angle;

void GetCharFromSerial() {
  //Get string from serial and put in inString
  //first letter in comm
  //http://forums.adafruit.com/viewtopic.php?f=8&t=9918
  Serial.flush(); //flush all previous received and transmitted data
  received = false;
  inCount = 0;
  do
  {
    while (!Serial.available());             // wait for input
    inString[inCount] = Serial.read();       // get it
    if (inString [inCount] == INTERMINATOR) break;
  }
  while (++inCount < INLENGTH);
  //inString[inCount] = 0;                     // null terminate the string
  //Serial.print(F("R1 "));
  //Serial.println(inString);
  //comm=inString[0];
  pan_angle = inString[0];
  tilt_angle = inString[1];
  received = true;
}


void setup()
{
  // attach the servos and startup the serial connection
  pan_servo.attach(PAN);
  tilt_servo.attach(TILT);
  Serial.begin(115200);
  Serial.println("PanTiltScannerThermalMLX90615");
  //mlx90615.writeEEPROM(Default_Emissivity); //write data into EEPROM when you need to adjust emissivity.
  //mlx90615.readEEPROM(); //read EEPROM data to check whether it's a default one.
  resetAll();
}


void loop() {
  GetCharFromSerial();
  if (received = true) {
    pan_servo.write(pan_angle);
    tilt_servo.write(tilt_angle);
    Serial.println(mlx90615.getTemperature(MLX90615_OBJECT_TEMPERATURE));
    received=false;
  }
}


// put the servos back to the "default" position
void resetAll() {
  reset(pan_servo);
  reset(tilt_servo);
  delay(15);
  pan_angle = 90;
  tilt_angle = 90;
}

// put a servo back to the "default" position (100 deg)
void reset(Servo servo) {
  servo.write(90);
  //slow reset
  // int newPos = 100;
  // int previousPos = servo.read();
  // if (newPos > previousPos) {
  //  for (int i=previousPos; i<newPos; i++) {
  //    servo.write(i);
  //    delay(15);
  //  }
  // } else {
  //  for (int i=previousPos; i>newPos; i--) {
  //    servo.write(i);
  //    delay(15);
  //  }
  // }
}

