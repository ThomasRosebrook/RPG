using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RPG.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using System.Runtime.Versioning;
//using System.Numerics;

namespace RPG.Screens
{
    public delegate void HandelChange();
    public class BattleScreen : GameScreen
    {
        private HandelChange _changeTurn;
        private enum Turn
        {
            Player,
            Enemy
        };

        SpriteFont spriteFont;

        private ContentManager _content;

        private Random _rand;

        private AttackScreen menu;

        private int _height = 900;

        private int _width = 900;

        private Texture2D _background;

        private Vector2 _position;

        private Vector2 _enemyPosition;

        bool guarding = false;

        bool flag = false;

        Turn whoTurn = Turn.Player;

        int timer = 0;

        

        //private Texture2D Character;

        //private Texture2D EnemySkin;

        private Player _player;

        private Enemy _enemy;

        

        public BattleScreen(Player player, Enemy enemy)
        {
            this.IsPopup = true;
            _player = player;
            _enemy = enemy;
            _changeTurn = FlipTurn;
            _rand = new Random();

            _position = new Vector2(200, _height / 2);
            _enemyPosition = new Vector2(700, _height / 2);

            
            int start = _rand.Next(2);
            if (start == 0)
            {
                whoTurn = Turn.Player;
            }
            else
            {
                whoTurn = Turn.Enemy;
            }
        }
        private void FlipTurn()
        {
            if (whoTurn == Turn.Player)
            {
                whoTurn = Turn.Enemy;
            }
            else
            {
                whoTurn = Turn.Player;
            }
        }
        public override void Activate()
        {
            if (_content == null)
                _content = new ContentManager(ScreenManager.Game.Services, "Content");
            _player.LoadContent(_content);
            _enemy.LoadContent(_content);
           spriteFont = _content.Load<SpriteFont>("PublicPixel");

            _enemy.InBattle = true;
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Update(GameTime gameTime, bool unfocused, bool covered)
        {
            _enemy.Update(gameTime);
            if (IsActive)
            { 
                if (_player.HP >= 0 && _enemy.GetHP() >= 0)
                {
                    //int turn = _rand.Next(2);
                    if (whoTurn == Turn.Player)
                    {
                        if (menu == null)
                        {
                            menu = new AttackScreen(_player, _enemy, _changeTurn);
                            ScreenManager.AddScreen(menu);
                        }
                        if (menu.test == true)
                        {
                            menu.ExitScreen();
                            menu = null;
                            FlipTurn();
                        }
                        //PlayerTurn();

                    }
                    else if (whoTurn == Turn.Enemy)
                    {
                        EnemyTurn();
                        FlipTurn();

                    }
                }
                else
                {
                    if (timer >= 40)
                    {
                        _player.strength += 5;
                        _player.magic += 5;
                        _player.money += _enemy.GetMoney();
                        _enemy.InBattle = false;
                        _enemy.IsAlive = false;
                        if (menu != null)
                        {
                            menu.ExitScreen();
                            menu = null;
                        }
                        this.ExitScreen();
                    }
                    timer += 1;
                    
                }
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.Game.GraphicsDevice.Clear(new Color(32, 18, 8));
            var spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();
            //spriteBatch.DrawString(spriteFont, $"{_player.HP}", new Vector2(450, 450), Color.White);
            //spriteBatch.DrawString(spriteFont, $"{_enemy.GetHP()}", new Vector2(450, 350), Color.White);
            //ScreenManager.SpriteBatch.Draw(_background, new Rectangle(650, 400, 120, 120), Color.Gray);
            _player.Draw(gameTime, spriteBatch);
            if (_enemy.GetHP() >= 0)
            {
                _enemy.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, "YOU WIN!!!!", new Vector2(450, 450), Color.White);
            }
            
            spriteBatch.End();
        }

    

        public void EnemyTurn()
        {
            int turn = _rand.Next(2);

            switch (turn)
            {
                case 0:
                    if (_player.guard)
                    {
                        _player.HP -= _enemy.GetStrength() / 2;
                    }
                    else
                    {
                        _player.HP -= _enemy.GetStrength();
                    }
                    _enemy.attackSound.Play();
                    break;
                case 1:
                    _player.HP -= _enemy.GetMagic();
                    _enemy.magicSound.Play();
                    break;
            }

        }
    }
}
