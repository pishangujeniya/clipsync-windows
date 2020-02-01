using System;


namespace ClipSync.Models {
    /// <summary>
    ///  User Connection Model
    /// </summary>
    public class UserConnection {

        /// <summary>
        /// Device Platform
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// Device MAC Address
        /// </summary>
        public string device_id { get; set; }
        /// <summary>
        /// Signal R Connection id
        /// </summary>
        public string connection_id { get; set; }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="device_id"></param>
        /// <param name="connection_id"></param>
        public UserConnection(string platform, string device_id, string connection_id) {
            this.platform = platform ?? throw new ArgumentNullException(nameof(platform));
            this.device_id = device_id ?? throw new ArgumentNullException(nameof(device_id));
            this.connection_id = connection_id ?? throw new ArgumentNullException(nameof(connection_id));
        }
    }
}

