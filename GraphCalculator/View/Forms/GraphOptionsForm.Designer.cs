namespace GraphCalculator.View.Forms
{
    partial class GraphOptionsForm
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
            this.WidthTrackBar = new System.Windows.Forms.TrackBar();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.ColorDialogButton = new System.Windows.Forms.Button();
            this.CurveColorDialog = new System.Windows.Forms.ColorDialog();
            this.OKButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.GraphWindow = new GraphCalculator.View.Forms.FieldRendererControl();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // WidthTrackBar
            // 
            this.WidthTrackBar.AutoSize = false;
            this.WidthTrackBar.Location = new System.Drawing.Point(12, 12);
            this.WidthTrackBar.Maximum = 100;
            this.WidthTrackBar.Minimum = 10;
            this.WidthTrackBar.Name = "WidthTrackBar";
            this.WidthTrackBar.Size = new System.Drawing.Size(115, 29);
            this.WidthTrackBar.TabIndex = 0;
            this.WidthTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.WidthTrackBar.Value = 10;
            this.WidthTrackBar.Scroll += new System.EventHandler(this.WidthTrackBar_Scroll);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(12, 44);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(55, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Width: XX";
            // 
            // ColorDialogButton
            // 
            this.ColorDialogButton.Location = new System.Drawing.Point(12, 60);
            this.ColorDialogButton.Name = "ColorDialogButton";
            this.ColorDialogButton.Size = new System.Drawing.Size(115, 23);
            this.ColorDialogButton.TabIndex = 3;
            this.ColorDialogButton.Text = "Select color";
            this.ColorDialogButton.UseVisualStyleBackColor = true;
            this.ColorDialogButton.Click += new System.EventHandler(this.ColorDialogButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.Location = new System.Drawing.Point(209, 94);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "Ok";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.NoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NoButton.Location = new System.Drawing.Point(134, 94);
            this.NoButton.Name = "CancelButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 5;
            this.NoButton.Text = "Cancel";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GraphWindow
            // 
            this.GraphWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphWindow.BackColor = System.Drawing.Color.Black;
            this.GraphWindow.CanBeControlled = false;
            this.GraphWindow.Location = new System.Drawing.Point(134, 13);
            this.GraphWindow.Name = "GraphWindow";
            this.GraphWindow.Size = new System.Drawing.Size(150, 75);
            this.GraphWindow.TabIndex = 2;
            this.GraphWindow.VSync = false;
            // 
            // GraphOptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 129);
            this.ControlBox = false;
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ColorDialogButton);
            this.Controls.Add(this.GraphWindow);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.WidthTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GraphOptionsForm";
            this.Text = "GraphOptionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphOptionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.WidthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar WidthTrackBar;
        private System.Windows.Forms.Label WidthLabel;
        private FieldRendererControl GraphWindow;
        private System.Windows.Forms.Button ColorDialogButton;
        private System.Windows.Forms.ColorDialog CurveColorDialog;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button NoButton;
    }
}