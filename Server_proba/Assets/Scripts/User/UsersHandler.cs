using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UsersHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField FIO; //ФИО пользователя
    public InputField Password; //Пароль пользователя
    public Text LegendLabel; //Поле заголовка, где отображается сеанс пользователя
    public GameObject ButtonsPanel; //поле, хранящее кнопки управления
    public GameObject InputPanel; //исходное поле
    public GameObject PlatoonSettingsPanel; //поле, хранящее настройки взвода
    public Button PlatoonButton; //кнопка, отвечающая за переключение на настройки взвода
    public GameObject AlertPanel; //окно ошибки
    public Text AlertText; //текст ошибки

    public void InputUser() //метод, отрабатывающий вход пользователя
    {
        if(Users.FindUser(new User(FIO.text, Password.text)))
        {
            LegendLabel.text = "Сеанс: " + FIO.text;
            LegendLabel.gameObject.SetActive(true);
            ButtonsPanel.SetActive(true);
            InputPanel.SetActive(false);
            PlatoonSettingsPanel.SetActive(true);
            PlatoonButton.interactable = false;
        }
        else
        {
            AlertText.text = "Введенная комбинация логина/пароля не найдена";
            AlertPanel.SetActive(true);
        }
    }

    void Start()
    {
        Users.LoadUsers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
