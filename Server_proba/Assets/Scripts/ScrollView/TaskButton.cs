using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;


    private Task task;
    private ManagerScrollV scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Task currentItem, ManagerScrollV currentScrollList)
    {
        task = currentItem;
        nameLabel.text = task.TaskName;
        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(task);
    }
}