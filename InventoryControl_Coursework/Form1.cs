using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryControl_Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new AddObject();
            addForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = "db.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    dataGridView1.Rows.Add("a", 1, 1, 2);
                }
            }
        }
    }
}
