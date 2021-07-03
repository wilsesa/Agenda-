using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text != string.Empty && txtNome.Text != string.Empty && txtTelefone.Text != string.Empty)
                {
                    //Capturar a string de conexão
                    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    System.Configuration.ConnectionStringSettings connString;
                    connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
                    //Cria um objeto de conexão
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = connString.ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into contato (nome,email,telefone) values (@nome,@email,@telefone)";
                    cmd.Parameters.AddWithValue("nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("telefone", txtTelefone.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    GridView1.DataBind();
                }
                else
                {
                    throw new Exception("Todos os campos são obrigatorios ... preencha os campos em branco");
                }
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('"+erro.Message+"'); </script>");
            }
            
        }
    }
}