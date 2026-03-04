using System.Text.Json;
using FastReport;
using FastReport.Export.PdfSimple;

namespace FastReportWinForms
{
    public partial class Form1 : Form
    {
        private List<Person> _allData = new List<Person>();
        private BindingSource _bindingSource = new BindingSource();
        private string? _tempPdfPath;

        public Form1()
        {
            InitializeComponent();
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing WebView2: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string jsonPath = Path.Combine(baseDir, "Data", "64KB.json");
                
                // Extensive search for Data folder (handles bin/Debug/netX.X scenarios)
                if (!File.Exists(jsonPath))
                {
                    string? current = baseDir;
                    while (current != null && !File.Exists(jsonPath))
                    {
                        jsonPath = Path.Combine(current, "Data", "64KB.json");
                        if (File.Exists(jsonPath)) break;
                        current = Directory.GetParent(current)?.FullName;
                    }
                }

                if (File.Exists(jsonPath))
                {
                    string jsonString = File.ReadAllText(jsonPath);
                    _allData = JsonSerializer.Deserialize<List<Person>>(jsonString) ?? new List<Person>();
                    
                    // Force UI update
                    _bindingSource.DataSource = null;
                    _bindingSource.DataSource = _allData;
                    
                    dgvData.DataSource = null;
                    dgvData.AutoGenerateColumns = true;
                    dgvData.DataSource = _bindingSource;
                    dgvData.Refresh();

                    this.Text = $"JSON Data Viewer - {_allData.Count} Records Loaded";
                }
                else
                {
                    MessageBox.Show("JSON data file not found in any expected location. Please ensure '64KB.json' is in a 'Data' folder.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filterText = txtSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(filterText))
            {
                _bindingSource.DataSource = _allData;
            }
            else
            {
                var filtered = _allData.Where(p => 
                    p.name.ToLower().Contains(filterText) || 
                    p.language.ToLower().Contains(filterText) || 
                    p.bio.ToLower().Contains(filterText) || 
                    p.id.ToLower().Contains(filterText)).ToList();
                _bindingSource.DataSource = filtered;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewReport();
        }

        private void PreviewReport()
        {
            try
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "demo.frx");
                if (!File.Exists(reportPath))
                {
                    var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
                    if (projectDir != null) reportPath = Path.Combine(projectDir, "Reports", "demo.frx");
                }

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Report file not found: " + reportPath);
                    return;
                }

                using (Report report = new Report())
                {
                    report.Load(reportPath);
                    
                    // Clear existing dictionary to prevent conflicts with pre-defined XML schemas
                    report.Dictionary.Clear();
                    
                    // Get data as a concrete List<Person>
                    var dataList = _bindingSource.Cast<Person>().ToList();
                    
                    // Register the list
                    report.RegisterData(dataList, "Persons");
                    
                    // Force the engine to recognize and enable the source
                    var ds = report.GetDataSource("Persons");
                    if (ds != null) ds.Enabled = true;

                    // Manually link the DataBand if needed
                    var dataBand = report.FindObject("Data1") as DataBand;
                    if (dataBand != null)
                    {
                        dataBand.DataSource = ds;
                    }

                    if (report.Prepare())
                    {
                        // Export to bytes
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PDFSimpleExport export = new PDFSimpleExport();
                            report.Export(export, ms);
                            byte[] pdfBytes = ms.ToArray();

                            // Preview in WebView2
                            ShowPdfPreview(pdfBytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }

        private void ShowPdfPreview(byte[] pdfBytes)
        {
            try
            {
                // Create a temporary file to show in WebView2 (standard way to show full PDF doc)
                if (_tempPdfPath == null)
                {
                    _tempPdfPath = Path.Combine(Path.GetTempPath(), "FastReportPreview_" + Guid.NewGuid().ToString() + ".pdf");
                }
                
                File.WriteAllBytes(_tempPdfPath, pdfBytes);
                
                if (webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate("file://" + _tempPdfPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing preview: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Cleanup temp file
            try
            {
                if (_tempPdfPath != null && File.Exists(_tempPdfPath))
                {
                    File.Delete(_tempPdfPath);
                }
            }
            catch { /* Ignore cleanup errors */ }
        }
    }

    public class Person
    {
        public string name { get; set; } = "";
        public string language { get; set; } = "";
        public string id { get; set; } = "";
        public string bio { get; set; } = "";
        public double version { get; set; }
    }
}


