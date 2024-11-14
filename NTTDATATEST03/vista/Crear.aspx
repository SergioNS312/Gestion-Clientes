<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="NTTDATAEXAMEN.vista.Crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Crear</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript"> 

        $(document).ready(function () {

            $('#ContentPlaceHolder1_btnGuardar').on("click", function () {
                var codigo = $("#ContentPlaceHolder1_txtCodigo").val();
                var nombre = $("#ContentPlaceHolder1_txtNombre").val();
                var apellido = $("#ContentPlaceHolder1_txtApellido").val();
                var edad = $("#ContentPlaceHolder1_txtEdad").val();
                var correo = $("#ContentPlaceHolder1_txtCorreo").val();
                var genero = $("#ContentPlaceHolder1_ddlGenero").val();
                var nacionalidad = $("#ContentPlaceHolder1_ddlNacionalidad").val();
                var perfil = $("#ContentPlaceHolder1_ddlPerfil").val();

                if (codigo != '' && nombre != '' && apellido != '' && edad != '' && correo != '' && genero != ''
                    && nacionalidad != 0 && perfil != 0 && isNaN(edad) && /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(correo) && correo.length == 5 && edad >= 18)
                    $('#divLoading').show();
            });

        });

    </script>

    <h2>
        <asp:Label ID="lblTitulo" runat="server" Text="Crear Usuario"></asp:Label>
    </h2>

    <div class="container">

        <div class="row">
            <div class="col">
                <div id="divSuccess" class="alert alert-success" role="alert" style="display: none;">
                    <asp:Label ID="lblAlert" runat="server" Text="El Usuario se registro correctamente."></asp:Label>
                </div>
                <div id="divDanger" class="alert alert-danger" role="alert" style="display: none;">
                    Se ha producido un error
                </div>
            </div>
        </div>

         <asp:Panel ID="pnlId" runat="server" Visible="false">
            <div class="row">
                <div class="col-4">
                    <div class="mb-1">
                        <asp:Label ID="lblId" runat="server" CssClass="form-label" Text="Id: "></asp:Label>
                        <asp:TextBox ID="txtId" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <div class="row">
        <div class="col-4">
            <div class="mb-1">
            <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" Text="Codigo: "></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" CssClass="text-error" ErrorMessage="Ingrese Codigo" ControlToValidate="txtCodigo"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCodigo" runat="server" CssClass="text-error"   
                ErrorMessage="Él Codigo debe ser de 5 caracteres"
                ControlToValidate="txtCodigo"
                ValidationExpression="^[a-zA-Z0-9'@&#.\s]{5}$" />
                </div>
         </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombres: "></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" CssClass="text-error" ErrorMessage="Ingrese Nombre" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblApellido" runat="server" CssClass="form-label" Text="Apellidos: "></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" CssClass="text-error" ErrorMessage="Ingrese Apellido" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblEdad" runat="server" CssClass="form-label" Text="Edad: "></asp:Label>
                    <asp:TextBox ID="txtEdad" Type="Integer" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEdad" runat="server" display=dynamic CssClass="text-error" ErrorMessage="Ingrese Edad" ControlToValidate="txtEdad"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEdad"  runat="server" CssClass="text-error" ValidationExpression="^([0-9])*$" ErrorMessage="Ingresa solo numeros. " ControlToValidate="txtEdad"
                       >
                        
                    </asp:RegularExpressionValidator>
                   <asp:RangeValidator runat="server" Type="Integer" CssClass="text-error" ControlToValidate="txtEdad" ErrorMessage="La edad debe ser mayor e igual a 18 años"
                     MinimumValue="18" MaximumValue="9999" >

                                            </asp:RangeValidator>
                    
                </div>
            </div>
        </div>

        <div class="row">
        <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblCorreo" runat="server" CssClass="form-label" Text="Correo: "></asp:Label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" CssClass="text-error" ErrorMessage="Ingrese Correo" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" CssClass="text-error" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ErrorMessage="El correo tiene el formato incorrecto" ControlToValidate="txtCorreo"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblGenero" runat="server" CssClass="form-label" Text="Genero: "></asp:Label>
                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGenero" runat="server" CssClass="text-error" ErrorMessage="Seleccionar Genero" ControlToValidate="ddlGenero"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblNacionalidad" runat="server" CssClass="form-label" Text="Nacionalidad: "></asp:Label>
                    <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" CssClass="text-error" ErrorMessage="Seleccionar Nacionalidad" ControlToValidate="ddlNacionalidad"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1">
                    <asp:Label ID="lblPerfil" runat="server" CssClass="form-label" Text="Perfil: "></asp:Label>
                    <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPerfil" runat="server" CssClass="text-error" ErrorMessage="Seleccionar Perfil" ControlToValidate="ddlPerfil"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div class="mb-1 mt-4">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-primary" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </div>
            </div>
        </div>



    </div>




    <div id="divLoading" class="div-loading" style="display: none;">
        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/img/loading.gif" />
    </div>

</asp:Content>
