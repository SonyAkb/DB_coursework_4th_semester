using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using LibInfo;

namespace CourseworkDB
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadRoles();
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoadRoles()
        {
            //textBoxUsername.Text = "sysadmin";
            //textBoxPassword.Text = "adminpass987";

            textBoxUsername.Text = "order_specialist";
            textBoxPassword.Text = "orderpass456";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Left = (this.ClientSize.Width - control.Width) / 2;
                if(!(control is Label))
                {
                    control.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
                    control.ForeColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color2);
                }
                
            }

            this.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color1);
            this.ForeColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color2);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                CustomMessageBox.Show("Пожалуйста, заполните все поля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string actualRole;
                bool isValidUser = NeedData.DB.ValidateUser(username, password, out actualRole);

                if (!isValidUser)
                {
                    CustomMessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isValidUser)
                {
                    this.Hide();
                    new WorkForm().Show();
                }
            }
            catch (Exception ex)
            {
                 CustomMessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Application.OpenForms.OfType<WorkForm>().Count() == 0)// Если закрывается форма входа, а рабочих окон нет
            {
                base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = true;// Если есть рабочие окна, просто скрываем форму входа
                this.Hide();
            }
        }

        public void ClearFields()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1) // Если это последняя форма
            {
                Application.Exit();// Если закрывается форма входа, закрываем все приложение
            }
        }

        public void SafeShow()
        {
            if (this.IsDisposed)
            {
                Program.MainLoginForm = new LoginForm();
                Program.MainLoginForm.Show();
            }
            else
            {
                this.Show();
            }
        }
    }
}
