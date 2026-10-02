namespace AppHub
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.themeToggleBtn = new System.Windows.Forms.Button();
            this.communityBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.logoLabel = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.sortComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.noResultsPanel = new System.Windows.Forms.Panel();
            this.noResultsLabel = new System.Windows.Forms.Label();
            this.noResultsIconLabel = new System.Windows.Forms.Label();
            this.toolsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.noResultsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.themeToggleBtn);
            this.headerPanel.Controls.Add(this.communityBtn);
            this.headerPanel.Controls.Add(this.homeBtn);
            this.headerPanel.Controls.Add(this.logoLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1600, 73);
            this.headerPanel.TabIndex = 0;
            // 
            // themeToggleBtn
            // 
            this.themeToggleBtn.BackColor = System.Drawing.Color.Transparent;
            this.themeToggleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themeToggleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.themeToggleBtn.Location = new System.Drawing.Point(1520, 21);
            this.themeToggleBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.themeToggleBtn.Name = "themeToggleBtn";
            this.themeToggleBtn.Size = new System.Drawing.Size(36, 33);
            this.themeToggleBtn.TabIndex = 3;
            this.themeToggleBtn.Text = "☀";
            this.themeToggleBtn.UseVisualStyleBackColor = false;
            this.themeToggleBtn.Click += new System.EventHandler(this.ThemeToggleBtn_Click);
            // 
            // communityBtn
            // 
            this.communityBtn.BackColor = System.Drawing.Color.Transparent;
            this.communityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.communityBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.communityBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.communityBtn.Location = new System.Drawing.Point(693, 21);
            this.communityBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.communityBtn.Name = "communityBtn";
            this.communityBtn.Size = new System.Drawing.Size(107, 33);
            this.communityBtn.TabIndex = 2;
            this.communityBtn.Text = "Community";
            this.communityBtn.UseVisualStyleBackColor = false;
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.homeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.homeBtn.Location = new System.Drawing.Point(597, 21);
            this.homeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(80, 33);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = false;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.logoLabel.ForeColor = System.Drawing.Color.Black;
            this.logoLabel.Location = new System.Drawing.Point(128, 21);
            this.logoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(91, 28);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "SX Tools";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.searchPanel.Controls.Add(this.sortComboBox);
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 73);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(128, 15, 128, 15);
            this.searchPanel.Size = new System.Drawing.Size(1600, 74);
            this.searchPanel.TabIndex = 1;
            // 
            // sortComboBox
            // 
            this.sortComboBox.BackColor = System.Drawing.Color.White;
            this.sortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sortComboBox.ForeColor = System.Drawing.Color.Black;
            this.sortComboBox.Items.AddRange(new object[] {
            "Sort: A-Z",
            "Sort: Z-A"});
            this.sortComboBox.Location = new System.Drawing.Point(1273, 18);
            this.sortComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.Size = new System.Drawing.Size(199, 28);
            this.sortComboBox.TabIndex = 1;
            this.sortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.searchTextBox.Location = new System.Drawing.Point(128, 18);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(1133, 27);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Search tools (e.g., audio, text, image, flashlight, blues)...";
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.noResultsPanel);
            this.mainPanel.Controls.Add(this.toolsFlowLayoutPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 147);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(128, 15, 128, 15);
            this.mainPanel.Size = new System.Drawing.Size(1600, 776);
            this.mainPanel.TabIndex = 2;
            // 
            // noResultsPanel
            // 
            this.noResultsPanel.BackColor = System.Drawing.Color.Transparent;
            this.noResultsPanel.Controls.Add(this.noResultsLabel);
            this.noResultsPanel.Controls.Add(this.noResultsIconLabel);
            this.noResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noResultsPanel.Location = new System.Drawing.Point(128, 15);
            this.noResultsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noResultsPanel.Name = "noResultsPanel";
            this.noResultsPanel.Size = new System.Drawing.Size(1344, 746);
            this.noResultsPanel.TabIndex = 1;
            this.noResultsPanel.Visible = false;
            // 
            // noResultsLabel
            // 
            this.noResultsLabel.AutoSize = true;
            this.noResultsLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.noResultsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.noResultsLabel.Location = new System.Drawing.Point(513, 345);
            this.noResultsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noResultsLabel.Name = "noResultsLabel";
            this.noResultsLabel.Size = new System.Drawing.Size(210, 37);
            this.noResultsLabel.TabIndex = 1;
            this.noResultsLabel.Text = "No tools found";
            // 
            // noResultsIconLabel
            // 
            this.noResultsIconLabel.AutoSize = true;
            this.noResultsIconLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.noResultsIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.noResultsIconLabel.Location = new System.Drawing.Point(552, 254);
            this.noResultsIconLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noResultsIconLabel.Name = "noResultsIconLabel";
            this.noResultsIconLabel.Size = new System.Drawing.Size(117, 81);
            this.noResultsIconLabel.TabIndex = 0;
            this.noResultsIconLabel.Text = "🔍";
            // 
            // toolsFlowLayoutPanel
            // 
            this.toolsFlowLayoutPanel.AutoSize = true;
            this.toolsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolsFlowLayoutPanel.Location = new System.Drawing.Point(128, 15);
            this.toolsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolsFlowLayoutPanel.Name = "toolsFlowLayoutPanel";
            this.toolsFlowLayoutPanel.Size = new System.Drawing.Size(1344, 0);
            this.toolsFlowLayoutPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1600, 923);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SX Tools Hub";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.noResultsPanel.ResumeLayout(false);
            this.noResultsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button communityBtn;
        private System.Windows.Forms.Button themeToggleBtn;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel toolsFlowLayoutPanel;
        private System.Windows.Forms.Panel noResultsPanel;
        private System.Windows.Forms.Label noResultsIconLabel;
        private System.Windows.Forms.Label noResultsLabel;
    }
}

