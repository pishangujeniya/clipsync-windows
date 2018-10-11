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

namespace ClipSync {
	public partial class LoginSignUpForm : Form, ApiRequest.ICallApiResponseListener {


		private string LoginApi = WebApi.login_api;
		private string SignUpApi = WebApi.sign_up_api;

		private CSHelper cSHelper;

		public IHubProxy _hub;

		bool isSignalRConnected = false;
		bool api_reponse_wait_looper = false;

		public LoginSignUpForm() {
			InitializeComponent();

			cSHelper = new CSHelper();

			api_reponse_wait_looper = false;
			isSignalRConnected = false;
			LoginSignUpProgressBar.Visible = false;
		}

		private void LoginSignUpForm_Load(object sender, EventArgs e) {

		}

		private void Login_Button_Click(object sender, EventArgs e) {

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
	
			_hub.Invoke("DetermineLength", WebApi.get_clips_api);

			_hub.On("ReceiveLength", delegate (String data) {
				Console.WriteLine(data);
			});

		}

		private void websocket_MessageReceived(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void websocket_Closed(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		private void websocket_Error(object sender, ErrorEventArgs e) {
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
				return;
			}

			IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();
			keyValuePairs.Add("uid", json_response["uid"].ToString());
			keyValuePairs.Add("platform", "WINDOWS");
			keyValuePairs.Add("device_id", cSHelper.GetMacAddress());

			
			try {
				var connection = new HubConnection(WebApi.signal_r_hub_api, keyValuePairs);
				_hub = connection.CreateHubProxy(WebApi.hub_name);
				connection.Start().Wait();
				isSignalRConnected = true;
			} catch (Exception e) {
				isSignalRConnected = false;
				Console.WriteLine("Exception in connecting to SignalR Hub : " + e.ToString());
			}

			if (!isSignalRConnected) {
				MessageBox.Show("ClipSync Server is not running", "Warning");
			}



			MessageBox.Show(json_response.ToString(), "response");
		}

		private void LoginSingUpBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			var data = (FormUrlEncodedContent)e.Argument;
			ApiRequest.CallApiAsync(LoginApi, WebApiRequestCode.login_api_rc, data, this);
			//BackgroundWorker.ReportProgress(-1);
			while (!api_reponse_wait_looper) {
			}
		}

		private void LoginSingUpBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			//if (e.ProgressPercentage == -1) {
			//    LoginSignUpProgressBar.MarqueeAnimationSpeed = 10;
			//}
		}

		private void LoginSingUpBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			LoginSignUpProgressBar.Hide();
		}
	}
}
