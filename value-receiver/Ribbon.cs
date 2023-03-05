using System;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Vbe.Interop;
using OpenCvSharp;
using ZXing;

namespace value_receiver {
    public partial class Ribbon {
        Thread scanner;
        bool stop_scanner;
        string use_macro;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e) {
            RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();

            item.Label = "Sample";

            macro.Items.Add(item);
        }

        void refresh_labels() {
            Thread.Sleep(1000);

            if (scanner != null && scanner.ThreadState == ThreadState.Running)
                connect.Label = "Stop Scanner";
            else
                connect.Label = "Start Scanner";
        }

        private void connect_Click(object sender, RibbonControlEventArgs e) {
            if (scanner != null) {
                connect.Label = "Stopping Scanner";

                stop_scanner = true;

                new Thread(new ThreadStart(refresh_labels)).Start();
            } else {
                connect.Label = "Starting Scanner";
                new Thread(new ThreadStart(refresh_labels)).Start();

                scanner = new Thread(new ThreadStart(start_scanner));
                stop_scanner = false;
                scanner.Start();
            }
        }

        void start_scanner() {
            var camera = new VideoCapture(0);
            var reader = new ZXing.OpenCV.BarcodeReader();
            var window = new OpenCvSharp.Window("Preview");
            var image = new Mat();

            while (!stop_scanner) {
                connect.Label = "Stop Scanner";

                camera.Read(image); // same as cvQueryFrame

                Result result = reader.Decode(image);

                if (result != null) {
                    ProcessMessage(result.Text);
                }

                window.ShowImage(image);

                var key = Cv2.WaitKey(1);
                if (key == 27 || window.IsDisposed)
                    break;
            }

            window.Close();

            image.Dispose();
            camera.Dispose();
            window.Dispose();
            
            scanner = null;
        }

        void ProcessMessage(string message) {
            try {
                // TODO: Replace Macro name with a user-selected one.
                Globals.ThisAddIn.Application.Run(use_macro, message);
            } catch (Exception) { }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e) {
            ProcessMessage(value.Text);
            value.Text = "";
        }

        private void start_stop_DialogLauncherClick(object sender, RibbonControlEventArgs e) {

        }

        private void macro_TextChanged(object sender, RibbonControlEventArgs e) {
            use_macro = macro.Text;
        }
    }
}
