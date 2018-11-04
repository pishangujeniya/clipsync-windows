using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSync
{
    public static class WebApi
    {
        public static string api_domain = "http://clipsync.pishangujeniya.com/";
		public static string signal_r_hub_api = @"http://pishangujeniya.com:8080";
		public static string hub_name = "SignalRHub";
		public static string recieve_copied_text_signalr_method_name = "ReceiveCopiedText";
		public static string send_copied_text_signalr_method_name = "SendCopiedText";
		public static string copied_watermark = "- Copied By ClipSync";
		public static int number_of_seconds_interval_between_copy = 3;
		public static string login_api = "LogIn.php";
        public static string sign_up_api = api_domain + "SignUp.php";
        public static string get_clips_api = api_domain + "GetClips.php";
    }

    public static class WebApiRequestCode
    {
        public const int api_domain_rc = 1000;
        public const int login_api_rc = 1001;
        public const int sign_up_api_rc = 1002;
        public const int get_clips_api_rc = 1003;



    }
}
