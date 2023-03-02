using Microsoft.Office.Core;
using System;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO:  Führen Sie diese Schritte aus, um das Element auf dem Menüband (XML) zu aktivieren:

// 1: Kopieren Sie folgenden Codeblock in die ThisAddin-, ThisWorkbook- oder ThisDocument-Klasse.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Erstellen Sie Rückrufmethoden im Abschnitt "Menübandrückrufe" dieser Klasse, um Benutzeraktionen
//    zu behandeln, z.B. das Klicken auf eine Schaltfläche. Hinweis: Wenn Sie dieses Menüband aus dem Menüband-Designer exportiert haben,
//    verschieben Sie den Code aus den Ereignishandlern in die Rückrufmethoden, und ändern Sie den Code für die Verwendung mit dem
//    Programmmodell für die Menübanderweiterung (RibbonX).

// 3. Weisen Sie den Steuerelementtags in der Menüband-XML-Datei Attribute zu, um die entsprechenden Rückrufmethoden im Code anzugeben.  

// Weitere Informationen erhalten Sie in der Menüband-XML-Dokumentation in der Hilfe zu Visual Studio-Tools für Office.


namespace VSTO_test {
    [ComVisible(true)]
    public class MyRibbon: Office.IRibbonExtensibility {
        private Office.IRibbonUI ribbon;

        public MyRibbon() {
        }

        public void ConnectReader(IRibbonControl control) {
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.In)) {
                // Connect to the named pipe
                pipeClient.Connect();

                // Read characters from the named pipe
                using (StreamReader reader = new StreamReader(pipeClient)) {
                    char[] buffer = new char[1000];
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string message = new string(buffer, 0, bytesRead);

                    // Pass the characters to your processing function
                    ProcessMessage(message);
                }
            }
        }

        public void StartReader(IRibbonControl control) { }


        private void ProcessMessage(string message) {
            MessageBox.Show(message);
        }

        #region IRibbonExtensibility-Member

        public string GetCustomUI(string ribbonID) {
            return GetResourceText("VSTO_test.MyRibbon.xml");
        }

        #endregion

        #region Menübandrückrufe
        //Erstellen Sie hier Rückrufmethoden. Weitere Informationen zum Hinzufügen von Rückrufmethoden finden Sie unter https://go.microsoft.com/fwlink/?LinkID=271226.

        public void Ribbon_Load(Office.IRibbonUI ribbonUI) {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Hilfsprogramme

        private static string GetResourceText(string resourceName) {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i) {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0) {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i]))) {
                        if (resourceReader != null) {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
