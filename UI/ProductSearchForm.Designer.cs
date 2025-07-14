namespace Estore.Ce.UI
{
    partial class ProductSearchForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label itemUpriceLabel;
            this.PackingQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SellingPriceTextBox = new System.Windows.Forms.TextBox();
            this.classCodeLabel = new System.Windows.Forms.Label();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.brandCodeLabel = new System.Windows.Forms.Label();
            this.BrandTextBox = new System.Windows.Forms.TextBox();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.pluCodeLabel = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.barcode1 = new Barcode.Barcode();
            label2 = new System.Windows.Forms.Label();
            itemUpriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(6, 181);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 23);
            label2.Text = "Packing Qty:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // itemUpriceLabel
            // 
            itemUpriceLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            itemUpriceLabel.Location = new System.Drawing.Point(7, 152);
            itemUpriceLabel.Name = "itemUpriceLabel";
            itemUpriceLabel.Size = new System.Drawing.Size(91, 23);
            itemUpriceLabel.Text = "Selling Price:";
            itemUpriceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PackingQuantityTextBox
            // 
            this.PackingQuantityTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PackingQuantityTextBox.Enabled = false;
            this.PackingQuantityTextBox.Location = new System.Drawing.Point(103, 181);
            this.PackingQuantityTextBox.Name = "PackingQuantityTextBox";
            this.PackingQuantityTextBox.Size = new System.Drawing.Size(100, 23);
            this.PackingQuantityTextBox.TabIndex = 80;
            // 
            // SellingPriceTextBox
            // 
            this.SellingPriceTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.SellingPriceTextBox.Enabled = false;
            this.SellingPriceTextBox.Location = new System.Drawing.Point(103, 152);
            this.SellingPriceTextBox.Name = "SellingPriceTextBox";
            this.SellingPriceTextBox.Size = new System.Drawing.Size(100, 23);
            this.SellingPriceTextBox.TabIndex = 78;
            // 
            // classCodeLabel
            // 
            this.classCodeLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.classCodeLabel.Location = new System.Drawing.Point(7, 123);
            this.classCodeLabel.Name = "classCodeLabel";
            this.classCodeLabel.Size = new System.Drawing.Size(92, 23);
            this.classCodeLabel.Text = "Category:";
            this.classCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.CategoryTextBox.Enabled = false;
            this.CategoryTextBox.Location = new System.Drawing.Point(103, 123);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(208, 23);
            this.CategoryTextBox.TabIndex = 77;
            // 
            // brandCodeLabel
            // 
            this.brandCodeLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.brandCodeLabel.Location = new System.Drawing.Point(7, 94);
            this.brandCodeLabel.Name = "brandCodeLabel";
            this.brandCodeLabel.Size = new System.Drawing.Size(91, 23);
            this.brandCodeLabel.Text = "Brand:";
            this.brandCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BrandTextBox
            // 
            this.BrandTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.BrandTextBox.Enabled = false;
            this.BrandTextBox.Location = new System.Drawing.Point(103, 94);
            this.BrandTextBox.Name = "BrandTextBox";
            this.BrandTextBox.Size = new System.Drawing.Size(208, 23);
            this.BrandTextBox.TabIndex = 76;
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.ProductNameTextBox.Enabled = false;
            this.ProductNameTextBox.Location = new System.Drawing.Point(103, 40);
            this.ProductNameTextBox.Multiline = true;
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(208, 48);
            this.ProductNameTextBox.TabIndex = 75;
            // 
            // pluCodeLabel
            // 
            this.pluCodeLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.pluCodeLabel.Location = new System.Drawing.Point(7, 11);
            this.pluCodeLabel.Name = "pluCodeLabel";
            this.pluCodeLabel.Size = new System.Drawing.Size(91, 23);
            this.pluCodeLabel.Text = "Barcode:";
            this.pluCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Location = new System.Drawing.Point(103, 11);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(208, 23);
            this.txtBarcode.TabIndex = 73;
            this.txtBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBarcode_Validating);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(7, 221);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(304, 37);
            this.btnScan.TabIndex = 85;
            this.btnScan.Text = "Manual Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
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
            // ProductSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(318, 265);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(label2);
            this.Controls.Add(this.PackingQuantityTextBox);
            this.Controls.Add(itemUpriceLabel);
            this.Controls.Add(this.SellingPriceTextBox);
            this.Controls.Add(this.classCodeLabel);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.brandCodeLabel);
            this.Controls.Add(this.BrandTextBox);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.pluCodeLabel);
            this.Controls.Add(this.txtBarcode);
            this.Name = "ProductSearchForm";
            this.Text = "Search";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ProductForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PackingQuantityTextBox;
        private System.Windows.Forms.TextBox SellingPriceTextBox;
        private System.Windows.Forms.Label classCodeLabel;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private System.Windows.Forms.Label brandCodeLabel;
        private System.Windows.Forms.TextBox BrandTextBox;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label pluCodeLabel;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnScan;
        private Barcode.Barcode barcode1;
    }
}