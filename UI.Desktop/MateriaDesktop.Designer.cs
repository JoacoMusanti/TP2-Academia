namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDMat = new System.Windows.Forms.Label();
            this.lblDescMat = new System.Windows.Forms.Label();
            this.lblHsSemMat = new System.Windows.Forms.Label();
            this.lblHsTotalesMat = new System.Windows.Forms.Label();
            this.lblIDPlanMat = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.txtIDMat = new System.Windows.Forms.TextBox();
            this.txtDescMat = new System.Windows.Forms.TextBox();
            this.txtHsSemMat = new System.Windows.Forms.TextBox();
            this.txtHsTotMat = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.22884F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.37931F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.39185F));
            this.tableLayoutPanel1.Controls.Add(this.lblIDMat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescMat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHsSemMat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHsTotalesMat, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIDPlanMat, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbPlan, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtIDMat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescMat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHsSemMat, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHsTotMat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.l, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbEspecialidad, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 245);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIDMat
            // 
            this.lblIDMat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIDMat.AutoSize = true;
            this.lblIDMat.Location = new System.Drawing.Point(46, 10);
            this.lblIDMat.Name = "lblIDMat";
            this.lblIDMat.Size = new System.Drawing.Size(56, 13);
            this.lblIDMat.TabIndex = 0;
            this.lblIDMat.Text = "ID Materia";
            // 
            // lblDescMat
            // 
            this.lblDescMat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDescMat.AutoSize = true;
            this.lblDescMat.Location = new System.Drawing.Point(39, 44);
            this.lblDescMat.Name = "lblDescMat";
            this.lblDescMat.Size = new System.Drawing.Size(63, 13);
            this.lblDescMat.TabIndex = 1;
            this.lblDescMat.Text = "Descripción";
            // 
            // lblHsSemMat
            // 
            this.lblHsSemMat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHsSemMat.AutoSize = true;
            this.lblHsSemMat.Location = new System.Drawing.Point(12, 78);
            this.lblHsSemMat.Name = "lblHsSemMat";
            this.lblHsSemMat.Size = new System.Drawing.Size(90, 13);
            this.lblHsSemMat.TabIndex = 2;
            this.lblHsSemMat.Text = "Horas Semanales";
            // 
            // lblHsTotalesMat
            // 
            this.lblHsTotalesMat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHsTotalesMat.AutoSize = true;
            this.lblHsTotalesMat.Location = new System.Drawing.Point(33, 112);
            this.lblHsTotalesMat.Name = "lblHsTotalesMat";
            this.lblHsTotalesMat.Size = new System.Drawing.Size(69, 13);
            this.lblHsTotalesMat.TabIndex = 3;
            this.lblHsTotalesMat.Text = "Horas totales";
            // 
            // lblIDPlanMat
            // 
            this.lblIDPlanMat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIDPlanMat.AutoSize = true;
            this.lblIDPlanMat.Location = new System.Drawing.Point(60, 180);
            this.lblIDPlanMat.Name = "lblIDPlanMat";
            this.lblIDPlanMat.Size = new System.Drawing.Size(42, 13);
            this.lblIDPlanMat.TabIndex = 4;
            this.lblIDPlanMat.Text = "ID Plan";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(158, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.Location = new System.Drawing.Point(239, 219);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbPlan
            // 
            this.cbPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbPlan, 2);
            this.cbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(108, 176);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(207, 21);
            this.cbPlan.TabIndex = 7;
            // 
            // txtIDMat
            // 
            this.txtIDMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtIDMat, 2);
            this.txtIDMat.Enabled = false;
            this.txtIDMat.Location = new System.Drawing.Point(108, 7);
            this.txtIDMat.Name = "txtIDMat";
            this.txtIDMat.ReadOnly = true;
            this.txtIDMat.Size = new System.Drawing.Size(207, 20);
            this.txtIDMat.TabIndex = 8;
            // 
            // txtDescMat
            // 
            this.txtDescMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescMat, 2);
            this.txtDescMat.Location = new System.Drawing.Point(108, 41);
            this.txtDescMat.Name = "txtDescMat";
            this.txtDescMat.Size = new System.Drawing.Size(207, 20);
            this.txtDescMat.TabIndex = 9;
            // 
            // txtHsSemMat
            // 
            this.txtHsSemMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtHsSemMat, 2);
            this.txtHsSemMat.Location = new System.Drawing.Point(108, 75);
            this.txtHsSemMat.Name = "txtHsSemMat";
            this.txtHsSemMat.Size = new System.Drawing.Size(207, 20);
            this.txtHsSemMat.TabIndex = 10;
            // 
            // txtHsTotMat
            // 
            this.txtHsTotMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtHsTotMat, 2);
            this.txtHsTotMat.Location = new System.Drawing.Point(108, 109);
            this.txtHsTotMat.Name = "txtHsTotMat";
            this.txtHsTotMat.Size = new System.Drawing.Size(207, 20);
            this.txtHsTotMat.TabIndex = 11;
            // 
            // l
            // 
            this.l.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(35, 146);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(67, 13);
            this.l.TabIndex = 12;
            this.l.Text = "Especialidad";
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbEspecialidad, 2);
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(108, 142);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(207, 21);
            this.cbEspecialidad.TabIndex = 13;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 245);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDMat;
        private System.Windows.Forms.Label lblDescMat;
        private System.Windows.Forms.Label lblHsSemMat;
        private System.Windows.Forms.Label lblHsTotalesMat;
        private System.Windows.Forms.Label lblIDPlanMat;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.TextBox txtIDMat;
        private System.Windows.Forms.TextBox txtDescMat;
        private System.Windows.Forms.TextBox txtHsSemMat;
        private System.Windows.Forms.TextBox txtHsTotMat;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.ComboBox cbEspecialidad;
    }
}