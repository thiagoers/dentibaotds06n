namespace Integrando_BD
{
    partial class Menu
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
            this.btnDentista = new System.Windows.Forms.Button();
            this.btnPaciente = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDentista
            // 
            this.btnDentista.Location = new System.Drawing.Point(30, 31);
            this.btnDentista.Name = "btnDentista";
            this.btnDentista.Size = new System.Drawing.Size(88, 38);
            this.btnDentista.TabIndex = 0;
            this.btnDentista.Text = "Dentista";
            this.btnDentista.UseVisualStyleBackColor = true;
            this.btnDentista.Click += new System.EventHandler(this.btnDentista_Click);
            // 
            // btnPaciente
            // 
            this.btnPaciente.Location = new System.Drawing.Point(135, 31);
            this.btnPaciente.Name = "btnPaciente";
            this.btnPaciente.Size = new System.Drawing.Size(88, 38);
            this.btnPaciente.TabIndex = 1;
            this.btnPaciente.Text = "Paciente";
            this.btnPaciente.UseVisualStyleBackColor = true;
            this.btnPaciente.Click += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(242, 31);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(88, 38);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 105);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnPaciente);
            this.Controls.Add(this.btnDentista);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDentista;
        private System.Windows.Forms.Button btnPaciente;
        private System.Windows.Forms.Button btnConsulta;
    }
}