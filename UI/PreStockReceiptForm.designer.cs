namespace Estore.Ce
{
    partial class SupplierDeliveryForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalCases = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPieces = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPurchaseOrderNumber = new System.Windows.Forms.TextBox();
            this.txtQuantityDelivered = new System.Windows.Forms.TextBox();
            this.barcode1 = new Barcode.Barcode();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.auxRefLabel = new System.Windows.Forms.Label();
            this.poNoLabel = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.grdItems = new System.Windows.Forms.DataGrid();
            this.txtSupplierInvoice = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtQuantityOnOrder = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtProductName2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(170, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.Text = "PO Qty:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalCases
            // 
            this.txtTotalCases.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalCases.Enabled = false;
            this.txtTotalCases.Location = new System.Drawing.Point(79, 115);
            this.txtTotalCases.Name = "txtTotalCases";
            this.txtTotalCases.Size = new System.Drawing.Size(89, 23);
            this.txtTotalCases.TabIndex = 8;
            this.txtTotalCases.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.Text = "Deliver Qty:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalPieces
            // 
            this.txtTotalPieces.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPieces.Enabled = false;
            this.txtTotalPieces.Location = new System.Drawing.Point(213, 115);
            this.txtTotalPieces.Name = "txtTotalPieces";
            this.txtTotalPieces.Size = new System.Drawing.Size(89, 23);
            this.txtTotalPieces.TabIndex = 9;
            this.txtTotalPieces.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(172, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.Text = "Piece";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.Text = "Total Case";
            // 
            // txtPurchaseOrderNumber
            // 
            this.txtPurchaseOrderNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchaseOrderNumber.Enabled = false;
            this.txtPurchaseOrderNumber.Location = new System.Drawing.Point(201, 4);
            this.txtPurchaseOrderNumber.Name = "txtPurchaseOrderNumber";
            this.txtPurchaseOrderNumber.Size = new System.Drawing.Size(107, 23);
            this.txtPurchaseOrderNumber.TabIndex = 86;
            // 
            // txtQuantityDelivered
            // 
            this.txtQuantityDelivered.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantityDelivered.Location = new System.Drawing.Point(87, 103);
            this.txtQuantityDelivered.Name = "txtQuantityDelivered";
            this.txtQuantityDelivered.Size = new System.Drawing.Size(72, 23);
            this.txtQuantityDelivered.TabIndex = 66;
            this.txtQuantityDelivered.Validated += new System.EventHandler(this.txtQuantityDelivered_Validated);
            this.txtQuantityDelivered.GotFocus += new System.EventHandler(this.txtQuantityDelivered_GotFocus);
            this.txtQuantityDelivered.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantityDelivered_Validating);
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
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(3, 42);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(298, 55);
            this.txtProductName.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.Text = "Plu Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // auxRefLabel
            // 
            this.auxRefLabel.BackColor = System.Drawing.Color.YellowGreen;
            this.auxRefLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.auxRefLabel.Location = new System.Drawing.Point(7, 7);
            this.auxRefLabel.Name = "auxRefLabel";
            this.auxRefLabel.Size = new System.Drawing.Size(45, 20);
            this.auxRefLabel.Text = "Ref#";
            // 
            // poNoLabel
            // 
            this.poNoLabel.BackColor = System.Drawing.Color.YellowGreen;
            this.poNoLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.poNoLabel.Location = new System.Drawing.Point(160, 7);
            this.poNoLabel.Name = "poNoLabel";
            this.poNoLabel.Size = new System.Drawing.Size(37, 20);
            this.poNoLabel.Text = "PO#";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcode.Location = new System.Drawing.Point(87, 16);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(214, 23);
            this.txtBarcode.TabIndex = 64;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.grdItems.BackgroundColor = System.Drawing.SystemColors.Info;
            this.grdItems.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.grdItems.HeaderForeColor = System.Drawing.Color.White;
            this.grdItems.Location = new System.Drawing.Point(6, 4);
            this.grdItems.Name = "grdItems";
            this.grdItems.SelectionBackColor = System.Drawing.Color.White;
            this.grdItems.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItems.Size = new System.Drawing.Size(295, 79);
            this.grdItems.TabIndex = 12;
            this.grdItems.Click += new System.EventHandler(this.grdItems_Click);
            // 
            // txtSupplierInvoice
            // 
            this.txtSupplierInvoice.AcceptsReturn = true;
            this.txtSupplierInvoice.AcceptsTab = true;
            this.txtSupplierInvoice.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierInvoice.Enabled = false;
            this.txtSupplierInvoice.Location = new System.Drawing.Point(54, 4);
            this.txtSupplierInvoice.Name = "txtSupplierInvoice";
            this.txtSupplierInvoice.Size = new System.Drawing.Size(100, 23);
            this.txtSupplierInvoice.TabIndex = 84;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Location = new System.Drawing.Point(7, 32);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(301, 23);
            this.txtSupplierName.TabIndex = 85;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 205);
            this.tabControl1.TabIndex = 87;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnScan);
            this.tabPage1.Controls.Add(this.txtProductId);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtQuantityDelivered);
            this.tabPage1.Controls.Add(this.txtProductName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtBarcode);
            this.tabPage1.Controls.Add(this.txtQuantityOnOrder);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(304, 176);
            this.tabPage1.Text = "Scan";
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnScan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnScan.Location = new System.Drawing.Point(3, 136);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(298, 37);
            this.btnScan.TabIndex = 87;
            this.btnScan.Text = "Manual Scan";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(154, 0);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(100, 23);
            this.txtProductId.TabIndex = 71;
            this.txtProductId.Visible = false;
            // 
            // txtQuantityOnOrder
            // 
            this.txtQuantityOnOrder.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantityOnOrder.Enabled = false;
            this.txtQuantityOnOrder.Location = new System.Drawing.Point(229, 103);
            this.txtQuantityOnOrder.Name = "txtQuantityOnOrder";
            this.txtQuantityOnOrder.Size = new System.Drawing.Size(72, 23);
            this.txtQuantityOnOrder.TabIndex = 69;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSubmit);
            this.tabPage2.Controls.Add(this.txtProductName2);
            this.tabPage2.Controls.Add(this.grdItems);
            this.tabPage2.Controls.Add(this.txtTotalPieces);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtTotalCases);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(304, 176);
            this.tabPage2.Text = "Items";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(6, 143);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(295, 30);
            this.btnSubmit.TabIndex = 89;
            this.btnSubmit.Text = "Submit";
            // 
            // txtProductName2
            // 
            this.txtProductName2.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName2.Enabled = false;
            this.txtProductName2.Location = new System.Drawing.Point(6, 89);
            this.txtProductName2.Multiline = true;
            this.txtProductName2.Name = "txtProductName2";
            this.txtProductName2.Size = new System.Drawing.Size(296, 23);
            this.txtProductName2.TabIndex = 66;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.YellowGreen;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 269);
            // 
            // SupplierDeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.txtPurchaseOrderNumber);
            this.Controls.Add(this.auxRefLabel);
            this.Controls.Add(this.poNoLabel);
            this.Controls.Add(this.txtSupplierInvoice);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SupplierDeliveryForm";
            this.Text = "Supplier Delivery";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SupplierDeliveryForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalCases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPieces;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPurchaseOrderNumber;
        private System.Windows.Forms.TextBox txtQuantityDelivered;
        private Barcode.Barcode barcode1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label auxRefLabel;
        private System.Windows.Forms.Label poNoLabel;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGrid grdItems;
        private System.Windows.Forms.TextBox txtSupplierInvoice;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtQuantityOnOrder;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnScan;
    }
}