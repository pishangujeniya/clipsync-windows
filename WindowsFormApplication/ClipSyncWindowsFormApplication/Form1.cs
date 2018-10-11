using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipSync
{

    internal static class NativeMethods
    {
        // See http://msdn.microsoft.com/en-us/library/ms649021%28v=vs.85%29.aspx
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        // See http://msdn.microsoft.com/en-us/library/ms632599%28VS.85%29.aspx#message_only
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }


    public partial class Form1 : Form, iResponse
    {

        public Form1()
        {
            InitializeComponent();

        }

        private static void LogService(string process)
        {
            FileStream fs = new FileStream("C:\\P\\TestApp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(process);
            sw.Flush();
            sw.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            notifyIcon1.BalloonTipText = "Current Time : " + DateTime.Now.ToString();

            notifyIcon1.BalloonTipTitle = "This is Test";

            //Keep the Baloon for 1 second
            notifyIcon1.ShowBalloonTip(1000);

            //Start the window in Minimized Mode

            //WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;

            AddClipBoardListener();
        }



        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void AddClipBoardListener()
        {
            //NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
            {

                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                {
                    string copied_content = (string)iData.GetData(DataFormats.Text);
                    //do something with it
                    Console.WriteLine(copied_content);
                    LogService(copied_content);
                }
                else if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    //Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);   // Clipboard image
                    //do something with it
                }
            }

            base.WndProc(ref m);
        }

        private async void Login_button_click(object sender, EventArgs e)
        {
            Console.WriteLine("BUtton CLicked");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApi.login_api);
                client.DefaultRequestHeaders.Accept.Clear();
                await GetPHPResponse(this);
            }

        }

        public static async Task GetPHPResponse(iResponse iResponse)
        {
            var stringContent = new FormUrlEncodedContent(new[]
               {
                new KeyValuePair<string, string>("userName", "pishang"),
                new KeyValuePair<string, string>("userPassword", "pishang"),
            });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApi.login_api);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.PostAsync(WebApi.login_api, stringContent);
                if (response.IsSuccessStatusCode)
                {
					// Get the URI of the created resource
					iResponse.ddresponse(false, JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString()));
                }
                else
                {
					iResponse.ddresponse(true, null);
                }
            }
        }

        public void ddresponse(bool isError, object json_reponse)
        {
            Console.WriteLine(isError + "repo" + json_reponse);
        }

        private void Sign_up_button_Click(object sender, EventArgs e)
        {

        }
    }

    public interface iResponse
    {
        void ddresponse(bool isError, object json_reponse);
    }






}


