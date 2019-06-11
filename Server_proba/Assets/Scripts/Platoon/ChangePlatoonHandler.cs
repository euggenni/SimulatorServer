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

    public void OpenPanel() //выполняет открытие меню редактирования списка студентов
    {
        CreatePanel.SetActive(true);
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        NamePlatoon.text = SelectedPlatoon.NamePlatoon;
        Students = new List<Student>(SelectedPlatoon.Students);
        Debug.Log(Students.Count);
        Debug.Log(Students.ToArray()[0].NameStudent);
        Table.UpdateContent();
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
