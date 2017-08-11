using System;
using System.Windows.Forms;

namespace Launchpad {

    public partial class LaunchScreen : Form {
        private Button Settings;
        public TextBox TextView;
        private Button ForceKill;

        public LaunchScreen() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.Settings = new System.Windows.Forms.Button();
            this.ForceKill = new System.Windows.Forms.Button();
            this.TextView = new System.Windows.Forms.TextBox();
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
            this.Settings.Click += new EventHandler(this.Settings_Click);
            // 
            // ForceKill
            // 
            this.ForceKill.Location = new System.Drawing.Point(13, 439);
            this.ForceKill.Name = "ForceKill";
            this.ForceKill.Size = new System.Drawing.Size(75, 23);
            this.ForceKill.TabIndex = 1;
            this.ForceKill.Text = "Force Kill";
            this.ForceKill.UseVisualStyleBackColor = true;
            this.ForceKill.Click += new EventHandler(this.ForceKill_Click);
            // 
            // TextView
            // 
            this.TextView.AcceptsReturn = true;
            this.TextView.AcceptsTab = true;
            this.TextView.Location = new System.Drawing.Point(13, 13);
            this.TextView.Multiline = true;
            this.TextView.Name = "TextView";
            this.TextView.ReadOnly = true;
            this.TextView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextView.Size = new System.Drawing.Size(983, 420);
            this.TextView.TabIndex = 2;
            // 
            // LaunchScreen
            // 
            this.ClientSize = new System.Drawing.Size(1008, 474);
            this.Controls.Add(this.TextView);
            this.Controls.Add(this.ForceKill);
            this.Controls.Add(this.Settings);
            this.Name = "LaunchScreen";
            this.Text = "Launchpad Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LaunchScreen_Load(object sender, EventArgs e) {
            
        }

        private void Settings_Click(object sender, EventArgs e) {
            TextView.AppendText("Clicked :" + e.ToString());
        }

        private void ForceKill_Click(object sender, EventArgs e) {
            LaunchpadController.Instance.Kill();
        }
    }
}
