using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl_Coursework
{
    public class Materials // Все определeнные материалы
    {
        public string Name { get; set; }
        public List<Material> Material {get; set;}
    }
    public class Material // Определенный материал закрепленный за определенной ячейкой
    {
        public string Name { get; set; }
        public Shelving Shelving { get; set; }
        public ShelvingUnit ShelvingUnit { get; set; }
        public int Count { get; set; }
    }
    public class Shelving // Стеллаж
    {
        public int Number { get; set; }
        public List<ShelvingUnit> ShelvingUnits { get; set; }
    }
    public class ShelvingUnit //Ячейка стеллажа
    {
        public int Number { get; set; }
    }
}
