
using Microsoft.Office.Tools.Ribbon;
using System;

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
            this.Scanner = this.Factory.CreateRibbonTab();
            this.start_stop = this.Factory.CreateRibbonGroup();
            this.connect = this.Factory.CreateRibbonButton();
            this.box2 = this.Factory.CreateRibbonBox();
            this.value = this.Factory.CreateRibbonEditBox();
            this.button1 = this.Factory.CreateRibbonButton();
            this.macro = this.Factory.CreateRibbonComboBox();
            this.Scanner.SuspendLayout();
            this.start_stop.SuspendLayout();
            this.box2.SuspendLayout();
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
            this.start_stop.Items.Add(this.connect);
            this.start_stop.Items.Add(this.macro);
            this.start_stop.Items.Add(this.box2);
            this.start_stop.Label = "Scanner";
            this.start_stop.Name = "start_stop";
            this.start_stop.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.start_stop_DialogLauncherClick);
            // 
            // connect
            // 
            this.connect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.connect.Label = "Start Scanner";
            this.connect.Name = "connect";
            this.connect.OfficeImageId = "MacroPlay";
            this.connect.ShowImage = true;
            this.connect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.connect_Click);
            // 
            // box2
            // 
            this.box2.Items.Add(this.value);
            this.box2.Items.Add(this.button1);
            this.box2.Name = "box2";
            // 
            // value
            // 
            this.value.Label = "Value";
            this.value.Name = "value";
            this.value.OfficeImageId = "TextBoxInsert";
            this.value.ShowImage = true;
            this.value.ShowLabel = false;
            this.value.SuperTip = "This value is used as though it were scanned in by the scanner. You can use this " +
    "field if the scanner is misbehaving or not working";
            this.value.Text = null;
            // 
            // button1
            // 
            this.button1.Label = "Dispatch";
            this.button1.Name = "button1";
            this.button1.SuperTip = "Dispatch Value";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // macro
            // 
            this.macro.Label = "Use Macro";
            this.macro.Name = "macro";
            this.macro.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.macro_TextChanged);
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
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Scanner;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup start_stop;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton connect;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox value;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal RibbonComboBox macro;
    }

    partial class ThisRibbonCollection {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
