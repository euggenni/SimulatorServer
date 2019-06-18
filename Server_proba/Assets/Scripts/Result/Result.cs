using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    private ResultManager resultManager;

    private int id;
    private string computer;
    private string student;
    private string platoon;
    private DateTime date;
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

    public string Platoon
    {
        get
        {
            return platoon;
        }

        set
        {
            platoon = value;
        }
    }

    public DateTime Date
    {
        get
        {
            return date;
        }

        set
        {
            date = value;
        }
    }

    public ResultManager ResultManager
    {
        get
        {
            return resultManager;
        }

        set
        {
            resultManager = value;
        }
    }

    public void OpenDescription() //Открывает окно с подробностями
    {
        ResultManager.ShowDescription();
    }

    public Result()
    {
        this.ID = 0;
        this.Computer = "Undefined";
        this.Student = "Неизвестный";
        this.Note = "Неизвестно";
        this.Platoon = "000";
        this.Date = new DateTime();
        this.ResultManager = null;
    }

    public Result(int ID, string Computer, string Student, string Note, string Platoon, DateTime Date, ResultManager resultManager)
    {
        this.ID = ID;
        this.Computer = Computer;
        this.Student = Student;
        this.Note = Note;
        this.Platoon = Platoon;
        this.Date = Date;
        this.resultManager = resultManager;
    }
}
