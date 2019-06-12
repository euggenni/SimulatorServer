using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description
{
    private string parameter;
    private string _value;

    public string Parameter
    {
        get
        {
            return parameter;
        }

        set
        {
            parameter = value;
        }
    }

    public string Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }

    public Description()
    {
        this.Parameter = "Неизвестный";
        this.Value = "Неизвестно";
    }

    public Description(string Parameter, string Value)
    {
        this.Parameter = Parameter;
        this.Value = Value;
    }
}
