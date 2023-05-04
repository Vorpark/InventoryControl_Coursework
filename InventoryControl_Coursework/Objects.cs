using System.Collections.Generic;

namespace InventoryControl_Coursework
{
    public class Shelving // Стеллаж
    {
        public int Number { get; set; }
        public ShelvingUnit ShelvingUnit { get; set; }
    }
    public class ShelvingUnit //Ячейка стеллажа
    {
        public int Number { get; set; }
        public Material Material { get; set; }
    }
    public class Material // Определенный материал закрепленный за определенной ячейкой стеллажа
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
