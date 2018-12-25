using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEditor;
using UnityEngine;

public class StoreImageInfo : EditorWindow
{
    public const string resourcesPath = "Assets/Resources/";
    public const string ImagePath = "Assets/Resources/Image/";
    public static float Progress = 0;
    public static string currect_path = "";
    public static bool isShow = false;
    private static List<CharacterInfo> characterInfos;
    
    [MenuItem("Tools/Store Image Info In Json File")]
    public static void StoreImageInfoFunc()
    {
        characterInfos = new List<CharacterInfo>();
        isShow = true;
        try
        {
            var dirs = Directory.GetDirectories(ImagePath, "*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < dirs.Length; i++)
            {
                Progress = (float)i / (float)dirs.Length;
                currect_path = dirs[i];
                EditorUtility.DisplayProgressBar("Progress", currect_path, Progress);

                characterInfos.Add(DealDir(dirs[i]));                
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message + '\n' + e.StackTrace);
        }

        EditorUtility.DisplayProgressBar("Progress", "Write In Json File", 1);
        WriteInJsonFile();

        EditorUtility.ClearProgressBar();
        isShow = false;        
    }

    private static void WriteInJsonFile()
    {
        var infos = new ImageInfos {infos = characterInfos};
        var outputPath = resourcesPath + "Json/AnimationInfos.json";
        //序列化
        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ImageInfos));
        MemoryStream msObj = new MemoryStream();
        //将序列化之后的Json格式数据写入流中
        js.WriteObject(msObj, infos);
        msObj.Position = 0;
        //从0这个位置开始读取流中的数据
        StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
        string json = sr.ReadToEnd();
        sr.Close();
        msObj.Close();
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            sw.Write(json);
        }
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }

    public static CharacterInfo DealDir(string dirPath)
    {                
        var characterInfo = new CharacterInfo();
        characterInfo.animationInfos = new List<AnimationInfo>();
        characterInfo.characterName = dirPath.Substring(ImagePath.Length);
        AnimationInfo animInfo = null;
        var animName = "";
        try
        {
            var pngPaths = Directory.GetFiles(dirPath, "*.png", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < pngPaths.Length; i++)
            {
                var tmp = Path.GetFileNameWithoutExtension(pngPaths[i]);
                var _index = tmp.IndexOf('_');
                tmp = tmp.Substring(0, _index);
                if (!tmp.Equals(animName))
                {
                    if (animInfo != null)
                    {
                        characterInfo.animationInfos.Add(animInfo);
                    }
                    animInfo = new AnimationInfo();
                    animInfo.frameInfos = new List<FrameInfo>();
                    animName = tmp;
                    animInfo.animationName = animName;
                }
                animInfo.frameInfos.Add(DealPng(pngPaths[i]));
            }
            characterInfo.animationInfos.Add(animInfo);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message + '\n' + e.StackTrace);
        }
        
        return characterInfo;
    }

    public static FrameInfo DealPng(string pngPath)
    {
        var info = new FrameInfo();
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(pngPath);
        info.name = Path.GetFileNameWithoutExtension(pngPath);
        info.path = Path.GetDirectoryName(pngPath).Substring(resourcesPath.Length).Replace('\\', '/') + "/" + info.name;
        var _index = info.name.IndexOf('_');
        info.frameCount = int.Parse(info.name.Substring(_index + 1));
        info.pivot = Utilities.ToSystemNumericsVector2(sprite.pivot);
        info.size.X = sprite.texture.width;
        info.size.Y = sprite.texture.height;
        return info;
    }
}





