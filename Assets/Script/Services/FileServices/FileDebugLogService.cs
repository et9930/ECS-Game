using System;
using System.IO;

public class FileDebugLogService : ILogService
{
    private string logFilePath = "Log\\log.txt";
    private FileStream file;
    private StreamWriter streamWriter;

    public FileDebugLogService()
    {
        file = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Delete);
        file.Position = file.Length;
        streamWriter = new StreamWriter(file);
        
    }

    ~FileDebugLogService()
    {
        file.Close();
    }

    public void LogMessage(string message)
    {
        streamWriter.Write(Utilities.GetTimeStamp() + " : <log> " + message + "\n");
    }

    public void ErrorMessage(string message)
    {
        streamWriter.Write(Utilities.GetTimeStamp() + " : <error> " + message + "\n");
    }
}