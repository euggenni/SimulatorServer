using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    private int id;
    private string computer;
    private string student;
    private List<Description> descriptions;
    private string note;

    public int ID
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Computer
    {
        get
        {
            return computer;
        }

        set
        {
            computer = value;
        }
    }

    public string Student
    {
        get
        {
            return student;
        }

        set
        {
            student = value;
        }
    }

    public string Note
    {
        get
        {
            return note;
        }

        set
        {
            note = value;
        }
    }

    public List<Description> Descriptions
    {
        get
        {
            return descriptions;
        }

        set
        {
            descriptions = value;
        }
    }

    public void OpenDescription() //Открывает окно с подробностями
    {

    }

    public Result()
    {
        this.ID = 0;
        this.Computer = "Undefined";
        this.Student = "Неизвестный";
        this.Note = "Неизвестно";
    }

    public Result(int ID, string Computer, string Student, string Note)
    {
        this.ID = ID;
        this.Computer = Computer;
        this.Student = Student;
        this.Note = Note;
    }
}
