using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibInfo;

namespace CourseworkDB
{
    public partial class AddInfoRequests : Form
    {
        int type;
        public string SelectedValue { get; private set; } // Добавляем свойство для хранения результата

        public AddInfoRequests(int typeOfRequests)
        {
            InitializeComponent();
            type = typeOfRequests;
        }

        private void AddInfoRequests_Load(object sender, EventArgs e)
        {
            richTextBoxInfoRequest.Text = Data.listSpecialRequest[type];
            switch (type)
            {
                case 0:
                    LoadRequestComboBox(NeedData.listStatusOrder);
                    break;
                case 1:
                    LoadRequestComboBox(NeedData.listRegion);
                    break;
                case 2:
                    LoadСustomersWithMostOrders();
                    break;
            }

            buttonAccept.Left = richTextBoxInfoRequest.Left;
            buttonCancel.Left = richTextBoxInfoRequest.Right - buttonCancel.Width;

            

            foreach (Control control in this.Controls)
            {
                if(!(control is Button))
                {
                    control.Left = (this.ClientSize.Width - control.Width) / 2;
                }
                control.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
                control.ForeColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color2);
            }

            this.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color1);
            this.ForeColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color2);
        }

        private void LoadRequestComboBox(List<string> list)
        {
            comboBox1.Visible = true;
            numericUpDown1.Visible = false;

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(list.ToArray());
        }

        private void LoadСustomersWithMostOrders()
        {
            comboBox1.Visible = false;
            numericUpDown1.Visible = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (type != 2 && comboBox1.SelectedItem == null)
            {
                CustomMessageBox.Show("Необходимо выбрать значение из списка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (type == 2 && numericUpDown1.Value <= 0)
            {
                CustomMessageBox.Show("Период должен быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectedValue = type == 2 ? numericUpDown1.Value.ToString() : comboBox1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
