using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlatoonHandler : MonoBehaviour
{
    public GameObject CreatePanel; //панель создания взвода
    public InputField NamePlatoon; //имя взвода
    public Button AddStudentButton; //кнопка добавления студента
    public Button SaveButton; //кнопка сохранения
    public UnityUITable.Table Table; //таблица с данными
    public UnityUITable.Table Table2; //таблицы с данными из предыдущего окна
    public Dropdown SelectPlatoon; //кнопка выбора взвода
    public Text PlatoonNameLabel; //текст, выводящий название взвода при контроле выполнения
    public List<Student> Students = new List<Student>(); //список студентов
    private List<Student> BufferStudents = new List<Student>(); //буферный список

    private void ReadData()
    {
        Transform ObjectHierarhy = Table.transform;
        Debug.Log(ObjectHierarhy.childCount);
        Transform Column = ObjectHierarhy.GetChild(0);
        Debug.Log("Число потомков" + Column.childCount);
        BufferStudents.Clear();
        for(int i = 1; i < Column.childCount; i++)
        {
            Transform Outline = Column.GetChild(i);
            Transform Content = Outline.GetChild(0);
            Transform Content2 = Content.GetChild(0);
            Transform InputCell = Content2.GetChild(0);
            InputField Cell = InputCell.GetComponent<InputField>();
            BufferStudents.Add(new Student(Cell.text));
        }
    }

    private void WriteData()
    {
        Transform ObjectHierarhy = Table.transform;
        Transform Column = ObjectHierarhy.GetChild(0);
        Students = new List<Student>(BufferStudents);
        for (int i = 1; i < BufferStudents.Count+1; i++)
        {
            Transform Outline = Column.GetChild(i);
            Transform Content = Outline.GetChild(0);
            Transform Content2 = Content.GetChild(0);
            Transform InputCell = Content2.GetChild(0);
            InputField Cell = InputCell.GetComponent<InputField>();
            Cell.text = BufferStudents.ToArray()[i - 1].NameStudent;
        }
    }

    public void AddStudent() //реализует добавление студента
    {
        Students.Add(new Student());
        ReadData();
        Table.UpdateContent();
        WriteData();
    }

    public void SavePlatoon() //реализует сохранение взвода
    {
        ReadData();
        PlatoonsManager.AddPlatoon(new Platoon(NamePlatoon.text, BufferStudents));
        PlatoonsManager.SavePlatoons();
        PlatoonsHandler.Starter(SelectPlatoon, Table2, PlatoonNameLabel);
        CreatePanel.SetActive(false);
    }

    public void OpenPanel() //открывает окно создания взвода
    {
        CreatePanel.SetActive(true);
        //SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        //NamePlatoon.text = SelectedPlatoon.NamePlatoon;
        NamePlatoon.text = "";
        Students = new List<Student>();
        Table.UpdateContent();
        //Invoke("UpdateTable", (float)0.5); //задержка для подгрузки данных
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
