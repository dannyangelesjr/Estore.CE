namespace Estore.Ce.UI
{
    partial class PreStockReplenishmentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtProductName2 = new System.Windows.Forms.TextBox();
            this.grdItems = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackingUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cmbLocationTo = new System.Windows.Forms.ComboBox();
            this.barcode1 = new Barcode.Barcode();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLocationFrom = new System.Windows.Forms.ComboBox();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.Text = "Location To";
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submitButton.BackColor = System.Drawing.Color.ForestGreen;
            this.submitButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.submitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitButton.Location = new System.Drawing.Point(3, 134);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(287, 34);
            this.submitButton.TabIndex = 82;
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnScan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnScan.Location = new System.Drawing.Point(3, 136);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(290, 37);
            this.btnScan.TabIndex = 86;
            this.btnScan.Text = "Manual Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtProductName2
            // 
            this.txtProductName2.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName2.Enabled = false;
            this.txtProductName2.Location = new System.Drawing.Point(3, 105);
            this.txtProductName2.Name = "txtProductName2";
            this.txtProductName2.Size = new System.Drawing.Size(287, 23);
            this.txtProductName2.TabIndex = 66;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.grdItems.BackgroundColor = System.Drawing.SystemColors.Info;
            this.grdItems.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.grdItems.HeaderForeColor = System.Drawing.Color.White;
            this.grdItems.Location = new System.Drawing.Point(3, 3);
            this.grdItems.Name = "grdItems";
            this.grdItems.SelectionBackColor = System.Drawing.Color.YellowGreen;
            this.grdItems.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItems.Size = new System.Drawing.Size(287, 96);
            this.grdItems.TabIndex = 12;
            this.grdItems.Click += new System.EventHandler(this.grdItems_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.Text = "Packing Unit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPackingUnit
            // 
            this.txtPackingUnit.BackColor = System.Drawing.SystemColors.Info;
            this.txtPackingUnit.Location = new System.Drawing.Point(91, 107);
            this.txtPackingUnit.Name = "txtPackingUnit";
            this.txtPackingUnit.ReadOnly = true;
            this.txtPackingUnit.Size = new System.Drawing.Size(72, 23);
            this.txtPackingUnit.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(42, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.Text = "Count";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.submitButton);
            this.tabPage2.Controls.Add(this.txtProductName2);
            this.tabPage2.Controls.Add(this.grdItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(296, 176);
            this.tabPage2.Text = "Items";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(304, 205);
            this.tabControl1.TabIndex = 83;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtProductId);
            this.tabPage1.Controls.Add(this.btnScan);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtPackingUnit);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtQuantity);
            this.tabPage1.Controls.Add(this.txtProductName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtBarcode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(296, 176);
            this.tabPage1.Text = "Scan";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(193, 107);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(100, 23);
            this.txtProductId.TabIndex = 90;
            this.txtProductId.Visible = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantity.Location = new System.Drawing.Point(91, 78);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(72, 23);
            this.txtQuantity.TabIndex = 66;
            this.txtQuantity.Validated += new System.EventHandler(this.txtQuantity_Validated);
            this.txtQuantity.GotFocus += new System.EventHandler(this.txtQuantity_GotFocus);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(3, 32);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(290, 40);
            this.txtProductName.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.Text = "Barcode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcode.Location = new System.Drawing.Point(65, 3);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(229, 23);
            this.txtBarcode.TabIndex = 64;
            // 
            // cmbLocationTo
            // 
            this.cmbLocationTo.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLocationTo.Location = new System.Drawing.Point(120, 32);
            this.cmbLocationTo.Name = "cmbLocationTo";
            this.cmbLocationTo.Size = new System.Drawing.Size(191, 23);
            this.cmbLocationTo.TabIndex = 82;
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
            this.barcode1.OnRead += new Barcode.Barcode.ScannerReadEventHandler(this.barcode1_OnRead);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.YellowGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.Text = "Location From";
            // 
            // cmbLocationFrom
            // 
            this.cmbLocationFrom.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLocationFrom.Location = new System.Drawing.Point(120, 3);
            this.cmbLocationFrom.Name = "cmbLocationFrom";
            this.cmbLocationFrom.Size = new System.Drawing.Size(191, 23);
            this.cmbLocationFrom.TabIndex = 85;
            // 
            // PreStockReplenishmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbLocationFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmbLocationTo);
            this.Name = "PreStockReplenishmentForm";
            this.Text = "Stock Replenishment";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.RestockForm_Closing);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtProductName2;
        private System.Windows.Forms.DataGrid grdItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPackingUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cmbLocationTo;
        private Barcode.Barcode barcode1;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLocationFrom;
    }
}