using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStudentManager : MonoBehaviour
{
    public UnityUITable.Table Table; //таблица с данными
    public static List<ConnectStudent> ConnectStudents = new List<ConnectStudent>();

    public void StartTesting() //начинает процесс тестирования
    {
        Server.StartTesting();
        ConnectStudents.ToArray()[0].State = "В процессе";
        UpdateTable();
    }

    public void EndTesting() //завершает процесс тестирования
    {
        Server.EndTesting();
        ConnectStudents.ToArray()[0].State = "Завершено";
        UpdateTable();
    }

    public void UpdateTable()
    {
        Table.UpdateContent();
    }

    // Start is called before the first frame update
    void Start()
    {
        ConnectStudents.Add(new ConnectStudent("Зверь-ПК", "Абдулаев Артур Багирович", "Ожидание"));
        Invoke("UpdateTable", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
