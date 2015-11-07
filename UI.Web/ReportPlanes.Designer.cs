namespace UI.Web
{
    /// <summary>
    /// Summary description for ReportPlanes.
    /// </summary>
    partial class ReportPlanes
    {
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPlanes));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTit = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTit)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.picture1,
            this.textBox1});
            this.pageHeader.Height = 0.9895834F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.line1,
            this.txtTit,
            this.line2});
            this.detail.Height = 3.052F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 1.5F;
            this.pageFooter.Name = "pageFooter";
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0F;
            this.line1.Width = 6.5F;
            this.line1.X1 = 0F;
            this.line1.X2 = 6.5F;
            this.line1.Y1 = 0F;
            this.line1.Y2 = 0F;
            // 
            // picture1
            // 
            this.picture1.Height = 1F;
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0F;
            this.picture1.Width = 1F;
            // 
            // textBox1
            // 
            this.textBox1.Height = 1F;
            this.textBox1.Left = 1F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-family: Arial Black; font-size: 15pt; text-align: center";
            this.textBox1.Text = "\r\nUniversidad Tecnológica nacional\r\nFacultad Regional Rosario";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 5.5F;
            // 
            // txtTit
            // 
            this.txtTit.Height = 0.637F;
            this.txtTit.Left = 0F;
            this.txtTit.Name = "txtTit";
            this.txtTit.Style = "font-family: Arial Black; font-size: 25pt; text-align: center";
            this.txtTit.Text = "Reporte de Planes";
            this.txtTit.Top = 0F;
            this.txtTit.Width = 6.5F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 5F;
            this.line2.Name = "line2";
            this.line2.Top = 0.637F;
            this.line2.Width = 6.5F;
            this.line2.X1 = 0F;
            this.line2.X2 = 6.5F;
            this.line2.Y1 = 0.637F;
            this.line2.Y2 = 0.637F;
            // 
            // ReportPlanes
            // 
            this.PageSettings.PaperHeight = 11F;
            this.MasterReport = false;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTit)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Picture picture1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtTit;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
    }
}
