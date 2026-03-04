namespace FastReportWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtSearch = new TextBox();
            dgvData = new DataGridView();
            btnPreview = new Button();
            lblSearch = new Label();
            splitContainer1 = new SplitContainer();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(62, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Type to filter...";
            txtSearch.Size = new Size(310, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(0, 41);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(372, 532);
            dgvData.TabIndex = 1;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPreview.Location = new Point(378, 11);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(107, 23);
            btnPreview.TabIndex = 2;
            btnPreview.Text = "Generate PDF";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblSearch);
            splitContainer1.Panel1.Controls.Add(dgvData);
            splitContainer1.Panel1.Controls.Add(txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(webView);
            splitContainer1.Panel2.Controls.Add(btnPreview);
            splitContainer1.Size = new Size(984, 573);
            splitContainer1.SplitterDistance = 372;
            splitContainer1.TabIndex = 4;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(3, 41);
            webView.Name = "webView";
            webView.Size = new Size(602, 532);
            webView.TabIndex = 3;
            webView.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 597);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "JSON Data Viewer & Report Preview";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dgvData;
        private Button btnPreview;
        private Label lblSearch;
        private SplitContainer splitContainer1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
    }
}
