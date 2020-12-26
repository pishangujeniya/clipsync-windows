using ClipSync.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using NLog;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace ClipSync.SignalR {

    /// <summary>
    /// Signal R Hub Main Class
    /// </summary>
    [HubName("SignalRHub")]
    public class SignalRHub : Hub {

        /// <summary>
        /// General Logger Target
        /// </summary>
        public static Logger generaLogger = LogManager.GetLogger("GeneralLog");
        /// <summary>
        /// Copy History Logger Target
        /// </summary>
        public static Logger copyHistoryLogger = LogManager.GetLogger("CopyHistory");

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /// <summary>
        /// On Connected Event
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected() {
            IRequest request = Context.Request;
            string connectionID = Context.ConnectionId;
            string uid = request.QueryString.Get("uid");
            string platform = request.QueryString.Get("platform");
            string device_id = request.QueryString.Get("device_id");
            string onConnectLog = String.Format("uid  : {0} | platform : {1} | device_id : {2} | connectionID : {3}", uid, platform, device_id, connectionID);
            generaLogger.Info(onConnectLog);
           

            //MessageBox.Show(onConnectLog);
            //Program.loginSignUpForm.LogWriter(onConnectLog);

            Users.AddUserConnection(uid, new UserConnection(platform, device_id, connectionID));
            return base.OnConnected();
        }

        /// <summary>
        /// On Disconnected Event
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled) {
            generaLogger.Info("OnDisconnected : " + Context.ConnectionId);
            string searched_uid = Users.GetUIDFromConnectionID(Context.ConnectionId);
            if (!searched_uid.Equals("") || searched_uid.Length > 0) {
                Users.DeleteUserConnection(searched_uid, Context.ConnectionId);
            } else {
                generaLogger.Info("UID not found for user connection string : " + Context.ConnectionId);
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// On Reconnected Event
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected() {
            return base.OnReconnected();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        /// <summary>
        /// Check Length
        /// </summary>
        /// <param name="message"></param>
        public void DetermineLength(string message) {

            generaLogger.Info(message);
            string newMessage = string.Format(@"{0} has a length of: {1}", message, message.Length);
            Clients.All.ReceiveLength(newMessage);
        }

        /// <summary>
        /// Send Copied Text to Every Client of the user
        /// </summary>
        /// <param name="text"></param>
        public void SendCopiedText(string text) {

            string connection_id = Context.ConnectionId;
            string uid = Users.GetUIDFromConnectionID(connection_id);
            generaLogger.Info("Received from : " + connection_id + " uid : " + uid + " this : " + text);
            ArrayList connectionList = Users.GetUserConnections(uid);
            for (int i = 0; i < connectionList.Count; i++) {
                UserConnection userConnection = (UserConnection)connectionList[i];
                if (!userConnection.connection_id.Equals(connection_id)) {
                    //the above if condition is to send to only those connection except the current incoming
                    Clients.Client(userConnection.connection_id).ReceiveCopiedText(text);
                }
            }
        }
    }
}
