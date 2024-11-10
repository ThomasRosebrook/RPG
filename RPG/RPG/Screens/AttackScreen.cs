using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Screens
{
    public class AttackScreen : BottomMenu
    {
        Player _player;
        Enemy _enemy;
        HandelChange _changeTurn;
        public AttackScreen(Player player, Enemy enemy, HandelChange changeTurn) : base("Physical", "Magic", "Bribe", "Other")
        {
            _player = player;
            _enemy = enemy;
            _changeTurn = changeTurn;
        }


        protected override void SelectOptionOne()
        
        {
            int HP = _enemy.GetHP();
            int num = _enemy.GetHP() - _player.strength; 
            _enemy.SetHP(num);
            _changeTurn.Invoke();

        }

        protected override void SelectOptionTwo()
        {
            int num = _player.magic - _enemy.GetHP();
            _enemy.SetHP(num);
            _changeTurn.Invoke();
        }

        protected override void SelectOptionThree()
        {
            if (_player.money >= _enemy.GetMoney())
            {
                _enemy.SetHP(0);
            }
            else
            {
                _player.HP -= 2;
            }
            _changeTurn.Invoke();
        } 

        protected override void SelectOptionFour()
        {
            _player.guard = true;
            _changeTurn.Invoke();
        }
    }
}
