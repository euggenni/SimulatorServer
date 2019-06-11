using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutUserHandler : MonoBehaviour
{
    public GameObject OkNoPanel; //окно да/нет
    public Text Label; //текст окна
    public Button OkButton; //кнопка "хорошо"

    void TaskOnClick() //выполняет перезапуск сцены
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ApplicationQuit()//выполняет выход из приложения
    {
        Application.Quit();
    }

    public void ShowPanel() //показывает окно да/нет
    {
        Label.text = "Вы точно хотите завершить сеанс?";
        OkNoPanel.SetActive(true);
        OkButton.onClick.RemoveAllListeners();     //необходимо использовать оба оператора в связке
        OkButton.onClick.AddListener(TaskOnClick); //во избежание коллизий
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
