using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoonsHandler : MonoBehaviour
{
    public Dropdown SelectPlatoon; //поле выбора взвода
    public UnityUITable.Table Table; //таблица с данными
    public static Platoon SelectedPlatoon = new Platoon(); //выбранный взвод
    public static List<Student> Students = new List<Student>(); //список выбранных студентов
    public Text PlatoonNameLabel; //текст, отображаемый в меню контроля процесса
    public GameObject Studentss;

    public void OnChangePlatoonDropdown() //обработчик события изменения выбранного взвода
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        PlatoonNameLabel.text = "Взвод: " + SelectPlatoon.captionText.text;
        byte number = 1;
        Students.Clear();
        foreach(Student student in SelectedPlatoon.Students)
        {
            Students.Add(new Student(student.NameStudent, number));
            number++;
        }
        Table.UpdateContent();
    }

    public static void OnChangePlatoonDropdownOut(Dropdown SelectPlatoon, UnityUITable.Table Table, Text PlatoonNameLabel) //внешний обработчик события изменения выбранного взвода
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        PlatoonNameLabel.text = "Взвод: " + SelectPlatoon.captionText.text;
        byte number = 1;
        Students.Clear();
        foreach (Student student in SelectedPlatoon.Students)
        {
            Students.Add(new Student(student.NameStudent, number));
            number++;
        }
        Table.UpdateContent();
    }

    public static void Starter(Dropdown SelectPlatoon, UnityUITable.Table Table, Text PlatoonNameLabel)//реализует процесс инициализации
    {
        PlatoonsManager.LoadPlatoons();
        SelectPlatoon.options.Clear();
        foreach (Platoon platoon in PlatoonsManager.Platoons)
        {
            SelectPlatoon.options.Add(new Dropdown.OptionData(platoon.NamePlatoon));
        }
        SelectPlatoon.RefreshShownValue();
        SelectPlatoon.value = 0;
        OnChangePlatoonDropdownOut(SelectPlatoon, Table, PlatoonNameLabel);
    }
    
    public void TranslatePlatoons() //запускает трансляцию списка взвода
    {
        Debug.Log("Translate list students started");
        Server.IsTranslate = true;
        Invoke("NewConnection", 9);
    }

    public void NewConnection()
    {
        Server.NewConnection(Studentss);
    }

    // Start is called before the first frame update
    void Start()
    {
        Starter(SelectPlatoon, Table, PlatoonNameLabel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
