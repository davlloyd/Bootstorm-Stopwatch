namespace BootStorm_Stopwatch
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bVCConnect = new System.Windows.Forms.Button();
            this.cClusters = new System.Windows.Forms.ComboBox();
            this.cDatastores = new System.Windows.Forms.ComboBox();
            this.lVMs = new System.Windows.Forms.ListView();
            this.lStatus = new System.Windows.Forms.Label();
            this.tStopwatch = new System.Windows.Forms.Timer(this.components);
            this.lTimer = new System.Windows.Forms.Label();
            this.bGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lVMCount = new System.Windows.Forms.Label();
            this.lResetCount = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.bReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lRespondCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // bVCConnect
            // 
            this.bVCConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bVCConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bVCConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVCConnect.Location = new System.Drawing.Point(35, 13);
            this.bVCConnect.Name = "bVCConnect";
            this.bVCConnect.Size = new System.Drawing.Size(132, 23);
            this.bVCConnect.TabIndex = 0;
            this.bVCConnect.Text = "vCenter Connect";
            this.bVCConnect.UseVisualStyleBackColor = false;
            this.bVCConnect.Click += new System.EventHandler(this.bVCConnect_Click);
            // 
            // cClusters
            // 
            this.cClusters.FormattingEnabled = true;
            this.cClusters.Location = new System.Drawing.Point(35, 66);
            this.cClusters.Name = "cClusters";
            this.cClusters.Size = new System.Drawing.Size(252, 21);
            this.cClusters.TabIndex = 2;
            this.cClusters.SelectedIndexChanged += new System.EventHandler(this.cClusters_SelectedIndexChanged);
            // 
            // cDatastores
            // 
            this.cDatastores.FormattingEnabled = true;
            this.cDatastores.Location = new System.Drawing.Point(348, 66);
            this.cDatastores.Name = "cDatastores";
            this.cDatastores.Size = new System.Drawing.Size(243, 21);
            this.cDatastores.TabIndex = 2;
            this.cDatastores.SelectedIndexChanged += new System.EventHandler(this.cDatastores_SelectedIndexChanged);
            // 
            // lVMs
            // 
            this.lVMs.Location = new System.Drawing.Point(35, 96);
            this.lVMs.Name = "lVMs";
            this.lVMs.Size = new System.Drawing.Size(556, 215);
            this.lVMs.TabIndex = 3;
            this.lVMs.UseCompatibleStateImageBehavior = false;
            this.lVMs.View = System.Windows.Forms.View.Details;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(13, 341);
            this.lStatus.Name = "lStatus";
            this.lStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lStatus.Size = new System.Drawing.Size(0, 13);
            this.lStatus.TabIndex = 4;
            // 
            // lTimer
            // 
            this.lTimer.AutoSize = true;
            this.lTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTimer.Location = new System.Drawing.Point(261, 11);
            this.lTimer.Name = "lTimer";
            this.lTimer.Size = new System.Drawing.Size(111, 29);
            this.lTimer.TabIndex = 5;
            this.lTimer.Text = "00:00:00";
            // 
            // bGo
            // 
            this.bGo.BackColor = System.Drawing.Color.LightGreen;
            this.bGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGo.Location = new System.Drawing.Point(204, 320);
            this.bGo.Name = "bGo";
            this.bGo.Size = new System.Drawing.Size(83, 23);
            this.bGo.TabIndex = 6;
            this.bGo.Text = "Go For It";
            this.bGo.UseVisualStyleBackColor = false;
            this.bGo.Click += new System.EventHandler(this.bGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "VMs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Tag = "Reset";
            this.label2.Text = "Reset";
            // 
            // lVMCount
            // 
            this.lVMCount.AutoSize = true;
            this.lVMCount.Location = new System.Drawing.Point(575, 10);
            this.lVMCount.Name = "lVMCount";
            this.lVMCount.Size = new System.Drawing.Size(13, 13);
            this.lVMCount.TabIndex = 9;
            this.lVMCount.Text = "0";
            // 
            // lResetCount
            // 
            this.lResetCount.AutoSize = true;
            this.lResetCount.Location = new System.Drawing.Point(575, 26);
            this.lResetCount.Name = "lResetCount";
            this.lResetCount.Size = new System.Drawing.Size(13, 13);
            this.lResetCount.TabIndex = 10;
            this.lResetCount.Text = "0";
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.Red;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(374, 320);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 12;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bReload
            // 
            this.bReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReload.Location = new System.Drawing.Point(293, 320);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(75, 23);
            this.bReload.TabIndex = 13;
            this.bReload.Text = "Reload";
            this.bReload.UseVisualStyleBackColor = false;
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Target Cluster";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Target Datastore";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Tag = "Reset";
            this.label5.Text = "Online";
            // 
            // lRespondCount
            // 
            this.lRespondCount.AutoSize = true;
            this.lRespondCount.Location = new System.Drawing.Point(575, 42);
            this.lRespondCount.Name = "lRespondCount";
            this.lRespondCount.Size = new System.Drawing.Size(13, 13);
            this.lRespondCount.TabIndex = 10;
            this.lRespondCount.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(204, 350);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(245, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 361);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bReload);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.lRespondCount);
            this.Controls.Add(this.lResetCount);
            this.Controls.Add(this.lVMCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bGo);
            this.Controls.Add(this.lTimer);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.lVMs);
            this.Controls.Add(this.cDatastores);
            this.Controls.Add(this.cClusters);
            this.Controls.Add(this.bVCConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BootStorm Timer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bVCConnect;
        private System.Windows.Forms.ComboBox cClusters;
        private System.Windows.Forms.ComboBox cDatastores;
        private System.Windows.Forms.ListView lVMs;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Timer tStopwatch;
        private System.Windows.Forms.Label lTimer;
        private System.Windows.Forms.Button bGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lVMCount;
        private System.Windows.Forms.Label lResetCount;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bReload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lRespondCount;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

