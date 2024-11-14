using NTTDATAEXAMEN.BE;
using NTTDATAEXAMEN.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NTTDATAEXAMEN.vista
{
    public partial class Crear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.cargarComboGenero();
                //this.cargarComboNacionalidad();
                //this.cargarComboPerfil();


                if (Request.QueryString["idUsuario"] != null)
                {
                    //ViewState["idUsuario"] = Request.QueryString["idUsuario"];
                    //this.obtenerUsuario();
           
                }
               
            }


        }

        /*public void cargarComboGenero()
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

        public void limpiarForm()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            ddlGenero.SelectedValue = "";
            ddlNacionalidad.SelectedValue = "";
            ddlPerfil.SelectedValue = "";
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivSuccessHide", "$('#divSuccess').hide();", true);
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivSuccessHide", "$('#divDanger').hide();", true);
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            

            
            UsuarioBE entity = new UsuarioBE();
            entity.codigo = txtCodigo.Text;
            entity.nombre = txtNombre.Text;
            entity.apellido = txtApellido.Text;
            entity.edad = Convert.ToInt32(txtEdad.Text);
            entity.correo = txtCorreo.Text;
            entity.idGenero = Convert.ToInt32(ddlGenero.SelectedValue);
            entity.idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue);
            entity.idPerfil = Convert.ToInt32(ddlPerfil.SelectedValue);

            bool rpta = false;
            UsuarioBL usuarioBL = new UsuarioBL();

            if (ViewState["idUsuario"] != null)
            {
                entity.id = Convert.ToInt32(txtId.Text);
                rpta = usuarioBL.Update(entity);
            }
            else
            {
                rpta = usuarioBL.Insertar(entity);
            }          

            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivSuccessHide", "$('#divSuccess').hide();", true);
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivSuccessHide", "$('#divDanger').hide();", true);

            if (rpta)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivSuccess", "$('#divSuccess').show();", true);

                if (ViewState["idUsuario"] != null)
                    this.lblAlert.Text = "El Usuario se actualizo correctamente.";
                else
                    this.limpiarForm();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "myDivDanger", "$('#divDanger').show();", true);
            }


            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
            

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarForm();
        }


        public void obtenerUsuario()
        {
            UsuarioBL clienteBL = new UsuarioBL();
            UsuarioBE entity = clienteBL.Get(Convert.ToInt32(ViewState["idUsuario"]));

            ControlClienteBL extraBL = new ControlClienteBL();
            List<ControlClienteBE> listG = extraBL.ListarGenero();
            List<NacionalidadBE> listN = extraBL.ListarNacionalidad();
            List<PerfilBE> listP = extraBL.ListarPerfil();

            var genero = listG.Where(l => l.id == entity.idGenero).FirstOrDefault();
            var nacionalidad = listN.Where(n => n.id == entity.idNacionalidad).FirstOrDefault();
            var perfil = listP.Where(p => p.id == entity.idPerfil).FirstOrDefault();


            this.lblTitulo.Text = "Editar Usuario";
            this.pnlId.Visible = true;
            this.txtId.Text = entity.id.ToString();
            this.txtId.Enabled = false;
            this.txtCodigo.Text = entity.codigo;
            this.txtNombre.Text = entity.nombre;
            this.txtApellido.Text = entity.apellido;
            this.txtEdad.Text = entity.edad.ToString();
            this.txtCorreo.Text = entity.correo;
            this.ddlGenero.SelectedValue = entity.idGenero.ToString();
            this.ddlGenero.Text = genero.descripcion;
            this.ddlNacionalidad.SelectedValue = entity.idNacionalidad.ToString();
            this.ddlNacionalidad.Text = nacionalidad.descripcion;
            this.ddlPerfil.SelectedValue = entity.idPerfil.ToString();
            this.ddlPerfil.Text = perfil.descripcion;
            this.btnGuardar.Text = "Actualizar";

        }*/
        
       
    }
}