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
            Material material = new Material() { Name = textBox1.Text, Count = Convert.ToInt32(textBox2.Text) }; // Проверка count
            Shelving shelving = new Shelving() { Number = Convert.ToInt32(textBox3.Text) }; // Проверка на уникальность стеллажа и number
            ShelvingUnit shelvingUnit = new ShelvingUnit() { Number = Convert.ToInt32(textBox4.Text) }; // Проверка на number
            shelvingUnit.Material = material;
            shelving.ShelvingUnits.Add(shelvingUnit); //Проверка на уникальность ячейки и занятость

            //При удачной проверке идет запись
            string path = "db.txt";
            string text = $"{shelving.Number} {shelvingUnit.Number} {material.Name} {material.Count}"; //$"Стеллаж:{shelving.Number} Номер ячейки:{shelvingUnit.Number} Материал:{material.Name} Количество:{material.Count}";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}
