using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using Smartcart;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smartcart
{
    class BroadcastServer
    {
        public static ArrayList socketList = new ArrayList(); //서버에 연결된 소켓들의 Array 입니다.
        private static BroadcastServer broadcastServer;
        private Thread threadWaitingSocket;
        private Socket listener;
        private int port;



        //static public TextBox txtBox = null;

        public static void start(int _port/*, TextBox mTextBox*/) //   서버 시작
        {
            if (broadcastServer == null)
            {
                broadcastServer = new BroadcastServer(_port);
            }
            //txtBox = mTextBox;
        }

        public static void stop()       // 서버 종료
        {
            Console.WriteLine("서버를 종료합니다.");
            /*if (txtBox.InvokeRequired)
            {
                txtBox.Invoke(new Action(delegate ()
                {
                    txtBox.AppendText("서버를 종료합니다.\r\n");
                }));
            }*/



            foreach (SocketHandler socketHandler in socketList)
            {
                socketHandler.end();
            }
            if (broadcastServer != null)
            {
                broadcastServer.threadStop();
            }
        }

        private void threadStop()
        {
            threadWaitingSocket.Abort();
            listener.Close();
        }

        private BroadcastServer(int _port)
        {
            port = _port;
            threadWaitingSocket = new Thread(new ThreadStart(WaitingSocket));
            threadWaitingSocket.Start();
        }
        private void WaitingSocket()    //  클라이언트의 접속을 체크하는 스레드.
        {
            IPAddress ipAddress = IPAddress.Any;

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(1000);      //  동시에 접속할 접속자수를 설정

            Console.WriteLine("연결을 기다립니다.");

            /*
            if (txtBox.InvokeRequired)
            {
                txtBox.Invoke(new Action(delegate ()
                {
                    txtBox.AppendText("연결을 기다립니다.\r\n");
                }));
            }
            */





            while (true)
            {
                Console.WriteLine("+++++++++++++");
                /*
                if (txtBox.InvokeRequired)
                {
                    txtBox.Invoke(new Action(delegate ()
                    {
                        txtBox.AppendText("+++++++++++++\r\n");
                    }));
                }*/
                Socket acceptedSocket = listener.Accept();      //  접속한 클라이언트 소켓
                Console.WriteLine("================");
                /*
                if (txtBox.InvokeRequired)
                {
                    txtBox.Invoke(new Action(delegate ()
                    {
                        txtBox.AppendText("================\r\n");
                    }));
                }*/
                string acceptedIP = ((IPEndPoint)acceptedSocket.RemoteEndPoint).Address.ToString(); //  접속한 클라이언트 IP

                socketList.Add(new SocketHandler(acceptedSocket/*, txtBox*/));                                  //  접속리스트에 추가

                Console.WriteLine(socketList.Count + "번째 컴퓨터 - " + acceptedIP + "에서 접속하였습니다.");
                /*
                if (txtBox.InvokeRequired)
                {
                    txtBox.Invoke(new Action(delegate ()
                    {
                        txtBox.AppendText(socketList.Count + "번째 컴퓨터 - " + acceptedIP + "에서 접속하였습니다.\r\n");
                    }));
                }*/

            }

        }
    }
}


public class SocketHandler
{
    public Socket socket;
    public Thread threadHandler;
    static public String temp;
    static public String[] arrTemp = null;

    static public String cartNumber;
    static public String cartName;
    static public String usingName;


    //static public TextBox txtBox = null;


    public SocketHandler(Socket socket/*, TextBox mTextBox*/)
    {
        this.socket = socket;
        threadHandler = new Thread(new ThreadStart(Handler));
        threadHandler.Start();



        //txtBox = mTextBox;

    }

    public void Handler()                   //  실질적인 서버작업
    {
        byte[] buffer = new byte[4096];
        int bufferCount;

        SendMsg((BroadcastServer.socketList.Count) + "명이 접속해 있습니다.");

        try
        {
            while (true)
            {
                buffer.Initialize();
                bufferCount = socket.Receive(buffer);

                if (bufferCount == 0) break;

                string Msgs = ASCIIEncoding.UTF8.GetString(buffer);

                byte[] byteimsi = new byte[bufferCount];    // 남은버퍼 없애기용 임시byte
                for (int i = 0; i < bufferCount; i++)
                {
                    byteimsi[i] = buffer[i];
                }
                Msgs = ASCIIEncoding.UTF8.GetString(byteimsi);
                Console.WriteLine("클라이언트에서 받은 메세지 : " + Msgs);
                temp = Msgs;
                arrTemp = temp.Split('/');

                cartNumber = arrTemp[0];
                cartName = arrTemp[1];
                usingName = arrTemp[2];

                ///////////////////////////////////////////////////////////////////////////////////////////

                string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
                string insertSql = "INSERT INTO cart VALUES('" + cartNumber + "', '" + cartName + "', '" + usingName + "')";
                
                MySqlConnection conDB = new MySqlConnection(constring);
                MySqlCommand cmdDB = new MySqlCommand(insertSql, conDB);
                MySqlDataReader MyReader;
                /*
                {
                    conDB.Open();
                    myreader = cmdDB.ExecuteReader();

                    while (myreader.Read())
                    {
                        this.chartSales2.Series["price"].Points.AddXY(myreader.GetString("product"), myreader.GetInt32("sum(price)"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
                try
                {
                    conDB.Open();
                    MyReader = cmdDB.ExecuteReader();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(insertSql, conDB);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                //////////////////////////////////////////////////////////////////////////////////////////////
                /*
                if (txtBox.InvokeRequired)
                {
                    txtBox.Invoke(new Action(delegate ()
                    {
                        txtBox.AppendText("클라이언트에서 받은 메세지" + Msgs + "\r\n");
                    }));
                }*/

                SendMsg(Msgs);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            /*
            if (txtBox.InvokeRequired)
            {
                txtBox.Invoke(new Action(delegate ()
                {
                    txtBox.AppendText(e.ToString());
                }));
            }*/
        }
        finally
        {
            Console.WriteLine("클라이언트가 종료하였습니다.");
            /*
            if (txtBox.InvokeRequired)
            {
                txtBox.Invoke(new Action(delegate ()
                {
                    txtBox.AppendText("클라이언트가 종료하였습니다.\r\n");
                }));
            }*/
            BroadcastServer.socketList.Remove(this);
            socket.Close();
            socket = null;
            ///////////////////////////////////////////////////////////////////////////////////////
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string delSql = "DELETE FROM cart WHERE(usingName = '" + usingName + "')";


            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(delSql, conDB);
            MySqlDataReader MyReader;
            /*
            {
                conDB.Open();
                myreader = cmdDB.ExecuteReader();

                while (myreader.Read())
                {
                    this.chartSales2.Series["price"].Points.AddXY(myreader.GetString("product"), myreader.GetInt32("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            try
            {
                conDB.Open();
                MyReader = cmdDB.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(delSql, conDB);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ////////////////////////////////////////////////////////////////////////////////////////
        }
    }

    public void SendMsg(string Msg)     //  메세지 보내기.
    {
        int bufferCount = 0;

        byte[] buffer = new byte[4096];

        buffer = ASCIIEncoding.UTF8.GetBytes(Msg);
        bufferCount = ASCIIEncoding.UTF8.GetByteCount(Msg);

        foreach (SocketHandler socketHandler in BroadcastServer.socketList)
        {
            socketHandler.socket.Send(buffer, 0, bufferCount, SocketFlags.None);
        }
    }

    public void end()
    {
        threadHandler.Abort();
    }
}

