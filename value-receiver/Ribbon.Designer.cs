
namespace value_receiver {
    partial class Ribbon: Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">"true", wenn verwaltete Ressourcen gelöscht werden sollen, andernfalls "false".</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.Scanner = this.Factory.CreateRibbonTab();
            this.start_stop = this.Factory.CreateRibbonGroup();
            this.connect = this.Factory.CreateRibbonButton();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.Scanner.SuspendLayout();
            this.start_stop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scanner
            // 
            this.Scanner.Groups.Add(this.start_stop);
            this.Scanner.Label = "Scanner";
            this.Scanner.Name = "Scanner";
            // 
            // start_stop
            // 
            this.start_stop.DialogLauncher = ribbonDialogLauncherImpl1;
            this.start_stop.Items.Add(this.connect);
            this.start_stop.Items.Add(this.editBox1);
            this.start_stop.Label = "Manage Scanner";
            this.start_stop.Name = "start_stop";
            this.start_stop.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.start_stop_DialogLauncherClick);
            // 
            // connect
            // 
            this.connect.Label = "Start Scanner";
            this.connect.Name = "connect";
            this.connect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.connect_Click);
            // 
            // editBox1
            // 
            this.editBox1.Label = "editBox1";
            this.editBox1.Name = "editBox1";
            this.editBox1.ShowLabel = false;
            this.editBox1.Text = null;
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.Scanner);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.Scanner.ResumeLayout(false);
            this.Scanner.PerformLayout();
            this.start_stop.ResumeLayout(false);
            this.start_stop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Scanner;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup start_stop;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton connect;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
    }

    partial class ThisRibbonCollection {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
