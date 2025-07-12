using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estore.Ce.Services;
using Estore.Ce.Helpers;

namespace Estore.Ce.UI
{
    public partial class SynchronizeForm : Form
    {
        private ISyncManager _syncManager;

        public SynchronizeForm()
        {
            InitializeComponent();

            InitializeService();

            // Subscribe to the StatusUpdated event
            _syncManager.StatusUpdated += UpdateStatusBar;
            _syncManager.RecordUpdated += UpdateProgressBar;
        }

        private void InitializeService()
        {
            _syncManager = new SyncManager();
        }

        private void UpdateStatusBar(string status)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => labelMessage.Text = status));
            }
            else
            {
                labelMessage.Text = status;
            }
        }

        private void UpdateProgressBar(int recordsFound, int recordsUpdated)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() =>
                {
                    progressBar.Maximum = recordsFound;
                    progressBar.Value = recordsUpdated;
                }));
            }
            else
            {
                progressBar.Maximum = recordsFound;
                progressBar.Value = recordsUpdated;
            }
        }

        private void synchronizeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you want to sync?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (!NetworkHelper.IsConnectedToServer())
                    {
                        MessageBox.Show("No connection. Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    synchronizeButton.Enabled = false;
                    panel1.Visible = false;
                    panel2.Visible = true;
                    pictureBox.Visible = true;
                    labelMessage.Text = "Sync in progress ...";
                    Application.DoEvents();

                    _syncManager.SyncAll();

                    pictureBox.Image = Resource.success;

                    MessageBox.Show("Sync completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    synchronizeButton.Enabled = true;
                }
            }
        }
    }
}