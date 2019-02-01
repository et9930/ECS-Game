using UnityEngine;

public class UnityDebugLogService : ILogService
{
    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public void ErrorMessage(string message)
    {
        Debug.LogError(message);
    }
}
