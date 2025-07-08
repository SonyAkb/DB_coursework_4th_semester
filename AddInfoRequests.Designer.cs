namespace CourseworkDB
{
    partial class AddInfoRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInfoRequests));
            this.richTextBoxInfoRequest = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxInfoRequest
            // 
            this.richTextBoxInfoRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInfoRequest.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxInfoRequest.Location = new System.Drawing.Point(40, 41);
            this.richTextBoxInfoRequest.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxInfoRequest.Name = "richTextBoxInfoRequest";
            this.richTextBoxInfoRequest.ReadOnly = true;
            this.richTextBoxInfoRequest.Size = new System.Drawing.Size(350, 103);
            this.richTextBoxInfoRequest.TabIndex = 0;
            this.richTextBoxInfoRequest.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 199);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(350, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Visible = false;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAccept.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(40, 260);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(110, 40);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(278, 260);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 40);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(40, 175);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(350, 26);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddInfoRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(434, 336);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBoxInfoRequest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddInfoRequests";
            this.Text = "Ввод дополнительных параметров";
            this.Load += new System.EventHandler(this.AddInfoRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInfoRequest;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}