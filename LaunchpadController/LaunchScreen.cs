using System;
using System.Windows.Forms;

namespace Launchpad {

    public partial class LaunchScreen : Form {
        private Button Settings;
        public RichTextBox TextView;
        private Button ForceKill;

        public LaunchScreen() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.Settings = new System.Windows.Forms.Button();
            this.ForceKill = new System.Windows.Forms.Button();
            this.TextView = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(94, 439);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // ForceKill
            // 
            this.ForceKill.Location = new System.Drawing.Point(13, 439);
            this.ForceKill.Name = "ForceKill";
            this.ForceKill.Size = new System.Drawing.Size(75, 23);
            this.ForceKill.TabIndex = 1;
            this.ForceKill.Text = "Force Kill";
            this.ForceKill.UseVisualStyleBackColor = true;
            this.ForceKill.Click += new System.EventHandler(this.ForceKill_Click);
            // 
            // TextView
            // 
            this.TextView.AcceptsTab = true;
            this.TextView.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextView.Location = new System.Drawing.Point(13, 13);
            this.TextView.Name = "TextView";
            this.TextView.ReadOnly = true;
            this.TextView.Size = new System.Drawing.Size(983, 420);
            this.TextView.TabIndex = 2;
            this.TextView.Text = "";
            this.TextView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextView_KeyPress);
            // 
            // LaunchScreen
            // 
            this.ClientSize = new System.Drawing.Size(1008, 474);
            this.Controls.Add(this.TextView);
            this.Controls.Add(this.ForceKill);
            this.Controls.Add(this.Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LaunchScreen";
            this.Text = "Launchpad Console";
            this.ResumeLayout(false);

        }

        private void LaunchScreen_Load(object sender, EventArgs e) {
            
        }

        private void Settings_Click(object sender, EventArgs e) {
            TextView.AppendText("Clicked :" + e.ToString());
        }

        private void ForceKill_Click(object sender, EventArgs e) {
            LaunchpadController.Instance.Kill();
        }

        private void TextView_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }
    }
}
