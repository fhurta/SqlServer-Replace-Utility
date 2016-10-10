using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SqlDbNameReplace
{
    public partial class Form1 : Form
    {
        private Server SqlServerSelection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var orig = tbOrigString.Text;
            var replacement = tbNewString.Text;

            var db = (Database)DatabasesComboBox.SelectedItem;

            foreach (var dbView in db.Views.OfType<Microsoft.SqlServer.Management.Smo.View>())
            {
                var str = dbView.TextBody;
                if (str.Contains(orig))
                {
                    Debug.WriteLine("V: " + dbView.Name);
                    var updated = str.Replace(orig, replacement);
                    dbView.TextBody = updated;
                    dbView.Alter();
                }
            }

            foreach (var sp in db.StoredProcedures.OfType<StoredProcedure>().Where(o => !o.IsSystemObject))
            {
                var str = sp.TextBody;
                if (str.Contains(orig))
                {
                    Debug.WriteLine("SP: " + sp.Name);
                    var updated = str.Replace(orig, replacement);
                    sp.TextBody = updated;
                    sp.Alter();
                }
            }

            foreach (var udf in db.UserDefinedFunctions.OfType<UserDefinedFunction>().Where(o => !o.IsSystemObject))
            {
                var str = udf.TextBody;
                if (str.Contains(orig))
                {
                    Debug.WriteLine("UDF: " + udf.Name);
                    var updated = str.Replace(orig, replacement);
                    udf.TextBody = updated;
                    udf.Alter();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the main window first
            Show();
            Application.DoEvents();

            var serverConn = new ServerConnection();
            var scForm = new ServerConnect.ServerConnect(serverConn);
            var dr = scForm.ShowDialog(this);
            if ((dr == DialogResult.OK) &&
                (serverConn.SqlConnectionObject.State == ConnectionState.Open))
            {
                SqlServerSelection = new Server(serverConn);
                if (SqlServerSelection != null)
                {
                    Text = SqlServerSelection.Name;

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
            if (SqlServerSelection?.ConnectionContext.SqlConnectionObject.State == ConnectionState.Open)
            {
                SqlServerSelection.ConnectionContext.Disconnect();
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
                SqlServerSelection.SetDefaultInitFields(typeof(Database), "Name", "IsSystemObject", "IsAccessible");

                // Add database object to combobox; the default ToString will display the database name
                foreach (Database db in SqlServerSelection.Databases)
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
    }
}