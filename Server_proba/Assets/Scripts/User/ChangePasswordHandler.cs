using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangePasswordHandler : MonoBehaviour
{
    public InputField OldPassword; //Старый пароль
    public InputField NewPassword; //Новый пароль
    public InputField DublicateNewPassword; //Повторение нового пароля
    public GameObject AlertPanel; //окно сообщения
    public Text AlertText; //текст сообщения
    public GameObject ChangePasswordPanel; //корневое окно
    public Text LegendLabel; //название сессии

    public void ChangePassword() //изменяет пароль
    {
        if (NewPassword.text == DublicateNewPassword.text)
        {
            if (Users.UpdatePassword(new User(LegendLabel.text.Substring(7), OldPassword.text), NewPassword.text))
            {
                Users.SaveUsers();
                ChangePasswordPanel.SetActive(false);
                AlertText.text = "Пароль успешно изменен.";
                AlertPanel.SetActive(true);
            }
            else
            {
                AlertText.text = "Введен неверный старый пароль";
                AlertPanel.SetActive(true);
            }
        }
        else
        {
            AlertText.text = "Введенный новый пароль не совпадает с его повтором.";
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
