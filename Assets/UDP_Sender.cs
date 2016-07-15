/*

	-----------------------
	UDP-Send
	-----------------------
	// http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC
	
	// > gesendetes unter 
	// 127.0.0.1 : 8050 empfangen
	
	// nc -lu 127.0.0.1 8050

        // todo: shutdown thread at the end
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDP_Sender : MonoBehaviour
{
    private static int localPort;

   
    private string IP;  // define in init
    public int port;  // define in init

   
    IPEndPoint remoteEndPoint;
    UdpClient client;

    
    string strMessage = "";
    public Slider yawSlider;
    public Slider pitchSlider;
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        init();
    }

    // OnGUI
   
     void Update() {
        if (UltimateJoystick.GetJoystickState("JoyMove"))
            UpdateJoystick();
    }
    void UpdateJoystick() {
        Vector2 value=UltimateJoystick.GetPosition("JoyMove");
        pitchSlider.value = value.y;
        yawSlider.value = value.x;
    }
    public void init()
    {            
        IP = "192.168.15.11";
        port = 8051;
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
    }

  
    private void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();

                // Den Text zum Remote-Client senden.
                if (text != "")
                {

                    // Daten mit der UTF8-Kodierung in das Binärformat kodieren.
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    // Den Text zum Remote-Client senden.
                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            print(err.ToString());
        }

    }

   
    private void sendString(string message,object parameter)
    {
        try
        {
            
            string completeMessage = message + "|" + parameter.ToString();
            print("Sent -->" + completeMessage);
            byte[] data = Encoding.UTF8.GetBytes(completeMessage);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    
    public void Remote_AdvanceStage()
    {        
        sendString("Stage","");
    }
    public void Remote_ToggleSAS(bool value)
    {
        sendString("SAS", value);
    }
    public void Remote_ToggleRCS(bool value)
    {
        sendString("RCS", value);
    }
    public void Remote_ToggleBrakes(bool value)
    {
        sendString("Brakes", value);
    }
    public void Remote_ToggleGear(bool value)
    {
        sendString("Gear", value);
    }
    public void Remote_ToggleLights(bool value)
    {
        sendString("Lights", value);
    }
    public void Remote_SetThrottle(float value) {
        sendString("Throttle", value);
    }
    public void Remote_SetPitch(float value) {
        sendString("Pitch", value);
    }
    public void Remote_SetYaw(float value)
    {
        sendString("Yaw", value);
    }
    public void Remote_SetRoll(float value)
    {
        sendString("Roll", value);
    }
    public void Remote_SetMoveX(float value)
    {
        sendString("MoveX", value);
    }
    public void Remote_SetMoveY(float value)
    {
        sendString("MoveY", value);
    }
    public void Remote_SetMoveZ(float value)
    {
        sendString("MoveZ", value);
    }
    public void Remote_SetCustom1(bool value)
    {
        sendString("Custom1", value);
    }
    public void Remote_SetCustom2(bool value)
    {
        sendString("Custom2", value);
    }
    public void Remote_SetCustom3(bool value)
    {
        sendString("Custom3", value);
    }
    public void Remote_SetCustom4(bool value)
    {
        sendString("Custom4", value);
    }
}
