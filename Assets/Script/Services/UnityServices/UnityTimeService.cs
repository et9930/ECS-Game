using System;
using UnityEngine;

public class UnityTimeService : ITimeService
{
    private readonly DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
    private double clientServerDeltaTime;

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public float GetFixedDeltaTime()
    {
        return Time.fixedDeltaTime;
    }

    public float GetTimeScale()
    {
        return Time.timeScale;
    }

    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }

    public float GetRealTimeSinceStartup()
    {
        return Time.realtimeSinceStartup;
    }

    public double GetTimeStamp()
    {
        return (DateTime.Now - startTime).TotalMilliseconds + clientServerDeltaTime; // 相差毫秒数
    }

    public void SetClientServerDeltaTime(double value)
    {
        clientServerDeltaTime += value;
    }

    public DateTime TimeStampToDateTime(double timeStamp)
    {
//        var toTimeStamp = new TimeSpan((long)timeStamp);
        return startTime.AddMilliseconds(timeStamp);
    }
}