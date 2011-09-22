// Hold the pulse counts for each wheel
volatile unsigned int cnt1, cnt2, cnt3, cnt4;
unsigned int oldCnt1, oldCnt2, oldCnt3, oldCnt4;

// Store the rpm for each wheel
unsigned int rpm1, rpm2, rpm3, rpm4;

// The minimum pulse count before the rpm is updated
unsigned int minCount = 8;

// The number of pulses that is considered stopped
unsigned int stopCount = 3;

// Timing variables the hold milli counts
unsigned long rateOld, old1, old2, old3, old4, delta;

// Set update frequency here. ie 10Hz
float updateHz = 5;
float updateMillis = 1000 / updateHz;

// Set current gain
double gain = 51.0;
double gain2 = 0.0048828125;

// Current variables
double input, current;

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
        if (cnt1 >= minCount || wheelStopped(cnt1, oldCnt1))
        {
            rpm1 = timeConst(old1) * cnt1;           
            cnt1 = 0;
            old1 = millis();
        }
        else
            oldCnt1 = cnt1;

        if (cnt2 >= minCount || wheelStopped(cnt2, oldCnt2))
        {
            rpm2 = timeConst(old2) * cnt2;
            cnt2 = 0;
            old2 = millis();
        }
        else
            oldCnt2 = cnt2;
  
        if (cnt3 >= minCount || wheelStopped(cnt3, oldCnt3))
        {
            rpm3 = timeConst(old3) * cnt3;
            cnt3 = 0;
            old3 = millis();
        }
        else
            oldCnt3 = cnt3;

        if (cnt4 >= minCount || wheelStopped(cnt4, oldCnt4))
        {
            rpm4 = timeConst(old4) * cnt4;
            cnt4 = 0;
            old4 = millis();
        }
        else
            oldCnt4 = cnt4;
        
        // Measure the current
        current = measureCurrent(0);

        // Print the current wheel speeds and current
        printVals();
        rateOld = millis();
    }
}

// Calculates the time constant based on previous milli
float timeConst(long oldTime)
{
    return 1.875 * 1000 / (millis() - oldTime);
}

// Determine if wheel stopped
boolean wheelStopped(int newCnt, int oldCnt)
{
    if ((newCnt - oldCnt) <= stopCount )
        return true;
    else
        return false;
}

// Measures the current
double measureCurrent(int input)
{
    input = analogRead(input);
    return ( ( (input / gain) * gain2) / (2.0/3.0) ) * 1000;
}

// Print the wheel speeds
void printVals()
{
    Serial.print(millis(),DEC);
    Serial.print(":");
    Serial.print(rpm1,DEC);
    Serial.print(",");
    Serial.print(rpm2,DEC);
    Serial.print(",");
    Serial.print(rpm3,DEC);
    Serial.print(",");
    Serial.print(rpm4,DEC);
    Serial.print(",");
    Serial.println(current,DEC);
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

