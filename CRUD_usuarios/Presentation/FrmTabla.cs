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

namespace CRUD_usuarios.Presentation
{
    public partial class FrmTabla : Form
    {
        public FrmTabla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Alumnos_DiProEntities db = new Alumnos_DiProEntities()) 
            {
                MAESTRO_PR oTable = new MAESTRO_PR();
                oTable.NOMBRE = txtNombre.Text;
                oTable.CORREO = txtCorreo.Text;
                oTable.FECHA_NACIMIENTO = dtpFecha.Value;

                db.MAESTRO_PR.Add(oTable);
                db.SaveChanges();

                this.Close();
            }
        }
    }
}
