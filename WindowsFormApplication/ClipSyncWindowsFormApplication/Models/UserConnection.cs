using System;


namespace ClipSync.Models {
    public class UserConnection {

        public string platform { get; set; }
        public string device_id { get; set; }
        public string connection_id { get; set; }

        public UserConnection(string platform, string device_id, string connection_id) {
            this.platform = platform ?? throw new ArgumentNullException(nameof(platform));
            this.device_id = device_id ?? throw new ArgumentNullException(nameof(device_id));
            this.connection_id = connection_id ?? throw new ArgumentNullException(nameof(connection_id));
        }
    }
}

