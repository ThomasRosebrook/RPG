using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using System.Collections.Generic;

namespace RPG.Screens
{
    public class StatScreen : SideMenu
    {

        public StatScreen(Player player) : base(player)
        {
            this.IsPopup = true;
            items = new List<MenuItem>()
            {
                new MenuItem($"Strength: {player.strength}"),
                new MenuItem($"Magic: {player.magic}"),
                new MenuItem($"Money: ${player.money}"),
                new MenuItem($"Luck: {player.luck}"),
                new MenuItem($"Health: {player.HP}"),
                new MenuItem("Back")
            };
            items[5].IsHovered = true;
            selectedItem = 5;
        }

        protected override void SelectItem()
        {
            switch (selectedItem)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    this.ExitScreen();
                    break;
                default:
                    break;
            }
        }
    }
}
