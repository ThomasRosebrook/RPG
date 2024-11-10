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
    public class LootableObject : IInteractable
    {
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

        }

        public void SetPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
