using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeroFight
{
    /// <summary>
    /// Логика взаимодействия для Upgrade.xaml
    /// </summary>
    public partial class Upgrade : Window
    {
        List<Character> characters;
        public Upgrade(List<Character> characters)
        {
            InitializeComponent();
            this.characters = characters;

            foreach(var a in characters)
            {
                mujiki.Items.Add(a.Name);
            }
        }

        private void mujiki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            skills.Text = Convert.ToString(character.SkillPoints);
        }

        private void strUp_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if(int.Parse(skills.Text) > 0)
            {
                character.Str += 1;
                character.PhysicalAttack += 1;
                character.SkillPoints -= 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void dexUp_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Dex += 1;
                character.SkillPoints -= 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void LuckUp_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Luck += 1;
                character.SkillPoints -= 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void conUp_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Con += 1;
                character.Hp += 5;
                character.MaxHP += 5;
                character.ExtendHp += 5;
                character.SkillPoints -= 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void intUp_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Inte += 1;
                character.MagicAttack += 2;
                character.Mp += 7;
                character.SkillPoints -= 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void strDown_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Str -= 1;
                character.PhysicalAttack -= 1;
                character.SkillPoints += 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void dexDown_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Dex -= 1;
                character.SkillPoints += 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void LuckDown_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Luck -= 1;
                character.SkillPoints += 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void conDown_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Con -= 1;
                character.SkillPoints += 1;
                character.Hp -= 5;
                character.MaxHP -= 5;
                character.ExtendHp -= 5;
                skills.Text = character.SkillPoints.ToString();
            }
        }

        private void intDown_Click(object sender, RoutedEventArgs e)
        {
            Character character = Character.GetCharacter(characters, mujiki.SelectedValue.ToString());
            if (int.Parse(skills.Text) > 0)
            {
                character.Inte -= 1;
                character.MagicAttack -= 2;
                character.Mp -= 7;
                character.SkillPoints += 1;
                skills.Text = character.SkillPoints.ToString();
            }
        }
    }
}
