using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PreparingTaskWindowHandler : MonoBehaviour {

    public UnityEngine.UI.Button taskPanelPrefab;
    public GameObject content;
    public GameObject taskPanel;
    UnityEngine.UI.Button scrollViewItem;
    private List<UnityEngine.UI.Button> items = new List<UnityEngine.UI.Button>();

    void OnEnable () {
        float yPosition = content.transform.position.y * 1.5f;
        float increaseValue = taskPanelPrefab.GetComponent<RectTransform>().rect.height;
        int counter = 0;
        foreach (var task in TaskManager.Tasks)
        {
            scrollViewItem = Instantiate(taskPanelPrefab, content.transform);
            items.Add(scrollViewItem);
            scrollViewItem.GetComponent<RectTransform>().position = new Vector3(transform.position.x, yPosition, transform.position.z);
            SetupItemInfo(task);
            scrollViewItem.transform.SetParent(content.transform, false);
            yPosition -= increaseValue + increaseValue * 0.3f;
            int index = counter;
            scrollViewItem.onClick.AddListener(() => OnClickPreparedTask(index));
            scrollViewItem.onClick.AddListener(() => OnClickPreparedTask(index));
            scrollViewItem.GetComponentsInChildren<UnityEngine.UI.Button>()[1].onClick.AddListener(() => OnClickDeletePreparedTask(scrollViewItem, index));
            counter++;
        }
	}

    void OnDisable()
    {
        foreach (var item in items)
        {
            Destroy(item);
        }
    }

    private void OnClickPreparedTask(int index)
    {
        taskPanel.GetComponent<TaskParamsMenuHandler>().InitParamsMenu(TaskManager.Tasks[index]);
        gameObject.SetActive(false);
    }

    private void OnClickDeletePreparedTask(UnityEngine.UI.Button item, int index)
    {
        Debug.Log(TaskManager.Tasks.Count);
        TaskManager.RemoveTask(index);
        Debug.Log(TaskManager.Tasks.Count);
        Destroy(item);
    }

    private void SetupItemInfo(Task item)
    {
        StringBuilder result = new StringBuilder();
        switch (item.LAType)
        {
            case LAType.TypeA10F: result.Append("A-10 Thunderbolt"); break;
            case LAType.Propeller: result.Append("Винтомоторный"); break;
            case LAType.CruiseMissle: result.Append("Крылатая ракета"); break;
            case LAType.F15: result.Append("F15"); break;
            case LAType.Helicopter: result.Append("AH-64 Apache"); break;
        }
        scrollViewItem.GetComponentsInChildren<Text>()[1].text = result.ToString();
    }

    void Destroy()
    {
        scrollViewItem.onClick.RemoveListener(() => OnClickPreparedTask(0));
    }
}
