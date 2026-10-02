using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AppHub
{
    public partial class ToolPageForm : Form
    {
        private static readonly Uri ToolsBaseUri = new Uri("https://sensationalx.com/tools/", UriKind.Absolute);
        private Tool _tool;
        private bool isDarkMode;
        private Uri _toolUri;

        public ToolPageForm(Tool tool, bool darkMode = false)
        {
            if (tool == null)
                throw new ArgumentNullException("tool");

            SetBrowserEmulationMode();
            InitializeComponent();
            _tool = tool;
            isDarkMode = darkMode;
            this.Text = tool.Title;
            ConfigureBrowser();
            LoadToolPage();
        }

        private void ToolPageForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void LoadToolPage()
        {
            try
            {
                _toolUri = ResolveToolUri(_tool.Link);
                SetStatus("Loading " + _toolUri.AbsoluteUri + "...", false);
                webBrowser.Navigate(_toolUri);
            }
            catch (Exception ex)
            {
                ShowNavigationError("The tool page could not be opened: " + ex.Message);
            }
        }

        private static Uri ResolveToolUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
                throw new InvalidOperationException("This tool does not have a page URL.");

            Uri absoluteUri;
            if (Uri.TryCreate(link, UriKind.Absolute, out absoluteUri))
            {
                if (absoluteUri.Scheme != Uri.UriSchemeHttp && absoluteUri.Scheme != Uri.UriSchemeHttps)
                    throw new InvalidOperationException("The tool page URL must use HTTP or HTTPS.");

                return absoluteUri;
            }

            Uri resolvedUri = new Uri(ToolsBaseUri, link);
            if (resolvedUri.Scheme != Uri.UriSchemeHttp && resolvedUri.Scheme != Uri.UriSchemeHttps)
                throw new InvalidOperationException("The tool page URL must use HTTP or HTTPS.");

            return resolvedUri;
        }

        private void ConfigureBrowser()
        {
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.AllowNavigation = true;
            webBrowser.IsWebBrowserContextMenuEnabled = true;
            webBrowser.WebBrowserShortcutsEnabled = true;
            webBrowser.Navigating += WebBrowser_Navigating;
            webBrowser.Navigated += WebBrowser_Navigated;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private static void SetBrowserEmulationMode()
        {
            try
            {
                using (RegistryKey browserEmulationKey = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
                {
                    if (browserEmulationKey != null)
                    {
                        browserEmulationKey.SetValue(
                            Path.GetFileName(Application.ExecutablePath),
                            11001,
                            RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception)
            {
                // The browser can still run if the per-user emulation setting cannot be written.
            }
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            SetStatus("Loading " + e.Url.AbsoluteUri + "...", false);
        }

        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetStatus(e.Url.AbsoluteUri, false);
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (IsBrowserErrorPage())
                    ShowNavigationError("The embedded browser could not render this page.");
                else
                    SetStatus("Loaded", false);
            }
        }

        private bool IsBrowserErrorPage()
        {
            string documentTitle = webBrowser.DocumentTitle ?? string.Empty;
            return documentTitle.IndexOf("cannot find", StringComparison.OrdinalIgnoreCase) >= 0
                || documentTitle.IndexOf("navigation canceled", StringComparison.OrdinalIgnoreCase) >= 0
                || documentTitle.IndexOf("page cannot be displayed", StringComparison.OrdinalIgnoreCase) >= 0
                || documentTitle.IndexOf("internet explorer", StringComparison.OrdinalIgnoreCase) >= 0
                    && documentTitle.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void SetStatus(string message, bool isError)
        {
            statusPanel.Visible = true;
            statusPanel.BackColor = isError
                ? System.Drawing.Color.FromArgb(255, 235, 238)
                : (isDarkMode ? System.Drawing.Color.FromArgb(28, 28, 31) : System.Drawing.Color.FromArgb(245, 245, 245));
            statusLabel.ForeColor = isError
                ? System.Drawing.Color.FromArgb(180, 35, 55)
                : (isDarkMode ? System.Drawing.Color.FromArgb(210, 210, 210) : System.Drawing.Color.FromArgb(90, 90, 90));
            statusLabel.Text = message;
        }

        private void ShowNavigationError(string message)
        {
            SetStatus(message, true);
            retryButton.Visible = true;
            openInBrowserButton.Visible = true;
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            LoadToolPage();
        }

        private void OpenInBrowserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_toolUri == null)
                    _toolUri = ResolveToolUri(_tool.Link);

                Process.Start(new ProcessStartInfo(_toolUri.AbsoluteUri)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowNavigationError("The external browser could not be opened: " + ex.Message);
            }
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                this.BackColor = System.Drawing.Color.FromArgb(11, 11, 12);
                this.ForeColor = System.Drawing.Color.White;
                toolbarPanel.BackColor = System.Drawing.Color.FromArgb(28, 28, 31);
                retryButton.ForeColor = System.Drawing.Color.White;
                openInBrowserButton.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                this.ForeColor = System.Drawing.Color.Black;
                toolbarPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                retryButton.ForeColor = System.Drawing.Color.Black;
                openInBrowserButton.ForeColor = System.Drawing.Color.Black;
            }

            SetStatus(statusLabel.Text, false);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
                webBrowser.GoBack();
            else
                this.Close();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();
        }
    }
}
