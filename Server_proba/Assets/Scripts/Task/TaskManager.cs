using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

    public static List<Task> tasks = new List<Task>();
    public static List<Task> Tasks
    {
        get
        {
            var temp = new List<Task>(JsonHelper.FromJson<Task>());
            tasks = temp != null ? temp : new List<Task>();
            return tasks;
        }

        set
        {
            tasks = value;
        }
    }

    void Start () {
        Tasks = new List<Task>(JsonHelper.FromJson<Task>());
	}

    public void SaveTaskSample()
    {
        tasks.Add(TaskParamsMenuHandler.task);
        Debug.Log(tasks.Count);
        JsonHelper.WriteJsonString(JsonHelper.ToJson(tasks.ToArray(), true));
    }

    public static void SaveTasks()
    {
        JsonHelper.WriteJsonString(JsonHelper.ToJson(Tasks.ToArray(), true));
    }

    public static void RemoveTask(int index)
    {
        tasks.RemoveAt(index);
        SaveTasks();
    }

}
