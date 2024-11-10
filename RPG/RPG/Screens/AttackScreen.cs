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

        public AttackScreen(Player player, Enemy enemy, HandelChange changeTurn) : base("Physical", "Magic", "Bribe", "Shield")
        {
            _player = player;
            _enemy = enemy;
            _changeTurn = changeTurn;
        }

        public override void Update(GameTime gameTime, bool unfocused, bool covered)
        {
            base.Update(gameTime, unfocused, covered);
        }

        protected override void SelectOptionOne()
        
        {
            sword.Play();
            //int HP = _enemy.GetHP();
            int damage = (RandomHelper.Next(0, 10) < _player.luck) ? (int)(_player.magic * 1.2) : _player.magic;
            int num = _enemy.GetHP() - damage; 
            _enemy.SetHP(num);
            //_changeTurn.Invoke();
            test = true;
        }

        protected override void SelectOptionTwo()
        {
            fire.Play();
            int damage = (RandomHelper.Next(0, 10) < _player.luck) ? (int)(_player.magic * 1.2) : _player.magic;
            int num = _enemy.GetHP() - damage;
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
                _enemy.Bribed = true;
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
