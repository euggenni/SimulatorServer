using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Users : MonoBehaviour
{

    private static List<User> users = new List<User>();
    private static string USERS_FILE_PATH = "users.json";

    public static List<User> _Users
    {
        get
        {
            return users;
        }

        set
        {
            users = value;
        }
    }

    public static bool AddUser(User user) //Добавляет нового пользователя
    {
        if (!_Users.Exists(x => x.Fio == user.Fio))
        {
            _Users.Add(user);
            return true;
        }
        else return false;
    }

    public static bool FindUser(User user) //Находит пользователя в списке
    {
        if (_Users.Exists(x => (x.Fio == user.Fio) && (x.Password == user.Password)))
        {
            return true;
        }
        else return false;
    }

    public static bool UpdatePassword(User user, string new_password) //Меняет пароль
    {
        if (_Users.Exists(x => (x.Fio == user.Fio) && (x.Password == user.Password)))
        {
            _Users.Find(x => (x.Fio == user.Fio) && (x.Password == user.Password)).Password = new User(user.Fio, new_password).Password;
            return true;
        }
        else return false;
    }

    public static void SaveUsers() //Сохраняет пользователей
    {
        try
        {
            string output = JsonHelper.ToJson(_Users.ToArray(), true);
            File.WriteAllText(USERS_FILE_PATH, output);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public static void LoadUsers() // читает список пользователей из файла
    {
        try
        {
            if (File.Exists(USERS_FILE_PATH))
            {
                _Users = new List<User>(JsonHelper.FromJson<User>(USERS_FILE_PATH));
            }
            else
            {
                _Users = new List<User>();
                AddUser(new User("Admin", "master"));
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    // Start is called before the first frame update
    void Start() //при инициализации читает список пользователей из файла
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
