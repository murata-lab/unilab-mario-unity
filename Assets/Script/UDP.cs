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

    // Use this for initialization
    void Start()
    {
        int LOCA_LPORT = 50007;

        udp = new UdpClient(LOCA_LPORT);
        udp.Client.ReceiveTimeout = 2000;

        // CharaControlスクリプトの参照を取得
        charaControl = GameObject.Find("Player").GetComponent<CharaControl>();

    }

    // Update is called once per frame
    void Update()
    {
        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);
        string text = Encoding.UTF8.GetString(data);  // 受信した信号
        Debug.Log("signal: " + text);

        // 受信した信号に基づいてキャラクターの操作を行う
        if (text == "0")
        {
            //　停止
        }
        else if (text == "1")
        {
            //  進む
            charaControl.MoveForward();
        }
        else if (text == "2")
        {
            //　戻る
            charaControl.MoveBackward();
        }
        else if (text == "3")
        {
            // ジャンプ
            charaControl.Jump();
        }
    }

}