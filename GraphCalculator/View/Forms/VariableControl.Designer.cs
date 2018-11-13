namespace GraphCalculator.View.Forms
{
    partial class VariableControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ValueTrackBar = new System.Windows.Forms.TrackBar();
            this.MaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ValueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(3, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NameTextBox.Size = new System.Drawing.Size(149, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteButton.Location = new System.Drawing.Point(312, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(20, 20);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "X";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(3, 77);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(38, 16);
            this.ErrorLabel.TabIndex = 4;
            this.ErrorLabel.Text = "(!) ...";
            this.ErrorLabel.Visible = false;
            // 
            // ValueTrackBar
            // 
            this.ValueTrackBar.AutoSize = false;
            this.ValueTrackBar.Location = new System.Drawing.Point(3, 29);
            this.ValueTrackBar.Maximum = 1000;
            this.ValueTrackBar.Name = "ValueTrackBar";
            this.ValueTrackBar.Size = new System.Drawing.Size(329, 18);
            this.ValueTrackBar.TabIndex = 5;
            this.ValueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ValueTrackBar.Scroll += new System.EventHandler(this.ValueTrackBar_Scroll);
            // 
            // MaxNumericUpDown
            // 
            this.MaxNumericUpDown.DecimalPlaces = 5;
            this.MaxNumericUpDown.Location = new System.Drawing.Point(253, 53);
            this.MaxNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MaxNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.MaxNumericUpDown.Name = "MaxNumericUpDown";
            this.MaxNumericUpDown.Size = new System.Drawing.Size(79, 20);
            this.MaxNumericUpDown.TabIndex = 6;
            this.MaxNumericUpDown.ValueChanged += new System.EventHandler(this.MaxNumericUpDown_ValueChanged);
            // 
            // MinNumericUpDown
            // 
            this.MinNumericUpDown.DecimalPlaces = 5;
            this.MinNumericUpDown.Location = new System.Drawing.Point(4, 54);
            this.MinNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MinNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.MinNumericUpDown.Name = "MinNumericUpDown";
            this.MinNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.MinNumericUpDown.TabIndex = 7;
            this.MinNumericUpDown.ValueChanged += new System.EventHandler(this.MinNumericUpDown_ValueChanged);
            // 
            // ValueNumericUpDown
            // 
            this.ValueNumericUpDown.DecimalPlaces = 5;
            this.ValueNumericUpDown.InterceptArrowKeys = false;
            this.ValueNumericUpDown.Location = new System.Drawing.Point(180, 3);
            this.ValueNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ValueNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ValueNumericUpDown.Name = "ValueNumericUpDown";
            this.ValueNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.ValueNumericUpDown.TabIndex = 8;
            this.ValueNumericUpDown.ValueChanged += new System.EventHandler(this.ValueNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(158, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "=";
            // 
            // VariableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ValueNumericUpDown);
            this.Controls.Add(this.MinNumericUpDown);
            this.Controls.Add(this.MaxNumericUpDown);
            this.Controls.Add(this.ValueTrackBar);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NameTextBox);
            this.Name = "VariableControl";
            this.Size = new System.Drawing.Size(335, 95);
            ((System.ComponentModel.ISupportInitialize)(this.ValueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TrackBar ValueTrackBar;
        private System.Windows.Forms.NumericUpDown MaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown MinNumericUpDown;
        private System.Windows.Forms.NumericUpDown ValueNumericUpDown;
        private System.Windows.Forms.Label label1;
    }
}
