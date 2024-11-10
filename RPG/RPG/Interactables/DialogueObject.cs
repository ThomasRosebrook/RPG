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
    public class DialogueObject : IInteractable
    {
        DialogueBox Dialogue;

        Vector2 position;

        public DialogueObject(string objectName, string dialogue)
        {
            Dialogue = new DialogueBox(objectName, dialogue);
        }

        public Vector2 GetPosition() => position;

        public void Interact(WorldScreen screen)
        {
            screen.ScreenManager.AddScreen(Dialogue);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void DrawPopup(SpriteBatch spriteBatch, Vector2 position)
        {
            PixelFont.DrawString(spriteBatch, FontSize.Small, position, Color.White, "Press SPACE to Interact");
        }
    }
}
