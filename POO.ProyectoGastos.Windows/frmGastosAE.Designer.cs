namespace POO.ProyectoGastos.Windows
{
    partial class frmGastosAE
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboPersonas = new System.Windows.Forms.ComboBox();
            this.textDetalle = new System.Windows.Forms.TextBox();
            this.comboTipoDeGasto = new System.Windows.Forms.ComboBox();
            this.textImporte = new System.Windows.Forms.TextBox();
            this.comboFormaDePago = new System.Windows.Forms.ComboBox();
            this.comboFondoComun = new System.Windows.Forms.ComboBox();
            this.comboNumTarje = new System.Windows.Forms.ComboBox();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.checkPagado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pagado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Persona:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo De Gasto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Empresa/Negocio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fondo Comun:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Detalle:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tarjeta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Forma De Pago:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Importe:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(614, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 81);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POO.ProyectoGastos.Windows.Properties.Resources.ok_24px;
            this.btnOk.Location = new System.Drawing.Point(217, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 81);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 22);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // comboPersonas
            // 
            this.comboPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPersonas.FormattingEnabled = true;
            this.comboPersonas.Location = new System.Drawing.Point(140, 97);
            this.comboPersonas.Name = "comboPersonas";
            this.comboPersonas.Size = new System.Drawing.Size(184, 24);
            this.comboPersonas.TabIndex = 13;
            // 
            // textDetalle
            // 
            this.textDetalle.Location = new System.Drawing.Point(140, 227);
            this.textDetalle.MaxLength = 50;
            this.textDetalle.Multiline = true;
            this.textDetalle.Name = "textDetalle";
            this.textDetalle.Size = new System.Drawing.Size(230, 65);
            this.textDetalle.TabIndex = 14;
            // 
            // comboTipoDeGasto
            // 
            this.comboTipoDeGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDeGasto.FormattingEnabled = true;
            this.comboTipoDeGasto.Location = new System.Drawing.Point(140, 137);
            this.comboTipoDeGasto.Name = "comboTipoDeGasto";
            this.comboTipoDeGasto.Size = new System.Drawing.Size(184, 24);
            this.comboTipoDeGasto.TabIndex = 15;
            // 
            // textImporte
            // 
            this.textImporte.Location = new System.Drawing.Point(140, 188);
            this.textImporte.MaxLength = 30;
            this.textImporte.Name = "textImporte";
            this.textImporte.Size = new System.Drawing.Size(230, 22);
            this.textImporte.TabIndex = 16;
            // 
            // comboFormaDePago
            // 
            this.comboFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFormaDePago.FormattingEnabled = true;
            this.comboFormaDePago.Location = new System.Drawing.Point(553, 94);
            this.comboFormaDePago.Name = "comboFormaDePago";
            this.comboFormaDePago.Size = new System.Drawing.Size(203, 24);
            this.comboFormaDePago.TabIndex = 17;
            // 
            // comboFondoComun
            // 
            this.comboFondoComun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFondoComun.FormattingEnabled = true;
            this.comboFondoComun.Location = new System.Drawing.Point(553, 142);
            this.comboFondoComun.Name = "comboFondoComun";
            this.comboFondoComun.Size = new System.Drawing.Size(203, 24);
            this.comboFondoComun.TabIndex = 18;
            // 
            // comboNumTarje
            // 
            this.comboNumTarje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNumTarje.FormattingEnabled = true;
            this.comboNumTarje.Location = new System.Drawing.Point(553, 216);
            this.comboNumTarje.Name = "comboNumTarje";
            this.comboNumTarje.Size = new System.Drawing.Size(203, 24);
            this.comboNumTarje.TabIndex = 19;
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(552, 264);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(204, 24);
            this.comboEmpresa.TabIndex = 20;
            // 
            // checkPagado
            // 
            this.checkPagado.AutoSize = true;
            this.checkPagado.Location = new System.Drawing.Point(552, 49);
            this.checkPagado.Name = "checkPagado";
            this.checkPagado.Size = new System.Drawing.Size(41, 20);
            this.checkPagado.TabIndex = 21;
            this.checkPagado.Text = "Si";
            this.checkPagado.UseVisualStyleBackColor = true;
            // 
            // frmGastosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 495);
            this.ControlBox = false;
            this.Controls.Add(this.checkPagado);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.comboNumTarje);
            this.Controls.Add(this.comboFondoComun);
            this.Controls.Add(this.comboFormaDePago);
            this.Controls.Add(this.textImporte);
            this.Controls.Add(this.comboTipoDeGasto);
            this.Controls.Add(this.textDetalle);
            this.Controls.Add(this.comboPersonas);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGastosAE";
            this.Text = "Gasto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboPersonas;
        private System.Windows.Forms.TextBox textDetalle;
        private System.Windows.Forms.ComboBox comboTipoDeGasto;
        private System.Windows.Forms.TextBox textImporte;
        private System.Windows.Forms.ComboBox comboFormaDePago;
        private System.Windows.Forms.ComboBox comboFondoComun;
        private System.Windows.Forms.ComboBox comboNumTarje;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.CheckBox checkPagado;
    }
}