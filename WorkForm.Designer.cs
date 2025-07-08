namespace CourseworkDB
{
    partial class WorkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripTopMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonTableMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonViewMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSplitButtonExit = new System.Windows.Forms.ToolStripSplitButton();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другойПользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonNewWindow = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.toolStripTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripTopMenu
            // 
            this.toolStripTopMenu.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTopMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonTableMenu,
            this.toolStripDropDownButtonViewMenu,
            this.toolStripSplitButtonExit,
            this.toolStripButtonNewWindow});
            this.toolStripTopMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripTopMenu.Name = "toolStripTopMenu";
            this.toolStripTopMenu.Size = new System.Drawing.Size(634, 27);
            this.toolStripTopMenu.TabIndex = 2;
            this.toolStripTopMenu.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonTableMenu
            // 
            this.toolStripDropDownButtonTableMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTableMenu.Image")));
            this.toolStripDropDownButtonTableMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTableMenu.Name = "toolStripDropDownButtonTableMenu";
            this.toolStripDropDownButtonTableMenu.Size = new System.Drawing.Size(104, 24);
            this.toolStripDropDownButtonTableMenu.Text = "Таблица";
            // 
            // toolStripDropDownButtonViewMenu
            // 
            this.toolStripDropDownButtonViewMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonViewMenu.Image")));
            this.toolStripDropDownButtonViewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonViewMenu.Name = "toolStripDropDownButtonViewMenu";
            this.toolStripDropDownButtonViewMenu.Size = new System.Drawing.Size(160, 24);
            this.toolStripDropDownButtonViewMenu.Text = "Представление";
            // 
            // toolStripSplitButtonExit
            // 
            this.toolStripSplitButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButtonExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.другойПользовательToolStripMenuItem});
            this.toolStripSplitButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonExit.Image")));
            this.toolStripSplitButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonExit.Name = "toolStripSplitButtonExit";
            this.toolStripSplitButtonExit.Size = new System.Drawing.Size(90, 24);
            this.toolStripSplitButtonExit.Text = "Выход";
            this.toolStripSplitButtonExit.ButtonClick += new System.EventHandler(this.toolStripSplitButtonExit_ButtonClick);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // другойПользовательToolStripMenuItem
            // 
            this.другойПользовательToolStripMenuItem.Name = "другойПользовательToolStripMenuItem";
            this.другойПользовательToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.другойПользовательToolStripMenuItem.Text = "Другой пользователь";
            this.другойПользовательToolStripMenuItem.Click += new System.EventHandler(this.AnotherToolStripMenuItem_Click);
            // 
            // toolStripButtonNewWindow
            // 
            this.toolStripButtonNewWindow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonNewWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewWindow.Image")));
            this.toolStripButtonNewWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewWindow.Name = "toolStripButtonNewWindow";
            this.toolStripButtonNewWindow.Size = new System.Drawing.Size(121, 24);
            this.toolStripButtonNewWindow.Text = "Новое окно";
            this.toolStripButtonNewWindow.Click += new System.EventHandler(this.toolStripButtonNewWindow_Click);
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewResult.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResult.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridViewResult.Location = new System.Drawing.Point(16, 107);
            this.dataGridViewResult.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            this.dataGridViewResult.RowHeadersWidth = 51;
            this.dataGridViewResult.RowTemplate.Height = 24;
            this.dataGridViewResult.Size = new System.Drawing.Size(604, 306);
            this.dataGridViewResult.TabIndex = 3;
            this.dataGridViewResult.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResult_CellValueChanged);
            this.dataGridViewResult.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewResult_DataError);
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonChange.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(250, 435);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(156, 62);
            this.buttonChange.TabIndex = 4;
            this.buttonChange.Text = "Изменить таблицу";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(16, 437);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSave.MinimumSize = new System.Drawing.Size(165, 48);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(165, 61);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(455, 434);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(165, 48);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(165, 63);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отменить изменения";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxInfo.Location = new System.Drawing.Point(16, 35);
            this.richTextBoxInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxInfo.Size = new System.Drawing.Size(604, 66);
            this.richTextBoxInfo.TabIndex = 9;
            this.richTextBoxInfo.Text = "";
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.toolStripTopMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "WorkForm";
            this.Text = "База данных ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkForm_FormClosing);
            this.Load += new System.EventHandler(this.WorkForm_Load);
            this.toolStripTopMenu.ResumeLayout(false);
            this.toolStripTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStripTopMenu;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonExit;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другойПользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTableMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonViewMenu;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewWindow;
    }
}