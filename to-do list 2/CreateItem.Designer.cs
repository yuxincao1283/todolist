namespace to_do_list_2
{
    partial class CreateItem
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
            TitleBox = new TextBox();
            DescriptionBox = new RichTextBox();
            ComboBox = new ComboBox();
            DateTimePicker = new DateTimePicker();
            TimePicker = new DateTimePicker();
            CustomRepeatDays = new TextBox();
            SaveItem = new Button();
            SuspendLayout();
            // 
            // TitleBox
            // 
            TitleBox.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            TitleBox.ForeColor = Color.DarkGray;
            TitleBox.Location = new Point(12, 12);
            TitleBox.Name = "TitleBox";
            TitleBox.Size = new Size(237, 25);
            TitleBox.TabIndex = 0;
            TitleBox.Text = "Add title";
            TitleBox.TextChanged += textBox1_TextChanged;
            TitleBox.Enter += TitleBox_Enter;
            TitleBox.Leave += TitleBox_Leave;
            // 
            // DescriptionBox
            // 
            DescriptionBox.AutoWordSelection = true;
            DescriptionBox.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            DescriptionBox.ForeColor = Color.DarkGray;
            DescriptionBox.Location = new Point(12, 148);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(302, 228);
            DescriptionBox.TabIndex = 1;
            DescriptionBox.Text = "Add description";
            DescriptionBox.TextChanged += DescriptionBox_TextChanged;
            DescriptionBox.Enter += DescriptionBox_Enter;
            DescriptionBox.Leave += DescriptionBox_Leave;
            // 
            // ComboBox
            // 
            ComboBox.DisplayMember = "No repeats";
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "No repeats", "Daily", "Weekly", "Yearly", "Custom" });
            ComboBox.Location = new Point(12, 102);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(162, 28);
            ComboBox.TabIndex = 6;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(12, 58);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(162, 27);
            DateTimePicker.TabIndex = 5;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // TimePicker
            // 
            TimePicker.Format = DateTimePickerFormat.Custom;
            TimePicker.Location = new Point(180, 58);
            TimePicker.Name = "TimePicker";
            TimePicker.ShowUpDown = true;
            TimePicker.Size = new Size(134, 27);
            TimePicker.TabIndex = 7;
            TimePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // CustomRepeatDays
            // 
            CustomRepeatDays.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Italic);
            CustomRepeatDays.ForeColor = Color.DarkGray;
            CustomRepeatDays.Location = new Point(180, 103);
            CustomRepeatDays.Name = "CustomRepeatDays";
            CustomRepeatDays.Size = new Size(134, 25);
            CustomRepeatDays.TabIndex = 8;
            CustomRepeatDays.Text = "Days for repeat";
            CustomRepeatDays.Visible = false;
            CustomRepeatDays.Enter += CustomRepeatDays_Enter;
            CustomRepeatDays.KeyPress += CustomRepeatDays_KeyPress;
            CustomRepeatDays.Leave += CustomRepeatDays_Leave;
            // 
            // SaveItem
            // 
            SaveItem.Location = new Point(255, 9);
            SaveItem.Name = "SaveItem";
            SaveItem.Size = new Size(59, 30);
            SaveItem.TabIndex = 9;
            SaveItem.Text = "Save";
            SaveItem.UseVisualStyleBackColor = true;
            SaveItem.Click += button1_Click;
            // 
            // CreateItem
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 386);
            Controls.Add(SaveItem);
            Controls.Add(CustomRepeatDays);
            Controls.Add(TimePicker);
            Controls.Add(ComboBox);
            Controls.Add(DateTimePicker);
            Controls.Add(DescriptionBox);
            Controls.Add(TitleBox);
            Name = "CreateItem";
            Text = "Form2";
            Load += CreateItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TitleBox;
        private RichTextBox DescriptionBox;
        private ComboBox ComboBox;
        private DateTimePicker DateTimePicker;
        private DateTimePicker TimePicker;
        private TextBox CustomRepeatDays;
        private Button SaveItem;
    }
}