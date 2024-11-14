using NTTDATAEXAMEN.BE;
using NTTDATAEXAMEN.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NTTDATAEXAMEN.vista
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.cargarComboGenero();
                //this.cargarComboNacionalidad();
                //this.cargarComboPerfil();

                UsuarioBE entity = new UsuarioBE();
                entity.apellido = "";
                entity.codigo = "";
                entity.idGenero = 0;
                entity.idNacionalidad = 0;
                entity.idPerfil = 0;
                this.ListarControlCliente();
                //this.ListarUsuario(entity);


            }
        }
        /*
        public void cargarComboGenero()
        {
            ddlGenero.Items.Add(new ListItem("--Seleccionar--", ""));
            ControlClienteBL extraBL = new ControlClienteBL();
            List<ControlClienteBE> list = extraBL.ListarGenero();

            foreach (var genero in list)
            {
                ddlGenero.Items.Add(new ListItem(genero.descripcion, genero.id.ToString()));
            }

        }
        public void cargarComboNacionalidad()
        {
            ddlNacionalidad.Items.Add(new ListItem("--Seleccionar--", ""));
            ControlClienteBL extraBL = new ControlClienteBL();
            List<NacionalidadBE> list = extraBL.ListarNacionalidad();

            foreach (var nacionalidad in list)
            {
                ddlNacionalidad.Items.Add(new ListItem(nacionalidad.descripcion, nacionalidad.id.ToString()));
            }

        }

        public void cargarComboPerfil()
        {
            ddlPerfil.Items.Add(new ListItem("--Seleccionar--", ""));
            ControlClienteBL extraBL = new ControlClienteBL();
            List<PerfilBE> list = extraBL.ListarPerfil();

            foreach (var perfil in list)
            {
                ddlPerfil.Items.Add(new ListItem(perfil.descripcion, perfil.id.ToString()));
            }

        }
        */
        public void ListarControlCliente()
        {
            this.hfDelete.Value = "0";

            ControlClienteBL controlClienteBL = new ControlClienteBL();
            List<ControlClienteBE> list = controlClienteBL.ListarControlCliente();            

            this.gvCliente.DataSource = list;
            this.gvCliente.DataBind();

            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
        }

        public void ListarUsuario(UsuarioBE entity)
        {
            this.hfDelete.Value = "0";

            UsuarioBL usuarioBL = new UsuarioBL();
            List<UsuarioListBE> list = usuarioBL.Listar(entity);

            this.gvCliente.DataSource = list;
            this.gvCliente.DataBind();

            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
        }


        /*
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.hfDelete.Value = "0";
            UsuarioBE entity = new UsuarioBE();
            entity.apellido = this.txtApellido.Text;
            entity.codigo = this.txtCodigo.Text;
            entity.idGenero = this.ddlGenero.SelectedValue.Equals("")? 0 : Convert.ToInt32(this.ddlGenero.SelectedValue);
            entity.idNacionalidad = this.ddlNacionalidad.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlNacionalidad.SelectedValue);
            entity.idPerfil = this.ddlPerfil.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlPerfil.SelectedValue);
            this.ListarUsuario(entity);
        }

        

        protected void gvUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.hfDelete.Value = "0";

            GridViewRow row = gvUsuario.Rows[e.NewEditIndex];
            string id = (row.FindControl("lblId2") as Label).Text;

            Response.Redirect("Crear.aspx?idUsuario=" + id);
        }

        protected void gvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvUsuario.Rows[e.RowIndex];
            string id = (row.FindControl("lblId2") as Label).Text;

            UsuarioBL UsuarioBL = new UsuarioBL();
            bool rpta = UsuarioBL.Delete(Convert.ToInt32(id));

            if (rpta)
            {
                UsuarioBE entity = new UsuarioBE();
                entity.apellido = this.txtApellido.Text;
                entity.codigo = this.txtCodigo.Text;
                entity.idGenero = this.ddlGenero.SelectedValue.Equals("") ? 0 :  Convert.ToInt32(this.ddlGenero.SelectedValue);
                entity.idNacionalidad = this.ddlNacionalidad.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlNacionalidad.SelectedValue);
                entity.idPerfil = this.ddlPerfil.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlPerfil.SelectedValue);
                this.ListarUsuario(entity);
                this.hfDelete.Value = id;
            }
            else
            {
                this.hfDelete.Value = "-1";
            }

        }
        */
        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.hfDelete.Value = "0";

                gvCliente.PageIndex = e.NewPageIndex;

                UsuarioBE entity = new UsuarioBE();
                entity.apellido = this.txtApellido.Text;
                entity.codigo = this.txtCodigo.Text;
                entity.idGenero = this.ddlGenero.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlGenero.SelectedValue);
                entity.idNacionalidad = this.ddlNacionalidad.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlNacionalidad.SelectedValue);
                entity.idPerfil = this.ddlPerfil.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlPerfil.SelectedValue);
                this.ListarControlCliente();

            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);//Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);//Console.WriteLine(ex.StackTrace);
            }
        }
            
    }
}