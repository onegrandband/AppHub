using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppHub
{
    public partial class Form1 : Form
    {
        private List<Tool> allTools = new List<Tool>();
        private bool isDarkMode = false;
        private readonly string searchPlaceholder = "Search tools (e.g., audio, text, image, flashlight, blues)...";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            InitializeTools();

            // Set up placeholder text behavior
            searchTextBox.Text = searchPlaceholder;
            searchTextBox.ForeColor = Color.FromArgb(169, 169, 169);
            
            searchTextBox.Leave += (s, evt) => 
            {
                if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                {
                    searchTextBox.Text = searchPlaceholder;
                    searchTextBox.ForeColor = Color.FromArgb(169, 169, 169);
                }
            };
            
            searchTextBox.Enter += (s, evt) => 
            {
                if (searchTextBox.Text == searchPlaceholder)
                {
                    searchTextBox.Text = "";
                    searchTextBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
            };

            RefreshToolsDisplay();
        }

        private void LoadTheme()
        {
            // Now using the boolean type we established in the Settings file
            isDarkMode = Properties.Settings.Default.DarkMode;
            ApplyTheme();
        }

        private void InitializeTools()
        {
            allTools = new List<Tool>
            {
                new Tool("Bath Reminder (NEW)", "Set reminders and timers for your bath routine and relaxation.", "🛁", "../tools/bath-reminder/"),
                new Tool("AI Blues", "Generate classic, soulful blues backing tracks and audio jams.", "💿", "../tools/blues/"),
                new Tool("Generator AI (Blues)", "Advanced AI composition engine tailored for blues music generation.", "✨", "../tools/blues-song-generator"),
                new Tool("SensationalX Audio Editor (NEW!)", "Edit waveforms, trim tracks, and apply audio processing effortlessly.", "🎚", "../tools/audio-editor"),
                new Tool("AI Pop Song Generator", "Generate fast and ready-to-go pop beats with AI.", "🎤", "../tools/pop-song-generator.html"),
                new Tool("AI Rock Beat Generator", "Generate fast and ready-to-go rock beats with AI.", "🎸", "../tools/rock-song-generator.html"),
                new Tool("Cooking Calculator", "Convert cups, teaspoons, tablespoons, and fluid volumes.", "⚖", "../tools/measurement-cooking-calc.html"),
                new Tool("CRESCENDO", "Music theory learner!", "🎵", "../tools/crescendo"),
                new Tool("Downloader", "Audio previewing and batch download center.", "⬇", "../tools/downloader.html"),
                new Tool("Calculator", "Calculate math instantly with precision.", "🧮", "../tools/calculator.html"),
                new Tool("Tempo Tapper", "Calculate BPM and track timing precisely.", "🖱", "../tools/tempo-tapper.html"),
                new Tool("Size Estimator", "Estimate audio size before exporting.", "💾", "../tools/size-estimator.html"),
                new Tool("Siesta", "Sleep timer for calculating time of sleep.", "🌙", "../tools/siesta/"),
                new Tool("Metronome", "Customizable click-track and rhythm guide.", "🔔", "../tools/metronome.html"),
                new Tool("4CHOOSE", "Generate headlines, price ROI, build with an HTML checklist, and manage SEO.", "🎲", "../tools/4ChooseTools.html"),
                new Tool("Video Recorder", "Record videos.", "🎥", "../tools/video-recorder"),
                new Tool("Audio Recorder", "Record audio.", "🎙", "../tools/audio-recorder"),
                new Tool("Chord Progression Generator", "Create chord progressions ;)", "🎼", "../tools/chord-generator.html"),
                new Tool("Delay Calculator", "Convert BPM to milliseconds for reverb & delay.", "⏱", "../tools/delay-calculator.html"),
                new Tool("Aspect Ratio Calculator", "Calculate dimensions for videos and covers.", "🎞", "../tools/aspect-ratio.html"),
                new Tool("Tone Generator", "Generate pure sine waves for audio testing.", "〰", "../tools/tone-generator.htm"),
                new Tool("Word Counter", "Count characters and words for metadata.", "📝", "../tools/word-counter.html"),
                new Tool("AI Beat Generator", "Generate fast and ready-to-go beats with AI.", "🥁", "../tools/ai-beat-generator.html"),
                new Tool("Hyperpop Beat Generator", "Generate hyperpop beats with AI.", "⚡", "../tools/hyperpop-song-generator.html"),
                new Tool("AI Digicore Beat Generator", "Generate fast and ready-to-go digicore beats with AI.", "💻", "../tools/digicorebeatgen.html"),
                new Tool("K-Pop Beat Generator", "Generate energetic K-Pop style beats.", "✨", "../tools/kpop-beat-generator.html"),
                new Tool("Cutecore Beat Generator", "Generate cutecore and ready-to-go beats with AI.", "💖", "../tools/cutecore-generator.html"),
                new Tool("Palette Generator", "Generate complimentary hex codes instantly.", "🎨", "../tools/color-palette.html"),
                new Tool("Base64 Encoder", "Convert images to raw code for web dev.", "🔢", "../tools/img-base64-encoder.html"),
                new Tool("Lorem Ipsum", "Generate placeholder text for design drafts.", "📄", "../tools/lorem-ipsum.html"),
                new Tool("Secure Key Generator", "Create strong passwords and API keys.", "🔑", "../tools/password-gen.html"),
                new Tool("Case Converter", "Format text instantly (UPPER, lower, etc).", "🔤", "../tools/case-converter.html"),
                new Tool("Mentality", "Very fast, and rapid autoclicker. Only supports Windows though.", "🖱", "../tools/mentality")
            };
        }

        private void RefreshToolsDisplay()
        {
            string searchQuery = searchTextBox.Text.ToLower();

            // Ignore placeholder text
            if (searchQuery == searchPlaceholder.ToLower())
                searchQuery = "";

            // Use safe fallback in case sortComboBox is not initialized yet
            string sortOrder = (sortComboBox.SelectedIndex <= 0) ? "az" : "za";

            // Filter
            var filteredTools = allTools.Where(t =>
                t.Title.ToLower().Contains(searchQuery) ||
                t.Description.ToLower().Contains(searchQuery)
            ).ToList();

            // Sort
            if (sortOrder == "az")
                filteredTools = filteredTools.OrderBy(t => t.Title).ToList();
            else
                filteredTools = filteredTools.OrderByDescending(t => t.Title).ToList();

            // CRITICAL FIX: Dispose old cards to prevent Memory and GDI handle leaks
            foreach (Control control in toolsFlowLayoutPanel.Controls)
            {
                control.Dispose(); 
            }
            toolsFlowLayoutPanel.Controls.Clear();

            // Show/hide no results
            if (filteredTools.Count == 0)
            {
                toolsFlowLayoutPanel.Visible = false;
                noResultsPanel.Visible = true;
            }
            else
            {
                toolsFlowLayoutPanel.Visible = true;
                noResultsPanel.Visible = false;

                // Add tool cards
                toolsFlowLayoutPanel.SuspendLayout(); // Prevents UI flicker while drawing many cards
                foreach (var tool in filteredTools)
                {
                    ToolCard card = new ToolCard(tool, isDarkMode)
                    {
                        Margin = new Padding(6)
                    };
                    card.ToolClicked += (s, evt) =>
                    {
                        ToolCard clickedCard = s as ToolCard;
                        if (clickedCard != null)
                        {
                            Tool selectedTool = clickedCard.GetTool();
                            if (string.Equals(selectedTool.Title, "Mentality", StringComparison.OrdinalIgnoreCase))
                            {
                                using (MentalityForm mentalityForm = new MentalityForm(clickedCard.IsDarkMode))
                                {
                                    mentalityForm.ShowDialog(this);
                                }
                            }
                            else
                            {
                                using (ToolPageForm toolPageForm = new ToolPageForm(selectedTool, clickedCard.IsDarkMode))
                                {
                                    toolPageForm.ShowDialog(this);
                                }
                            }
                        }
                    };
                    toolsFlowLayoutPanel.Controls.Add(card);
                }
                toolsFlowLayoutPanel.ResumeLayout();
            }
        }

        private void ApplyTheme()
        {
            Color bgColor = isDarkMode ? Color.FromArgb(11, 11, 12) : Color.FromArgb(245, 245, 245);
            Color headerBg = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            Color textColor = isDarkMode ? Color.White : Color.Black;

            this.BackColor = bgColor;
            headerPanel.BackColor = headerBg;
            searchPanel.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.FromArgb(245, 245, 245);
            mainPanel.BackColor = bgColor;

            logoLabel.ForeColor = textColor;
            homeBtn.ForeColor = isDarkMode ? Color.FromArgb(153, 153, 153) : Color.FromArgb(128, 128, 128);
            communityBtn.ForeColor = isDarkMode ? Color.FromArgb(153, 153, 153) : Color.FromArgb(128, 128, 128);
            
            themeToggleBtn.ForeColor = isDarkMode ? Color.FromArgb(153, 153, 153) : Color.FromArgb(128, 128, 128);
            themeToggleBtn.Text = isDarkMode ? "☀" : "🌙";

            searchTextBox.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            
            // Protect placeholder text color from turning solid black/white on theme change
            if (searchTextBox.Text == searchPlaceholder)
            {
                searchTextBox.ForeColor = Color.FromArgb(169, 169, 169);
            }
            else
            {
                searchTextBox.ForeColor = textColor;
            }

            sortComboBox.BackColor = isDarkMode ? Color.FromArgb(28, 28, 31) : Color.White;
            sortComboBox.ForeColor = textColor;

            noResultsLabel.ForeColor = isDarkMode ? Color.FromArgb(153, 153, 153) : Color.FromArgb(100, 100, 100);
            noResultsIconLabel.ForeColor = isDarkMode ? Color.FromArgb(80, 80, 80) : Color.FromArgb(200, 200, 200);

            // Refresh cards with new theme
            RefreshToolsDisplay();

            // Save theme preference directly as a boolean
            Properties.Settings.Default.DarkMode = isDarkMode;
            Properties.Settings.Default.Save();
        }

        private void ThemeToggleBtn_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ignore placeholder text
            if (searchTextBox.Text == searchPlaceholder)
                return;
            
            RefreshToolsDisplay();
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshToolsDisplay();
        }
    }
}
