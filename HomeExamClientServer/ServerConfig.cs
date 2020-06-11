using log4net;
using log4net.Config;
using System;
using System.Buffers;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeExamClientServer
{
   public  enum commands
    {
        list = 1,
        delete ,
        upload ,
        download 

    };

    class ServerConfig
    {
        
        DbConnection myConnection;
		TcpListener listener;
		IPAddress ipAddr;
		int portNum;
        NetworkStream stream = null;
        StreamReader reader;
        Stream inputstream;
        int nRet;
        string messageRecieved;
        int size;
        commands Commands;
        TcpClient  returnedByAccept;

        string fileName;
        byte[] buffMessage=new byte[1024];
        char[] buff;
        string username;
        string password;
        bool isAuthorized = false;
        string pathToDirectory;

        List<TcpClient> mClients;

        public ServerConfig()
        {
            mClients = new List<TcpClient>();
            myConnection = new DbConnection();
        }

        public bool running;

        public async void StartListeningForIncomingConnection(IPAddress ip = null, int port = 23000)
        {
            await  MyLogger.Log("started listening to connections ");
            if (ip == null)
            {
                ip = IPAddress.Any;
            }

            if (port <= 0)
            {
                port = 23000;
            }
            ipAddr = ip;
            portNum = port;
            MyLogger.Log(string.Format("IP Address: {0} - Port: {1}", ipAddr.ToString(), portNum));

            listener = new TcpListener(ipAddr, portNum);

            try
            {
                MyLogger.Log("starting server LIstener");
                listener.Start();
                running = true;

                while (running)
                {
                    MyLogger.Log("accepting  connections");
                     returnedByAccept = await listener.AcceptTcpClientAsync();
                    MyLogger.Log($"connection accepted from {returnedByAccept}");
                    mClients.Add(returnedByAccept);

                    MyLogger.Log(string.Format($"Client connected successfully, count: {mClients.Count} - {returnedByAccept.Client.RemoteEndPoint}"));

                    TakeCareOfTCPClient(returnedByAccept);
                }

            }
            catch (Exception excp)
            {
               MyLogger.Log(excp.ToString());
            }
        }

        public void StopServer()
        {
            try
            {
                MyLogger.Log("Stopping server");
                if (listener != null)
                {
                    listener.Stop();
                }

                foreach (TcpClient c in mClients)
                {
                    MyLogger.Log($"Closing connection to : {c.Client.RemoteEndPoint.ToString()}");
                    c.Close();
                }

                mClients.Clear();
            }
            catch (Exception excp)
            {
                MyLogger.Log(excp.ToString());
            }
        }
        private async void TakeCareOfTCPClient(TcpClient paramClient)
        {
            
            reader = null;
            try
            {
                MyLogger.Log("Preparing to read and write Data");
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                while (running)
                {
                    sendToClient("provide UserName", paramClient);


                    Debug.WriteLine("*** Ready to read ");
                    MyLogger.Log("ready to read data");
                    
                   
                    size= await stream.ReadAsync(buffMessage, 0, buffMessage.Length);//start reading data and get the size
                    username = Encoding.ASCII.GetString(buffMessage,0,size);//decode the data in the buffer to a string 
                    MyLogger.Log($"username provided is {username}");


                    Array.Clear(buffMessage, 0, buffMessage.Length);
                    sendToClient("Provide Password", paramClient);

                  
                    size = await stream.ReadAsync(buffMessage, 0, buffMessage.Length);//start reading data and get the size
                    password = Encoding.ASCII.GetString(buffMessage, 0, size);//decode the data in the buffer to a string 
                    MyLogger.Log($"password provided is {password}");


                    if (size == 0)
                    {
                        MyLogger.Log("data to read  is null");
                        RemoveClient(paramClient);

                        Debug.WriteLine("Socket disconnected");
                        MyLogger.Log("Socket disconnected");
                        break;
                    }

                    checkAuthorization(username, password);
                    // if the user is authorozied, startlistening to commands.  "user inside the server"
                    if (isAuthorized == true)
                    {
                        Array.Clear(buffMessage, 0, buffMessage.Length);
                       
                        sendToClient("your options are : '1 for list'  ' 2 for delete'  '3 for upload'  '4 for download'", paramClient);

                        MyLogger.Log($"the path to directory is {pathToDirectory} ");
                        Debug.WriteLine($"the path to directory is {pathToDirectory}");

                        size = await stream.ReadAsync(buffMessage, 0, buffMessage.Length);//start reading data and get the size
                        string getvalue=Encoding.ASCII.GetString(buffMessage, 0, size);
                        commands comandNum =(commands) int.Parse(getvalue);// cust the comand integer to enum

                        switch (comandNum)
                        {
                            case commands.list:
                                listAllStoredFiles();  
                                 break;

                            case commands.delete:
                                sendToClient("provide file name", returnedByAccept);
                                size = await stream.ReadAsync(buffMessage, 0, buffMessage.Length);//start reading data and get the size
                                fileName = Encoding.ASCII.GetString(buffMessage, 0, size);//decode the data in the buffer to a string 
                                await delteFileAsync(fileName);
                                break;

                            case commands.download:
                                break;

                            case commands.upload:

                                break;
                            default:
                                break;
                        }
                        
                    }
                    //clear the buffer
                    Array.Clear(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                MyLogger.Log($"will remove client- error accured {paramClient}");
                RemoveClient(paramClient);
                MyLogger.Log(excp.ToString());
            }
        }

        private async Task downloadDataAsync()
        {
           //1. get  the file to download

            //go to file

            //open file ,read the file 

            //cut to chunk's 

            //send in a while loop

            //dont forget to check that client is saving it in memory and not in buffer
        }

        private async Task uploadDataAsync()
        {
         
            
            //very similar as download .
        }

        private async Task delteFileAsync(string fileName)
        {
            Debug.WriteLine("comand=delete");
            MyLogger.Log("comand=delete");
            var filePath = pathToDirectory + @"\" + fileName;
            FileInfo fi = new FileInfo(filePath);
            await fi.DeleteAsync();
            MyLogger.Log($"File {fileName} deleted");
            sendToClient($"file {fileName} deleted", returnedByAccept);
        }

        private void listAllStoredFiles()
        {
            Debug.WriteLine("trying to send list back to client");
            MyLogger.Log("sending data back to client");
            string[] fileArray = Directory.GetFiles(pathToDirectory);
            foreach (var item in fileArray)
            {
                Array.Clear(buffMessage, 0, buffMessage.Length);
                sendToClient(item.ToString(), returnedByAccept);
            }
 
        }

        private bool checkAuthorization(string username, string passwordFromClient)
        {
            //check if use authorozied 
             pathToDirectory = myConnection.findUserForAuth(username, passwordFromClient);
            if (pathToDirectory.Length >= 1)
            {
                MyLogger.Log($"user {username} with password {password} is authorozied ");
                return  isAuthorized = true;
            }
            MyLogger.Log("the user have no rights to access the server");
            StopServer();
            return false;
        }

        private void RemoveClient(TcpClient paramClient) // remove client if couple of them are connected - testing for multiple connections
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
                MyLogger.Log(String.Format("Client removed, count: {0}", mClients.Count));
            }
        }

        public async void SendToAll(string leMessage)// send data to couple of clients - test - barely works 
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }
            try
            {
                 buffMessage = Encoding.ASCII.GetBytes(leMessage);

                foreach (TcpClient c in mClients)
                {
                    c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                MyLogger.Log(excp.ToString());
            }
        }

        public void sendToClient(string message,TcpClient c) // send string to client 
        {
            try
            {
                buffMessage = Encoding.ASCII.GetBytes(message+"\n");
                c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                Array.Clear(buffMessage, 0, buffMessage.Length);
            }
            catch (Exception excp)
            {
                MyLogger.Log(excp.ToString());
            }
        }
        
        public async Task recieveDataAsync()
        {
            size = await stream.ReadAsync(buffMessage, 0, buffMessage.Length);//start reading data and get the size
            string data = Encoding.ASCII.GetString(buffMessage, 0, size);//decode the data in the buffer to a string 
        }
    }

}

