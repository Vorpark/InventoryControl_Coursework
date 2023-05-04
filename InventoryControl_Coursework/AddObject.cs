using System;
using System.IO;
using System.Windows.Forms;

namespace InventoryControl_Coursework
{
    public partial class AddObject : Form
    {
        public AddObject()
        {
            InitializeComponent();
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
            
            if (check)
            {
                string path = "db.txt";
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
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
                if (check)
                {
                    Material material = new Material() { Name = textBox1.Text, Count = count };
                    Shelving shelving = new Shelving() { Number = numberShelving }; 
                    ShelvingUnit shelvingUnit = new ShelvingUnit() { Number = numberShelvingUnit };
                    shelvingUnit.Material = material;
                    shelving.ShelvingUnits.Add(shelvingUnit);

                    string text = $"{shelving.Number} {shelvingUnit.Number} {material.Name} {material.Count}";
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLineAsync(text);
                    }
                }
            }
        }
    }
}
