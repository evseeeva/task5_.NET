using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace task5
{
    public partial class ParamForm : Form
    {
        ParameterInfo[] paramInfo;
        public Object[] parameters;
        public ParamForm(ParameterInfo[] paramInfo)
        {
            InitializeComponent();
            this.paramInfo = paramInfo;
            parameters = new Object[1];
            label1.Text = $"{paramInfo[0].Name} (type: {paramInfo[0].ParameterType.Name})";
        }

       
        private void submitButton_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Equals("")) MessageBox.Show("No data entered");
            else
            {
                try
                {
                    Convert.ToDouble(textBox1.Text);
                    parameters[0] = Convert.ToDouble(textBox1.Text); ;
                    Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Wrong types!");
                }
            }

          
            
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
