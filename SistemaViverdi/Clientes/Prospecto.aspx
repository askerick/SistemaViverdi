<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebMaster.Master" AutoEventWireup="true" CodeBehind="Prospecto.aspx.cs" Inherits="SistemaViverdi.Clientes.Prospecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/Prospecto.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <!-- page content -->
        <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Prospectos</h3>
              </div>

              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
              </div>
            </div>
            <div class="clearfix"></div>
     

            <div class="row">
              <div class="col-md-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Nuevo Prospecto <small></small></h2>
                   
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <br />
                    <form class="form-horizontal form-label-left input_mask">

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control has-feedback-left" id="txtNombre" placeholder="Nombre">
                        <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control" id="txtApellido" placeholder="Apellido">
                        <span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control has-feedback-left" id="txtCorreo" placeholder="Correo">
                        <span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control" id="txtCelular" placeholder="Celular">
                        <span class="fa fa-phone form-control-feedback right" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control has-feedback-left" id="txtEmpresa" placeholder="Empresa">
                        <span class="fa fa-building form-control-feedback left" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control" id="cboPais" placeholder="Pais">
                        <span class="fa fa-globe form-control-feedback right" aria-hidden="true"></span>
                      </div>
               <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control has-feedback-left" id="cboEstado" placeholder="Estado">
                        <span class="fa fa-building-o form-control-feedback left" aria-hidden="true"></span>
                      </div>

                      <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <input type="text" class="form-control" id="txtCiudad" placeholder="Ciudad">
                        <span class="fa fa-building-o form-control-feedback right" aria-hidden="true"></span>
                      </div>
   <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                    <input type="text" class="form-control" id="dllDireccion" placeholder="Dirección">
                        <span class="fa fa-road form-control-feedback right" aria-hidden="true"></span>
                      </div>

                     
                  <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Comentarios</label>
                    <div class="col-md-9 col-sm-9 col-xs-12">
                      <textarea class="resizable_textarea form-control" id="txtComentarios" placeholder="..."></textarea>
                    </div>
                  </div>
     <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Vendedor</label>
                    <div class="col-md-9 col-sm-9 col-xs-12">
                                     <select id="cboVendedor" class="selectpicker">
  <option value="0">Fernando</option>
  <option value="1">Azael</option>
  
</select>
                    </div>
                  </div>
     <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Publicidad</label>
                    <div class="col-md-9 col-sm-9 col-xs-12">
                                     <select id="cboPublicidad" class="selectpicker">
  <option value="0">Correo</option>
  <option value="1">Facebook</option>
   <option value="2">Recomendado</option>
  
</select>
                    </div>
                  </div>

                       <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Tipo pedido</label>
                    <div class="col-md-9 col-sm-9 col-xs-12">
                                     <select id="cboTipoPedido" class="selectpicker">
  <option value="0">Sistema de Riego</option>
  <option value="1">diseño Jardineria</option>
   <option value="2">Varios</option>
  
</select>
                    </div>
                  </div>
    <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Forma de Pago</label>
                    <div class="col-md-9 col-sm-9 col-xs-12">
                      <textarea class="resizable_textarea form-control" id="txtFormaPago" placeholder=""></textarea>
                    </div>
                  </div>

        



                
                   
                    
                      
                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-12 col-sm-9 col-xs-12 ">
                        
						   <button class="btn btn-primary" type="reset">Limpiar</button>
                          <button type="submit" onclick="guardarProspecto()" class="btn btn-success">Guardar</button>
                        </div>
                      </div>

                    </form>
                  </div>
                </div>

           

            


              </div>

        

       


         
          </div>
        </div>
        <!-- /page content -->
</asp:Content>
