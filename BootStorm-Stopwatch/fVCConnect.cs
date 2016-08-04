using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMware.Vim;

namespace BootStorm_Stopwatch
{
    public partial class fVCConnect : Form
    {
        bool _connected =false;
        VimClient _client = null;
        fMain _mainform = null;

        public fVCConnect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ConnectToVC(false);
        }

        private bool ConnectToVC(bool _remotecall)
        {
            bool _ret = false;
            this.Cursor = Cursors.WaitCursor;
            if ((tVCName.Text.Length > 0) && (tAccount.Text.Length > 0))
            {
                string _vcurl = "https://" + tVCName.Text + "/sdk";

                try
                {
                    _client.Connect(_vcurl);
                    _client.ServiceTimeout = 999999;
                    UserSession _session = _client.Login(tAccount.Text, tPassword.Text);
                    if (_session.LoginTime != null)
                    {
                        _connected = true;
                        _mainform.Visible = true;
                        _mainform.Status("vCenter connected");
                        _mainform.Activate();
                        _mainform.Client = _client;
                        this.Visible = false;
                        _mainform.put_PostConnect();
                        _ret = true;
                    }
                    else
                    {
                        if (!_remotecall)
                        {
                            DialogResult _result = MessageBox.Show("Connection Failed", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (_result == DialogResult.Cancel)
                                Application.Exit();
                        }
                    }
                }
                catch
                {
                    if (!_remotecall)
                    {
                        this.Cursor = Cursors.Default;
                        DialogResult _result = MessageBox.Show("Connection Failed to " + tVCName.TextAlign, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (_result == DialogResult.Cancel)
                            Application.Exit();
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                if(!_remotecall)
                    MessageBox.Show("Please Enter Details", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _ret;
        }

        public VimClient Client
        { 
            get { return _client; }
            set { _client = value;}
        }

        public bool Reconnect()
        {
            return this.ConnectToVC(true);
        }

        public fMain MainForm { set { _mainform = value; } }

        public bool Connected { get { return _connected; } }

        private void fVCConnect_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            _mainform.Visible = true;
            _mainform.Activate();
            this.Visible = false;
        }

        private void fVCConnect_Load(object sender, EventArgs e)
        {

        }
    }
}
