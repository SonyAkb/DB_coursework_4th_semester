using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;
using LibInfo;

namespace CourseworkDB
{
    public partial class WorkForm : Form
    {
        private string currentTable = " ";
        private bool flagDifUser = false;
        
        public WorkForm()
        {
            InitializeComponent();
            this.FormClosing += WorkForm_FormClosing;
        }


        private void WorkForm_Load(object sender, EventArgs e)
        {
            LoadTables();
            LoadViewes();
            ShowChangeButtons(false, false, true);

            richTextBoxInfo.Left = (this.ClientSize.Width - richTextBoxInfo.Width) / 2;
            dataGridViewResult.Left = (this.ClientSize.Width - dataGridViewResult.Width) / 2;

            buttonChange.Left = (this.ClientSize.Width - buttonChange.Width) / 2;
            buttonSave.Left = dataGridViewResult.Left + buttonSave.Width / 3;
            buttonCancel.Left = dataGridViewResult.Right - buttonCancel.Width - buttonSave.Width / 3;

            this.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color1);
            this.ForeColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color2);

            richTextBoxInfo.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
            
            dataGridViewResult.BackgroundColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
            dataGridViewResult.GridColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color4);

            buttonChange.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
            buttonSave.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
            buttonCancel.BackColor = ColorTranslator.FromHtml(LibInfo.ThemeColors.color3);
        }

        private void LoadTables()
        {
            toolStripDropDownButtonTableMenu.DropDownItems.Clear();

            List<string> listTable = NeedData.DB.GetTables();
            listTable.Sort();

            foreach (string table in listTable)
            {
                var item1 = new ToolStripMenuItem(Data.localizationDictionary[table]);
                Func<DataTable> loadTableFunc = NeedData.DB.GetTableViewDataFunction(table, NeedData.DB.GetTables);
                item1.Click += (sender, e) =>
                {
                    currentTable = table;
                    DataTable data = loadTableFunc();
                    dataGridViewResult.DataSource = data;
                    ChangeAccess("Текущая таблица:", Data.localizationDictionary[table]);
                };
                toolStripDropDownButtonTableMenu.DropDownItems.Add(item1);
            }
        }

        private void LoadViewes()
        {
            toolStripDropDownButtonViewMenu.DropDownItems.Clear();

            List<string> listView = NeedData.DB.GetViews();
            listView.Sort();

            foreach (string table in listView)
            {
                var item1 = new ToolStripMenuItem(Data.localizationDictionary[table]);

                string currentTable = table;// Создаем локальную копию table для замыкания
                if (Data.listCastomRequest.Contains(table))
                {
                    item1.Click += (sender, e) =>
                    {
                        _ = HandleSpecialRequestAsync(currentTable);
                    };
                }
                else
                {
                    Func<DataTable> loadTableFunc = NeedData.DB.GetTableViewDataFunction(table, NeedData.DB.GetViews);

                    item1.Click += (sender, e) =>
                    {
                        currentTable = table;
                        DataTable data = loadTableFunc();
                        dataGridViewResult.DataSource = data;
                        ShowChangeButtons(false, false, true);
                        ChangeAccess("Текущее представление:", Data.localizationDictionary[currentTable]);
                    };
                    
                }
                toolStripDropDownButtonViewMenu.DropDownItems.Add(item1);
            }
        }

        private async Task HandleSpecialRequestAsync(string table)
        {
            using (AddInfoRequests addInfo = new AddInfoRequests(Data.listCastomRequest.IndexOf(table)))
            {
                if (addInfo.ShowDialog() == DialogResult.OK)
                {
                    string selectedValue = addInfo.SelectedValue;

                    DataTable data = await Task.Run(() => GetDataForRequest(table, selectedValue));
                    dataGridViewResult.Invoke((MethodInvoker)(() => dataGridViewResult.DataSource = data));
                }
            }
        }

        private DataTable GetDataForRequest(string table, string value)
        {
            switch (Data.listCastomRequest.IndexOf(table))
            {
                case 0: return NeedData.DB.GetOrdersWithStatus(value);
                case 1: return NeedData.DB.GetRegionWarehouseStock(value);
                case 2: return NeedData.DB.GetTopCustomersLastQuarter(int.Parse(value));
                default: return null;
            }
        }

        private void AnotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Вы уверены, что хотите сменить пользователя?",
                               "Подтверждение",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                flagDifUser = true;
                foreach (var form in Application.OpenForms.OfType<WorkForm>().ToList())
                {
                    form.Close();
                }
                Program.MainLoginForm.SafeShow();
                Program.MainLoginForm.ClearFields();
            }
        }

        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flagDifUser)// flagDifUser = true когда пользователь сам инициировал смену аккаунта
            {
                Application.Exit();
                return;
            }
            if (Application.OpenForms.OfType<WorkForm>().Count() == 1)// Если это последняя форма WorkForm - закрываем приложение
            {
                Program.ExitApplication();
            }// Иначе просто закрываем текущую форму (другие WorkForm остаются открытыми)
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Вы уверены, что хотите выйти?",
                               "Подтверждение",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Program.ExitApplication();
            }
        }

        private void toolStripSplitButtonExit_ButtonClick(object sender, EventArgs e)
        {
            ExitToolStripMenuItem_Click(sender, e);
        }

        private void dataGridViewResult_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            buttonChange.Enabled = true;
        }

        private void ChangeAccess(string message1, string message2 = "", string message3 = "")
        {
            buttonChange.Visible = false;
            richTextBoxInfo.Text = $"{message1} {message2} {message3}";

            if(NeedData.DB.CurrentPrivileges.Count > 1)
            {
                buttonChange.Visible = true;
            }
        }

        private void ShowChangeButtons(bool condition1, bool condition2, bool condition3, bool condition4 = true)
        {
            buttonCancel.Visible = condition1;
            buttonSave.Visible = condition1;
            buttonChange.Visible = condition2;
            dataGridViewResult.ReadOnly = condition3;
            toolStripTopMenu.Enabled = condition4;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            ShowChangeButtons(true, false, false, false);
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, есть ли несохраненные ошибки
                if (dataGridViewResult.IsCurrentCellDirty)
                {
                    dataGridViewResult.EndEdit();
                }

                if (dataGridViewResult.DataSource == null)
                {
                    CustomMessageBox.Show("Нет данных для сохранения");
                    return;
                }
                ShowChangeButtons(false, true, true);

                if (dataGridViewResult.DataSource is DataTable dataTable)
                {
                    using (MySqlConnection conn = new MySqlConnection(NeedData.DB.connectionString))
                    {
                        
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {currentTable}", conn);
                        MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                        adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                        adapter.InsertCommand = commandBuilder.GetInsertCommand();
                        adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                        int updatedRows = adapter.Update(dataTable);
                        CustomMessageBox.Show($"Сохранено изменений: {updatedRows}");

                        dataTable.AcceptChanges();// Обновляем DataGridView
                       
                    }
                }
            }
            catch (FormatException ex)
            {
                CustomMessageBox.Show(
                    $"Ошибка формата данных: {ex.Message}\nПроверьте введенные значения.",
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                buttonCancel_Click(sender, e);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(
                    $"Ошибка при сохранении: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                buttonCancel_Click(sender, e);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ShowChangeButtons(false, true, true);

            if (dataGridViewResult.DataSource is DataTable dataTable)
            { 
                dataTable.RejectChanges();// Откатываем все изменения
                dataGridViewResult.Refresh();// Обновляем отображение
                CustomMessageBox.Show("Изменения отменены!");
            }
        }

        private void toolStripButtonNewWindow_Click(object sender, EventArgs e)
        {
            var workForm = new WorkForm();
            workForm.Show();
        }

        private void dataGridViewResult_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true; // Отменяем стандартное сообщение об ошибке

            // Получаем название столбца, где произошла ошибка
            string columnName = dataGridViewResult.Columns[e.ColumnIndex].HeaderText;

            // Определяем тип ожидаемых данных
            Type expectedType = dataGridViewResult.Columns[e.ColumnIndex].ValueType;

            CustomMessageBox.Show(
                $"Некорректное значение в столбце '{columnName}'. " +
                $"Ожидается тип данных: {expectedType?.Name ?? "не определен"}",
                "Ошибка ввода",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            // Откатываем изменения в текущей ячейке
            if (dataGridViewResult.IsCurrentCellDirty)
            {
                dataGridViewResult.CancelEdit();
            }
        }

        
    }
}
