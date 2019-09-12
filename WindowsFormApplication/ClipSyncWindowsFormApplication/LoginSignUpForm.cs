using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Runtime.InteropServices;
using ClipSync.SignalR;
using Microsoft.Owin.Hosting;

namespace ClipSync {

    public partial class LoginSignUpForm : Form {

        public string mTime = DateTime.Now.ToLongTimeString();

        private CSHelper cSHelper;

        public IHubProxy _hub;

        bool isSignalRConnected = false;

        static LoginSignUpForm loginFormHandle = null;

        public string uid = "";

        public LoginSignUpForm() {
            InitializeComponent();
            this.cSHelper = new CSHelper();
        }


        private void LoginSignUpForm_Load(object sender, EventArgs e) {
            try {

                loginFormHandle = this;

                this.LogWriter("-------------------");
                this.LogWriter("Enter address and port then start server and wait.");
                this.LogWriter("Your ip is: " + cSHelper.GetMachineIpAddress());

                this.serverGroupBox.Show();
                this.serverAddressTextBox.Text = "*";
                //this.serverAddressTextBox.Text = "localhost";

                this.connectUidTextBox.Text = new Random().Next().ToString();

            } catch (Exception ex) {
                this.LogWriter(ex.ToString());
            }
        }

        private void LoginButtonClick(object sender, EventArgs e) {

            Login_Button.Enabled = false;

            string serverAddress = this.connectServerAddressTextBox.Text;
            string serverPort = this.connectServerPortTextBox.Text;
            string uid = this.connectUidTextBox.Text;

            this.LogWriter("Connecting to the ClipSync server");

            IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("uid", uid);
            keyValuePairs.Add("platform", "WINDOWS");
            keyValuePairs.Add("device_id", cSHelper.GetMacAddress());

            try {
                var connection = new HubConnection("http://" + serverAddress + ":" + serverPort, keyValuePairs);
                this._hub = connection.CreateHubProxy(WebApi.hub_name);
                connection.Start().Wait();
                isSignalRConnected = true;
            } catch (Exception ex) {
                isSignalRConnected = false;
                this.LogWriter("Exception in connecting to SignalR Hub : " + ex.ToString());
            }

            if (!isSignalRConnected) {
                MessageBox.Show("ClipSync Server is not running, so Please close the whole app and try again after sometime.", "Warning");
            } else {

                MessageBox.Show("ClipSync Server is now connected, You need to connect to this uid: " + uid + " from all your devices. Now you can minimise this window", "Success");
                this.LogWriter("ClipSync Server is now connected, You need to connect to this uid: " + uid + " from all your devices. Now you can minimise this window");

                AddClipBoardListener();

                this._hub.On(WebApi.recieve_copied_text_signalr_method_name, delegate (String data) {
                    //Console.WriteLine("Recieved Text :" + data);

                    if (data != null && data.Length > 0) {
                        if (!data.Contains(WebApi.copied_watermark) && !data.Equals(ClipBoardHelper.GetText(), StringComparison.InvariantCultureIgnoreCase)) {
                            this.LogWriter("Your ClipBoard Updated with :");
                            ClipBoardHelper.SetText(data + WebApi.copied_watermark);
                            this.LogWriter(data + WebApi.copied_watermark);
                        }
                    }

                });
            }

        }

        private void StartServerButton_Click(object sender, EventArgs e) {
            this.startServerButton.Enabled = false;
            this.LogWriter("Starting server on ");
            string url = "http://" + "*" + ":" + this.serverPortTextBox.Text + "/";
            this.LogWriter(url);
            try {
                var SignalR = WebApp.Start<Startup>(url);
                this.LogWriter(string.Format("Server running at {0}", url + "signalr/hubs"));
                this.LogWriter("Your ip is: " + cSHelper.GetMachineIpAddress());
                this.LogWriter("Open the below link in your browser and if it opens then you can proceed further");
                this.LogWriter("http://" + cSHelper.GetMachineIpAddress() + ":" + this.serverPortTextBox.Text + "/signalr/hubs");
                this.connectServerAddressTextBox.Text = cSHelper.GetMachineIpAddress();
                this.connectServerPortTextBox.Text = this.serverPortTextBox.Text;
                this.startServerButton.Enabled = false;
            } catch (System.Reflection.TargetInvocationException ex) {
                this.LogWriter("You need to run as administrator");
                this.LogWriter("Only server address localhost is allowed without administrator permissions");
                MessageBox.Show("You need to run as administrator", "Error");
                Console.WriteLine(ex.ToString());
                this.startServerButton.Enabled = true;
            } catch (Exception ex) {
                this.LogWriter(ex.ToString());
                this.startServerButton.Enabled = true;
            }
        }
        /// <summary>
        /// Log Writer on Form
        /// </summary>
        /// <param name="t">string text to write</param>
        public void LogWriter(string t) {
            // Running on the worker thread
            loginFormHandle.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                this.consoleTextBox.Text = this.consoleTextBox.Text + "\n" + t;
                this.consoleTextBox.SelectionStart = this.consoleTextBox.Text.Length;
                this.consoleTextBox.ScrollToCaret();
            });
            // Back on the worker thread

        }
        private void AddClipBoardListener() {
            //NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        private void websocket_MessageReceived(object sender, EventArgs e) {
            this.LogWriter("websocket_MessageReceived");
        }

        private void websocket_Closed(object sender, EventArgs e) {
            this.LogWriter("websocket_Closed");
        }

        //private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e) {
        //    this.consoleLogWriter("websocket_Error");
        //}

        protected override void WndProc(ref Message m) {
            if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE) {

                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE) {
                    string copied_content = (string)iData.GetData(DataFormats.Text);
                    //do something with it
                    if (copied_content != null && !copied_content.Contains(WebApi.copied_watermark) && copied_content.Length > 0) {
                        double lastTime = TimeSpan.Parse(mTime).Seconds;
                        mTime = DateTime.Now.ToLongTimeString();
                        if ((TimeSpan.Parse(mTime).Seconds - lastTime) > WebApi.number_of_seconds_interval_between_copy) {
                            this.LogWriter(copied_content);
                            _hub.Invoke(WebApi.send_copied_text_signalr_method_name, copied_content);
                        }
                    }
                } else if (iData.GetDataPresent(DataFormats.Bitmap)) {
                    //Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);   // Clipboard image
                    //do something with it
                }
            }

            base.WndProc(ref m);
        }

    }


    internal static class NativeMethods {
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
}
