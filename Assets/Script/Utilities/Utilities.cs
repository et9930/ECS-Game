using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEngine;
using Random = System.Random;

public static class Utilities
{
    private static Random random = new Random();

    public static System.Numerics.Vector2 ToSystemNumericsVector2(UnityEngine.Vector2 value)
    {
        return new System.Numerics.Vector2(value.x, value.y);
    }

    public static UnityEngine.Vector2 ToUnityEngineVector2(System.Numerics.Vector2 value)
    {
        return new UnityEngine.Vector2(value.X, value.Y);
    }

    public static UnityEngine.Vector3 ToUnityEngineVector3(System.Numerics.Vector3 value)
    {
        return new UnityEngine.Vector3(value.X, value.Y, value.Z);
    }

    public static T ParseJson<T>(string strJson)
    {
        T obj;

        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(strJson)))
        {
            var deseralizer = new DataContractJsonSerializer(typeof(T));
            obj = (T)deseralizer.ReadObject(ms);//反序列化ReadObject
        }

        return obj;
    }

    public static string ToJson(object item)
    {
        return Nakama.TinyJson.JsonWriter.ToJson(item);
    }

    public static System.Numerics.Vector4 ToSystemNumericsVector4(UnityEngine.Color value)
    {
        return new System.Numerics.Vector4(value.r, value.g, value.b, value.a);
    }

    public static System.Numerics.Vector4 ToSystemNumericsVector4(UnityEngine.Vector4 value)
    {
        return new System.Numerics.Vector4(value.x, value.y, value.z, value.w);
    }

    public static System.Numerics.Vector3 ToSystemNumericsVector3(UnityEngine.Color value)
    {
        return new System.Numerics.Vector3(value.r, value.g, value.b);
    }

    public static System.Numerics.Vector3 ToSystemNumericsVector3(UnityEngine.Vector3 value)
    {
        return new System.Numerics.Vector3(value.x, value.y, value.z);
    }

    public static UnityEngine.Color ToUnityEngineColor(System.Numerics.Vector4 value)
    {
        if (value.X <= 1 && value.Y <= 1 && value.Z <= 1 && value.W <= 1)
        {
            return new Color(value.X, value.Y, value.Z, value.W);
        }
        return new Color(value.X / 255.0f, value.Y / 255.0f, value.Z / 255.0f, value.W / 255.0f);
    }

    public static UnityEngine.Color ToUnityEngineColor(System.Numerics.Vector3 value)
    {
        if (value.X <= 1 && value.Y <= 1 && value.Z <= 1)
        {
            return new Color(value.X, value.Y, value.Z);
        }
        return new Color(value.X / 255.0f, value.Y / 255.0f, value.Z / 255.0f);
    }

    public static int RandomInt(int min, int max)
    {
        var result = random.Next(min, max);
        Debug.Log("---- random int : " + result);
        return result;
    }

    public static float RandomFloat(float min, float max)
    {
        var result = (float)random.NextDouble() * (max - min) + min;
        Debug.Log("---- random float : " + result);
        return result;
    }

    public static Vector2 Vector3PositionToVector2Position(System.Numerics.Vector3 value)
    {
        return new Vector2(value.X, value.Y + value.Z - 1.5f);
    }

    public static bool CheckSuccess(float probability)
    {
        if (probability <= 0.0f) return false;
        if (probability >= 1.0f) return true;
        var probabilityResult = random.NextDouble();
        var result = probabilityResult <= probability;
        Debug.Log("---- " + probability + " result " + result + " " + probabilityResult);

        return result;
    }

    public static void SetRandomSeed(int seed)
    {
        Debug.Log("---- set random seed " + seed);
        random = new Random(seed);
    }
}