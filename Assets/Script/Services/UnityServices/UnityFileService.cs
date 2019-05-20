using System.IO;
using UnityEngine;

public class UnityFileService : IFileService
{
    private readonly string _saveDir = Application.persistentDataPath + "/SavedGames/";

    public string GetPath(string matchId)
    {
        return _saveDir + "match_record_data_" + matchId + ".savedmatch";
    }

    public bool CheckSavedFile(string matchId)
    {
        return File.Exists(GetPath(matchId));
    }

    public string ReadSavedMatch(string matchId)
    {
        
        if (!CheckSavedFile(matchId)) return "";
        var path = GetPath(matchId);
        var fs = File.Open(path, FileMode.Open);
        var fsLen = (int)fs.Length;
        var readByte = new byte[fsLen];
        fs.Read(readByte, 0, readByte.Length);
        fs.Close();
        return System.Text.Encoding.UTF8.GetString(readByte);
    }

    public void SaveMatchFile(string matchRecord, string matchId)
    {
        var path = GetPath(matchId);
        var dir = path.Substring(0, path.LastIndexOf('/'));
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        var writeByte = System.Text.Encoding.UTF8.GetBytes(matchRecord);
        var fs = File.Open(path, FileMode.Create);
        fs.Write(writeByte, 0, writeByte.Length);
        fs.Close();
    }
}