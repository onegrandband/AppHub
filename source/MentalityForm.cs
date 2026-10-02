using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AppHub
{
    public class MentalityForm : Form
    {
        private readonly bool isDarkMode;
        private readonly List<MentalityVersion> versions = new List<MentalityVersion>();
        private ComboBox platformSelector;
        private DataGridView versionsGrid;
        private Label statusLabel;

        public MentalityForm(bool darkMode = false)
        {
            isDarkMode = darkMode;
            InitializeForm();
            InitializeVersions();
            InitializeVersionTable();
            ApplyTheme();
            ApplyPlatformFilter("Auto"); // Replaced "auto-default"
        }

        private void InitializeForm()
        {
            SuspendLayout(); // Prevents UI flicker while adding controls

            Text = "Mentality";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(900, 500);
            ClientSize = new Size(1200, 650);
            AutoScaleMode = AutoScaleMode.Font;

            Label titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(24, 18),
                Text = "Download Mentality"
            };

            Label descriptionLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(26, 58),
                Text = "Download the latest model of Mentality!"
            };

            Label sortLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(26, 103),
                Text = "Sort by Platform:"
            };

            platformSelector = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(145, 99),
                Size = new Size(180, 25)
            };
            
            // Consolidated redundant auto-detect items
            platformSelector.Items.AddRange(new object[]
            {
                "Auto-detect",
                "Windows",
                "MacOS",
                "Linux",
                "All"
            });
            
            platformSelector.SelectedIndexChanged += PlatformSelector_SelectedIndexChanged;
            platformSelector.SelectedIndex = 0; 

            versionsGrid = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoGenerateColumns = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(24, 145),
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(1152, 430),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            versionsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            versionsGrid.CellContentClick += VersionsGrid_CellContentClick;

            statusLabel = new Label
            {
                AutoEllipsis = true,
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Height = 34,
                Padding = new Padding(24, 0, 24, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Ready"
            };

            Controls.Add(titleLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(sortLabel);
            Controls.Add(platformSelector);
            Controls.Add(versionsGrid);
            Controls.Add(statusLabel);
            
            ResumeLayout(false);
        }

        private void InitializeVersions()
        {
            // The constructor now takes 'LocalFileName' to avoid brittle string matching later
            versions.Add(new MentalityVersion(
                "Mentality_1.2.1.exe", "Mentality_1.2.1.exe", "41 KB", "1.2.1", "Windows 10/11", "Stable",
                "Fixed bug where hotkey setting did nothing.", "TBD", "Windows", true));
            versions.Add(new MentalityVersion(
                "Mentality.dmg", "Mentality.dmg", "TBD", "1.1.1", "MacOS 12+", "In Development",
                "Mac release is currently being worked on.", "TBD", "Mac", false));
            versions.Add(new MentalityVersion(
                "Mentality.tar.gz", "Mentality.tar.gz", "TBD", "1.1.1", "Ubuntu 20.04+", "In Development",
                "Linux release is currently being worked on.", "TBD", "Linux", false));
            versions.Add(new MentalityVersion(
                "Mentality.exe", "Mentality_1.2.0.exe", "37 KB", "1.2.0", "Windows 10 & 11", "Stable",
                "Profile presets, per-app rulesets, scheduled timers, interval jitter, smart pause, and coordinate locking. Additionally, it also adds plugin sandboxing, and UI accessibility enhancements :)",
                "TBD", "Windows", true));
            versions.Add(new MentalityVersion(
                "Mentality.exe", "Mentality_SX_1.1.1.exe", "27 KB", "1.1.1", "Windows 10 & 11", "Stable",
                "Misc bug fixes, clear hotkey setting, hotkey selection saving, and win-key (MOD_WIN) support",
                "TBD", "Windows", true));
            versions.Add(new MentalityVersion(
                "Mentality.exe", "Mentality_1.1.0.exe", "25.5 KB", "1.1.0", "Windows 10/11", "Stable",
                "Select multiple hotkeys (e.g Ctrl+Shift), hotkey bug fix, remove passphrase",
                "TBD", "Windows", true));
            versions.Add(new MentalityVersion(
                "Mentality.exe", "Mentality.exe", "17.5 KB", "1.0.0", "Windows 10 & 11", "Legacy",
                "Initial release. Auto-clicker with many bugs, but this was/is just the start!!!!!",
                "TBD", "Windows", true));
        }

        private void InitializeVersionTable()
        {
            AddTextColumn("ExecutableName", "Executable Name", 145);
            AddTextColumn("Size", "Size", 65);
            AddTextColumn("Version", "Version", 65);
            AddTextColumn("Compatibility", "Compatibility", 115);
            AddTextColumn("Type", "Type", 95);
            AddTextColumn("Description", "Description", 390);
            AddTextColumn("Commit", "GitHub Commit", 95);

            DataGridViewButtonColumn downloadColumn = new DataGridViewButtonColumn
            {
                Name = "Download",
                HeaderText = "Download",
                Width = 115,
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Standard
            };
            versionsGrid.Columns.Add(downloadColumn);

            foreach (MentalityVersion version in versions)
            {
                int rowIndex = versionsGrid.Rows.Add(
                    version.ExecutableName,
                    version.Size,
                    version.Version,
                    version.Compatibility,
                    version.Type,
                    version.Description,
                    version.Commit,
                    version.DownloadAvailable ? "Windows" : "Coming Soon");

                DataGridViewRow row = versionsGrid.Rows[rowIndex];
                row.Tag = version;
                row.Cells[7].Style.BackColor = version.DownloadAvailable
                    ? Color.FromArgb(224, 224, 224)
                    : Color.FromArgb(240, 240, 240);
                row.Cells[7].Style.ForeColor = version.DownloadAvailable
                    ? Color.Black
                    : Color.FromArgb(150, 150, 150);
            }
        }

        private void AddTextColumn(string name, string headerText, int width)
        {
            versionsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                Width = width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private void PlatformSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] filterValues = { "Auto", "Windows", "Mac", "Linux", "All" };
            ApplyPlatformFilter(filterValues[platformSelector.SelectedIndex]);
        }

        private void ApplyPlatformFilter(string platform)
        {
            string targetPlatform = (platform == "Auto") ? DetectPlatform() : platform;

            // CRITICAL: Hiding a row that has the active selection crashes the DataGridView. Clear it first.
            versionsGrid.CurrentCell = null;

            foreach (DataGridViewRow row in versionsGrid.Rows)
            {
                if (row.Tag is MentalityVersion version)
                {
                    row.Visible = targetPlatform == "All" || version.Platform == targetPlatform;
                }
            }

            statusLabel.Text = targetPlatform == "All"
                ? "Showing all platforms."
                : "Showing " + targetPlatform + " versions.";
        }

        private string DetectPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32Windows:
                    return "Windows";
                case PlatformID.MacOSX:
                    return "Mac";
                case PlatformID.Unix:
                    return "Linux";
                default:
                    return "All";
            }
        }

        private void VersionsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 7)
                return;

            MentalityVersion version = versionsGrid.Rows[e.RowIndex].Tag as MentalityVersion;
            if (version != null && version.DownloadAvailable)
                DownloadVersion(version);
        }

        private void DownloadVersion(MentalityVersion version)
        {
            string sourceDirectory = Path.Combine(Application.StartupPath, "MentalityFiles");
            string sourcePath = Path.Combine(sourceDirectory, version.LocalFileName);

            if (!File.Exists(sourcePath))
            {
                MessageBox.Show(
                    "The local file was not found.\n\nExpected location:\n" + sourcePath +
                    "\n\nNo website was opened. Place the file in that folder and try again.",
                    "Mentality file not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = version.ExecutableName;
                saveDialog.Title = "Save Mentality locally";

                // Generate dynamic filter based on the target extension (.exe, .dmg, .tar.gz, etc)
                string ext = Path.GetExtension(version.ExecutableName);
                if (string.IsNullOrEmpty(ext)) ext = ".exe";
                saveDialog.Filter = $"Mentality file (*{ext})|*{ext}|All files (*.*)|*.*";

                if (saveDialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    File.Copy(sourcePath, saveDialog.FileName, true);
                    statusLabel.Text = "Saved " + version.ExecutableName + " locally.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "The local file could not be copied:\n" + ex.Message,
                        "Copy failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ApplyTheme()
        {
            Color backgroundColor = isDarkMode ? Color.FromArgb(11, 11, 12) : Color.White;
            Color panelColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            Color textColor = isDarkMode ? Color.White : Color.Black;
            Color secondaryTextColor = isDarkMode ? Color.FromArgb(190, 190, 190) : Color.FromArgb(90, 90, 90);

            BackColor = backgroundColor;
            ForeColor = textColor;
            
            versionsGrid.BackgroundColor = panelColor;
            versionsGrid.GridColor = isDarkMode ? Color.FromArgb(65, 65, 70) : Color.FromArgb(220, 220, 220);
            versionsGrid.DefaultCellStyle.BackColor = panelColor;
            versionsGrid.DefaultCellStyle.ForeColor = textColor;
            versionsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 51, 102);
            versionsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            versionsGrid.ColumnHeadersDefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(45, 45, 50) : Color.FromArgb(244, 244, 244);
            versionsGrid.ColumnHeadersDefaultCellStyle.ForeColor = textColor;
            versionsGrid.EnableHeadersVisualStyles = false;
            
            platformSelector.BackColor = panelColor;
            platformSelector.ForeColor = textColor;
            
            statusLabel.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.FromArgb(245, 245, 245);
            statusLabel.ForeColor = secondaryTextColor;
        }

        private sealed class MentalityVersion
        {
            public MentalityVersion(string executableName, string localFileName, string size, string version, 
                string compatibility, string type, string description, string commit, string platform, bool downloadAvailable)
            {
                ExecutableName = executableName;
                LocalFileName = localFileName;
                Size = size;
                Version = version;
                Compatibility = compatibility;
                Type = type;
                Description = description;
                Commit = commit;
                Platform = platform;
                DownloadAvailable = downloadAvailable;
            }

            public string ExecutableName { get; private set; }
            public string LocalFileName { get; private set; } // New property maps straight to your physical files
            public string Size { get; private set; }
            public string Version { get; private set; }
            public string Compatibility { get; private set; }
            public string Type { get; private set; }
            public string Description { get; private set; }
            public string Commit { get; private set; }
            public string Platform { get; private set; }
            public bool DownloadAvailable { get; private set; }
        }
    }
}
