namespace POO.ProyectoGastos.Windows
{
    partial class frmPrincipal
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnGastosHgr = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button5.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.shutdown_48px;
            this.button5.Location = new System.Drawing.Point(683, 493);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 102);
            this.button5.TabIndex = 1;
            this.button5.Text = "Salir";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button4.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.categorize_50px;
            this.button4.Location = new System.Drawing.Point(367, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 181);
            this.button4.TabIndex = 0;
            this.button4.Text = "Proximos Pagos";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button3.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.city_50px;
            this.button3.Location = new System.Drawing.Point(618, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 181);
            this.button3.TabIndex = 0;
            this.button3.Text = "Empresas Negocios";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnPersonas
            // 
            this.btnPersonas.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPersonas.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.client_management_50px;
            this.btnPersonas.Location = new System.Drawing.Point(108, 279);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(207, 181);
            this.btnPersonas.TabIndex = 0;
            this.btnPersonas.Text = "Grupo Familiar";
            this.btnPersonas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPersonas.UseVisualStyleBackColor = false;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // btnGastosHgr
            // 
            this.btnGastosHgr.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnGastosHgr.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.cash_register_50px;
            this.btnGastosHgr.Location = new System.Drawing.Point(108, 63);
            this.btnGastosHgr.Name = "btnGastosHgr";
            this.btnGastosHgr.Size = new System.Drawing.Size(207, 181);
            this.btnGastosHgr.TabIndex = 0;
            this.btnGastosHgr.Text = "Gastos Del Hogar";
            this.btnGastosHgr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGastosHgr.UseVisualStyleBackColor = false;
            this.btnGastosHgr.Click += new System.EventHandler(this.btnGastosHgr_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button6.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.cash_register_50px;
            this.button6.Location = new System.Drawing.Point(367, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(207, 181);
            this.button6.TabIndex = 0;
            this.button6.Text = "Gastos Totales";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button7.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.categorize_50px;
            this.button7.Location = new System.Drawing.Point(618, 279);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(207, 181);
            this.button7.TabIndex = 0;
            this.button7.Text = "Datos Guardados";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 607);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnGastosHgr);
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGastosHgr;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}