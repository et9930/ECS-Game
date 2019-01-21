using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

struct outputColor
{
    public int x;
    public int y;
    public Color color;
}

public class ExtractSingleSprite : EditorWindow
{

    public const string resourcesPath = "Assets/Resources/";
    public const string outputRootPath = "Assets/Resources/Output/";
    public static float Progress = 0;
    public static string currect_png_path = "";
    public static bool isShow = false;

    [MenuItem("Tools/Extract Single Sprite")]
    public static void ExtractSprite()
    {
        isShow = true;
        foreach (var obj in Selection.objects)
        {
            // get select path
            var selectionPath = AssetDatabase.GetAssetPath(obj);
            if (selectionPath.StartsWith(resourcesPath))
            {
                // check path is dir
                if (Directory.Exists(selectionPath))
                {
                    try
                    {
                        // get all png file path
                        var paths = Directory.GetFiles(selectionPath, "*.png", SearchOption.AllDirectories);
                        for (int i = 0; i < paths.Length; i++)
                        {
                            Progress = (float)i / (float)paths.Length;
                            currect_png_path = paths[i];
                            EditorUtility.DisplayProgressBar("Progress", currect_png_path, Progress);       
                            
                            DealPngFile(paths[i]);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.Message);
                    }
                }
            }
        }        
        EditorUtility.ClearProgressBar();
        isShow = false;

        Debug.Log("Extract Single Sprite Over.");
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }

    public static void DealPngFile(string pngFilePath)
    {
        // set output dir
        var outputDir = Path.GetDirectoryName(pngFilePath);
        outputDir = outputDir.Substring(resourcesPath.Length);
        var outputFileName = Path.GetFileName(pngFilePath);
        
        System.IO.Directory.CreateDirectory(outputRootPath + outputDir);

        // set texture readable
        TextureImporter textureImporter = AssetImporter.GetAtPath(pngFilePath) as TextureImporter;
        textureImporter.textureType = TextureImporterType.Default;
        textureImporter.isReadable = true;
        AssetDatabase.ImportAsset(pngFilePath);

        // read origin texture and get new texture
        Texture2D tex = AssetDatabase.LoadAssetAtPath<Texture2D>(pngFilePath);
        var outputTex = new Texture2D(tex.width, tex.height);
        var outputPixel = new Stack<outputColor>();

        // mark the pixel has read
        var hasRead = new bool[tex.width, tex.height];
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                hasRead[x, y] = false;
            }
        }

        // set new texture to (255, 255, 255, 0)
        var initColor = new Color(255, 255, 255, 0);
        for (int x = 0; x < outputTex.width; x++)
        {
            for (int y = 0; y < outputTex.height; y++)
            {
                outputTex.SetPixel(x, y, initColor);
            }
        }
        outputTex.Apply();

        // get origin center pixel
        var center_x = tex.width / 2;
        var center_y = tex.height / 2;
        var center_color = tex.GetPixel(center_x, center_y);
        if (center_color.a != 0)
        {
            var outputColor = new outputColor
            {
                x = center_x,
                y = center_y,
                color = center_color
            };
            hasRead[center_x, center_y] = true;
            outputPixel.Push(outputColor);
        }
        else
        {
            center_x = tex.width / 4 * 3;
            center_y = tex.height / 2;
            center_color = tex.GetPixel(center_x, center_y);
            if (center_color.a != 0)
            {
                var outputColor = new outputColor
                {
                    x = center_x,
                    y = center_y,
                    color = center_color
                };
                hasRead[center_x, center_y] = true;
                outputPixel.Push(outputColor);
            }
        }

        // enum pixel
        while (outputPixel.Count != 0)
        {
            var temp = outputPixel.Pop();
            outputTex.SetPixel(temp.x, temp.y, temp.color);

            //up
            if (temp.y + 1 < tex.height)
            {
                if (hasRead[temp.x, temp.y + 1] == false)
                {
                    var up_color = tex.GetPixel(temp.x, temp.y + 1);
                    if (up_color.a != 0)
                    {
                        var outputColor = new outputColor
                        {
                            x = temp.x,
                            y = temp.y + 1,
                            color = up_color
                        };
                        outputPixel.Push(outputColor);
                        hasRead[temp.x, temp.y + 1] = true;
                    }
                }
            }
            
            //down
            if (temp.y - 1 > -1)
            {
                if (hasRead[temp.x, temp.y - 1] == false)
                {
                    var down_color = tex.GetPixel(temp.x, temp.y - 1);
                    if (down_color.a != 0)
                    {
                        var outputColor = new outputColor
                        {
                            x = temp.x,
                            y = temp.y - 1,
                            color = down_color
                        };
                        outputPixel.Push(outputColor);
                        hasRead[temp.x, temp.y - 1] = true;
                    }
                }
            }

            //left
            if (temp.x - 1 > -1)
            {
                if (hasRead[temp.x - 1, temp.y] == false)
                {
                    var left_color = tex.GetPixel(temp.x - 1, temp.y);
                    if (left_color.a != 0)
                    {
                        var outputColor = new outputColor
                        {
                            x = temp.x - 1,
                            y = temp.y,
                            color = left_color
                        };
                        outputPixel.Push(outputColor);
                        hasRead[temp.x - 1, temp.y] = true;
                    }
                }
            }

            //right
            if (temp.x + 1 < tex.width)
            {
                if (hasRead[temp.x + 1, temp.y] == false)
                {
                    var right_color = tex.GetPixel(temp.x + 1, temp.y);
                    if (right_color.a != 0)
                    {
                        var outputColor = new outputColor
                        {
                            x = temp.x + 1,
                            y = temp.y,
                            color = right_color
                        };
                        outputPixel.Push(outputColor);
                        hasRead[temp.x + 1, temp.y] = true;
                    }
                }
            }
        }
        outputTex.Apply();

        // write file
        var bytes = outputTex.EncodeToPNG();
        File.WriteAllBytes(outputRootPath  + outputDir + "\\" + outputFileName, bytes);
    }
}
