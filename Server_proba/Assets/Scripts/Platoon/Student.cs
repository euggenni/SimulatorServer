using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Student
{
    [SerializeField]
    private string nameStudent;
    [SerializeField]
    private byte idStudent;

    public string NameStudent
    {
        get
        {
            return nameStudent;
        }

        set
        {
            nameStudent = value;
        }
    }

    public byte IdStudent
    {
        get
        {
            return idStudent;
        }

        set
        {
            idStudent = value;
        }
    }

    public Student()
    {
        this.NameStudent = "Неизвестный";
        this.IdStudent = 0;
    }

    public Student(string NameStudent) :base()
    {
        this.NameStudent = NameStudent;
    }
}
