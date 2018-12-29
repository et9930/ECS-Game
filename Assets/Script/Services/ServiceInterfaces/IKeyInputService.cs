public interface IKeyInputService
{
    float GetMoveKeyValue(string moveKeyName);
    bool GetKeyDown(string keyName);
    bool GetKeyUp(string keyName);
}