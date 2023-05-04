using System.Collections.Generic;

namespace InventoryControl_Coursework
{
    public class Material // Определенный материал закрепленный за определенной ячейкой
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    public class Shelving // Стеллаж
    {
        public int Number { get; set; }
        public List<ShelvingUnit> ShelvingUnits { get; set; }
        public Shelving()
        {
            ShelvingUnits = new List<ShelvingUnit>();
        }
    }
    public class ShelvingUnit //Ячейка стеллажа
    {
        public int Number { get; set; }
        public Material Material { get; set; }
    }
}
