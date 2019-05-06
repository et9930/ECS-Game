using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildFinish : IPostprocessBuildWithReport
{
    private readonly string sourceFolder = "Build";
    private readonly List<string> targetFolderList = new List<string>
    {
//        "G:\\Test\\01",
//        "G:\\Test\\02",
//        "G:\\Test\\03",
    };

    public int callbackOrder => 0;
    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log("Coping");
        foreach (var targetFolder in targetFolderList)
        {
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
        }

        foreach (var targetFolder in targetFolderList)
        {
            Debug.Log("Copy to " + targetFolder);
            DirectoryCopy(sourceFolder, targetFolder, true);
        }
        
        Debug.Log("Copy finish");
    }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, true);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}