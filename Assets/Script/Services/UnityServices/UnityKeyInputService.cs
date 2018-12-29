using UnityEngine;

public class UnityKeyInputService : IKeyInputService
{
    public bool GetKeyDown(string keyName)
    {
        return Input.GetButtonDown(keyName);
    }

    public bool GetKeyUp(string keyName)
    {
        return Input.GetButtonUp(keyName);
    }
    
    public float GetMoveKeyValue(string moveKeyName)
    {
        return Input.GetAxis(moveKeyName);
    }
}

