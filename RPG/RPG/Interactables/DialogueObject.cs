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
    }
}
