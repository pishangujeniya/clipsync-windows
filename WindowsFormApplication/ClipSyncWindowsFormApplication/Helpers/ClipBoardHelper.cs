using System.Threading;

namespace ClipSync.Helpers {

    /// <summary>
    /// Windows ClipBoard Helper
    /// </summary>
    public static class ClipBoardHelper {
        /// <summary>
        /// Set the text value to Windows ClipBoard
        /// </summary>
        /// <param name="p_Text">text to set as last copied content</param>
        public static void SetText(string p_Text) {
            if (p_Text == null) {
                p_Text = "";
            }

            Thread STAThread = new Thread(
                delegate () {
                    // Use a fully qualified name for Clipboard otherwise it
                    // will end up calling itself.
                    System.Windows.Forms.Clipboard.SetText(p_Text);
                });
            STAThread.SetApartmentState(ApartmentState.STA);
            STAThread.Start();
            STAThread.Join();
        }

        /// <summary>
        /// Get the text value to Windows ClipBoard
        /// </summary>
        /// <returns>clipboard text content string</returns>
        public static string GetText() {
            string ReturnValue = string.Empty;
            Thread STAThread = new Thread(
                delegate () {
                    // Use a fully qualified name for Clipboard otherwise it
                    // will end up calling itself.
                    ReturnValue = System.Windows.Forms.Clipboard.GetText();
                });
            STAThread.SetApartmentState(ApartmentState.STA);
            STAThread.Start();
            STAThread.Join();

            return ReturnValue;
        }
    }
}
