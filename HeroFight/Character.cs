using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
    public class Character
    {
        private string name;
        private int lvl = 0;
        private int str = 1;
        private int dex = 1;
        private int luck = 1;
        private int con = 1;
        private int inte = 1;
        private int hp = 30;
        private int mp = 20;
        int physicalAttack = 1;
        int magicAttack = 2;
        int exp = 0;
        private bool alive = true;
        private int skillPoints = 0;
        private int requiredExp = 100;
        private int tokens = 2;
        private int extendHp = 30;
        private int maxHP = 30;
        public Character(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Con { get => con; set => con = value; }
        public int Inte { get => inte; set => inte = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int PhysicalAttack { get => physicalAttack; set => physicalAttack = value; }
        public int MagicAttack { get => magicAttack; set => magicAttack = value; }
        public int Exp { get => exp; set => exp = value; }
        public bool Alive { get => alive; set => alive = value; }
        public int SkillPoints { get => skillPoints; set => skillPoints = value; }
        public int RequiredExp { get => requiredExp; set => requiredExp = value; }
        public int ExtendHp { get => extendHp; set => extendHp = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }

        public static Character GetCharacter(List<Character> characters, string name )
        {
            foreach(var b in characters)
            {
                if(b.Name == name)
                {
                    return b;
                }
            }
            return null;
        }

        public Character Attack(Character character)
        {
            character.hp -= this.physicalAttack;
            return character;
        }
        
        public Character MAttack(Character character)
        {
            character.hp -= this.magicAttack;
            this.mp -= 5;
            return character;
        }

        public void LvlUp()
        {
            if (this.lvl > 2)
            { int tokens =+ 1; }
            this.Lvl += 1;
            this.SkillPoints += tokens;
            this.requiredExp *= 3;
        }

        public void Revive()
        {
            this.alive = true;
            this.hp += extendHp;
            if (this.hp > maxHP)
            {
                this.hp = maxHP;
            }
        }
    }
}
