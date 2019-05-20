public interface IFileService
{
    bool CheckSavedFile(string matchId);
    string ReadSavedMatch(string matchId);
    void SaveMatchFile(string matchRecord, string matchId);
}