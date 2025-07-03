namespace Estore.Ce
{
    partial class PreStockReceiptListForm
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.grdItems = new System.Windows.Forms.DataGrid();
            this.barcode1 = new Barcode.Barcode();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.ForestGreen;
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(158, 231);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(157, 35);
            this.btnContinue.TabIndex = 11;
            this.btnContinue.Text = "Continue >>>";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.grdItems.BackgroundColor = System.Drawing.SystemColors.Info;
            this.grdItems.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.grdItems.HeaderForeColor = System.Drawing.Color.White;
            this.grdItems.Location = new System.Drawing.Point(3, 3);
            this.grdItems.Name = "grdItems";
            this.grdItems.SelectionBackColor = System.Drawing.Color.White;
            this.grdItems.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItems.Size = new System.Drawing.Size(312, 222);
            this.grdItems.TabIndex = 10;
            this.grdItems.Click += new System.EventHandler(this.grdItems_Click);
            // 
            // barcode1
            // 
            this.barcode1.BufferSize = 7905;
            this.barcode1.DecoderParameters.CODABAR = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.CODABARParams.ClsiEditing = false;
            this.barcode1.DecoderParameters.CODABARParams.NotisEditing = false;
            this.barcode1.DecoderParameters.CODABARParams.Redundancy = true;
            this.barcode1.DecoderParameters.CODE128 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.CODE128Params.EAN128 = true;
            this.barcode1.DecoderParameters.CODE128Params.ISBT128 = true;
            this.barcode1.DecoderParameters.CODE128Params.Other128 = true;
            this.barcode1.DecoderParameters.CODE128Params.Redundancy = false;
            this.barcode1.DecoderParameters.CODE39 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.CODE39Params.Code32Prefix = false;
            this.barcode1.DecoderParameters.CODE39Params.Concatenation = false;
            this.barcode1.DecoderParameters.CODE39Params.ConvertToCode32 = false;
            this.barcode1.DecoderParameters.CODE39Params.FullAscii = false;
            this.barcode1.DecoderParameters.CODE39Params.Redundancy = false;
            this.barcode1.DecoderParameters.CODE39Params.ReportCheckDigit = false;
            this.barcode1.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
            this.barcode1.DecoderParameters.CODE93 = Barcode.DisabledEnabled.Undefined;
            this.barcode1.DecoderParameters.CODE93Params.Redundancy = false;
            this.barcode1.DecoderParameters.D2OF5 = Barcode.DisabledEnabled.Disabled;
            this.barcode1.DecoderParameters.D2OF5Params.Redundancy = true;
            this.barcode1.DecoderParameters.EAN13 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.EAN8 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
            this.barcode1.DecoderParameters.I2OF5 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.I2OF5Params.CheckDigitScheme = Symbol.Barcode.I2OF5.CheckDigitSchemes.None;
            this.barcode1.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
            this.barcode1.DecoderParameters.I2OF5Params.Redundancy = true;
            this.barcode1.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
            this.barcode1.DecoderParameters.KOREAN_3OF5 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.MSI = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode.MSI.CheckDigitCounts.One;
            this.barcode1.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode.MSI.CheckDigitSchemes.Mod_11_10;
            this.barcode1.DecoderParameters.MSIParams.Redundancy = true;
            this.barcode1.DecoderParameters.MSIParams.ReportCheckDigit = false;
            this.barcode1.DecoderParameters.UPCA = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode.UPC.Preambles.System;
            this.barcode1.DecoderParameters.UPCAParams.ReportCheckDigit = true;
            this.barcode1.DecoderParameters.UPCE0 = Barcode.DisabledEnabled.Enabled;
            this.barcode1.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
            this.barcode1.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode.UPC.Preambles.None;
            this.barcode1.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
            this.barcode1.DeviceName = null;
            this.barcode1.EnableScanner = false;
            this.barcode1.ReaderParameters.ReaderSpecific.ContactSpecific.InitialScanTime = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ContactSpecific.PulseDelay = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ContactSpecific.QuietZoneRatio = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Barcode.AIM_MODE.AIM_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Barcode.AIM_TYPE.AIM_TYPE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Barcode.DPM_MODE.DPM_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Barcode.FOCUS_MODE.FOCUS_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Barcode.FOCUS_POSITION.FOCUS_POSITION_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Barcode.ILLUMINATION_MODE.ILLUMINATION_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Barcode.INVERSE1D_MODE.INVERSE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Barcode.LINEAR_SECURITY_LEVEL.SECURITY_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistModeEx = Barcode.PICKLIST_MODE.PICKLIST_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Barcode.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Barcode.VIEWFINDER_MODE.VIEWFINDER_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
            this.barcode1.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Barcode.AIM_MODE.AIM_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Barcode.AIM_TYPE.AIM_TYPE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Barcode.DBP_MODE.DBP_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Barcode.LINEAR_SECURITY_LEVEL.SECURITY_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.NarrowBeam = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Barcode.RASTER_MODE.RASTER_MODE_UNDEFINED;
            this.barcode1.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Barcode.DisabledEnabled.Undefined;
            this.barcode1.ScanParameters.BeepFrequency = 2670;
            this.barcode1.ScanParameters.BeepTime = 200;
            this.barcode1.ScanParameters.CodeIdType = Barcode.CodeIdTypes.None;
            this.barcode1.ScanParameters.LedTime = 3000;
            this.barcode1.ScanParameters.ScanType = Barcode.ScanTypes.Foreground;
            this.barcode1.ScanParameters.WaveFile = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 269);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(3, 231);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 35);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PreStockReceiptListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PreStockReceiptListForm";
            this.Text = "Supplier Deliveries";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.DataGrid grdItems;
        private Barcode.Barcode barcode1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefresh;
    }
}