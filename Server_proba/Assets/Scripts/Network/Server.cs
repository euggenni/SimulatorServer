﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour
{
    public static bool IsTranslate = false; //флаг, отвечающий за раздачу списка взвода
    
    public class NewMessage : MessageBase
    {
        public string Text;
    }
    void Start()
    {
        SetupServer();
    }
    void Update()
    {}
    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(178, OnReceve);
    }
    public void OnReceve(NetworkMessage netMsg)
    {
        Debug.Log(netMsg.ReadMessage<NewMessage>().Text);
    }
    public void SendTask()
    {
        NewMessage JData = new NewMessage();
        JData.Text = JsonHelper.ToJson(TaskParamsMenuHandler.task);
        NetworkServer.SendToAll(178, JData);
        NetworkServer.SendToClient(NetworkServer.connections[1].connectionId, 178, JData);
    }

    public static void StartTesting() //начинает процесс тестирования
    {
        NewMessage JData = new NewMessage();
        JData.Text = "Start";
        NetworkServer.SendToAll(178, JData);
        Debug.Log("Test starting");
    }

    public static void EndTesting() //Завершает процесс тестирования
    {
        NewMessage JData = new NewMessage();
        JData.Text = "End";
        NetworkServer.SendToAll(178, JData);
        Debug.Log("End testing");
    }

    public static void NewConnection(GameObject Students)
    {
        Students.SetActive(true);
        Debug.Log("Student connected");
    }
}
