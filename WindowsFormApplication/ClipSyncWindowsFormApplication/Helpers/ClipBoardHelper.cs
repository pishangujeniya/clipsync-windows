using System.Threading;

namespace ClipSync.Helpers {

    public static class ClipBoardHelper {
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
