namespace VSTO_test {
    public partial class ThisAddIn {
        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) {
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject() {
            return new MyRibbon();
        }

        #region Von VSTO generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InternalStartup() {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}