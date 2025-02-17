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
            this.button3 = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnGastosHgr = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnFondosComunes = new System.Windows.Forms.Button();
            this.BtnGastosFijos = new System.Windows.Forms.Button();
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
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button3.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.city_50px;
            this.button3.Location = new System.Drawing.Point(367, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 94);
            this.button3.TabIndex = 0;
            this.button3.Text = "Empresas Negocios";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button7.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.categorize_50px;
            this.button7.Location = new System.Drawing.Point(618, 366);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(207, 94);
            this.button7.TabIndex = 0;
            this.button7.Text = "Datos Guardados";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnFondosComunes
            // 
            this.btnFondosComunes.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnFondosComunes.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.cash_register_50px;
            this.btnFondosComunes.Location = new System.Drawing.Point(618, 63);
            this.btnFondosComunes.Name = "btnFondosComunes";
            this.btnFondosComunes.Size = new System.Drawing.Size(207, 181);
            this.btnFondosComunes.TabIndex = 2;
            this.btnFondosComunes.Text = "Fondos";
            this.btnFondosComunes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFondosComunes.UseVisualStyleBackColor = false;
            this.btnFondosComunes.Click += new System.EventHandler(this.btnFondosComunes_Click);
            // 
            // BtnGastosFijos
            // 
            this.BtnGastosFijos.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnGastosFijos.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.cash_register_50px;
            this.BtnGastosFijos.Location = new System.Drawing.Point(367, 63);
            this.BtnGastosFijos.Name = "BtnGastosFijos";
            this.BtnGastosFijos.Size = new System.Drawing.Size(207, 181);
            this.BtnGastosFijos.TabIndex = 3;
            this.BtnGastosFijos.Text = "GastosFijos";
            this.BtnGastosFijos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGastosFijos.UseVisualStyleBackColor = false;
            this.BtnGastosFijos.Click += new System.EventHandler(this.BtnGastosFijos_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.BtnGastosFijos);
            this.Controls.Add(this.btnFondosComunes);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnGastosHgr);
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGastosHgr;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnFondosComunes;
        private System.Windows.Forms.Button BtnGastosFijos;
    }
}