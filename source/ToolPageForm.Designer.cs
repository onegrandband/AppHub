namespace AppHub
{
    partial class ToolPageForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.retryButton = new System.Windows.Forms.Button();
            this.openInBrowserButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();

            // toolbarPanel
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.toolbarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbarPanel.Controls.Add(this.closeButton);
            this.toolbarPanel.Controls.Add(this.openInBrowserButton);
            this.toolbarPanel.Controls.Add(this.retryButton);
            this.toolbarPanel.Controls.Add(this.forwardButton);
            this.toolbarPanel.Controls.Add(this.backButton);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.Height = 45;
            this.toolbarPanel.Padding = new System.Windows.Forms.Padding(8);

            // backButton
            this.backButton.Text = "← Back";
            this.backButton.Location = new System.Drawing.Point(8, 9);
            this.backButton.Size = new System.Drawing.Size(80, 25);
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.TabIndex = 0;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);

            // forwardButton
            this.forwardButton.Text = "Forward →";
            this.forwardButton.Location = new System.Drawing.Point(95, 9);
            this.forwardButton.Size = new System.Drawing.Size(80, 25);
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.TabIndex = 1;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);

            // retryButton
            this.retryButton.Text = "Retry";
            this.retryButton.Location = new System.Drawing.Point(182, 9);
            this.retryButton.Size = new System.Drawing.Size(60, 25);
            this.retryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retryButton.TabIndex = 2;
            this.retryButton.Visible = false;
            this.retryButton.Click += new System.EventHandler(this.RetryButton_Click);

            // openInBrowserButton
            this.openInBrowserButton.Text = "Open in Browser";
            this.openInBrowserButton.Location = new System.Drawing.Point(247, 9);
            this.openInBrowserButton.Size = new System.Drawing.Size(115, 25);
            this.openInBrowserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openInBrowserButton.TabIndex = 3;
            this.openInBrowserButton.Visible = false;
            this.openInBrowserButton.Click += new System.EventHandler(this.OpenInBrowserButton_Click);

            // closeButton
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.Text = "✕ Close";
            this.closeButton.Location = new System.Drawing.Point(920, 9);
            this.closeButton.Size = new System.Drawing.Size(70, 25);
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.TabIndex = 4;
            this.closeButton.Click += (s, e) => this.Close();

            // statusPanel
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Height = 32;
            this.statusPanel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.statusPanel.TabIndex = 1;

            // statusLabel
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Text = "Ready";

            // webBrowser
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 45);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.TabIndex = 0;

            // ToolPageForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.toolbarPanel);
            this.Name = "ToolPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Page";
            this.Load += new System.EventHandler(this.ToolPageForm_Load);
        }

        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button retryButton;
        private System.Windows.Forms.Button openInBrowserButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}
