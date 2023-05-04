﻿using System;
using System.IO;
using System.Windows.Forms;

namespace InventoryControl_Coursework
{
    public partial class ObjectForm : Form
    {
        bool editing = false;
        string oldObject;
        public ObjectForm()
        {
            InitializeComponent();
        }
        public ObjectForm(string[] words) : this()
        {
            editing = true;
            textBox3.Text = words[0];
            textBox4.Text = words[1];
            textBox1.Text = words[2];
            textBox2.Text = words[3];
            button1.Text = "Изменить";
            oldObject = $"{words[0]} {words[1]} {words[2]} {words[3]}";
        }
        private void AddNewObject(object sender, EventArgs e)
        {
            bool check = true;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле название материала не может быть пустым!", "Ошибка!", MessageBoxButtons.OK);
                check = false;
            }
            if (!int.TryParse(textBox2.Text, out int count) && textBox2.Text == "")
            {
                MessageBox.Show("Поле количество материала введено неверно!", "Ошибка!", MessageBoxButtons.OK);
                check = false;
            }
            if (!int.TryParse(textBox3.Text, out int numberShelving) && textBox3.Text == "")
            {
                MessageBox.Show("Поле номер стеллажа введено неверно!", "Ошибка!", MessageBoxButtons.OK);
                check = false;
            }
            if (!int.TryParse(textBox4.Text, out int numberShelvingUnit) && textBox4.Text == "")
            {
                MessageBox.Show("Поле номер ячейки введено неверно!", "Ошибка!", MessageBoxButtons.OK);
                check = false;
            }

            string path = "db.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (words[0] == textBox3.Text && words[1] == textBox4.Text)
                        {
                            MessageBox.Show("Данная ячейка стеллажа уже занята!", "Ошибка!", MessageBoxButtons.OK);
                            check = false;
                            break;
                        }
                    }
                }
            }

            if (check)
            {
                if (editing)
                {
                    Edit(oldObject);
                }
                else
                {
                        Material material = new Material() { Name = textBox1.Text, Count = count };
                        Shelving shelving = new Shelving() { Number = numberShelving };
                        ShelvingUnit shelvingUnit = new ShelvingUnit() { Number = numberShelvingUnit };
                        shelvingUnit.Material = material;
                        shelving.ShelvingUnit = shelvingUnit;

                        string text = $"{shelving.Number} {shelving.ShelvingUnit.Number} {material.Name} {material.Count}";
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLineAsync(text);
                        }
                }
            }
        }
        private void Edit(string oldObject)
        {
            string text;
            string path = "db.txt";
            string newObject = $"{textBox3.Text} {textBox4.Text} {textBox1.Text} {textBox2.Text}";
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            text = text.Replace(oldObject, newObject);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}
