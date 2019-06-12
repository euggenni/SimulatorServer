using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlatoonHandler : MonoBehaviour
{
    public GameObject CreatePanel; //панель редактирования взвода
    public GameObject OkNoPanel; //панель сообщения
    public Text AlertLabel; //текст сообщения
    public Button AlertButton; //кнопка подтверждения
    public InputField NamePlatoon; //имя взвода
    public Button AddStudentButton; //кнопка добавления студента
    public Button DeletePlatoon; //кропка удаления взвода
    public Button SaveButton; //кнопка сохранения
    public UnityUITable.Table Table; //таблица с данными
    public UnityUITable.Table Table2; //таблицы с данными из предыдущего окна
    public Dropdown SelectPlatoon; //кнопка выбора взвода
    public List<Student> Students = new List<Student>(); //список студентов
    private List<Student> BufferStudents = new List<Student>(); //буферный список
    private Platoon SelectedPlatoon = new Platoon();

    public void UpdateTable() //вызов функции обновления таблицы
    {
        Table.UpdateContent();
    }

    public void UpdateHeadTable() ////вызов функции обновления головной таблицы
    {
        //Table2.UpdateContent();
        //SelectPlatoon.value = 1;
        PlatoonsHandler.OnChangePlatoonDropdownOut(SelectPlatoon, Table2);
    }

    public void OpenPanel() //выполняет открытие меню редактирования списка студентов
    {
        CreatePanel.SetActive(true);
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        NamePlatoon.text = SelectedPlatoon.NamePlatoon;
        Students = new List<Student>(SelectedPlatoon.Students);
        Debug.Log(Students.Count);
        Debug.Log(Students.ToArray()[0].NameStudent);
        Invoke("UpdateTable", (float)0.5); //задержка для подгрузки данных
    }

    private void ReadData()
    {
        Transform ObjectHierarhy = Table.transform;
        Debug.Log(ObjectHierarhy.childCount);
        Transform Column = ObjectHierarhy.GetChild(0);
        Debug.Log("Число потомков" + Column.childCount);
        BufferStudents.Clear();
        for (int i = 1; i < Column.childCount; i++)
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
        for (int i = 1; i < BufferStudents.Count + 1; i++)
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
        PlatoonsManager.Platoons[PlatoonsManager.Platoons.FindIndex(x => x.NamePlatoon == SelectedPlatoon.NamePlatoon)] = new Platoon(NamePlatoon.text, BufferStudents);
        PlatoonsManager.SavePlatoons();
        PlatoonsHandler.Starter(SelectPlatoon, Table2);
        Invoke("UpdateHeadTable", (float)0.5);
        CreatePanel.SetActive(false);
    }

    public void ShowDeleteWindow() //выводит дополнительное подтверждение удаления
    {
        AlertLabel.text = "Вы точно хотите удалить взвод?";
        OkNoPanel.SetActive(true);
        AlertButton.onClick.RemoveAllListeners();     //необходимо использовать оба оператора в связке
        AlertButton.onClick.AddListener(DeletePlatoonHandler); //во избежание коллизий
    }

    public void DeletePlatoonHandler() //реализует удаление взвода
    {
        PlatoonsManager.Platoons.RemoveAt(PlatoonsManager.Platoons.FindIndex(x => x.NamePlatoon == SelectedPlatoon.NamePlatoon));
        PlatoonsHandler.SelectedPlatoon = null;
        SelectPlatoon.value = 0;
        PlatoonsManager.SavePlatoons();
        PlatoonsHandler.Starter(SelectPlatoon, Table2);
        Invoke("UpdateHeadTable", (float)0.5);
        OkNoPanel.SetActive(false);
        CreatePanel.SetActive(false);
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
