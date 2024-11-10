using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Interactables
{
    public class NPC : IInteractable
    {
        WorldScreen Screen;

        Vector2 position;

        Enemy enemy;

        public bool IsAlive
        {
            get => enemy.IsAlive;
        }

        public NPC(Enemy enemy, Vector2 position)
        {
            this.enemy = enemy;
            enemy.WorldPosition = position;
            this.position = position;
        }

        public void DrawPopup(SpriteBatch spriteBatch, Vector2 position)
        {
            if (IsAlive) enemy.Draw(spriteBatch);
            //PixelFont.DrawString(spriteBatch, FontSize.Small, position, Color.White, "Press SPACE to Interact");
        }

        public Vector2 GetPosition() => position;

        public void Interact(WorldScreen screen)
        {
            
            if (IsAlive)
            {
                Screen = screen;
                BattleScreen battle = new BattleScreen(screen.player, enemy);
                screen.ScreenManager.AddScreen(battle);
                battle.BattleDone += OnBattleDone;
                screen.battleStart = true;
            }
            
        }

        void OnBattleDone(object sender, EventArgs e)
        {
            Screen.battleFinish = true;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
            enemy.WorldPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            enemy.LoadContent(content);
        }
    }
}
