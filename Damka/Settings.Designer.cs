namespace Damka
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.CloseButton = new System.Windows.Forms.Button();
            this.turnBox = new System.Windows.Forms.GroupBox();
            this.WhiteRadio = new System.Windows.Forms.RadioButton();
            this.BlackRadio = new System.Windows.Forms.RadioButton();
            this.depthBar = new System.Windows.Forms.TrackBar();
            this.depthNumLbl = new System.Windows.Forms.Label();
            this.depthBox = new System.Windows.Forms.GroupBox();
            this.turnBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.depthBar)).BeginInit();
            this.depthBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CloseButton.Location = new System.Drawing.Point(129, 330);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(192, 51);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // turnBox
            // 
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Controls.Add(this.WhiteRadio);
            this.turnBox.Controls.Add(this.BlackRadio);
            this.turnBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.turnBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.turnBox.Location = new System.Drawing.Point(22, 53);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(180, 100);
            this.turnBox.TabIndex = 8;
            this.turnBox.TabStop = false;
            this.turnBox.Text = "First turn:";
            // 
            // WhiteRadio
            // 
            this.WhiteRadio.AutoSize = true;
            this.WhiteRadio.Location = new System.Drawing.Point(35, 31);
            this.WhiteRadio.Name = "WhiteRadio";
            this.WhiteRadio.Size = new System.Drawing.Size(113, 20);
            this.WhiteRadio.TabIndex = 1;
            this.WhiteRadio.Text = "White player";
            this.WhiteRadio.UseVisualStyleBackColor = true;
            // 
            // BlackRadio
            // 
            this.BlackRadio.AutoSize = true;
            this.BlackRadio.Location = new System.Drawing.Point(35, 59);
            this.BlackRadio.Name = "BlackRadio";
            this.BlackRadio.Size = new System.Drawing.Size(113, 20);
            this.BlackRadio.TabIndex = 0;
            this.BlackRadio.Text = "Black player";
            this.BlackRadio.UseVisualStyleBackColor = true;
            this.BlackRadio.CheckedChanged += new System.EventHandler(this.BlackRadio_CheckedChanged);
            // 
            // depthBar
            // 
            this.depthBar.BackColor = System.Drawing.SystemColors.MenuText;
            this.depthBar.LargeChange = 1;
            this.depthBar.Location = new System.Drawing.Point(12, 57);
            this.depthBar.Minimum = 1;
            this.depthBar.Name = "depthBar";
            this.depthBar.Size = new System.Drawing.Size(360, 45);
            this.depthBar.TabIndex = 9;
            this.depthBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.depthBar.Value = 1;
            this.depthBar.ValueChanged += new System.EventHandler(this.depthBar_ValueChanged);
            // 
            // depthNumLbl
            // 
            this.depthNumLbl.AutoSize = true;
            this.depthNumLbl.BackColor = System.Drawing.Color.Transparent;
            this.depthNumLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.depthNumLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.depthNumLbl.Location = new System.Drawing.Point(171, 19);
            this.depthNumLbl.Name = "depthNumLbl";
            this.depthNumLbl.Size = new System.Drawing.Size(41, 29);
            this.depthNumLbl.TabIndex = 11;
            this.depthNumLbl.Text = "10";
            // 
            // depthBox
            // 
            this.depthBox.BackColor = System.Drawing.Color.Transparent;
            this.depthBox.Controls.Add(this.depthNumLbl);
            this.depthBox.Controls.Add(this.depthBar);
            this.depthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.depthBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.depthBox.Location = new System.Drawing.Point(22, 193);
            this.depthBox.Name = "depthBox";
            this.depthBox.Size = new System.Drawing.Size(387, 118);
            this.depthBox.TabIndex = 8;
            this.depthBox.TabStop = false;
            this.depthBox.Text = "Level of difficulty:";
            this.depthBox.Enter += new System.EventHandler(this.LanBox_Enter);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Damka.Properties.Resources.Board;
            this.ClientSize = new System.Drawing.Size(430, 406);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.depthBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(446, 445);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(446, 445);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.turnBox.ResumeLayout(false);
            this.turnBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.depthBar)).EndInit();
            this.depthBox.ResumeLayout(false);
            this.depthBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox turnBox;
        private System.Windows.Forms.RadioButton WhiteRadio;
        private System.Windows.Forms.RadioButton BlackRadio;
        private System.Windows.Forms.TrackBar depthBar;
        private System.Windows.Forms.Label depthNumLbl;
        private System.Windows.Forms.GroupBox depthBox;
    }
}