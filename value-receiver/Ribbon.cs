using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;
using OpenCvSharp;
using ZXing.OpenCV;
using ZXing;
using System.Windows;

namespace value_receiver {
    public partial class Ribbon {
        Thread listener;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e) {
            listener = new Thread(new ThreadStart(start_scanner));
        }

        private void connect_Click(object sender, RibbonControlEventArgs e) {
            if (listener.ThreadState.Equals(ThreadState.Running)) {
                listener.Abort();
                listener = new Thread(new ThreadStart(start_scanner));
                
                this.connect.Label = "Connect to Scanner";
            } else {
                listener.Start();
                this.connect.Label = "Disconnect";
            }
        }

        void start_scanner() {
            VideoCapture camera = new VideoCapture(0);
            ZXing.OpenCV.BarcodeReader reader = new ZXing.OpenCV.BarcodeReader();

            using (var window = new OpenCvSharp.Window("Camera"))
            using (Mat image = new Mat()) {
                while (true) {
                    camera.Read(image); // same as cvQueryFrame

                    Result result = reader.Decode(image);

                    if (result != null) {
                        ProcessMessage(result.Text);
                    }

                    window.ShowImage(image);

                    Cv2.WaitKey(30);
                }
            }
        }

        void ProcessMessage(string message) {
            try {
                MessageBox.Show(message);
            } catch(NullReferenceException) { }
        }

        private void start_stop_DialogLauncherClick(object sender, RibbonControlEventArgs e) {

        }
    }
}
