using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsForm1
{
   
    public partial class FormPrincipal : Form
    {
        class Cliente
        {
            public int Id;
            public string Nombre;
            public string Apellido;
            public float Salario;

        }

        List<Cliente> lsClientes = new List<Cliente>();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Dios Primero Pasare Programacion 2", " ", MessageBoxButtons.YesNoCancel);
           
        }
       
        private void cargarClie()
        {
            dgvCliente.Rows.Clear();
                
            foreach(Cliente c in lsClientes)
            {
                dgvCliente.Rows.Add(c.Id, c.Nombre, c.Apellido, c.Salario);
            }
        }
         private void Datos()
        {

            Cliente c = new Cliente();
            c.Id =int.Parse(textID.Text.Trim());
            c.Nombre = textBoxNom.Text.Trim();
            c.Apellido = textApelli.Text.Trim();
            c.Salario = float.Parse(textSala.Text.Trim());
            lsClientes.Add(c);

           
            
        }
        private void limpiarCampos()
        {
            textID.Text = string.Empty; 
            textBoxNom.Text = string.Empty;
            textApelli.Text = string.Empty;
            textSala.Text = string.Empty;

        }
        private void AgregarClientes()
        {
            try
            {
                Datos();
                MessageBox.Show("Registro Agregado");
                limpiarCampos();
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Cambiar(bool e)
        {
            dgvCliente.Enabled= e;
            buttnAgregar.Enabled = e;
            buttCargar.Enabled = e;
            buttElimi.Enabled = e;
            textBoxNom.Enabled = e;
            textApelli.Enabled = e;

        }
    
        public void Salir()
        {

            if (MessageBox.Show("Quieres salir de la app", "Mi aplicacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Salir();

        }

        private void buttnEnviar_Click(object sender, EventArgs e)
        {
            AgregarClientes();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCiud_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttCargar_Click(object sender, EventArgs e)
        {
            cargarClie();
        }

        private void buttModificar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.Rows.Count > 0)
            {
                 DataGridViewRow FilasSelec = dgvCliente.CurrentRow;
                Cambiar(false);

                if(buttModificar.Text=="Modificar Cliente")
                {
                    dgvCliente.Enabled = false;
                    buttModificar.Text = "Guardar Cambios";

                    textID.Text = FilasSelec.Cells[0].Value.ToString();
                    textBoxNom.Text = FilasSelec.Cells[1].Value.ToString();
                    textApelli.Text = FilasSelec.Cells[2].Value.ToString();
                    textSala.Text = FilasSelec.Cells[3].Value.ToString();
                }
                else
                {
                    try
                    {
                        buttModificar.Text = "Modificar Cliente";

                        string sal = float.Parse(textSala.Text.Trim()).ToString("C2");
                        dgvCliente.Rows[FilasSelec.Index].Cells[3].Value = sal;

                        lsClientes.FirstOrDefault(c => c.Id == Convert.ToInt32(textID.Text.Trim())).Salario = float.Parse(textSala.Text.Trim());

                        MessageBox.Show("Se ha modificado el registro ");
                        limpiarCampos();
                        Cambiar(true);
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                }
            }
        }

        private void buttElimi_Click(object sender, EventArgs e)
        {

            if(dgvCliente.Rows.Count> 0)
            {
                if(MessageBox.Show("Esta seguro de eliminar el registro", "Borrado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataGridViewRow FilaSelect = dgvCliente
                }

            }

        }
    }
}
