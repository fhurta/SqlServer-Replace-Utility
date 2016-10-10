using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace ServerConnect
{
    public partial class ServerConnect : Form
    {
        private ServerConnection _serverConn;
        private bool _errorFlag;

        public ServerConnect(ServerConnection serverConn)
        {
            _serverConn = serverConn;
            InitializeComponent();
        }

        private void ServerConnect_Load(object sender, EventArgs e)
        {
            GetServerList();
            ProcessWindowsAuthentication();
        }

        private void ServerConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_errorFlag)
            {
                e.Cancel = true;
            }

            // Reset error condition
            _errorFlag = false;
        }

        private void WindowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ProcessWindowsAuthentication();
        }

        private void CancelCommandButton_Click(object sender, EventArgs e)
        {
            _serverConn = null;
            Close();
        }

        private void ConnectCommandButton_Click(object sender, EventArgs e)
        {
            Cursor csr = null;

            try
            {
                csr = Cursor; // Save the old cursor
                Cursor = Cursors.WaitCursor; // Display the waiting cursor

                _errorFlag = false; // Assume no error

                // Recreate connection if necessary
                if (_serverConn == null)
                {
                    _serverConn = new ServerConnection();
                }

                // Fill in necessary information
                _serverConn.ServerInstance = ServerNamesComboBox.Text;

                // Setup capture and execute to be able to display script
                _serverConn.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql;

                // Set connection timeout
                _serverConn.ConnectTimeout = (int)TimeoutUpDown.Value;
                if (WindowsAuthenticationRadioButton.Checked)
                {
                    // Use Windows authentication
                    _serverConn.LoginSecure = true;
                }
                else
                {
                    // Use SQL Server authentication
                    _serverConn.LoginSecure = false;
                    _serverConn.Login = UserNameTextBox.Text;
                    _serverConn.Password = PasswordTextBox.Text;
                }

                if (DisplayEventsCheckBox.CheckState == CheckState.Checked)
                {
                    _serverConn.InfoMessage += OnSqlInfoMessage;
                    _serverConn.ServerMessage += OnServerMessage;
                    _serverConn.SqlConnectionObject.StateChange += OnStateChange;
                    _serverConn.StatementExecuted += OnStatementExecuted;
                }

                // Go ahead and connect
                _serverConn.Connect();
            }
            catch (ConnectionFailureException ex)
            {
                MessageBox.Show(this, ex.ToString());
                _errorFlag = true;
            }
            catch (SmoException ex)
            {
                MessageBox.Show(this, ex.ToString());
                _errorFlag = true;
            }
            finally
            {
                Cursor = csr; // Restore the original cursor
            }
        }

        private void GetServerList()
        {
            // Set local server as default
            var dt = SmoApplication.EnumAvailableSqlServers(false);
            if (dt.Rows.Count > 0)
            {
                // Load server names into combo box
                foreach (DataRow dr in dt.Rows)
                {
                    ServerNamesComboBox.Items.Add(dr["Name"]);
                }

                // Default to this machine 
                ServerNamesComboBox.SelectedIndex = ServerNamesComboBox.FindStringExact(Environment.MachineName);

                // If this machine is not a SQL server 
                // then select the first server in the list
                if (ServerNamesComboBox.SelectedIndex < 0)
                {
                    ServerNamesComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(this, Properties.Resources.NoSqlServers);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProcessWindowsAuthentication()
        {
            if (WindowsAuthenticationRadioButton.Checked)
            {
                UserNameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
            }
            else
            {
                UserNameTextBox.Enabled = true;
                PasswordTextBox.Enabled = true;
            }
        }

        private void OnSqlInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            foreach (SqlError err in args.Errors)
            {
                MessageBox.Show(this,
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        Properties.Resources.SqlError,
                        err.Source, err.Class, err.State, err.Number, err.LineNumber,
                        err.Procedure, err.Server, err.Message));
            }
        }

        private void OnServerMessage(object sender, ServerMessageEventArgs args)
        {
            var err = args.Error;

            MessageBox.Show(this,
                string.Format(
                    System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.SqlError,
                    err.Source, err.Class, err.State, err.Number, err.LineNumber,
                    err.Procedure, err.Server, err.Message));
        }

        private void OnStateChange(object sender, StateChangeEventArgs args)
        {
            if (IsDisposed == false)
            {
                MessageBox.Show(this,
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        Properties.Resources.StateChanged,
                        args.OriginalState.ToString(), args.CurrentState.ToString()));
            }
        }

        private void OnStatementExecuted(object sender, StatementEventArgs args)
        {
            MessageBox.Show(this, args.SqlStatement);
        }
    }
}