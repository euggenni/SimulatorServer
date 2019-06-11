using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddUserHandler : MonoBehaviour
{
    public InputField UserName; //ФИО пользователя
    public InputField Password; //Пароль пользователя
    public InputField DublicatePassword; //Повторение пароля
    public GameObject AlertPanel; //окно сообщения
    public Text AlertText; //текст сообщения
    public GameObject AddUserPanel; //корневое окно

    public void AddUser() //Добавляет нового пользователя
    {
        if (Password.text == DublicatePassword.text)
        {
            if(Users.AddUser(new User(UserName.text, Password.text)))
            {
                Users.SaveUsers();
                AddUserPanel.SetActive(false);
                AlertText.text = "Новый пользователь успешно добавлен.";
                AlertPanel.SetActive(true);
            }
            else
            {
                AlertText.text = "Новый пользователь уже был добавлен ранее.";
                AlertPanel.SetActive(true);
            }
        }
        else
        {
            AlertText.text = "Введенные пароли не совпадают.";
            AlertPanel.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
