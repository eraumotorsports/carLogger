// Hold the pulse counts for each wheel
volatile unsigned int cnt1, cnt2, cnt3, cnt4;

// Store the rpm for each wheel
unsigned int rpm1, rpm2, rpm3, rpm4;

// The minimum pulse count before the rpm is updated
unsigned int minCount = 30;

// Timing variables the hold milli counts
unsigned long rateOld, old1, old2, old3, old4, delta;

// Set update frequency here. ie 10Hz
float updateHz = 5;
float updateMillis = 1000 / updateHz;


void setup()
{
    Serial.begin(9600);

    // Setup the interrupts
    attachInterrupt(2, rpm_inc1, RISING); //pin 21
    attachInterrupt(3, rpm_inc2, RISING); //pin 20
    attachInterrupt(4, rpm_inc3, RISING); //pin 19
    attachInterrupt(5, rpm_inc4, RISING); //pin 18
    
    // Zero out all the variables
    cnt1 = cnt2 = cnt3 = cnt4 = 0;
    rpm1 = rpm2 = rpm3 = rpm4 = 0;
    old1 = old2 = old3 = old4 = 0;
    rateOld = 0;
}

void loop()
{
    // Determine the time delta since the last output
    delta = millis() - rateOld;
    if (delta >= updateMillis)
    {
        // Only update the wheel rpm if the minCount has been met
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
        
        // Print the current wheel speeds
        printRPMs(rpm1, rpm2, rpm3, rpm4);
        rateOld = millis();
    }
}

// Calculates the time constant based on previous milli
float timeConst(long oldTime)
{
    return 1.875 * 1000 / (millis() - oldTime);
}

// Print the wheel speeds
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

