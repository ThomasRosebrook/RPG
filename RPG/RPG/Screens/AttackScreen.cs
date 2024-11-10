using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace RPG.Screens
{
    public class AttackScreen : BottomMenu
    {
        Player _player;
        Enemy _enemy;
        HandelChange _changeTurn;
        public bool test;
        private SoundEffect sword;
        private SoundEffect fire;
        private SoundEffect bribe;

        public AttackScreen(Player player, Enemy enemy, HandelChange changeTurn) : base("Physical", "Magic", "Bribe", "Other")
        {
            _player = player;
            _enemy = enemy;
            _changeTurn = changeTurn;
        }


        protected override void SelectOptionOne()
        
        {
            sword.Play();
            int HP = _enemy.GetHP();
            int num = _enemy.GetHP() - _player.strength; 
            _enemy.SetHP(num);
            //_changeTurn.Invoke();
            test = true;
        }

        protected override void SelectOptionTwo()
        {
            fire.Play();
            int num = _player.magic - _enemy.GetHP();
            _enemy.SetHP(num);
            //_changeTurn.Invoke();
            test = true;
        }

        protected override void SelectOptionThree()
        {
            bribe.Play();
            if (_player.money >= _enemy.GetMoney())
            {
                _enemy.SetHP(-1);
            }
            else
            {
                _player.HP -= 2;
            }
            //_changeTurn.Invoke();
            test = true;
        } 

        protected override void SelectOptionFour()
        {
            _player.guard = true;
            //_changeTurn.Invoke();
            test = true;
        }

        public override void Activate()
        {
            base.Activate();
            bribe = _content.Load<SoundEffect>("BribeSFX");
            sword = _content.Load<SoundEffect>("SwordSFX");
            fire = _content.Load<SoundEffect>("FireAttackSFX/EM_Fire_Cast_02");
        }
    }
}
