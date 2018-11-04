using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using WebSocket4Net;


using System.Configuration;
using System.IO;

using System.Net;

using System.Runtime.InteropServices;


namespace ClipSync {

	public partial class LoginSignUpForm : Form, ApiRequest.ICallApiResponseListener {


		private string LoginApi = WebApi.login_api;
		private string SignUpApi = WebApi.sign_up_api;

		public string mTime = DateTime.Now.ToLongTimeString();

		private CSHelper cSHelper;

		public IHubProxy _hub;

		bool isSignalRConnected = false;
		bool isLoggedIn = false;
		bool api_reponse_wait_looper = false;

		public string uid = "";

		public LoginSignUpForm() {
			InitializeComponent();

			cSHelper = new CSHelper();

			api_reponse_wait_looper = false;
			isSignalRConnected = false;
			LoginSignUpProgressBar.Visible = false;
		}

		private void LoginSignUpForm_Load(object sender, EventArgs e) {
			connectClipSyncButton.Hide();
		}

		private void Login_Button_Click(object sender, EventArgs e) {

			Login_Button.Hide();

			LoginSignUpProgressBar.Show();
			LoginSignUpProgressBar.Style = ProgressBarStyle.Marquee;
			LoginSignUpProgressBar.MarqueeAnimationSpeed = 30;

			string user_name = username_text_box.Text;
			string password = Password_text_box.Text;

			var login_parameters = new FormUrlEncodedContent(new[]{
				new KeyValuePair<string, string>("userName", user_name),
				new KeyValuePair<string, string>("userPassword", password),
			});

			LoginSingUpBackgroundWorker.RunWorkerAsync(login_parameters);

		}

		private void Sign_Up_Button_Click(object sender, EventArgs e) {

			//_hub.Invoke("DetermineLength", WebApi.get_clips_api);

			//_hub.On("ReceiveLength", delegate (String data) {
			//	Console.WriteLine(data);
			//});

			MessageBox.Show("Yet To Implement", "Info");

		}

		private void websocket_MessageReceived(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void websocket_Closed(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e) {
			throw new NotImplementedException();
		}

		public void CallApiResponse(int request_code, bool isError, dynamic json_response) {
			api_reponse_wait_looper = true;
			switch (request_code) {
				case WebApiRequestCode.login_api_rc: {
						Login_reponse(isError, json_response);
						break;
					}
				case WebApiRequestCode.sign_up_api_rc: {
						break;
					}
				default: {
						Console.WriteLine("Illegal Request Code " + request_code + " in " + this.GetType().Name);
						break;
					}
			}
			api_reponse_wait_looper = false;
		}

		private void Login_reponse(bool isError, dynamic json_response) {
			if (isError) {
				MessageBox.Show("Something Went Wrong, Please try again or check your internet connection.", "Error");
				return;
			}


			//"success":"true","uid":"121212","username":"***","email":"p***@***.***"

			if (json_response["success"].ToString() != "true") {
				isLoggedIn = false;
				return;
			}

			uid = json_response["uid"].ToString();

			MessageBox.Show(json_response.ToString(), "response");

			isLoggedIn = true;

			// Running on the worker thread
			Invoke((MethodInvoker)delegate {
				// Running on the UI thread
				connectClipSyncButton.Show();
			});
			// Back on the worker thread

		}




		private void AddClipBoardListener() {
			//NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
			NativeMethods.AddClipboardFormatListener(Handle);
		}

		protected override void WndProc(ref Message m) {
			if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE) {

				IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

				if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE) {
					string copied_content = (string)iData.GetData(DataFormats.Text);
					//do something with it
					if (copied_content!= null && !copied_content.Contains(WebApi.copied_watermark) && copied_content.Length > 0) {
						double lastTime = TimeSpan.Parse(mTime).Seconds;
						mTime = DateTime.Now.ToLongTimeString();
						if ((TimeSpan.Parse(mTime).Seconds - lastTime) > WebApi.number_of_seconds_interval_between_copy) {
							Console.WriteLine(copied_content);
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




		private void LoginSingUpBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			var data = (FormUrlEncodedContent)e.Argument;
			ApiRequest.CallApiAsync(LoginApi, WebApiRequestCode.login_api_rc, data, this);
			//BackgroundWorker.ReportProgress(-1);
			//while (!api_reponse_wait_looper) {
			//}
		}

		private void LoginSingUpBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			//if (e.ProgressPercentage == -1) {
			//    LoginSignUpProgressBar.MarqueeAnimationSpeed = 10;
			//}
		}

		private void LoginSingUpBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			LoginSignUpProgressBar.Hide();

			

		}

		private void connectClipSyncButtonClick(object sender, EventArgs e) {

			connectClipSyncButton.Hide();

			IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();
			keyValuePairs.Add("uid", uid);
			keyValuePairs.Add("platform", "WINDOWS");
			keyValuePairs.Add("device_id", cSHelper.GetMacAddress());


			try {
				var connection = new HubConnection(WebApi.signal_r_hub_api, keyValuePairs);
				_hub = connection.CreateHubProxy(WebApi.hub_name);
				connection.Start().Wait();
				isSignalRConnected = true;
			} catch (Exception ex) {
				isSignalRConnected = false;
				Console.WriteLine("Exception in connecting to SignalR Hub : " + ex.ToString());
			}

			if (!isSignalRConnected) {
				MessageBox.Show("ClipSync Server is not running, so Please close the whole app and try again after sometime.", "Warning");
			} else {

				MessageBox.Show("ClipSync Server is now connected, Now you can minimise this window", "Success");

				AddClipBoardListener();

				_hub.On(WebApi.recieve_copied_text_signalr_method_name, delegate (String data) {
					Console.WriteLine("Recieved Text :" + data);

					if (data != null && data.Length > 0) {
						if (!data.Contains(WebApi.copied_watermark) && !data.Equals(ClipBoardHelper.GetText(),StringComparison.InvariantCultureIgnoreCase)) {
							Console.WriteLine("Your ClipBoard Updated with :");
							ClipBoardHelper.SetText(data+WebApi.copied_watermark);
							Console.WriteLine(data+WebApi.copied_watermark);
						}
					}

				});
			}
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
