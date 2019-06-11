using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;

[Serializable]
public class User
{
    [SerializeField]
    private string fio;
    [SerializeField]
    private string password;

    public string Fio
    {
        get
        {
            return fio;
        }

        set
        {
            fio = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public User()
    {
        this.Fio = "Undefined";
        this.Password = ComputeSHA512Checksum("Undefined");
    }

    public User(String FIO, String PAssword)
    {
        this.Fio = FIO;
        this.Password = ComputeSHA512Checksum(PAssword);
    }

    public static bool operator ==(User user1, User user2)
    {
        if (user1.Fio == user2.Fio && user1.Password == user2.Password) return true;
        else return false;
    }

    public static bool operator !=(User user1, User user2)
    {
        if (user1.Fio == user2.Fio && user1.Password == user2.Password) return false;
        else return true;
    }

    private static string ComputeSHA512Checksum(string path) //генерирует хеш значение
    {
            SHA512 shaM = new SHA512Managed();
            byte[] fileData = System.Text.Encoding.Default.GetBytes(path);
            byte[] checkSum = shaM.ComputeHash(fileData);
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
    }
}
