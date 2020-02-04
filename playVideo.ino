/*
  Play Video - Sprite Media Player
  created 1 Nov 2019
  by Pedro Oliveira
  ⏚ -------- Ground
     -------  Pin 0 (RX)
  R  -------  Pin 1 (TX)
  L  -------  
*/

void setup() {
  Serial.begin(9600);
}

void loop() {
  playVideo(001);
  delay(5000);
}

void playVideo(int8_t video){
  Serial.write(video);
  Serial.flush();
}
