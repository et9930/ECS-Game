public interface ITimeService
{
    float GetDeltaTime();
    float GetFixedDeltaTime();
    float GetTimeScale();
    void SetTimeScale(float value);
    float GetRealTimeSinceStartup();
}