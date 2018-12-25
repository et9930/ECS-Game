using UnityEngine;

public class UnityLoadConfigService : ILoadConfigService
{
    public string LoadJsonFile(string jsonPath)
    {
        var configObj = Resources.Load(jsonPath);
        var jsonString = configObj.ToString();
        return jsonString;
    }
}