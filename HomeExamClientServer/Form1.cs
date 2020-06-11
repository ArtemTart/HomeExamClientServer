using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SQLite;
using System.Xml.Linq;
using log4net;
using System.Reflection;
using log4net.Config;
using System.IO;
using log4net.Repository.Hierarchy;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Threading;

namespace HomeExamClientServer
{
    /* The Server Side of the application */

    public partial class Form1 : Form
    {
        ServerConfig serverConfig;
        DbConnection myConnection;
        
        public Form1()
        {
            InitializeComponent();
            MyLogger m = new MyLogger();
            MyLogger.Log("initialize FORM1");
            serverConfig = new ServerConfig();
            myConnection = new DbConnection();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            serverConfig.StartListeningForIncomingConnection();
            MyLogger.Log("server started listening");
        }

        private async  void btnLogin_Click(object sender, EventArgs e)
        {
           await MyLogger.Log("log in clicked, checking user and password on DB ");
           if (txtUserName.Text.Trim()=="" && txtPassword.Text.Trim() == "")
            {
               MessageBox.Show("Empty Fields");
            }
            else
            {
                if (myConnection.checkAdmin(txtUserName.Text,txtPassword.Text) > 0)
                {
                    MyLogger.Log($"the user is authenticated ith the {txtUserName.Text} and passord {txtPassword.Text}");
                    await MyLogger.Log("logged in as admin - admin flag in query");
                    button1.Enabled = true;
                    newUserPwdLbl.Visible = true;
                    NewUserNameLbl.Visible = true;
                    NewUserTxt.Visible = true;
                    NewUserPwdTxt.Visible = true;
                    NewUserPathLbl.Visible = true;
                    NewUserPathTxt.Visible = true;
                    AddNewUser.Visible = true;
                    DeleteUserBtn.Visible = true;
                    UpdatePwdBtn.Visible = true;
                    SendToServerTxt.Visible = true;
                    SendToClientBtn.Visible = true;
                }
                else
                {
                   await MyLogger.Log("wrong username and password for admin ");
                }
            }
            
        }
       
        private async void AddNewUser_Click(object sender, EventArgs e)
        {
            myConnection.InsertNewUsers(NewUserTxt.Text, NewUserPwdTxt.Text, NewUserPathTxt.Text);
            await MyLogger.Log($"new user added with those params name : {NewUserTxt.Text} and password : {NewUserPwdTxt.Text} and filepath:  {NewUserPathTxt.Text}");
        }

        private async void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            myConnection.DeleteByUserName(NewUserTxt.Text);
            await MyLogger.Log($"User with this UserName is delted : {NewUserTxt.Text}");
        }

        private async void UpdatePwdBtn_Click(object sender, EventArgs e)
        {
            myConnection.updatePwd(NewUserTxt.Text, NewUserPwdTxt.Text);
            await MyLogger.Log($"User with those Params Updated {NewUserTxt.Text} and {NewUserPwdTxt.Text} ");
        }

        private void StopServerBtn_Click(object sender, EventArgs e)
        {
            serverConfig.StopServer();
            MyLogger.Log("server stopped by request from user");

            ActiveForm.Close();
        }

        private async void SendToClientBtn_Click(object sender, EventArgs e)
        {
            serverConfig.SendToAll(SendToServerTxt.Text);
           await MyLogger.Log(@"Sent the data  : {SendToServerTxt.Text}");
        }
    }
}
