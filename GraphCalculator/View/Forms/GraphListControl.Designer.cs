namespace GraphCalculator.View.Forms
{
    partial class GraphListControl
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
            this.GraphsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddGraphButton = new System.Windows.Forms.Button();
            this.AddFunctionButton = new System.Windows.Forms.Button();
            this.AddVariableButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GraphsFlowLayoutPanel
            // 
            this.GraphsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphsFlowLayoutPanel.AutoScroll = true;
            this.GraphsFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GraphsFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GraphsFlowLayoutPanel.Location = new System.Drawing.Point(0, 32);
            this.GraphsFlowLayoutPanel.Name = "GraphsFlowLayoutPanel";
            this.GraphsFlowLayoutPanel.Size = new System.Drawing.Size(304, 301);
            this.GraphsFlowLayoutPanel.TabIndex = 0;
            this.GraphsFlowLayoutPanel.WrapContents = false;
            // 
            // AddGraphButton
            // 
            this.AddGraphButton.Location = new System.Drawing.Point(3, 3);
            this.AddGraphButton.Name = "AddGraphButton";
            this.AddGraphButton.Size = new System.Drawing.Size(100, 23);
            this.AddGraphButton.TabIndex = 1;
            this.AddGraphButton.Text = "Graph";
            this.AddGraphButton.UseVisualStyleBackColor = true;
            this.AddGraphButton.Click += new System.EventHandler(this.AddGraphButton_Click);
            // 
            // AddFunctionButton
            // 
            this.AddFunctionButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddFunctionButton.Location = new System.Drawing.Point(101, 3);
            this.AddFunctionButton.Name = "AddFunctionButton";
            this.AddFunctionButton.Size = new System.Drawing.Size(100, 23);
            this.AddFunctionButton.TabIndex = 2;
            this.AddFunctionButton.Text = "Function";
            this.AddFunctionButton.UseVisualStyleBackColor = true;
            this.AddFunctionButton.Click += new System.EventHandler(this.AddFunctionButton_Click);
            // 
            // AddVariableButton
            // 
            this.AddVariableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddVariableButton.Location = new System.Drawing.Point(199, 3);
            this.AddVariableButton.Name = "AddVariableButton";
            this.AddVariableButton.Size = new System.Drawing.Size(100, 23);
            this.AddVariableButton.TabIndex = 3;
            this.AddVariableButton.Text = "Variable";
            this.AddVariableButton.UseVisualStyleBackColor = true;
            this.AddVariableButton.Click += new System.EventHandler(this.AddVariableButton_Click);
            // 
            // GraphListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddVariableButton);
            this.Controls.Add(this.AddFunctionButton);
            this.Controls.Add(this.AddGraphButton);
            this.Controls.Add(this.GraphsFlowLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(304, 30);
            this.Name = "GraphListControl";
            this.Size = new System.Drawing.Size(304, 333);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GraphsFlowLayoutPanel;
        private System.Windows.Forms.Button AddGraphButton;
        private System.Windows.Forms.Button AddFunctionButton;
        private System.Windows.Forms.Button AddVariableButton;
    }
}
