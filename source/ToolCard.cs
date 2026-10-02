using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppHub
{
    public partial class ToolCard : UserControl
    {
        private Tool _tool;
        private bool _isDarkMode;
        public event EventHandler ToolClicked;

        public ToolCard(Tool tool, bool isDarkMode = false)
        {
            InitializeComponent();
            _tool = tool;
            _isDarkMode = isDarkMode;
            SetupUI(isDarkMode);
        }

        private void SetupUI(bool isDarkMode)
        {
            this.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(340, 220);
            this.Padding = new Padding(8);
            this.Cursor = Cursors.Hand;

            // Icon label
            Label iconLabel = new Label
            {
                Text = _tool.IconName,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 51, 102),
                Size = new Size(48, 48),
                Location = new Point(8, 8),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Title label
            Label titleLabel = new Label
            {
                Text = _tool.Title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = isDarkMode ? Color.White : Color.FromArgb(51, 51, 51),
                Size = new Size(300, 30),
                Location = new Point(8, 62),
                AutoSize = false
            };

            // Description label
            Label descLabel = new Label
            {
                Text = _tool.Description,
                Font = new Font("Segoe UI", 8),
                ForeColor = isDarkMode ? Color.FromArgb(153, 153, 153) : Color.FromArgb(128, 128, 128),
                Size = new Size(300, 80),
                Location = new Point(8, 100),
                AutoSize = false,
                MaximumSize = new Size(300, 100)
            };
            descLabel.Text = WrapText(descLabel.Text, 45);

            this.Controls.Add(iconLabel);
            this.Controls.Add(titleLabel);
            this.Controls.Add(descLabel);

            // Click handlers
            this.Click += (s, e) => ToolClicked?.Invoke(this, EventArgs.Empty);
            iconLabel.Click += (s, e) => ToolClicked?.Invoke(this, EventArgs.Empty);
            titleLabel.Click += (s, e) => ToolClicked?.Invoke(this, EventArgs.Empty);
            descLabel.Click += (s, e) => ToolClicked?.Invoke(this, EventArgs.Empty);

            // Hover effect
            this.MouseEnter += (s, e) =>
            {
                this.BorderStyle = BorderStyle.Fixed3D;
                this.BackColor = isDarkMode ? Color.FromArgb(40, 40, 43) : Color.FromArgb(245, 245, 245);
            };
            this.MouseLeave += (s, e) =>
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                this.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            };
        }

        private string WrapText(string text, int charPerLine)
        {
            if (text.Length <= charPerLine)
                return text;

            string result = "";
            int currentPos = 0;
            while (currentPos < text.Length)
            {
                int endPos = Math.Min(currentPos + charPerLine, text.Length);
                result += text.Substring(currentPos, endPos - currentPos) + "\n";
                currentPos = endPos;
            }
            return result.TrimEnd();
        }

        public Tool GetTool()
        {
            return _tool;
        }

        public bool IsDarkMode
        {
            get { return _isDarkMode; }
        }
    }
}
