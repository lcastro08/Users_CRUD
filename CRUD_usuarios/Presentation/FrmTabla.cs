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
        public int? id;
        MAESTRO_PR oTabla = null;
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
                CargaDatos();
        }

        private void CargaDatos()
        {
            using (Alumnos_DiProEntities db = new Alumnos_DiProEntities())
            {
                oTabla = db.MAESTRO_PR.Find(id);
                txtCorreo.Text = oTabla.CORREO;
                txtNombre.Text = oTabla.NOMBRE;
                dtpFecha.Value = oTabla.FECHA_NACIMIENTO.GetValueOrDefault();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Alumnos_DiProEntities db = new Alumnos_DiProEntities()) 
            {
                if (id == null)
                    oTabla = new MAESTRO_PR();

                //MAESTRO_PR oTable = new MAESTRO_PR();
                oTabla.NOMBRE = txtNombre.Text;
                oTabla.CORREO = txtCorreo.Text;
                oTabla.FECHA_NACIMIENTO = dtpFecha.Value;

                if(id==null)
                    db.MAESTRO_PR.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }
    }
}
