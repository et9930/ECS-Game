using UnityEngine;

public class UnityTimeService : ITimeService
{
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
}