﻿namespace UI.Desktop
{
    partial class MenuPrincipal
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
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.btnAdministrarPlanes = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnUsuarios, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEspecialidades, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnComisiones, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAdministrarPlanes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnMaterias, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.4966F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.5034F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 294);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(3, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(145, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Administrar usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Location = new System.Drawing.Point(186, 3);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(145, 23);
            this.btnEspecialidades.TabIndex = 1;
            this.btnEspecialidades.Text = "Administrar especialidades";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // btnComisiones
            // 
            this.btnComisiones.Location = new System.Drawing.Point(3, 167);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(145, 23);
            this.btnComisiones.TabIndex = 2;
            this.btnComisiones.Text = "Administar comisiones";
            this.btnComisiones.UseVisualStyleBackColor = true;
            this.btnComisiones.Click += new System.EventHandler(this.btnComisiones_Click);
            // 
            // btnAdministrarPlanes
            // 
            this.btnAdministrarPlanes.Location = new System.Drawing.Point(186, 167);
            this.btnAdministrarPlanes.Name = "btnAdministrarPlanes";
            this.btnAdministrarPlanes.Size = new System.Drawing.Size(145, 23);
            this.btnAdministrarPlanes.TabIndex = 3;
            this.btnAdministrarPlanes.Text = "Administrar planes";
            this.btnAdministrarPlanes.UseVisualStyleBackColor = true;
            this.btnAdministrarPlanes.Click += new System.EventHandler(this.btnAdministrarPlanes_Click);
            // 
            // btnMaterias
            // 
            this.btnMaterias.Location = new System.Drawing.Point(3, 94);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(145, 23);
            this.btnMaterias.TabIndex = 4;
            this.btnMaterias.Text = "Administrar materias";
            this.btnMaterias.UseVisualStyleBackColor = true;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 318);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnComisiones;
        private System.Windows.Forms.Button btnAdministrarPlanes;
        private System.Windows.Forms.Button btnMaterias;
    }
}