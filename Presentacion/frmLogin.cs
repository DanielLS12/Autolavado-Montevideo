using Interfaz;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaLoading
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        // Variable que servira para ocultar o visualizar la contraseña
        // 
        bool vision = true;

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int posY = 0;
        int posX = 0;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            //Para poder mover el formulario a través del panel de control
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Texts == "Usuario")
            {
                txtUsuario.Texts = "";
                txtUsuario.ForeColor = Color.FromArgb(0, 49, 84);
                icoUsuario.IconColor = Color.FromArgb(0, 49, 84);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Texts == "")
            {
                txtUsuario.Texts = "Usuario";
                txtUsuario.ForeColor = Color.Gainsboro;
                icoUsuario.IconColor = Color.Black;
            }
        }

        private void txtUsuario__TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Texts == "Usuario")
            {
                txtUsuario.ForeColor = Color.Gainsboro;
            }
            else
            {
                txtUsuario.ForeColor = Color.FromArgb(0, 49, 84);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Texts == "Contraseña")
            {
                txtPassword.Texts = "";
                txtPassword.ForeColor = Color.FromArgb(0, 49, 84);
                icoPass.IconColor = Color.FromArgb(0, 49, 84);
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Texts == "")
            {
                txtPassword.Texts = "Contraseña";
                txtPassword.ForeColor = Color.Gainsboro;
                icoPass.IconColor = Color.Black;
                icoVer.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                vision = true;
            }
        }

        private void txtPassword__TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Texts == "Contraseña")
            {
                txtPassword.ForeColor = Color.Gainsboro;
                icoVer.Visible = false;
                txtPassword.PasswordChar = false;
            }
            else
            {
                txtPassword.ForeColor = Color.FromArgb(0, 49, 84);
                if (txtPassword.Texts.Length > 0)
                {
                    icoVer.Visible = true;
                } else
                {
                    icoVer.Visible = false;
                    if(vision)
                    {
                        txtPassword.PasswordChar = true;
                        vision = true;
                    }
                }
            }
        }


        public void Alerta(string msg,frmAlert.enmType type)
        {
            frmAlert frm = new frmAlert();
            frm.mostrarAlerta(msg,type);
        }

        private void icoVer_Click(object sender, EventArgs e)
        {
            if (vision)
            {
                icoVer.IconChar = FontAwesome.Sharp.IconChar.Eye;
                vision = false;
                txtPassword.PasswordChar = false;
            }
            else
            {
                icoVer.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword.PasswordChar = true;
                vision = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPassword.Focus();
                e.Handled = true;
            }
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Texts.Trim();
            string password = txtPassword.Texts;
            label4.Visible = false;
            label5.Visible = false;


            if (string.IsNullOrEmpty(usuario) || usuario.Equals("Usuario"))
            {
                label4.Visible = true;
            }
            if (string.IsNullOrEmpty(password) || password.Equals("Contraseña"))
            {
                label5.Visible = true;
            }

            if (!label4.Visible && !label5.Visible)
            {
                try
                {
                    //Variables que seran usados para las validaciones más abajo
                    bool existeCuenta = false,estado_usuario = false;
                    int? id_Trab = 0;

                    //Declaración de una tarea para el proceso de verificación de la cuenta
                    var task = new Task(() =>
                    {
                        var cuenta = Negocio.Login.verificar(usuario, password);
                        existeCuenta = cuenta.Count > 0;
                        foreach(var c in cuenta)
                        {
                            estado_usuario = c.estado_usuario;
                            id_Trab = c.id_Trabajador;
                        }
                    });

                    //Ejecucion de la tarea
                    task.Start();

                    //Lo que se muestra en el botón mientras esta ejecutando la tarea
                    btnLogin.Enabled = false;
                    btnLogin.Text = "Cargando...";
                    btnLogin.BackColor = Color.LightGray;

                    //Una vez se obtenga un resultado de la tarea
                    await task;

                    //Volver a los valores predeterminados del botón
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Ingresar";
                    btnLogin.BackColor = Color.FromArgb(0, 49, 84);

                    if (existeCuenta)
                    {
                        if (estado_usuario)
                        {
                            Hide();
                            InterfazPrincipal interfazPrincipal = new InterfazPrincipal();
                            interfazPrincipal.FormClosed += (s, args) => this.Close();
                            interfazPrincipal.Show();
                            interfazPrincipal.txtIdTrab.Text = id_Trab.ToString();
                            if (id_Trab != 0)
                            {
                                interfazPrincipal.btnUser.Text = Negocio.Persona.traerNombreApellido((short)id_Trab);
                            }
                            Alerta("Cuenta iniciada correctamente", frmAlert.enmType.Success);
                        }
                        else
                        {
                           Alerta("Esta cuenta se encuentra inhabilitada", frmAlert.enmType.Error);
                        }
                    }
                    else
                    {
                        Alerta("Usuario y/o contraseña incorrecta, vuelva a intentarlo", frmAlert.enmType.Error);
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al iniciar sesión:" + ex.Message + ", vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }

            txtUsuario.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
