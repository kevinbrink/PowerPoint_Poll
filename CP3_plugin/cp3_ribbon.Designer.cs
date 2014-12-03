// Note: Several items refer to CP3. This is for legacy reasons. 
namespace CP3_plugin {
    partial class cp3_ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public cp3_ribbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cp3_ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.insertPoll = this.Factory.CreateRibbonButton();
            this.editPoll = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "CP4 Poll";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.insertPoll);
            this.group1.Items.Add(this.editPoll);
            this.group1.Name = "group1";
            // 
            // insertPoll
            // 
            this.insertPoll.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.insertPoll.Image = ((System.Drawing.Image)(resources.GetObject("insertPoll.Image")));
            this.insertPoll.KeyTip = "P";
            this.insertPoll.Label = "Insert Poll";
            this.insertPoll.Name = "insertPoll";
            this.insertPoll.ShowImage = true;
            this.insertPoll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.addPoll_Click);
            // 
            // editPoll
            // 
            this.editPoll.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.editPoll.Image = ((System.Drawing.Image)(resources.GetObject("editPoll.Image")));
            this.editPoll.Label = "Edit Poll";
            this.editPoll.Name = "editPoll";
            this.editPoll.ShowImage = true;
            this.editPoll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editPoll_Click);
            // 
            // cp3_ribbon
            // 
            this.Name = "cp3_ribbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.cp3_ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton insertPoll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton editPoll;
    }

    partial class ThisRibbonCollection {
        internal cp3_ribbon cp3_ribbon {
            get { return this.GetRibbon<cp3_ribbon>(); }
        }
    }
}
