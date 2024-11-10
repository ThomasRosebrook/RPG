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

namespace RPG.Screens
{
    public class BattleScreen : GameScreen
    {

        private enum Turn
        {
            Player,
            Enemy
        };

        private ContentManager _content;

        private Random _rand;

        private int _height = 900;

        private int _width = 900;

        private Vector2 _position;

        private Vector2 _enemyPosition;

        bool guarding = false;

        Turn whoTurn = Turn.Player;

        //private Texture2D Character;

        //private Texture2D EnemySkin;

        private Player _player;

        private Enemy _enemy;

        

        public BattleScreen(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;

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

        public override void Activate()
        {
            _player.LoadContent(_content);
            _enemy.LoadContent();
            
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public void Update()
        {
            if (_player.HP <= 0 && _enemy.GetHP() <= 0)
            {
                //int turn = _rand.Next(2);
                if (whoTurn == Turn.Player)
                {
                    PlayerTurn();
                    whoTurn = Turn.Enemy;
                }
                else
                {
                    EnemyTurn();
                    whoTurn = Turn.Player;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
        }

        public void PlayerTurn()
        {
            int num;
            switch (_player.Action)
            {
                case TurnAction.Attack:
                     num = _player.strength - _enemy.GetHP();
                    _enemy.SetHP(num);
                    break;
                case TurnAction.Magic:
                     num = _player.magic - _enemy.GetHP();
                    _enemy.SetHP(num);
                    break;
                case TurnAction.Money:
                    if (_player.money >= _enemy.GetMoney())
                    {
                        _enemy.SetHP(0);
                    }
                    else
                    {
                        _player.HP -= 2;
                    }
                    break;
                case TurnAction.Guard:
                    guarding = true;
                    break;
            }
        }

        public void EnemyTurn()
        {
            int turn = _rand.Next(2);

            switch (turn)
            {
                case 0:
                    _player.HP -= _enemy.GetStrength();
                    break;
                case 1:
                    _player.HP -= _enemy.GetMagic();
                    break;
            }

        }
    }
}
