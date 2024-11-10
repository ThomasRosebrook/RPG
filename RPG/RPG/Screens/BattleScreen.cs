using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RPG.ScreenManagement;
using System;

namespace RPG.Screens
{
    public delegate void HandelChange();
    public class BattleScreen : GameScreen
    {
        public EventHandler<EventArgs> BattleDone;

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

        private Vector2 _position;

        private Vector2 _enemyPosition;
        Turn whoTurn = Turn.Player;

        int timer = 0;

        

        //private Texture2D Character;

        //private Texture2D EnemySkin;

        private Player _player;

        private Enemy _enemy;

        private HealthBar PlayerHealth;
        private HealthBar EnemyHealth;

        private bool BattleOver = false;

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

            EnemyHealth = new HealthBar(false, _enemy.GetHP());
            PlayerHealth = new HealthBar(true, _player.HP);

            _enemy.InBattle = true;
            _player.InBattle = true;
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Update(GameTime gameTime, bool unfocused, bool covered)
        {
            if (IsActive)
            { 
                if (_player.HP >= 0 && _enemy.GetHP() >= 0)
                {
                    _enemy.Update(gameTime);

                    PlayerHealth.UpdateHealth(_player.HP);
                    EnemyHealth.UpdateHealth(_enemy.GetHP());
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
                    BattleOver = true;
                    if (timer >= 40)
                    {
                        if (_player.HP > 0)
                        {
                            _player.strength += RandomHelper.Next(3, 7);
                            _player.magic += RandomHelper.Next(3, 7);
                            _player.luck += RandomHelper.Next(0, 1);
                            if (!_enemy.Bribed) _player.money += _enemy.GetMoney();
                            _player.HP = _player.MAX_HP;
                            if (_enemy.GetHP() <= 0) _enemy.IsAlive = false;
                        }
                        
                        _enemy.InBattle = false;
                        _player.InBattle = false;
                        
                        if (menu != null)
                        {
                            menu.ExitScreen();
                            menu = null;
                        }
                        BattleDone?.Invoke(this, new EventArgs());
                        this.ExitScreen();

                    }
                    timer += 1;
                    if (_player.HP <= 0) timer = 40;
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
            if (!BattleOver)
            {
                _player.Draw(gameTime, spriteBatch);
                _enemy.Draw(spriteBatch);
                
                EnemyHealth.Draw(spriteBatch);
                PlayerHealth.Draw(spriteBatch);
            }
            else if (_enemy.GetHP() <= 0 && _player.HP > 0)
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
