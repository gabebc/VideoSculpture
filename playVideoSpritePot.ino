/*
  Play Video - Sprite Media Player
  created 1 Nov 2019
  by Pedro Oliveira
  ⏚ -------- Ground
     -------  Pin 0 (RX)
  R  -------  Pin 1 (TX)
  L  -------  

  Potentiometer control added by Gabe BC
*/
const int analogInPin = A0; 

int sensorValue = 0;        // value read from the pot
int outputValue = 0; 
int old_poten = 0;

void setup() {
  Serial.begin(9600);
}

void loop() {
int poten = map(analogRead(analogInPin), 0, 1023, 0, 5);
  if (poten != old_poten){
  old_poten = poten;  // save the changed value
  playVideo(poten);
  delay(10);
}
}

void playVideo(int8_t video){
  Serial.write(video);
  Serial.flush();
}
