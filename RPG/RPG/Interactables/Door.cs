using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public void DrawPopup(SpriteBatch spriteBatch, Vector2 position)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Interact(WorldScreen screen)
        {
            Opened = true;
        }

        public void SetPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
