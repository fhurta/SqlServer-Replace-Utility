using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SqlDbNameReplace
{
    public partial class Form1 : Form
    {
        private Server _sqlServerSelection;

        public Form1()
        {
            DoutLn($"x {DateTime.Now:O}");
            InitializeComponent();
            Out("Enumerating servers, please wait..");
        }

        private static void DoutLn(string s)
        {
            Debug.WriteLine(s);
        }

        private void Out(string s)
        {
            Debug.WriteLine(s);
            if (tbOut.InvokeRequired)
            {
                tbOut.Invoke(new Action(() => OuptutText(s)));
            }
            else
            {
                OuptutText(s);
            }
        }

        private void OuptutText(string s)
        {
            tbOut.Text += s + Environment.NewLine;
            tbOut.SelectionStart = tbOut.Text.Length;
            tbOut.ScrollToCaret();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            await SearchOrReplace(false);
        }

        private async Task SearchOrReplace(bool searchOnly)
        {
            var orig = tbOrigString.Text;
            var replacement = tbNewString.Text;

            var db = (Database)DatabasesComboBox.SelectedItem;
            Out($"Database: {db.Name}");

            var opts = RegexOptions.CultureInvariant | RegexOptions.Compiled;
            if (chbIgnoreCase.Checked)
            {
                opts |= RegexOptions.IgnoreCase;
            }
            var expr = chbWholeWord.Checked ? $"(?<Key>\\b{orig}\\b)" : $"(?<Key>{orig})";
            var regex = new Regex(expr, opts);

            await DbHelper.ScanAndReplaceAsync(db, regex, replacement, Out, searchOnly);

            Out("Finished");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Display the main window first
            Show();
            Application.DoEvents();

            var serverConn = new ServerConnection();
            var scForm = new ServerConnect.ServerConnect(serverConn);
            Out("OK. Choose server..");

            var dr = scForm.ShowDialog(this); //TODO: this takes quite long
            if (dr == DialogResult.OK && serverConn.SqlConnectionObject.State == ConnectionState.Open)
            {
                Out("Now choose database..");
                _sqlServerSelection = new Server(serverConn);
                if (_sqlServerSelection != null)
                {
                    Text = _sqlServerSelection.Name;

                    // Refresh database list
                    ShowDatabases(true);
                }
            }
            else
            {
                Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_sqlServerSelection?.ConnectionContext.SqlConnectionObject.State == ConnectionState.Open)
            {
                _sqlServerSelection.ConnectionContext.Disconnect();
            }
        }

        private void ShowDatabases(bool selectDefault)
        {
            // Show the current databases on the server
            Cursor csr = null;

            try
            {
                csr = Cursor; // Save the old cursor
                Cursor = Cursors.WaitCursor; // Display the waiting cursor

                // Clear control
                DatabasesComboBox.Items.Clear();

                // Limit the properties returned to just those that we use
                _sqlServerSelection.SetDefaultInitFields(typeof(Database), "Name", "IsSystemObject", "IsAccessible");

                // Add database object to combobox; the default ToString will display the database name
                foreach (Database db in _sqlServerSelection.Databases)
                {
                    if (!db.IsSystemObject && db.IsAccessible)
                    {
                        DatabasesComboBox.Items.Add(db);
                    }
                }

                if (selectDefault && (DatabasesComboBox.Items.Count > 0))
                {
                    DatabasesComboBox.SelectedIndex = 0;
                }
            }
            catch (SmoException ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
            finally
            {
                Cursor = csr; // Restore the original cursor
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await SearchOrReplace(true);
        }
    }
}