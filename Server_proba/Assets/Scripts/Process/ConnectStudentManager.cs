using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStudentManager : MonoBehaviour
{
    public UnityUITable.Table Table; //таблица с данными
    public static List<ConnectStudent> ConnectStudents = new List<ConnectStudent>();


    public void UpdateTable()
    {
        Table.UpdateContent();
    }

    // Start is called before the first frame update
    void Start()
    {
        ConnectStudents.Add(new ConnectStudent("K-333-2", "Петров Петр Петрович", "Ожидает"));
        ConnectStudents.Add(new ConnectStudent("K-333-3", "Сидоров Сидр Сидорович", "Ожидает"));
        ConnectStudents.Add(new ConnectStudent("K-333-5", "Иванов Иван Иванович", "В процессе"));
        Invoke("UpdateTable", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
