public interface ILocalStorageService
{
    // set
    void SetInt(string key, int value);
    void SetFloat(string key, float value);
    void SetString(string key, string value);
    void SetBool(string key, bool value);

    // get
    int GetInt(string key);
    float GetFloat(string key);
    string GetString(string key);
    bool GetBool(string key);

    // check
    bool HasKey(string key);
    
    // delete
    void DeleteKey(string key);
    void DeleteAll();
}