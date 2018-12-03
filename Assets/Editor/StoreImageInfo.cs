using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using UnityEditor;
using OfficeOpenXml;
using UnityEngine;

public class Infos : ScriptableObject
{
    public List<PngInfo> infos;
}

[System.Serializable]
public class PngInfo
{
    public string name;
    public string animName;
    public int frameCount;
    public Vector2 size;
    public Vector2 pivot;
}

public class StoreImageInfo : EditorWindow
{
    public const string resourcesPath = "Assets/Resources/";
    public const string ImagePath = "Assets/Resources/Output/Image/";
    public static float Progress = 0;
    public static string currect_path = "";
    public static bool isShow = false;
    private static Dictionary<string, Infos> pngInfos = new Dictionary<string, Infos>();
    
    [MenuItem("Tools/Store Image Info In Excel File")]
    public static void StoreImageInfoFunc()
    {

        isShow = true;
        try
        {
            var dirs = Directory.GetDirectories(ImagePath, "*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < dirs.Length; i++)
            {
                Progress = (float)i / (float)dirs.Length;
                currect_path = dirs[i];
                EditorUtility.DisplayProgressBar("Progress", currect_path, Progress);
                
                pngInfos.Add(dirs[i].Substring(ImagePath.Length), DealDir(dirs[i]));                
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        EditorUtility.DisplayProgressBar("Progress", "Write In Asset File", 1);
        WriteInAssetFile();

        EditorUtility.ClearProgressBar();
        isShow = false;        
    }

    private static void WriteInAssetFile()
    {
        foreach (var item in pngInfos)
        {
            var outputPath = resourcesPath + "Image/" + item.Key + ".asset";
            AssetDatabase.CreateAsset(item.Value, outputPath);
            AssetDatabase.Refresh();
        }
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }

    public static Infos DealDir(string dirPath)
    {        
        var pngInfos = ScriptableObject.CreateInstance<Infos>();
        var infoList = new List<PngInfo>();
        try
        {
            var pngPaths = Directory.GetFiles(dirPath, "*.png", SearchOption.TopDirectoryOnly);
            Debug.Log(pngPaths.Length);
            for (int i = 0; i < pngPaths.Length; i++)
            {
                infoList.Add(DealPng(pngPaths[i]));
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        pngInfos.infos = infoList;
        return pngInfos;
    }

    public static PngInfo DealPng(string pngPath)
    {
        var info = new PngInfo();
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(pngPath);
        info.name = Path.GetFileNameWithoutExtension(pngPath);
        var _index = info.name.IndexOf('_');
        info.animName = info.name.Substring(0, _index);
        info.frameCount = int.Parse(info.name.Substring(_index + 1));
        info.pivot = sprite.pivot;
        info.size.x = sprite.texture.width;
        info.size.y = sprite.texture.height;
        return info;
    }
}





