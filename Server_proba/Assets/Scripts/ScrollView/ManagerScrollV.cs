using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScrollV : MonoBehaviour
{
    private List<Task> taskList = TaskManager.tasks;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool; 

    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    void Update()
    {

    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = contentPanel.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            Task item = taskList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            TaskButton sampleButton = newButton.GetComponent<TaskButton>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryTransferItemToOtherShop(Task task)
    {
        taskList.Remove(task);
        JsonHelper.WriteJsonString(JsonHelper.ToJson(taskList.ToArray(), true));
    }

    public void AddTask()
    {
        RefreshDisplay();
    }

    void AddItem(Task taskToAdd, ManagerScrollV shopList)
    {
        shopList.taskList.Add(taskToAdd);
    }

    private void RemoveItem(Task taskToRemove, ManagerScrollV shopList)
    {
        for (int i = shopList.taskList.Count - 1; i >= 0; i--)
        {
            if (shopList.taskList[i] == taskToRemove)
            {
                shopList.taskList.RemoveAt(i);
            }
        }
    }
}
