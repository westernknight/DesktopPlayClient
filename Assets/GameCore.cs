using UnityEngine;
using System.Collections;

using LayoutTest;
using System.Net.Sockets;
public class GameCore : MonoBehaviour
{
    SocketClient socketClient = new SocketClient();
    public string stringToEdit = "192.168.1.103";

    bool connectionSuccessfull = false;
    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        if (connectionSuccessfull == false)
        {
            stringToEdit = GUILayout.TextField(stringToEdit, 25);
            if (GUILayout.Button("Connect"))
            {
                socketClient.msg_callback += DebugSocket;
                socketClient.connectsucess_callback += ConnectSucess;
                socketClient.cmd_callback += CMDCallback;
                socketClient.Start(stringToEdit, 5656);

            }
        }
        else
        {
            if (GUILayout.Button("send test"))
            {
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnApplicationQuit()
    {
        if (connectionSuccessfull)
        {
            socketClient.Disconnect();
        }
        
    }
    void ConnectSucess()
    {
        connectionSuccessfull = true;
    }
    void DebugSocket(string sz)
    {
        Debug.Log(sz);
    }
    void CMDCallback(Socket ts, string json)
    {
        Debug.Log(json);
    }
}
