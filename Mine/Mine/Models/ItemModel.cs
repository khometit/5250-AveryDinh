using System;
using SQLite;

namespace Mine.Models
{
    /// <summary>
    /// Model to create items for the characters to use and Monsters to drop
    /// </summary>
    public class ItemModel
    {
        //The ID for the item
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //The Display Text for the item
        public string Text { get; set; }

        //The Description of the item
        public string Description { get; set; }

        //The value of the Item +9 Damage
        public int Value { get; set; } = 0;
    }
}