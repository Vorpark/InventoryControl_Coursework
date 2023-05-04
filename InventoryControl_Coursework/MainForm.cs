using System;
using System.IO;
using System.Windows.Forms;

namespace InventoryControl_Coursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateData();
        }

        private void AddNewObject(object sender, EventArgs e)
        {
            var addForm = new ObjectForm();
            addForm.ShowDialog();
            UpdateData();
        }
        
        private void UpdateData()
        {
            dataGridView1.Rows.Clear();
            string path = "db.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        dataGridView1.Rows.Add(words[0], words[1], words[2], words[3]);
                    }
                }
            }
        }

        private void EditObject(object sender, EventArgs e)
        {
            string[] words = { dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() };
            var addForm = new ObjectForm(words);
            addForm.ShowDialog();
            UpdateData();
        }

        private void DeleteObject(object sender, EventArgs e)
        {
            string text;
            string oldObject = $"{dataGridView1[0, dataGridView1.CurrentRow.Index].Value} {dataGridView1[1, dataGridView1.CurrentRow.Index].Value} {dataGridView1[2, dataGridView1.CurrentRow.Index].Value} {dataGridView1[3, dataGridView1.CurrentRow.Index].Value}";
            string path = "db.txt";
            string newObject = "";
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            text = text.Replace(oldObject, newObject);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLineAsync(text);
            }
            UpdateData();
        }

        private void FindMaterial(object sender, EventArgs e)
        {
            bool find = false;
            dataGridView1.Rows.Clear();
            string path = "db.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        if (words[2] == textBox1.Text || words[2].ToLower() == textBox1.Text)
                        {
                            dataGridView1.Rows.Add(words[0], words[1], words[2], words[3]);
                            find = true;
                        }
                    }
                }
                if (!find)
                {
                    MessageBox.Show("Ничего не найдено!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
        }

        private void FindShelvingAndUnit(object sender, EventArgs e)
        {
            bool find = false;
            dataGridView1.Rows.Clear();
            string path = "db.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        if (words[0] == textBox2.Text && words[1] == textBox3.Text)
                        {
                            dataGridView1.Rows.Add(words[0], words[1], words[2], words[3]);
                            find = true;
                        }
                    }
                }
                if (!find)
                {
                    MessageBox.Show("Ничего не найдено!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
        }

        private void RemoveFilter(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
