
namespace Scramble
{
    partial class Scramble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scramble));
            this.encryptButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.browseButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.encryptModeBox = new System.Windows.Forms.ComboBox();
            this.encryptModeLabel = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.encryptButton.Location = new System.Drawing.Point(10, 216);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(364, 30);
            this.encryptButton.TabIndex = 4;
            this.encryptButton.Text = "Encrypt / Decrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aboutButton.Location = new System.Drawing.Point(10, 246);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(364, 30);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(10, 176);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(364, 10);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.browseButton.Location = new System.Drawing.Point(10, 186);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(364, 30);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse File";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pathBox.Location = new System.Drawing.Point(10, 156);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(364, 20);
            this.pathBox.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(10, 126);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(364, 10);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // encryptModeBox
            // 
            this.encryptModeBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.encryptModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encryptModeBox.FormattingEnabled = true;
            this.encryptModeBox.Location = new System.Drawing.Point(10, 105);
            this.encryptModeBox.Name = "encryptModeBox";
            this.encryptModeBox.Size = new System.Drawing.Size(364, 21);
            this.encryptModeBox.TabIndex = 1;
            // 
            // encryptModeLabel
            // 
            this.encryptModeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.encryptModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptModeLabel.Location = new System.Drawing.Point(10, 85);
            this.encryptModeLabel.Name = "encryptModeLabel";
            this.encryptModeLabel.Size = new System.Drawing.Size(364, 20);
            this.encryptModeLabel.TabIndex = 7;
            this.encryptModeLabel.Text = "Encryption Mode";
            this.encryptModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Enabled = false;
            this.splitter3.Location = new System.Drawing.Point(10, 75);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(364, 10);
            this.splitter3.TabIndex = 8;
            this.splitter3.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(10, 52);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(364, 23);
            this.progressBar.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(10, 32);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(364, 20);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "Idle";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pathLabel
            // 
            this.pathLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(10, 136);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(364, 20);
            this.pathLabel.TabIndex = 11;
            this.pathLabel.Text = "Path";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(10, 2);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(364, 30);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "File Encryption For Dummies";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Scramble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 286);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.encryptModeLabel);
            this.Controls.Add(this.encryptModeBox);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.aboutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Scramble";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Scramble";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ComboBox encryptModeBox;
        private System.Windows.Forms.Label encryptModeLabel;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}

