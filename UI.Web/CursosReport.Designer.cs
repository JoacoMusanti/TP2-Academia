namespace UI.Web
{
    /// <summary>
    /// Summary description for CursosReport.
    /// </summary>
    partial class CursosReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CursosReport));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.txtCarrera = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMateria = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtComision = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarrera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label2,
            this.label3,
            this.label4,
            this.label5,
            this.label6,
            this.picture1,
            this.textBox1,
            this.textBox2,
            this.line2,
            this.line1});
            this.pageHeader.Height = 1.991333F;
            this.pageHeader.Name = "pageHeader";
            // 
            // label2
            // 
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "background-color: NavajoWhite; font-weight: bold";
            this.label2.Text = "Carrera";
            this.label2.Top = 1.768F;
            this.label2.Width = 1F;
            // 
            // label3
            // 
            this.label3.Height = 0.2F;
            this.label3.HyperLink = null;
            this.label3.Left = 1F;
            this.label3.Name = "label3";
            this.label3.Style = "background-color: NavajoWhite; font-weight: bold";
            this.label3.Text = "Materia";
            this.label3.Top = 1.768F;
            this.label3.Width = 1F;
            // 
            // label4
            // 
            this.label4.Height = 0.2F;
            this.label4.HyperLink = null;
            this.label4.Left = 2F;
            this.label4.Name = "label4";
            this.label4.Style = "background-color: NavajoWhite; font-weight: bold";
            this.label4.Text = "Comision";
            this.label4.Top = 1.768F;
            this.label4.Width = 1F;
            // 
            // label5
            // 
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 3F;
            this.label5.Name = "label5";
            this.label5.Style = "background-color: NavajoWhite; font-weight: bold";
            this.label5.Text = "Año";
            this.label5.Top = 1.768F;
            this.label5.Width = 1F;
            // 
            // label6
            // 
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 4F;
            this.label6.Name = "label6";
            this.label6.Style = "background-color: NavajoWhite; font-weight: bold";
            this.label6.Text = "Cupo";
            this.label6.Top = 1.768F;
            this.label6.Width = 1F;
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtCarrera,
            this.txtMateria,
            this.txtComision,
            this.textBox4,
            this.textBox5});
            this.detail.Height = 0.2187501F;
            this.detail.Name = "detail";
            // 
            // txtCarrera
            // 
            this.txtCarrera.DataField = "Carrera";
            this.txtCarrera.Height = 0.2F;
            this.txtCarrera.Left = 0F;
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Text = "textBox1";
            this.txtCarrera.Top = 0F;
            this.txtCarrera.Width = 1F;
            // 
            // txtMateria
            // 
            this.txtMateria.DataField = "Materia";
            this.txtMateria.Height = 0.2F;
            this.txtMateria.Left = 1F;
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Text = "textBox2";
            this.txtMateria.Top = 0F;
            this.txtMateria.Width = 1F;
            // 
            // txtComision
            // 
            this.txtComision.DataField = "Comision";
            this.txtComision.Height = 0.2F;
            this.txtComision.Left = 2F;
            this.txtComision.Name = "txtComision";
            this.txtComision.Text = "textBox3";
            this.txtComision.Top = 0F;
            this.txtComision.Width = 1F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "Anio";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 3F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 1F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Cupo";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 4F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Text = "textBox5";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 1F;
            // 
            // pageFooter
            // 
            this.pageFooter.Name = "pageFooter";
            // 
            // picture1
            // 
            this.picture1.Height = 1F;
            this.picture1.HyperLink = null;
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0F;
            this.picture1.Width = 1F;
            // 
            // textBox1
            // 
            this.textBox1.Height = 0.646F;
            this.textBox1.Left = 1.136F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-family: Arial Black; font-size: 15pt; text-align: center";
            this.textBox1.Text = "Universidad Tecnológica Nacional\r\nFacultad Regional Rosario";
            this.textBox1.Top = 0.135F;
            this.textBox1.Width = 5.5F;
            // 
            // textBox2
            // 
            this.textBox2.Height = 0.5960001F;
            this.textBox2.Left = 0.292F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-family: Arial Black; font-size: 25pt; text-align: center";
            this.textBox2.Text = "Reporte de cursos";
            this.textBox2.Top = 1.093F;
            this.textBox2.Width = 6.448001F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.line2.LineWeight = 5F;
            this.line2.Name = "line2";
            this.line2.Top = 1F;
            this.line2.Width = 6.854F;
            this.line2.X1 = 0F;
            this.line2.X2 = 6.854F;
            this.line2.Y1 = 1F;
            this.line2.Y2 = 1F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.line1.LineWeight = 5F;
            this.line1.Name = "line1";
            this.line1.Top = 1.689F;
            this.line1.Width = 6.854F;
            this.line1.X1 = 0F;
            this.line1.X2 = 6.854F;
            this.line1.Y1 = 1.689F;
            this.line1.Y2 = 1.689F;
            // 
            // CursosReport
            // 
            this.PageSettings.PaperHeight = 11F;
            this.MasterReport = false;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.854001F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.CursosReport_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarrera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtCarrera;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtMateria;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtComision;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.Picture picture1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
    }
}
