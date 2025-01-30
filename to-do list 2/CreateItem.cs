using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace to_do_list_2
{

    public partial class CreateItem : Form
    {

        private const string DefaultText = "Days for repeat";
        private const string TextBoxDefaultFont = "Arial Rounded MT Bold";
        private Color DefaultColor = Color.DarkGray;
        private const string EmptyString = "";
        private const int DefaultFont_size = 9;
        private MainList parent;
        public CreateItem()
        {
            InitializeComponent();
        }

        //#TO-DO LIST:
        /* 
         * Add restriction to the amount of text the title can hold 
         * Add restriction to the amount of text description can hold
         * Add cloud support
         * Add error handling for entering date before today's date
         */

        public void whosmydaddy(MainList daddy)
        {
            this.parent = daddy;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CreateItem_Load(object sender, EventArgs e)
        {
            this.TimePicker.CustomFormat = "HH:mm";
            this.ComboBox.SelectedIndex = 0;
        }

        private void DescriptionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox.SelectedIndex == 4)
            {
                //make right text box appear
                this.CustomRepeatDays.Visible = true;
            }
            else
            {
                //make it disappear
                this.CustomRepeatDays.Visible = false;
            }
        }


        private void CustomRepeatDays_Enter(object sender, EventArgs e)
        {
            if (this.CustomRepeatDays.Font.Name == TextBoxDefaultFont
            && this.CustomRepeatDays.Text == DefaultText)
            {
                this.CustomRepeatDays.Font = new Font("Microsoft YaHei UI", DefaultFont_size);
                this.CustomRepeatDays.Text = EmptyString;
                this.CustomRepeatDays.ForeColor = Color.Black;
            }
        }
        private void CustomRepeatDays_Leave(object sender, EventArgs e)
        {
            if (this.CustomRepeatDays.Text == EmptyString)
            {
                this.CustomRepeatDays.Font = new Font(TextBoxDefaultFont, DefaultFont_size, FontStyle.Italic);
                this.CustomRepeatDays.Text = DefaultText;
                this.CustomRepeatDays.ForeColor = DefaultColor;
                //this.CustomRepeatDays.Font.Italic = true;
            }
        }

        private void CustomRepeatDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = this.TitleBox.Text;
            string description = this.DescriptionBox.Text;
            DateTime date = this.DateTimePicker.Value;
            DateTime time = this.TimePicker.Value;

            DateTime fullDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);

            int repeatingDays = -1;
            int repeats = this.ComboBox.SelectedIndex;

            ListEntry entry = new ListEntry(title, description, fullDate, repeats, repeatingDays);
            this.parent.receiveEntry(entry);

            //close form

            Close();
        }

        private void DescriptionBox_Leave(object sender, EventArgs e)
        {
            if (this.DescriptionBox.Text == EmptyString)
            {
                this.DescriptionBox.Font = new Font(TextBoxDefaultFont, DefaultFont_size, FontStyle.Italic);
                this.DescriptionBox.Text = "Add description";
                this.DescriptionBox.ForeColor = DefaultColor;
            }
        }

        private void DescriptionBox_Enter(object sender, EventArgs e)
        {
            if (this.DescriptionBox.Font.Name == TextBoxDefaultFont
            && this.DescriptionBox.Text == "Add description")
            {
                this.DescriptionBox.Font = new Font("Microsoft YaHei UI", DefaultFont_size);
                this.DescriptionBox.Text = EmptyString;
                this.DescriptionBox.ForeColor = Color.Black;
            }
        }

        private void TitleBox_Enter(object sender, EventArgs e)
        {
            if (this.TitleBox.Font.Name == TextBoxDefaultFont
            && this.TitleBox.Text == "Add title")
            {
                this.TitleBox.Font = new Font("Microsoft YaHei UI", DefaultFont_size);
                this.TitleBox.Text = EmptyString;
                this.TitleBox.ForeColor = Color.Black;
            }
        }

        private void TitleBox_Leave(object sender, EventArgs e)
        {
            if (this.TitleBox.Text == EmptyString)
            {
                this.TitleBox.Font = new Font(TextBoxDefaultFont, DefaultFont_size, FontStyle.Italic);
                this.TitleBox.Text = "Add title";
                this.TitleBox.ForeColor = DefaultColor;
            }
        }

    }
}
