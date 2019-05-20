using System;

public interface ITimeService
{
    float GetDeltaTime();
    float GetFixedDeltaTime();
    float GetTimeScale();
    void SetTimeScale(float value);
    float GetRealTimeSinceStartup();
    double GetTimeStamp();
    void SetClientServerDeltaTime(double value);
    DateTime TimeStampToDateTime(double timeStamp);
}