using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIInfo : EditorWindow
{
    public const string resourcesPath = "Assets/Resources/";
    public const string UiPath = "Assets/Resources/Prefab/UI/";
    public static float Progress = 0;
    public static string currect_path = "";
    public static bool isShow = false;
    private static List<UiInfo> uiInfos;

    [MenuItem("Tools/Store UI Info In Json File")]
    public static void StoreUIInfoFunc()
    {
        uiInfos = new List<UiInfo>();
        isShow = true;
        try
        {
            var dirs = Directory.GetFiles(UiPath, "*.prefab", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < dirs.Length; i++)
            {
                Progress = (float) i / (float) dirs.Length;
                currect_path = dirs[i];
                EditorUtility.DisplayProgressBar("Progress", currect_path, Progress);

                uiInfos.Add(DealPrefab(dirs[i]));
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message + '\n' + e.StackTrace);
            throw;
        }

        EditorUtility.DisplayProgressBar("Progress", "Write In Json File", 1);
        WriteInJsonFile();

        EditorUtility.ClearProgressBar();
        isShow = false;
    
    }

    private static void WriteInJsonFile()
    {
        var infos = new UiInfoList {UIConfigs = uiInfos};
        var outputPath = resourcesPath + "Json/UIConfig.json";

        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UiInfoList));
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

    public static UiInfo DealPrefab(string path)
    {
        var uiInfo = new UiInfo();
        uiInfo.Components = new List<ComponentInfo>();

        var prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
        var transform = prefab.transform;
        uiInfo.UiName = prefab.name;

        DealChildren(transform, ref uiInfo.Components, "");
        
        return uiInfo;
    }

    public static void DealChildren(Transform transform, ref List<ComponentInfo> components, string rootPath)
    {
        var component = GetComponentInfo(transform.gameObject, rootPath);
        if (component.ComponentType != "null")
        {
            components.Add(component);
        }

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                DealChildren(transform.GetChild(i), ref components, rootPath+transform.gameObject.name+"/");
            }
        }
    }

    public static ComponentInfo GetComponentInfo(GameObject gameObject, string rootPath)
    {
        var componentInfo = new ComponentInfo();
        componentInfo.ComponentName = gameObject.name;
        componentInfo.ComponentPath = rootPath + gameObject.name;

        if (gameObject.GetComponent<Text>() != null)
        {
            componentInfo.ComponentType = "Text";
            return componentInfo;
        }

        if (gameObject.GetComponent<Image>() != null)
        {
            componentInfo.ComponentType = "Image";
            return componentInfo;
        }

        if (gameObject.GetComponent<Button>() != null)
        {
            componentInfo.ComponentType = "Button";
            return componentInfo;
        }

        if (gameObject.GetComponent<Toggle>() != null)
        {
            componentInfo.ComponentType = "Toggle";
            return componentInfo;
        }

        if (gameObject.GetComponent<InputField>() != null)
        {
            componentInfo.ComponentType = "InputField";
            return componentInfo;
        }

        if (gameObject.GetComponent<Slider>() != null)
        {
            componentInfo.ComponentType = "Slider";
            return componentInfo;
        }

        componentInfo.ComponentType = "null";
        return componentInfo;
    }
}
