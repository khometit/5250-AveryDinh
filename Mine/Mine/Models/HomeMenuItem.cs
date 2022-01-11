using System;
using System.Collections.Generic;
using System.Text;

namespace Mine.Models
{
    public enum MenuItemType
    {
        Items,
        About,
        Game
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
