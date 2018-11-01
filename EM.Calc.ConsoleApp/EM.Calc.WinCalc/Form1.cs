using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM.Calc.WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Core.Calc Calc { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calc = new Core.Calc();
            
                string[] operations = Calc.Operations
                .Select(o => o.Name)
                .ToArray();

            cbOperation.Items.AddRange(operations);
        }

        private void btnExec_Click(object sender, EventArgs e)
        {

            try
            {
                var values = tbinput.Text
                .Split(' ').Select(Convert.ToDouble)
                .ToArray();
                var operation = cbOperation.Text;
                var result = Calc.Execute(operation, values);
                lblResult.Text = $"{result}";
            }
            catch
            {
                MessageBox.Show("Неккоректный ввод");
            }


        }

        private void tbinput_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 32 && number != 44 ) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operation = Calc.Operations
                .Where(o => o.Name == cbOperation.Text)
                .FirstOrDefault();

            var ope = (IExtOperation)operation;

            toolTip1.SetToolTip(cbOperation, ope.Description);
        }
    }
}
