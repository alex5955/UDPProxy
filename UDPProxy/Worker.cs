using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using ModelLib;
using Newtonsoft.Json;

namespace UDPProxy
{
    internal class Worker
    {
        public async void Start()
        {
            UdpClient client = new UdpClient(10100);

            Console.WriteLine("UDP Receiver startet på port " + 10100);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            using (HttpClient c = new HttpClient())
            {
                while (true)
                {
                    byte[] bytes = client.Receive(ref remote);
                    string s = Encoding.UTF8.GetString(bytes);

                    StringContent content = new StringContent(s, Encoding.UTF8, "application/json");

                    await c.PostAsync("http://localhost:49938/api/Sensor/", content);
                    
                    Console.WriteLine(s);
                }
            }

        }
    }
}