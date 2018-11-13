namespace GraphCalculator.View.Forms
{
    partial class MainForm
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
            this.UISplitContainer = new System.Windows.Forms.SplitContainer();
            this.GraphWindow = new GraphCalculator.View.Forms.FieldRendererControl();
            this.MainGraphListControl = new GraphCalculator.View.Forms.GraphListControl();
            ((System.ComponentModel.ISupportInitialize)(this.UISplitContainer)).BeginInit();
            this.UISplitContainer.Panel1.SuspendLayout();
            this.UISplitContainer.Panel2.SuspendLayout();
            this.UISplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // UISplitContainer
            // 
            this.UISplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UISplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.UISplitContainer.Location = new System.Drawing.Point(0, 0);
            this.UISplitContainer.Name = "UISplitContainer";
            // 
            // UISplitContainer.Panel1
            // 
            this.UISplitContainer.Panel1.Controls.Add(this.MainGraphListControl);
            this.UISplitContainer.Panel1MinSize = 250;
            // 
            // UISplitContainer.Panel2
            // 
            this.UISplitContainer.Panel2.Controls.Add(this.GraphWindow);
            this.UISplitContainer.Size = new System.Drawing.Size(726, 360);
            this.UISplitContainer.SplitterDistance = 350;
            this.UISplitContainer.TabIndex = 5;
            // 
            // GraphWindow
            // 
            this.GraphWindow.BackColor = System.Drawing.Color.Black;
            this.GraphWindow.CanBeControlled = false;
            this.GraphWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphWindow.FieldRenderer = null;
            this.GraphWindow.Location = new System.Drawing.Point(0, 0);
            this.GraphWindow.Name = "GraphWindow";
            this.GraphWindow.Size = new System.Drawing.Size(372, 360);
            this.GraphWindow.TabIndex = 0;
            this.GraphWindow.VSync = true;
            // 
            // MainGraphListControl
            // 
            this.MainGraphListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGraphListControl.Location = new System.Drawing.Point(0, 0);
            this.MainGraphListControl.MinimumSize = new System.Drawing.Size(304, 30);
            this.MainGraphListControl.Name = "MainGraphListControl";
            this.MainGraphListControl.Size = new System.Drawing.Size(350, 360);
            this.MainGraphListControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 360);
            this.Controls.Add(this.UISplitContainer);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.UISplitContainer.Panel1.ResumeLayout(false);
            this.UISplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UISplitContainer)).EndInit();
            this.UISplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer UISplitContainer;
        private FieldRendererControl GraphWindow;
        private GraphListControl MainGraphListControl;
    }
}