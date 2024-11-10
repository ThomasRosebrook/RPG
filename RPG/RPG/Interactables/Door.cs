using RPG.ScreenManagement;
using RPG.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Interactables
{
    public class Door : IInteractable
    {
        public bool Opened = false;

        public void Interact(WorldScreen screen)
        {
            Opened = true;
        }
    }
}
