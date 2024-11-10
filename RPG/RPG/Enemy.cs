using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Enemy
    {
        protected int HP { get; set; }

        protected int Strength { get; set; }

        protected int Magic { get; set; }

        protected decimal Money { get; set; }

        protected int Luck { get; set; }


        public int GetHP()
        {
            return HP;
        }

        public void SetHP(int hp)
        {
            HP = hp;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetMagic()
        {
            return Magic;
        }

        public decimal GetMoney()
        {
            return Money;
        }

        public int GetLuck()
        {
            return Luck;
        }
        public abstract void LoadContent();
        
    }
}
