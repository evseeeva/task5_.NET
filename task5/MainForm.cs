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
using ClassLibrary;
using System.Collections;

namespace task5
{
    public partial class MainForm : Form
    {

        Type[] types;
        public List<IDevice> objects = null;

        public MainForm()
        {
            InitializeComponent();
            Assembly asm;
            
            asm = Assembly.LoadFrom("ClassLibrary.dll");
            types = asm.GetTypes();

            foreach (Type t in types)
            {
                if (t.GetInterface("IDevice") != null && t.IsSubclassOf(typeof(Camera)))
                {
                    comboBoxClasses.Items.Add(t.Name);
                }
            }
            objects = new List<IDevice>();
            objects.Add(new DigitalCamera("Canon", "EOS M6", 24.2, 16,  3));
            objects.Add(new DigitalCamera("Nikon", "D780", 24.5, 64, 3.2));
            objects.Add(new FilmCamera("Kodak", "Mini SHOT 3", 15, 4, 0.001));
            objects.Add(new VideoCamera("Sony", "ZV-1", 20.1, 128, 1080));
            foreach(IDevice d in objects)
            {
                objectsListBox.Items.Add($"{d.GetType().Name} : {d.getParameters()} ");
            }
        }

        Type currentType = null;


        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String selectedClass = (String)comboBoxClasses.SelectedItem;

            foreach (Type t in types)
            {
                if (t.Name == selectedClass)
                {
                    currentType = t;
                    break;
                }
            }
           

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (currentType != null) { 
            AddForm addForm = new AddForm(currentType);
            addForm.ShowDialog();
            if (addForm.newObject != null)
            {
                objects.Add(addForm.newObject);
                objectsListBox.Items.Add($"{currentType.Name} : {addForm.newObject.getParameters()}");
            }
        } else { MessageBox.Show("No Type selected"); }
           
        }



        private void executeButton_Click(object sender, EventArgs e)
        {

            if (objectsListBox.SelectedIndex >= 0 && comboBoxMethods.SelectedIndex >= 0)
            {
                IDevice currentObject = objects.ElementAt(objectsListBox.SelectedIndex);
                MethodInfo currentMethod = curMethods.ElementAt(comboBoxMethods.SelectedIndex);
                ParameterInfo[] paramInfo = currentMethod.GetParameters();
                String result = "";
                if (paramInfo.Length > 0)
                {
                    ParamForm paramForm = new ParamForm(paramInfo);
                    paramForm.ShowDialog();
                    if (paramForm.parameters.Length > 0)
                    {
                        result = currentMethod.Invoke(currentObject, paramForm.parameters).ToString();
                        objectsListBox.Items.Clear();
                        foreach (IDevice d in objects)
                        {
                            objectsListBox.Items.Add($"{d.GetType().Name} : {d.getParameters()} ");
                        }
                    }
                   
                }
                else result = currentMethod.Invoke(currentObject, null).ToString();
                outputTextBox.Text = result;


            }
            else { MessageBox.Show("No object or method selected"); }
        }
        List<MethodInfo> curMethods = new List<MethodInfo>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMethods.Items.Clear();
            curMethods.Clear();
           
            foreach (MethodInfo m in objects.ElementAt(objectsListBox.SelectedIndex).GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                
                if (!m.IsSpecialName && m.DeclaringType != typeof(object))
                {
                    curMethods.Add(m);
                    comboBoxMethods.Items.Add(m.Name);
                }
                    

            }

          
        }

    }
}
