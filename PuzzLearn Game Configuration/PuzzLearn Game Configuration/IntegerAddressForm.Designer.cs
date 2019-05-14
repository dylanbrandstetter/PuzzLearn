namespace PuzzLearn_Game_Configuration
{
    partial class IntegerAddressForm
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
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ShortIntPanel = new System.Windows.Forms.Panel();
            this.MultiplicationFactorUpDown = new System.Windows.Forms.NumericUpDown();
            this.OffsetUpDown = new System.Windows.Forms.NumericUpDown();
            this.OffsetLabel = new System.Windows.Forms.Label();
            this.MultiplyLabel = new System.Windows.Forms.Label();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.AddressPanel = new System.Windows.Forms.Panel();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.ButtonsPanel.SuspendLayout();
            this.ShortIntPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplicationFactorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUpDown)).BeginInit();
            this.DescriptionPanel.SuspendLayout();
            this.AddressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Controls.Add(this.ConfirmButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 114);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(260, 31);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(182, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(101, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ShortIntPanel
            // 
            this.ShortIntPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShortIntPanel.Controls.Add(this.MultiplicationFactorUpDown);
            this.ShortIntPanel.Controls.Add(this.OffsetUpDown);
            this.ShortIntPanel.Controls.Add(this.OffsetLabel);
            this.ShortIntPanel.Controls.Add(this.MultiplyLabel);
            this.ShortIntPanel.Location = new System.Drawing.Point(12, 80);
            this.ShortIntPanel.Name = "ShortIntPanel";
            this.ShortIntPanel.Size = new System.Drawing.Size(260, 28);
            this.ShortIntPanel.TabIndex = 2;
            // 
            // MultiplicationFactorUpDown
            // 
            this.MultiplicationFactorUpDown.DecimalPlaces = 3;
            this.MultiplicationFactorUpDown.Location = new System.Drawing.Point(202, 3);
            this.MultiplicationFactorUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.MultiplicationFactorUpDown.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.MultiplicationFactorUpDown.Name = "MultiplicationFactorUpDown";
            this.MultiplicationFactorUpDown.Size = new System.Drawing.Size(55, 20);
            this.MultiplicationFactorUpDown.TabIndex = 1;
            this.MultiplicationFactorUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OffsetUpDown
            // 
            this.OffsetUpDown.Location = new System.Drawing.Point(48, 3);
            this.OffsetUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OffsetUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.OffsetUpDown.Name = "OffsetUpDown";
            this.OffsetUpDown.Size = new System.Drawing.Size(38, 20);
            this.OffsetUpDown.TabIndex = 0;
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(4, 5);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(38, 13);
            this.OffsetLabel.TabIndex = 1;
            this.OffsetLabel.Text = "Offset:";
            this.OffsetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MultiplyLabel
            // 
            this.MultiplyLabel.AutoSize = true;
            this.MultiplyLabel.Location = new System.Drawing.Point(92, 5);
            this.MultiplyLabel.Name = "MultiplyLabel";
            this.MultiplyLabel.Size = new System.Drawing.Size(104, 13);
            this.MultiplyLabel.TabIndex = 3;
            this.MultiplyLabel.Text = "Multiplication Factor:";
            this.MultiplyLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionPanel.Controls.Add(this.DescriptionTextBox);
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 46);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(260, 28);
            this.DescriptionPanel.TabIndex = 1;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(87, 4);
            this.DescriptionTextBox.MaxLength = 32;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(170, 20);
            this.DescriptionTextBox.TabIndex = 0;
            this.DescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(14, 7);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "*Description:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AddressPanel
            // 
            this.AddressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressPanel.Controls.Add(this.AddressTextBox);
            this.AddressPanel.Controls.Add(this.AddressLabel);
            this.AddressPanel.Location = new System.Drawing.Point(12, 12);
            this.AddressPanel.Name = "AddressPanel";
            this.AddressPanel.Size = new System.Drawing.Size(260, 28);
            this.AddressPanel.TabIndex = 0;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.Location = new System.Drawing.Point(87, 5);
            this.AddressTextBox.MaxLength = 8;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(170, 20);
            this.AddressTextBox.TabIndex = 0;
            this.AddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressTextBox_KeyDown);
            this.AddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(3, 7);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(78, 13);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "*Address (hex):";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // IntegerAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.AddressPanel);
            this.Controls.Add(this.ShortIntPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "IntegerAddressForm";
            this.Text = "IntegerAddressForm";
            this.ButtonsPanel.ResumeLayout(false);
            this.ShortIntPanel.ResumeLayout(false);
            this.ShortIntPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplicationFactorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUpDown)).EndInit();
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            this.AddressPanel.ResumeLayout(false);
            this.AddressPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Panel ShortIntPanel;
        private System.Windows.Forms.Label OffsetLabel;
        private System.Windows.Forms.Label MultiplyLabel;
        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel AddressPanel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.NumericUpDown MultiplicationFactorUpDown;
        private System.Windows.Forms.NumericUpDown OffsetUpDown;
    }
}