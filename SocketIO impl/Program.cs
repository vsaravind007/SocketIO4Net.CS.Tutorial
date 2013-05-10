//SocketIO NodeJS Group Chat Implemenatation Test
//Coded Developed By Aravind.V.S
//www.aravindvs.com
//Licence: DWFUW! Licence

using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SocketIO_impl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Form1 MyForm;
        static Form2 temp;
        static Client socket;
        public static String ip;
        public static String user;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            user = "x";
            MyForm = new Form1();
            temp = new Form2();
            Application.Run(temp);
            try
            {
                socket = new Client(ip.ToString());
                socket.On("txt", (data) =>
                {
                    //MessageBox.Show(data.RawMessage);
                    String msg = data.Json.Args[0].ToString();
                    Console.Write(msg);
                    MyForm.update(msg);
                    //MessageBox.Show(msg, "Received Data");
                });
                socket.Connect();
                 }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"Something Went Wrong!!");
                Application.Exit();
            }
            if (socket.ReadyState.ToString() == "Connecting")
            {
                userset();
                Application.Run(MyForm);
            }
            else
            {
                MessageBox.Show("Failed To Connect To Server!", "Error!");
                Application.Exit();
            }
        }
        public static void emit(String msg)
        {
            socket.Emit("private message",user + " : " + msg);
          
        }
        public static void userset()
        {
            if(socket != null)
             socket.Emit("newuser", user);
        }
        public static void disco()
        {
            if (socket != null)
                socket.Emit("exit", user);
            socket.Close();
        }
    }
    }
