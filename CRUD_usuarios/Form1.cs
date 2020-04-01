using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_usuarios.Models;

namespace CRUD_usuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refrescar();
        }


        #region HELPER
        private void refrescar ()
        {
            using (Alumnos_DiProEntities db = new Alumnos_DiProEntities()) //Crear objeto
            {
                var lst = from d in db.MAESTRO_PR
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla();
            oFrmTabla.ShowDialog();

            refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
