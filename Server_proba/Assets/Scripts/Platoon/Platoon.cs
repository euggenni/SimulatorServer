using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Platoon
{
    [SerializeField]
    private List<Student> students;
    [SerializeField]
    private string namePlatoon;
    [SerializeField]
    private byte idPlatoon;

    public List<Student> Students
    {
        get
        {
            return students;
        }

        set
        {
            students = value;
        }
    }

    public string NamePlatoon
    {
        get
        {
            return namePlatoon;
        }

        set
        {
            namePlatoon = value;
        }
    }

    public byte IdPlatoon
    {
        get
        {
            return idPlatoon;
        }

        set
        {
            idPlatoon = value;
        }
    }

    public Platoon()
    {
        this.Students = new List<Student>();
        this.NamePlatoon = "000";
        this.IdPlatoon = 0;
    }

    public Platoon(string NamePlatoon) :base()
    {
        this.NamePlatoon = NamePlatoon;
    }

    public Platoon(List<Student> Students, string NamePlatoon, byte IDPlatoon)
    {
        this.Students = Students;
        this.NamePlatoon = NamePlatoon;
        this.IdPlatoon = IDPlatoon;
    }

    public void AddStudent(Student newStudent) //осуществляет добавление студентов
    {
        Students.Add(newStudent);
    }

    public void DeleteStudent(Student student) //осуществляет удаление указанного студента
    {
        Students.Remove(Students.Find(x => x.NameStudent == student.NameStudent));
    }

    public void RemoveStudents() //удаляет всех студентов
    {
        Students.Clear();
    }

    public void UpNamePlatoon() //переводит взвод на следующий курс
    {
        try
        {
            int name = Convert.ToInt32(NamePlatoon);
            name += 10;
            NamePlatoon = name.ToString();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public Student GetStudent(string StudentName) //Возвращает студента по имени
    {
        return Students.Find(x => x.NameStudent == StudentName);
    }
}
