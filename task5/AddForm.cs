using System;
using ClassLibrary;
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
    public partial class AddForm : Form
    {   public IDevice newObject;
        Type type;
        
        public AddForm(Type t)
        {
            InitializeComponent();
            this.type = t;
            PropertyInfo[] pi = type.GetProperties();
            label1.Text = $"{pi[1].Name} (type: {pi[1].PropertyType})";
            label2.Text = $"{pi[2].Name} (type: {pi[2].PropertyType})";
            label3.Text = $"{pi[3].Name} (type: {pi[3].PropertyType})";
            label4.Text = $"{pi[4].Name} (type: {pi[4].PropertyType})";
            label5.Text = $"{pi[0].Name} (type: {pi[0].PropertyType})";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String[] properties = {textBox1.Text , textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            int flag = 0;
            for (int i = 0; i<5; i++)
            {
                if (properties[i].Equals("")) flag = 1;
                
            }
            if (flag == 1)
            {
                MessageBox.Show("No data entered");
            }
            else {
                try
                {
                    Convert.ToDouble(properties[2]);
                    Convert.ToDouble(properties[3]);
                    Convert.ToDouble(properties[4]);
                    newObject = createObject(properties, type);
                    Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Wrong types!");
                }
                
            }
               

        }
        private IDevice createObject(string[] properties, Type type)
        {
           

            if (type.Name.Equals("DigitalCamera"))
            {

                return new DigitalCamera(properties[0], properties[1], Double.Parse(properties[2]), Double.Parse(properties[3]), Double.Parse(properties[4]));
            }
            else if (type.Name.Equals("FilmCamera"))
            {
                return new FilmCamera(properties[0], properties[1], Double.Parse(properties[2]), Double.Parse(properties[3]), Double.Parse(properties[4]));
            }
            else if (type.Name.Equals("VideoCamera"))
            {
                return new VideoCamera(properties[0], properties[1], Double.Parse(properties[2]), Double.Parse(properties[3]), Double.Parse(properties[4]));
            }
            return null;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
