using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;

public class Network : MonoBehaviour
{
    public static Network instance;

    [Header("Network Settings")]
    public string ServerIP = "192.168.0.105";
    public int ServerPort = 5500;
    public bool isConnected;

    public TcpClient playerSocket;
    public NetworkStream myStream;
    public StreamReader myReader;
    public StreamWriter myWriter;

    private byte[] asyncBuff;
    public bool shouldHandleData;


    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        ConnectGameServer();
	}

    private void ConnectGameServer()
    {
        if(playerSocket != null)
        {
            if(playerSocket.Connected || isConnected)
            {
                return;
            }
            playerSocket.Close();
            playerSocket = null;
        }

        playerSocket = new TcpClient();
        playerSocket.ReceiveBufferSize = 4096;
        playerSocket.SendBufferSize = 4096;
        playerSocket.NoDelay = false;
        Array.Resize(ref asyncBuff, 8192);
        playerSocket.BeginConnect(ServerIP, ServerPort, new AsyncCallback(ConnectCallback), playerSocket);
        isConnected = true;
    }

    void ConnectCallback(IAsyncResult result)
    {
        if(playerSocket != null)
        {
            playerSocket.EndConnect(result);
            if (playerSocket.Connected == false)
            {
                isConnected = false;
                return;
            }
            else
            {
                playerSocket.NoDelay = true;
                myStream = playerSocket.GetStream();
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
            }
        }
    }

    void OnReceive(IAsyncResult result)
    {
        if (playerSocket != null)
        {
            if (playerSocket == null)
            {
                return;
            }

            int byteArray = myStream.EndRead(result);
            byte[] myBytes = null;
            Array.Resize(ref myBytes, byteArray);
            Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteArray);

            if (byteArray == 0)
            {
                Debug.Log("You got disconnected from the Server.");
                playerSocket.Close();
                return;
            }

            shouldHandleData = true;

            if (playerSocket == null)
            {
                return;
            }
            myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
        }
    }
}
