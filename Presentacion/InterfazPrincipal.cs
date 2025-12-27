using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FontAwesome.Sharp;
using Interfaz.Formularios;
using pruebaLoading;
using Color = System.Drawing.Color;
using FontFamily = System.Drawing.FontFamily;

namespace Interfaz
{
    public partial class InterfazPrincipal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form formActual;

        Thread hilo1;

        public InterfazPrincipal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Formulario
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnHome.Visible = false;
            dtpFecFin.Value = DateTime.Today;
            dtpFecIni.Value = DateTime.Today;
        }

        private void InterfazPrincipal_Shown(object sender, EventArgs e)
        {
            if (txtIdTrab.Text.Equals("0"))
            {
                btnGastos.Visible = btnPreAdicional.Visible =
                btnPreLavado.Visible = btnPersonal.Visible = btnUser.Visible = false;

                panCaja.Visible = panGast.Visible = 
                panDeud.Visible = panNumDeud.Visible =
                panNumServ.Visible = panVent.Visible = false;

                chartCateSoli.Visible = chartVehServ.Visible = chartVent.Visible = false;

                dtpFecIni.Visible = dtpFecFin.Visible = lblSepDtp.Visible = false;
            }
            else
            {
                var dataTrab = Negocio.Trabajador.traerDatosPerfil(short.Parse(txtIdTrab.Text));
                foreach (var t in dataTrab)
                {
                    if (t.ocupacion.Equals("Lavador"))
                    {
                        btnGastos.Visible = false;
                        btnPreAdicional.Visible = false;
                        btnPreLavado.Visible = false;
                        btnPersonal.Visible = false;
                        btnAct.Visible = false;

                        panCaja.Visible = panGast.Visible =
                        panDeud.Visible = panNumDeud.Visible =
                        panNumServ.Visible = panVent.Visible = false;

                        chartCateSoli.Visible = chartVehServ.Visible = chartVent.Visible = false;

                        dtpFecIni.Visible = dtpFecFin.Visible = lblSepDtp.Visible = false;
                    }
                }
            }
        }

        private void graficosDonaBar_y_Datos()
        {
            while (true)
            {
                Series s1 = new Series("CategoriasVehiculos");
                s1.ChartType = SeriesChartType.Doughnut;
                s1.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
                s1.LabelForeColor = Color.WhiteSmoke;
                s1.IsValueShownAsLabel = true;
                s1.LabelFormat = "{0}%";

                if (chartCateSoli.InvokeRequired)
                {
                    chartCateSoli.Invoke(new MethodInvoker(delegate {

                        chartCateSoli.Series.Clear();
                        chartCateSoli.Series.Add(s1);

                    }));
                }
                else
                {
                    chartCateSoli.Series.Clear();
                    chartCateSoli.Series.Add(s1);
                }

                if (chartCateSoli.InvokeRequired)
                {
                    chartCateSoli.Invoke(new MethodInvoker(delegate {

                        var categoriasMasSolicitadas = Negocio.Estadistica.categoriasMasSolicitadas();
                        chartCateSoli.DataSource = categoriasMasSolicitadas;
                        chartCateSoli.Series[0].XValueMember = "descripcion";
                        chartCateSoli.Series[0].YValueMembers = "porcentaje";
                        chartCateSoli.DataBind();

                    }));
                }
                else
                {
                    var categoriasMasSolicitadas = Negocio.Estadistica.categoriasMasSolicitadas();
                    chartCateSoli.DataSource = categoriasMasSolicitadas;
                    chartCateSoli.Series[0].XValueMember = "descripcion";
                    chartCateSoli.Series[0].YValueMembers = "porcentaje";
                    chartCateSoli.DataBind();
                }

                
                Series s2 = new Series("Placas");
                s2.ChartType = SeriesChartType.Bar;
                s2.YValueType = ChartValueType.Int32;
                s2.Color = Color.FromArgb(255, 128, 0);

                if (chartVehServ.InvokeRequired)
                {
                    chartVehServ.Invoke(new MethodInvoker(delegate {

                        chartVehServ.Series.Clear();
                        chartVehServ.Series.Add(s2);

                    }));
                }
                else
                {
                    chartVehServ.Series.Clear();
                    chartVehServ.Series.Add(s2);
                }

                if (chartVehServ.InvokeRequired)
                {
                    chartVehServ.Invoke(new MethodInvoker(delegate {

                        var vehServicios = Negocio.Estadistica.topVehiculosServicios();
                        chartVehServ.DataSource = vehServicios;
                        chartVehServ.Series[0].XValueMember = "Veh";
                        chartVehServ.Series[0].YValueMembers = "CantServ";
                        chartVehServ.DataBind();
                        chartVehServ.Series[0].Sort(
                        System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending);

                    }));
                }
                else
                {
                    var vehServicios = Negocio.Estadistica.topVehiculosServicios();
                    chartVehServ.DataSource = vehServicios;
                    chartVehServ.Series[0].XValueMember = "Veh";
                    chartVehServ.Series[0].YValueMembers = "CantServ";
                    chartVehServ.DataBind();
                    chartVehServ.Series[0].Sort(
                    System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending);
                }

                if (lblCaja.InvokeRequired)
                {
                    lblCaja.Invoke(new MethodInvoker(delegate
                    {
                        List<ObjectParameter> datos = Negocio.Estadistica.datosInterfazPrincipal();
                        lblNumDeud.Text = datos[0].Value.ToString();
                        lblNumServ.Text = datos[1].Value.ToString();
                        lblGastos.Text = $"S/.{datos[2].Value.ToString()}";
                        lblDeudas.Text = $"S/.{datos[3].Value.ToString()}";
                        lblVentas.Text = $"S/.{datos[4].Value.ToString()}";
                        lblCaja.Text = $"S/.{datos[5].Value.ToString()}";
                    }));
                } else
                {
                    List<ObjectParameter> datos = Negocio.Estadistica.datosInterfazPrincipal();
                    lblNumDeud.Text = datos[0].Value.ToString();
                    lblNumServ.Text = datos[1].Value.ToString();
                    lblGastos.Text = $"S/.{datos[2].Value.ToString()}";
                    lblDeudas.Text = $"S/.{datos[3].Value.ToString()}";
                    lblVentas.Text = $"S/.{datos[4].Value.ToString()}";
                    lblCaja.Text = $"S/.{datos[5].Value.ToString()}";
                }

                // Se van actualizando los datos cada minuto
                Thread.Sleep(60000);
            }
        }

        private void graficoColumn()
        {
            Series s3 = new Series("Ventas");
            s3.ChartType = SeriesChartType.Column;
            s3.Color = Color.LimeGreen;
            s3.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9);
            s3.LabelForeColor = Color.Lime;
            s3.IsValueShownAsLabel = true;
            s3.XValueType = ChartValueType.Date;

            if (chartVent.InvokeRequired)
            {
                chartVent.Invoke(new MethodInvoker(delegate {

                    chartVent.Series.Clear();
                    chartVent.Series.Add(s3);

                }));
            }
            else
            {
                chartVent.Series.Clear();
                chartVent.Series.Add(s3);
            }

            if (chartVent.InvokeRequired)
            {
                chartVent.Invoke(new MethodInvoker(delegate {

                    var ventasGrafica = Negocio.Estadistica.ventasGraficas(dtpFecIni.Value, dtpFecFin.Value);
                    chartVent.DataSource = ventasGrafica;
                    chartVent.Series[0].XValueMember = "fecha_pedido";
                    chartVent.Series[0].YValueMembers = "ventas";
                    chartVent.DataBind();
                }));
            }
            else
            {
                var ventasGrafica = Negocio.Estadistica.ventasGraficas(dtpFecIni.Value,dtpFecFin.Value);
                chartVent.DataSource = ventasGrafica;
                chartVent.Series[0].XValueMember = "fecha_pedido";
                chartVent.Series[0].YValueMembers = "ventas";
                chartVent.DataBind();
            }
        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {
            hilo1 = new Thread(new ThreadStart(graficosDonaBar_y_Datos));
            hilo1.Start();
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        //Estructura
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(16, 195, 43);
            public static Color color9 = Color.FromArgb(237, 184, 121);

        }

        //metodos
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if(pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if(pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 49,84);
                currentBtn.Font = new Font(new FontFamily("Verdana"), 14);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Bordes izquierdos de los botones
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icono de inicio
                //IconoInicio.IconChar = currentBtn.IconChar;
                //IconoInicio.IconChar = Color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 49, 84);
                currentBtn.Font = new Font(new FontFamily("Verdana"), 13);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                btnHome.Visible = false;
                if(txtIdTrab.Text != "0")
                {
                    dtpFecIni.Visible = true;
                    dtpFecFin.Visible = true;
                    lblSepDtp.Visible = true;
                }
            }
        }

        private void OpenForm(Form form)
        {
            if (formActual != null)
            {
                //abrir solo formulario
                formActual.Close();
            }
            formActual = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(form);
            panelEscritorio.Tag = form;
            form.BringToFront();
            form.Show();
            btnHome.Visible = true;
            dtpFecIni.Visible = false;
            dtpFecFin.Visible = false;
            lblSepDtp.Visible = false;
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmVehiculo());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmServicio());
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmGasto());
        }

        private void btnPreLavado_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmPreLavado());
        }

        private void btnPreAdicional_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmPreAdicional());
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            FrmPersonal personal = new FrmPersonal();
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmPersonal());
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new FrmCaja());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FrmUser user = new FrmUser();
            ActivateButton(sender, RGBColors.color9);
            OpenForm(user);
            var dataTrab = Negocio.Trabajador.traerDatosPerfil(short.Parse(this.txtIdTrab.Text));
            foreach(var t in dataTrab)
            {
                user.txtIdPers.Text = t.id_Persona.ToString();
                user.txtNom.Text = t.nombres;
                user.txtApePat.Text = t.apellido_paterno;
                user.txtApeMat.Text = t.apellido_materno;
                user.txtTelef.Text = t.telefono;
                user.txtCorreo.Text = t.correo;
                user.txtUser.Text = t.usuario;
                user.lblOcup.Text = t.ocupacion;
                user.txtIdUser.Text = t.id_UL.ToString();
            }
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            WebClient webclient = new WebClient();

            try
            {
                if (!webclient.DownloadString("https://pastebin.com/raw/35ucfDtF").Contains("1.0.0"))
                {
                    if (MessageBox.Show("Hay una nueva versión disponible, ¿Desea actualizar?", "Actualización - Carwash Montevideo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start("Updater.exe");
                        this.Close();
                    }
                } else
                {
                    MessageBox.Show("Por el momento se encuentra con la última versión", "Actualización - Carwash Montevideo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //IconoInicio.IconChar = currentBtn.IconChar;
            //IconoInicio.IconColor = Color.White;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int Wparam, int lParam);

        private void PanelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            formActual.Close();
            Reset();
        }

        public void Alerta(string msg, frmAlert.enmType type)
        {
            frmAlert frm = new frmAlert();
            frm.mostrarAlerta(msg, type);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Alerta("Cuenta cerrada correctamente", frmAlert.enmType.Success);
            this.Hide();
            frmLogin login = new frmLogin();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            //Detener los subprocesos (threads)
            hilo1.Abort();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblFec.Text = DateTime.Now.ToLongDateString();
        }

        private void InterfazPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Detener los subprocesos (threads)
            hilo1.Abort();
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            graficoColumn();
        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            graficoColumn();
        }
    }
}
