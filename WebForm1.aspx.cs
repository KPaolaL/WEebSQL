using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassMiAcessoSQL;
using System.Data.SqlClient;
using System.Data;

namespace WebPruebaAccesoSQL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClassAccesoSQL objacc = null;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objacc = new ClassAccesoSQL(@"Data Source = LAPTOP-SFMTQ4SG\SQLEXPRESS; Initial Catalog= BDTIENDA; Integrated Security = true;");
                Session["objacc"] = objacc;
            }
            else
            {
                objacc = (ClassAccesoSQL)Session["objacc"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection temp = null;
            string mensaje = " ";
            temp = objacc.AbrirConexion(ref mensaje);
            //  TextBox1.Text = mensaje;
            if (temp != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "123", "msgbox('Correcto', '" + mensaje + "', 'success')", true);
                temp.Close(); //Cerrar conexion 
                temp.Dispose(); //Destruir la conexion
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                   "1234", "msgbox('Incorrecto', '" + mensaje + "', 'error')", true);

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataReader caja = null;
            SqlConnection cnab = null;
            string m = "";
            cnab = objacc.AbrirConexion(ref m);
            //  TextBox1.Text = mensaje;
            if (cnab != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "123", "msgbox3('Correcto', '" + m + "', 'success')", true);
                caja = objacc.ConsultarReader("select * from EMPLEADO", cnab, ref m);
                if(caja!= null)
                {
                    ListBox1.Items.Clear();
                   while(caja.Read())
                    {
                        ListBox1.Items.Add(caja[0] + "" + caja["NOMBRE"]);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                       "mess77", "msgbox3('Peligro', '" + m + "', 'error')", true);
                }
                cnab.Close();
                cnab.Dispose();



            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                   "messg3B", "msgbox3('Peligro', '" + m + "', 'error')", true);

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet contenedor = null;
            SqlConnection cnab = null;
            string m = "";
            cnab = objacc.AbrirConexion(ref m);
            //  TextBox1.Text = mensaje;
            if (cnab != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "messg3B", "msgbox3('Correcto', '" + m + "', 'success')", true);
                contenedor = objacc.ConsultaDS("select * from EMPLEADO", cnab, ref m);
                cnab.Close();
                cnab.Dispose();
                if (contenedor != null)
                {
                    //la consulta es correcta y se muestran los datos
                    GridView1.DataSource = contenedor.Tables[0];
                    GridView1.DataBind();
                    Session["Tabla1"] = contenedor;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                       "mess77", "msgbox3('Peligro', '" + m + "', 'error')", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                   "messg88", "msgbox3('Peligro', '" + m + "', 'error')", true);

            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataSet t = Session["Tabla1"] as DataSet;
            ListBox1.Items.Clear();
            ListBox1.Items.Add("Datos recuperados del dataTable 0");
            DataRow registro = null;
            for(int w=t.Tables[0].Rows.Count-1; w>=0; w--)
            {
                registro = t.Tables[0].Rows[w];
                ListBox1.Items.Add(registro[0] + " -- " + registro[1]);
            }
        }
    }
}