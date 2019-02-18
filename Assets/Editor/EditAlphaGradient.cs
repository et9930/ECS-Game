using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditAlphaGradient : EditorWindow
{
    public const string outputRootPath = "Assets/Resources/Output/";
    public static float Progress = 0;
    public static string current_png_path = "";
    public static bool isShow = false;

    [MenuItem("Tools/Edit Alpha Gradient")]
    public static void EditAlpha()
    {
        isShow = true;
        for (var i = 0; i < Selection.objects.Length; i++)
        {
            // get select path
            var selectionPath = AssetDatabase.GetAssetPath(Selection.objects[i]);
            try
            {
                if (selectionPath.EndsWith(".png"))
                {
                    Progress = (float)i / (float)Selection.objects.Length;
                    current_png_path = selectionPath;
                    EditorUtility.DisplayProgressBar("Progress", current_png_path, Progress);

                    DealPngFile(selectionPath);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
            
        
        EditorUtility.ClearProgressBar();
        isShow = false;

        Debug.Log("Edit Alpha Gradient Over.");
    }

    private static void DealPngFile(string pngFilePath)
    {
        // set texture readable
        TextureImporter textureImporter = AssetImporter.GetAtPath(pngFilePath) as TextureImporter;
        textureImporter.textureType = TextureImporterType.Default;
        textureImporter.isReadable = true;
        AssetDatabase.ImportAsset(pngFilePath);

        Texture2D tex = AssetDatabase.LoadAssetAtPath<Texture2D>(pngFilePath);
        var outputTex = new Texture2D(tex.width, tex.height);

        for (var x = 0; x < tex.width; x++)
        {
            var alpha = 1 - x / (float)tex.width;
            for (var y = 0; y < tex.height; y++)
            {
                var color = tex.GetPixel(x, y);
                color.a = alpha;
                outputTex.SetPixel(x, y ,color);
                outputTex.Apply();
            }
        }

        var bytes = outputTex.EncodeToPNG();
        File.WriteAllBytes(outputRootPath + "output.png", bytes);
    }
}