using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Screens;

namespace RPG.Interactables
{
    public interface IInteractable
    {
        public void SetPosition(Vector2 position);

        public Vector2 GetPosition();

        public void Interact(WorldScreen screen);

        public void DrawPopup(SpriteBatch spriteBatch, Vector2 position);
    }
}
