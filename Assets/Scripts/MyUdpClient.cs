using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#if !UNITY_EDITOR
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Networking;
using Windows.Storage.Streams;
#endif

public class MyUdpClient : MonoBehaviour
{

#if !UNITY_EDITOR
    private bool _useUWP = true;
    private DatagramSocket socket;
#endif

#if UNITY_EDITOR
    private bool _useUWP = false;
    private System.Net.Sockets.UdpClient udpClient;
#endif

    //private string lastPacket = null;
    //private string errorStatus = null;
    //private string successStatus = null;
    public string message;

    public void Start()
    {
        // You can call Connect method on button click or as required.
    }

    public void Connect()
    {
        if (_useUWP)
        {
            ConnectUWP("192.168.3.255", 6000);
        }
        else
        {
            ConnectUnity("192.168.3.255", 6000);
        }
    }

    static byte[] converthexstringtobytearray(string input)
    {
        List<byte> byteList = new List<byte>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '\\' && i + 1 < input.Length)
            {
                if (input[i + 1] == 'x')
                {
                    string hexValue = input.Substring(i + 2, 2);
                    byteList.Add(Convert.ToByte(hexValue, 16));
                    i += 3;
                }
                else if (input[i + 1] == 'r')
                {
                    byteList.Add(0x0D);
                    i += 1;
                }
            }
            else
            {
                byteList.Add((byte)input[i]);
            }
        }
        return byteList.ToArray();
    }

#if UNITY_EDITOR
    private void ConnectUWP(string host, int port)
#else
    private async void ConnectUWP(string host, int port)
#endif
    {
#if UNITY_EDITOR
        ;// errorStatus = "UWP UDP client used in Unity!";
#else
        try
        {
            if (socket != null)
            {
                socket.Dispose();
            }

            socket = new DatagramSocket();
            HostName serverHost = new HostName(host);
            IOutputStream outputStream = await socket.GetOutputStreamAsync(serverHost, port.ToString());

            SendPacketUWP(outputStream);
            //successStatus = "Packet Sent!";
        }
        catch (Exception e)
        {
           ; //errorStatus = e.ToString();
        }
#endif
    }

    private void ConnectUnity(string host, int port)
    {
#if !UNITY_EDITOR
        ;//errorStatus = "Unity UDP client used in UWP!";
#else
        try
        {
            udpClient = new System.Net.Sockets.UdpClient();
            udpClient.Connect(host, port);

            SendPacketUnity();
            //successStatus = "Packet Sent!";
        }
        catch (Exception e)
        {
            ;//errorStatus = e.ToString();
        }
#endif
    }

#if !UNITY_EDITOR
    private void SendPacketUWP(IOutputStream stream)
    {
        byte[] bytesToSend = converthexstringtobytearray(message);
        DataWriter writer = new DataWriter(stream);
        writer.WriteBytes(bytesToSend);
        writer.StoreAsync().AsTask().Wait();
        //Debug.Log("Packet Sent in UWP: " + message);
    }
#endif

    private void SendPacketUnity()
    {
#if UNITY_EDITOR
        byte[] bytesToSend = converthexstringtobytearray(message);
        udpClient.Send(bytesToSend, bytesToSend.Length);
        //Debug.Log("Packet Sent in Unity: " + message);
#endif
    }

    public void Update()
    {
      
    }

    public void OnDestroy()
    {
#if UNITY_EDITOR
        if (udpClient != null)
        {
            udpClient.Close();
        }
#else
        if (socket != null)
        {
            socket.Dispose();
        }
#endif
    }
}