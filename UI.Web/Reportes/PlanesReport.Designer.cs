namespace UI.Web
{
    /// <summary>
    /// Summary description for ReportePlanes.
    /// </summary>
    partial class PlanesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanesReport));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtCarrera = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDesc = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarrera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.picture1,
            this.textBox1,
            this.line1,
            this.textBox2,
            this.line2,
            this.label1,
            this.label2});
            this.pageHeader.Height = 1.916667F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtCarrera,
            this.txtDesc});
            this.detail.Height = 0.25F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Name = "pageFooter";
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.line1.LineWeight = 5F;
            this.line1.Name = "line1";
            this.line1.Top = 1F;
            this.line1.Width = 6.698F;
            this.line1.X1 = 0F;
            this.line1.X2 = 6.698F;
            this.line1.Y1 = 1F;
            this.line1.Y2 = 1F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.line2.LineWeight = 5F;
            this.line2.Name = "line2";
            this.line2.Top = 1.596F;
            this.line2.Width = 6.646F;
            this.line2.X1 = 0F;
            this.line2.X2 = 6.646F;
            this.line2.Y1 = 1.596F;
            this.line2.Y2 = 1.596F;
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
            this.textBox1.Text = "Universidad Tecnológica Nacional\r\nFacultad Regional Rosario";
            this.textBox1.Top = 0.125F;
            this.textBox1.Width = 5.5F;
            // 
            // textBox2
            // 
            this.textBox2.Height = 0.596F;
            this.textBox2.Left = 0.146F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-family: Arial Black; font-size: 25pt; text-align: center";
            this.textBox2.Text = "Reporte de planes";
            this.textBox2.Top = 1F;
            this.textBox2.Width = 6.448F;
            // 
            // label1
            // 
            this.label1.Height = 0.262F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "background-color: NavajoWhite; font-weight: bold; text-align: center";
            this.label1.Text = "Carrera";
            this.label1.Top = 1.656F;
            this.label1.Width = 2.031F;
            // 
            // label2
            // 
            this.label2.Height = 0.262F;
            this.label2.HyperLink = null;
            this.label2.Left = 2.031F;
            this.label2.Name = "label2";
            this.label2.Style = "background-color: NavajoWhite; font-weight: bold; text-align: center";
            this.label2.Text = "Descripcion";
            this.label2.Top = 1.656F;
            this.label2.Width = 2.042F;
            // 
            // txtCarrera
            // 
            this.txtCarrera.DataField = "Carrera";
            this.txtCarrera.Height = 0.2729999F;
            this.txtCarrera.Left = 0F;
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Text = "textBox3";
            this.txtCarrera.Top = 0F;
            this.txtCarrera.Width = 2.031F;
            // 
            // txtDesc
            // 
            this.txtDesc.DataField = "Descripcion";
            this.txtDesc.Height = 0.2729999F;
            this.txtDesc.Left = 2.031F;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Text = "textBox4";
            this.txtDesc.Top = 0F;
            this.txtDesc.Width = 2.042F;
            // 
            // PlanesReport
            // 
            this.PageSettings.PaperHeight = 11F;
            this.MasterReport = false;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.646F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PlanesReport_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarrera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Picture picture1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtCarrera;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtDesc;
    }
}
