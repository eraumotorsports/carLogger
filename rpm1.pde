volatile unsigned int cnt1, cnt2, cnt3, cnt4;

unsigned int rpm1, rpm2, rpm3, rpm4, minCount;

unsigned long rateOld, old1, old2, old3, old4, delta;

// Set update frequency here. ie 10Hz
float updateHz = 5;
float updateMillis = 1000 / updateHz;


void setup()
{
    Serial.begin(9600);
    attachInterrupt(2, rpm_inc1, RISING); //pin 21
    attachInterrupt(3, rpm_inc2, RISING); //pin 20
    attachInterrupt(4, rpm_inc3, RISING); //pin 19
    attachInterrupt(5, rpm_inc4, RISING); //pin 18
    
    cnt1 = cnt2 = cnt3 = cnt4 = 0;
    rpm1 = rpm2 = rpm3 = rpm4 = 0;
    rateOld = 0;
    minCount = 30;
}

void loop()
{
    delta = millis() - rateOld;
    if (delta >= updateMillis)
    {

        if (cnt1 >= minCount)
        {
            rpm1 = timeConst(old1) * cnt1;
            cnt1 = 0;
            old1 = millis();
        }
        if (cnt2 >= minCount)
        {
            rpm2 = timeConst(old2) * cnt2;
            cnt2 = 0;
            old2 = millis();
        }
        if (cnt3 >= minCount)
        {
            rpm3 = timeConst(old3) * cnt3;
            cnt3 = 0;
            old3 = millis();
        }
        if (cnt4 >= minCount)
        {
            rpm4 = timeConst(old4) * cnt4;
            cnt4 = 0;
            old4 = millis();
        }
        printRPMs(rpm1, rpm2, rpm3, rpm4);
        rateOld = millis();
    }
}

float timeConst(long oldTime)
{
    return 1.875 * 1000 / (millis() - oldTime);
}

void printRPMs(int rpm1, int rpm2, int rpm3, int rpm4)
{
    Serial.print(millis(),DEC);
    Serial.print(":");
    Serial.print(rpm1,DEC);
    Serial.print(",");
    Serial.print(rpm2,DEC);
    Serial.print(",");
    Serial.print(rpm3,DEC);
    Serial.print(",");
    Serial.println(rpm4,DEC);
}

int calcRPM(int oldRPM, int count)
{
    if (count < minCount)
        return oldRPM;

    return timeConst * count;
}

void rpm_inc1()
{
    cnt1++;
}

void rpm_inc2()
{
    cnt2++;
}

void rpm_inc3()
{
    cnt3++;
}

void rpm_inc4()
{
    cnt4++;
}
// vim: syntax=c

