using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStudent
{
    private string computer;
    private string student;
    private string state;

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

    public string State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }

    public ConnectStudent()
    {
        this.Computer = "Unknown";
        this.Student = "Неизвестный";
        this.State = "Ожидает";
    }

    public ConnectStudent(string Computer, string Student, string State)
    {
        this.Computer = Computer;
        this.Student = Student;
        this.State = State;
    }
}
