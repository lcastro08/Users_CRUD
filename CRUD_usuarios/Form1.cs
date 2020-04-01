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

        private int? GetId()
        {
            try
            {
              return  int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla();
            oFrmTabla.ShowDialog();

            refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null )
            {
                Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla(id);
                oFrmTabla.ShowDialog();

                refrescar();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
              using(Alumnos_DiProEntities db = new Alumnos_DiProEntities())
                {
                    MAESTRO_PR oTabla = db.MAESTRO_PR.Find(id);
                    db.MAESTRO_PR.Remove(oTabla);

                    db.SaveChanges();
                }

                refrescar();
            }
        }
    }
}
