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

    public void OnChangePlatoonDropdown() //обработчик события изменения выбранного взвода
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        byte number = 1;
        Students.Clear();
        foreach(Student student in SelectedPlatoon.Students)
        {
            Students.Add(new Student(student.NameStudent, number));
            number++;
        }
        Table.UpdateContent();
    }

    public static void OnChangePlatoonDropdownOut(Dropdown SelectPlatoon, UnityUITable.Table Table) //внешний обработчик события изменения выбранного взвода
    {
        SelectedPlatoon = PlatoonsManager.GetPlatoon(SelectPlatoon.captionText.text);
        byte number = 1;
        Students.Clear();
        foreach (Student student in SelectedPlatoon.Students)
        {
            Students.Add(new Student(student.NameStudent, number));
            number++;
        }
        Table.UpdateContent();
    }

    public static void Starter(Dropdown SelectPlatoon, UnityUITable.Table Table)//реализует процесс инициализации
    {
        PlatoonsManager.LoadPlatoons();
        //PlatoonsManager.Platoons.Sort();
        SelectPlatoon.options.Clear();
        foreach (Platoon platoon in PlatoonsManager.Platoons)
        {
            SelectPlatoon.options.Add(new Dropdown.OptionData(platoon.NamePlatoon));
        }
    }
    
    public void TranslatePlatoons() //запускает трансляцию списка взвода
    {
        Server.IsTranslate = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Starter(SelectPlatoon, Table);
        Invoke("OnChangePlatoonDropdown", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
