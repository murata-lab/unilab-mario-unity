using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Debug = UnityEngine.Debug;

public class UDP : MonoBehaviour
{

    static UdpClient udp;
    IPEndPoint remoteEP = null;
    int i = 0;
    public CharaControl charaControl;

    void Start()
    {
        int LOCA_LPORT = 50007;

        udp = new UdpClient(LOCA_LPORT);
        udp.Client.ReceiveTimeout = 2000;

        charaControl = GameObject.Find("Player").GetComponent<CharaControl>();

        charaControl.StopMoving();

    }

    void Update()
    {
        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);
        string text = Encoding.UTF8.GetString(data);
        Debug.Log("signal: " + text);

        // 受信した信号に基づいてキャラクターの操作を行う
        // 0:とまれ, 1:すすめ, 2:戻れ, 3:ジャンプ
        if (text == "0")
        {
            charaControl.StopMoving();
        }
        else if (text == "1")
        {
            charaControl.MoveForward();
        }
        else if (text == "2")
        {
            charaControl.MoveBackward();
        }
        else if (text == "3")
        {
            charaControl.Jump();
        }
    }

}