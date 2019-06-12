using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    public UnityUITable.Table Table; //таблица с данными
    public List<Description> Descriptions = new List<Description>();

    public void UpdateTable()
    {
        Table.UpdateContent();
    }
    // Start is called before the first frame update
    void Start()
    {
        Descriptions.Add(new Description("Ракета 1", "9M333"));
        Descriptions.Add(new Description("Ракета 2", "Пусто"));
        Descriptions.Add(new Description("Ракета 3", "Пусто"));
        Descriptions.Add(new Description("Ракета 4", "Пусто"));
        Descriptions.Add(new Description("Погодные условия", "Простые"));
        Descriptions.Add(new Description("Помехи", "Горизонтальные"));
        Descriptions.Add(new Description("Интервал помех", "4с"));
        Descriptions.Add(new Description("Тумблер НРЗ", "Вкл"));
        Descriptions.Add(new Description("Тумблер АОЗ", "Вкл"));
        Invoke("UpdateTable", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
