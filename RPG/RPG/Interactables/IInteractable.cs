using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using RPG.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Interactables
{
    public interface IInteractable
    {
        public void SetPosition(Vector2 position);

        public Vector2 GetPosition();

        public void Interact(WorldScreen screen);
    }
}
