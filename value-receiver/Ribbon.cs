using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;

namespace value_receiver {
    public partial class Ribbon {
        Thread listener;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e) {
            listener = new Thread(new ThreadStart(start_listener));
        }

        private void connect_Click(object sender, RibbonControlEventArgs e) {
            if (listener.ThreadState.Equals(ThreadState.Running)) {
                listener.Abort();
                listener = new Thread(new ThreadStart(start_listener));
                
                this.connect.Label = "Connect to Scanner";
            } else {
                listener.Start();
                this.connect.Label = "Disconnect";
            }
        }

        void start_listener() {
            while (true) {
                this.connect.Label = "Disconnect";
                // TODO: Replace with value from text field

                var stream = new TcpClient("localhost", 8080);
                using (var reader = new StreamReader(stream.GetStream(), Encoding.UTF8)) {
                    string line;

                    while ((line = reader.ReadLine()) != null) {
                        ProcessMessage(line);
                    }
                }

                Thread.Sleep(10);
            }
        }

        void ProcessMessage(string message) {
            try {
                var code = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(message)["raw"];

                System.Windows.Forms.MessageBox.Show(code);
            } catch(NullReferenceException) { }
        }

        private void start_stop_DialogLauncherClick(object sender, RibbonControlEventArgs e) {

        }
    }
}
