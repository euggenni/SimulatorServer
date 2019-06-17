using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonHelper
{
    private const string TASK_FILE_PATH = "tasks.json";

    public static T[] FromJson<T>()
    {
        string json = GetJsonString();
        Wrapper<T> wrapper = new Wrapper<T>();
        try
        {
            wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Tasks;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return new T[0];
        }
    }

    public static T[] FromJson<T>(string Path)
    {
        string json = "";
        if (File.Exists(Path))
        {
            json = File.ReadAllText(Path);
        }
        Wrapper<T> wrapper = new Wrapper<T>();
        try
        {
            wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Tasks;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return new T[0];
        }
    }

    public static string ToJson<T>(T[] list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Tasks = list;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T data)
    {
        return JsonUtility.ToJson(data);
    }

    public static string ToJson<T>(T[] list, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Tasks = list;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    public static string GetJsonString()
    {
        string output = "";
        if (File.Exists(TASK_FILE_PATH))
        {
            output = File.ReadAllText(TASK_FILE_PATH);
        }

        return output;
    }

    public static void WriteJsonString(string json)
    {
        File.WriteAllText(TASK_FILE_PATH, json);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Tasks;
    }
}
