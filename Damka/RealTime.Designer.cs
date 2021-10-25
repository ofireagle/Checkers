namespace Damka
{
    partial class RealTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealTime));
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.MenuButton = new System.Windows.Forms.Button();
            this.trunTitle = new System.Windows.Forms.Label();
            this.playTurnLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.algorithmWorker = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.InstructionsButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl
            // 
            this.tbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbl.ColumnCount = 8;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.Location = new System.Drawing.Point(42, 107);
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 8;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl.Size = new System.Drawing.Size(640, 640);
            this.tbl.TabIndex = 1;
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.Sienna;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MenuButton.ForeColor = System.Drawing.Color.SeaShell;
            this.MenuButton.Location = new System.Drawing.Point(495, 780);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(192, 51);
            this.MenuButton.TabIndex = 5;
            this.MenuButton.Text = "Main Menu";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // trunTitle
            // 
            this.trunTitle.AutoSize = true;
            this.trunTitle.BackColor = System.Drawing.Color.Sienna;
            this.trunTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.trunTitle.ForeColor = System.Drawing.Color.SeaShell;
            this.trunTitle.Location = new System.Drawing.Point(209, 39);
            this.trunTitle.Name = "trunTitle";
            this.trunTitle.Size = new System.Drawing.Size(165, 31);
            this.trunTitle.TabIndex = 6;
            this.trunTitle.Text = "Player turn:";
            // 
            // playTurnLabel
            // 
            this.playTurnLabel.AutoSize = true;
            this.playTurnLabel.BackColor = System.Drawing.Color.Sienna;
            this.playTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.playTurnLabel.ForeColor = System.Drawing.Color.SeaShell;
            this.playTurnLabel.Location = new System.Drawing.Point(374, 39);
            this.playTurnLabel.Name = "playTurnLabel";
            this.playTurnLabel.Size = new System.Drawing.Size(144, 31);
            this.playTurnLabel.TabIndex = 7;
            this.playTurnLabel.Text = "(Player...)";
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Sienna;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SettingsButton.ForeColor = System.Drawing.Color.SeaShell;
            this.SettingsButton.Location = new System.Drawing.Point(37, 780);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsButton.Size = new System.Drawing.Size(192, 51);
            this.SettingsButton.TabIndex = 8;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Damka.Properties.Resources._4544827697_6f73866999_b;
            this.pictureBox1.Location = new System.Drawing.Point(37, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 650);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(190, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(381, 64);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // InstructionsButton
            // 
            this.InstructionsButton.BackColor = System.Drawing.Color.Sienna;
            this.InstructionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.InstructionsButton.ForeColor = System.Drawing.Color.SeaShell;
            this.InstructionsButton.Location = new System.Drawing.Point(255, 780);
            this.InstructionsButton.Name = "InstructionsButton";
            this.InstructionsButton.Size = new System.Drawing.Size(215, 51);
            this.InstructionsButton.TabIndex = 13;
            this.InstructionsButton.Text = "Instructions";
            this.InstructionsButton.UseVisualStyleBackColor = false;
            this.InstructionsButton.Click += new System.EventHandler(this.InstructionsButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Sienna;
            this.pictureBox3.Location = new System.Drawing.Point(203, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(357, 39);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // RealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Damka.Properties.Resources.istockphoto_698791078_612x612;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 865);
            this.Controls.Add(this.InstructionsButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.playTurnLabel);
            this.Controls.Add(this.trunTitle);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 904);
            this.MinimumSize = new System.Drawing.Size(750, 904);
            this.Name = "RealTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers";
            this.Load += new System.EventHandler(this.RealTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Label trunTitle;
        private System.Windows.Forms.Label playTurnLabel;
        private System.Windows.Forms.Button SettingsButton;
        private System.ComponentModel.BackgroundWorker algorithmWorker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button InstructionsButton;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}