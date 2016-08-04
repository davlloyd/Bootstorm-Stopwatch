using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using VMware.Vim;
using System.Diagnostics;
using System.Threading;

namespace BootStorm_Stopwatch
{
    public partial class fMain : Form
    {
        VimClient _client = null;
        fVCConnect _vcstuff = null;
        fComplete _completebox = null;

        public fMain()
        {
            InitializeComponent();
        }

        public void Status(string message)
        {
            lStatus.Text = message;
            Application.DoEvents();
        }

        private void bVCConnect_Click(object sender, EventArgs e)
        {
            PositionChildForm(_vcstuff);
            if (_vcstuff == null)
                _vcstuff = new fVCConnect();
            _vcstuff.MainForm = this;
            _vcstuff.Client = _client;
            _vcstuff.Activate();
            _vcstuff.Visible = true;
        }

        public void put_PostConnect()
        {
            this.UseWaitCursor = true;
            if(_vcstuff.Connected)
                get_ClusterList();
            this.UseWaitCursor = false;
            Application.DoEvents();
        }

        private bool get_ClusterList()
        {
            cClusters.Enabled = true;
            cDatastores.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Status("Loading Cluster List");
            cClusters.Items.Clear();
            cClusters.Items.Add("--- Select Cluster ---");
            cClusters.SelectedIndex = 0;
            bool _return = true;
            try
            {
                SortedDictionary<string, string> _clist = new SortedDictionary<string, string>();
                NameValueCollection _filter = new NameValueCollection();
                IList<EntityViewBase> _clusterviews = _client.FindEntityViews(typeof(ClusterComputeResource), _client.ServiceContent.RootFolder, _filter, null);

                foreach (ClusterComputeResource _cluster in _clusterviews)
                    _clist.Add(_cluster.Name, _cluster.Name);

                foreach(string _item in _clist.Values)
                    cClusters.Items.Add(_item);
            }
            catch (Exception _x)
            {
                Debug.WriteLine("Stuffed:/t" + _x.Message, "Query");
                _return = false;
            }
            Debug.WriteLine("Listed", "Clusters");
            Status("Cluster List Loaded");
            this.Cursor = Cursors.Default;
            return _return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cClusters.Enabled = false;
            cDatastores.Enabled = false;
            _client = new VimClient();
            _client.ServiceTimeout = 600000;
            _vcstuff = new fVCConnect();
            lVMs.Columns.Add("VM");
            lVMs.Columns.Add("State");
            lVMs.Columns.Add("Tools");
            lVMs.Columns.Add("Done");
            lVMs.Columns[0].Width = 120;
            lVMs.Columns[1].Width = 120;
            lVMs.Columns[2].Width = 120;
            lVMs.Columns[3].Width = 120;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //_client.Logout();
            try
            {
                _client.Disconnect();
                _client = null;
            }
            catch
            { }
            Debug.WriteLine("Cleaned UP", "End");
        }

        private void cClusters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_client.ServiceContent != null)
                get_DatastoreList();
            else
            {
                MessageBox.Show("Session disconnected, reconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cClusters.Items.Clear();
                cDatastores.Items.Clear();
                lVMs.Items.Clear();
            }
        }

        public void get_DatastoreList()
        {
            if (cClusters.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Status("Loading Datastore List");
                cDatastores.Enabled = true;
                cDatastores.Items.Clear();
                cDatastores.Items.Add("--- Select Datastore ---");
                cDatastores.SelectedIndex = 0;
                NameValueCollection _filter = new NameValueCollection();
                _filter.Add("Name", cClusters.Text);
                IList<EntityViewBase> _clusterviews = _client.FindEntityViews(typeof(ClusterComputeResource), _client.ServiceContent.RootFolder, _filter, null);
                if (_clusterviews != null)
                {
                    SortedDictionary<string, string> _dslist = new SortedDictionary<string, string>();
                    ClusterComputeResource _cluster = (ClusterComputeResource)_clusterviews[0];
                    foreach (ManagedObjectReference _dsref in _cluster.Datastore)
                    {
                        Datastore _ds = (Datastore)_client.GetView(_dsref, null);
                        _dslist.Add(_ds.Name, _ds.Name);
                    }
                    foreach (string _entry in _dslist.Values)
                        cDatastores.Items.Add(_entry);
                }
                Debug.WriteLine("listed", "datastores");
                this.Cursor = Cursors.Default;
                Status("Datastore List Loaded");
            }
        }

        private void cDatastores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_client.ServiceContent != null)
                this.get_VMList();
            else
            {
                MessageBox.Show("Session disconnected, reconnect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cClusters.Items.Clear();
                cDatastores.Items.Clear();
                lVMs.Items.Clear();
            }
        }

        public void get_VMList()
        {
            lVMCount.Text = "0";
            lVMs.Items.Clear();
            if (cDatastores.SelectedIndex > 0)
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = 0;
                this.Cursor = Cursors.WaitCursor;
                Status("Loading VMs Commenced");
                lVMs.Items.Clear();
                NameValueCollection _filter = new NameValueCollection();
                _filter.Add("Name", cDatastores.Text);
                IList<EntityViewBase> _dsviews = _client.FindEntityViews(typeof(Datastore), _client.ServiceContent.RootFolder, _filter, null);
                Datastore _ds = (Datastore)_dsviews[0];
                int i = 0;
                foreach (ManagedObjectReference _vmref in _ds.Vm)
                {
                    ListViewItem _item = null;
                    VirtualMachine _vm = (VirtualMachine)_client.GetView(_vmref, null);
                    if (_vm.Guest.ToolsRunningStatus == "guestToolsRunning")
                    {
                        i = int.Parse(lVMCount.Text) + 1;
                        lVMCount.Text = i.ToString();
                        progressBar1.Maximum++;
                        _item = new ListViewItem(new string[] { _vm.Name, _vm.Runtime.PowerState.ToString(), _vm.Guest.ToolsRunningStatus, "Discovered" });
                    }
                    else 
                        _item = new ListViewItem(new string[] { _vm.Name, _vm.Runtime.PowerState.ToString(), _vm.Guest.ToolsRunningStatus, "Excluded" });
                    ListViewItem _lvi = lVMs.Items.Add(_item);
                    Application.DoEvents();
                }
                this.Cursor = Cursors.Default;
                Status("Loading VMs finished");
            }
        }

        public VimClient Client { set { _client = value; } }

        private void bGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lVMs.Items.Count > 0)
            {
                Status("Generating Storm");
                Stopwatch _watch = new Stopwatch();
                _watch.Start();
                lTimer.Text = "00:00:00";
                bool _completed = false;
                int _run = 1;
                NameValueCollection _filter = new NameValueCollection();
                lResetCount.Text = "0";
                lRespondCount.Text = "0";
                int i = 0;
                int r = 0;
                while (!_completed)
                {
                    _completed = true;
                    foreach (ListViewItem _listitem in lVMs.Items)
                    {
                        try
                        {
                            if (_listitem.SubItems[1].Text == "poweredOn")
                            {

                                if ((_listitem.SubItems[3].Text != "Complete") && (_listitem.SubItems[3].Text != "Failed"))
                                {
                                    IList<EntityViewBase> _vmview = null;
                                    _completed = false;
                                    _filter.Clear();
                                    _filter.Add("Name", _listitem.SubItems[0].Text);
                                    lTimer.Text = _watch.Elapsed.Hours.ToString().PadLeft(2, '0') + ":" + _watch.Elapsed.Minutes.ToString().PadLeft(2, '0') + ":" + _watch.Elapsed.Seconds.ToString().PadLeft(2, '0');
                                    Application.DoEvents();
                                    try
                                    {
                                        _vmview = _client.FindEntityViews(typeof(VirtualMachine), _client.ServiceContent.RootFolder, _filter, null);
                                    }
                                    catch(Exception _x)
                                    {
                                        Debug.WriteLine(_x);
                                    }
                                    if (_vmview != null)
                                    {
                                        VirtualMachine _vm = (VirtualMachine)_vmview[0];
                                        if (_run == 1)
                                        {
                                            Status("Reseting " + _listitem.SubItems[0].Text);
                                            try
                                            {
                                                i = int.Parse(lResetCount.Text) + 1;
                                                lResetCount.Text = i.ToString();
                                                _vm.ResetVM_Task();
                                                _listitem.SubItems[2].Text = "Gone";
                                                _listitem.SubItems[3].Text = "Reset";
                                                Application.DoEvents();

                                            }
                                            catch(Exception _x)
                                            {
                                                Debug.WriteLine(_x);
                                                _listitem.SubItems[3].Text = "Failed";
                                                Application.DoEvents();
                                            }
                                        }
                                        else
                                        {
                                            Status("Checking " + _listitem.SubItems[0].Text);
                                            try
                                            {
                                                if ((_vm.Guest.ToolsRunningStatus == "guestToolsRunning") && (_vm.RecentTask != null))
                                                {
                                                    Task _task = (Task)_client.GetView(_vm.RecentTask[0], null);
                                                    if (_task.Info.State == TaskInfoState.success)
                                                    {
                                                        r++;
                                                        if (r <= progressBar1.Maximum)
                                                            progressBar1.Value = r;
                                                        lRespondCount.Text = r.ToString();
                                                        _listitem.SubItems[2].Text = "guestToolsRunning";
                                                        _listitem.SubItems[3].Text = "Complete";
                                                        Application.DoEvents();
                                                    }
                                                }
                                            }
                                            catch (Exception _x)
                                            {
                                                Debug.WriteLine(_x);
                                            }
                                        }
                                    }
                                }
                            }
                            lTimer.Text = _watch.Elapsed.Hours.ToString().PadLeft(2, '0') + ":" + _watch.Elapsed.Minutes.ToString().PadLeft(2, '0') + ":" + _watch.Elapsed.Seconds.ToString().PadLeft(2, '0');
                            Application.DoEvents();
                        }
                        catch(Exception _x)
                        {
                            Debug.WriteLine(_x);
                        }
                    }
                    Status("Validating Guests State");
                    _run++;

                }
                this.Done = true;
                this.Cursor = Cursors.Default;
                Status("All guests back online");
                _watch.Stop();
                _completebox = new fComplete();
                PositionChildForm(_completebox);
                _completebox.TimeCompleted = lTimer.Text;
                _completebox.LUNName = cDatastores.Text;
                //_completebox.Location = lVMs.Location.ToString();
                _completebox.Visible = true;
                _completebox.Activate();
                //MessageBox.Show("Time to complete: " + lTimer.Text, cDatastores.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Default;
        }

            /// </summary>
        private void PositionChildForm(Form _form)
        {
	        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
	        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

	        Point parentPoint = this.Location;

	        int parentHeight = this.Height;
	        int parentWidth = this.Width;

	        int childHeight = _form.Height;
	        int childWidth = _form.Width;

	        int resultX;
	        int resultY;

	        // If we would move off the screen, position near the top.
	        resultY = parentPoint.Y + 50; // move down 50
	        resultX = parentPoint.X + 20;

	        // set our child form to the new position
	        _form.Location = new Point(resultX, resultY);
        }

        public bool Done { get; set; }
        public System.Windows.Forms.Timer Stopwatch { get { return tStopwatch; } }
        public Label TimeDisplay { get { return lTimer; } }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bReload_Click(object sender, EventArgs e)
        {
            if(_vcstuff.Reconnect())
                this.get_VMList();
            else
                MessageBox.Show("Reconnec to vCenter Failed","Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class VMThread : IDisposable
    {
        NameValueCollection _filter = null;
        VimClient _client = null;
        ListViewItem _listitem = null;

        public VMThread(VimClient client, NameValueCollection filter, ListViewItem listitem)
        {
            _filter = filter;
            _client = client;
            _listitem = listitem;
        }

        public void Reset()
        {
            IList<EntityViewBase> _vmview = _client.FindEntityViews(typeof(VirtualMachine), _client.ServiceContent.RootFolder, _filter, null);
            if (_vmview != null)
            {
                VirtualMachine _vm = (VirtualMachine)_vmview[0];
                try
                {
                    _vm.ResetVM_Task();
                    _listitem.SubItems[2].Text = _vm.Guest.ToolsRunningStatus;
                    _listitem.SubItems[3].Text = "Reset";
                    Application.DoEvents();

                }
                catch
                {
                    _listitem.SubItems[3].Text = "Failed";
                    Application.DoEvents();
                }
            }
        }

        public void Review()
        {
            IList<EntityViewBase> _vmview = _client.FindEntityViews(typeof(VirtualMachine), _client.ServiceContent.RootFolder, _filter, null);
            if (_vmview != null)
            {
                VirtualMachine _vm = (VirtualMachine)_vmview[0];
                if (_vm.Guest.ToolsRunningStatus == "guestToolsRunning")
                {
                    _listitem.SubItems[2].Text = "guestToolsRunning";
                    _listitem.SubItems[3].Text = "Complete";
                    Application.DoEvents();
                }
            }
        }


        public void Dispose()
        {
        }
    }
}
