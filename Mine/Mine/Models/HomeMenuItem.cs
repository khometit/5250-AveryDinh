using System;
using System.Collections.Generic;
using System.Text;

namespace Mine.Models
{
    /// <summary>
    /// Enum class containing all currently supported menu option
    /// </summary>
    public enum MenuItemType
    {
        Items,
        About,
        Game
    }

    /// <summary>
    /// Class to contain a menu option
    /// </summary>
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
