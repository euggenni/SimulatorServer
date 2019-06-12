using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public UnityUITable.Table Table; //таблица с данными
    public List<Result> Results = new List<Result>();

    public void UpdateTable()
    {
        Table.UpdateContent();
    }
    // Start is called before the first frame update
    void Start()
    {
        Results.Add(new Result(1, "K-333-2", "Петров Петр Петрович", "Хорошо"));
        Results.Add(new Result(2, "K-333-3", "Сидоров Сидр Сидорович", "Удовлетв"));
        Results.Add(new Result(3, "K-333-5", "Иванов Иван Иванович", "Хорошо"));
        Invoke("UpdateTable", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
