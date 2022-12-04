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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeroFight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Character> characters;
        public static int firstFighterMove;
        public static int secondFighterMove;
        private static Character? firstCharacter;
        private static Character? secondCharacter;
        public MainWindow()
        {
            InitializeComponent();
            Character ivan = new Character("ivan");
            Character legolas = new Character("legolas");
            characters = new List<Character>();
            Characters.Add(ivan);
            Characters.Add(legolas);

            foreach (var a in Characters)
            {
                firstFighter.Items.Add(a.Name);
                secondFighter.Items.Add(a.Name);
            }
            bodyPart.Items.Add("Head");
            bodyPart.Items.Add("Body");
            bodyPart.Items.Add("Legs");

            bodyPart2.Items.Add("Head");
            bodyPart2.Items.Add("Body");
            bodyPart2.Items.Add("Legs");

            firstFighterMove = 0;
            secondFighterMove = 0;
            FirstCharacter = null;
            SecondCharacter = null;

        }


        internal List<Character> Characters { get => characters; set => characters = value; }
        internal static Character? FirstCharacter { get => firstCharacter; set => firstCharacter = value; }
        internal static Character? SecondCharacter { get => secondCharacter; set => secondCharacter = value; }

        private void firstFighter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstCharacter = Character.GetCharacter(characters, firstFighter.SelectedValue.ToString());
        }

        private void secondFighter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            secondCharacter = Character.GetCharacter(characters, secondFighter.SelectedValue.ToString());
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            bodyPart.Visibility = Visibility.Visible;
            firstFighterMove = 1;
        }

        private void magicAttack_Click(object sender, RoutedEventArgs e)
        {
            bodyPart.Visibility = Visibility.Visible;
            firstFighterMove = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bodyPart.Visibility = Visibility.Visible;
            firstFighterMove = 3;
        }

        private void Attack_Copy_Click(object sender, RoutedEventArgs e)
        {
            bodyPart2.Visibility = Visibility.Visible;
            secondFighterMove = 1;
        }

        private void magicAttack_Copy_Click(object sender, RoutedEventArgs e)
        {
            bodyPart2.Visibility = Visibility.Visible;
            secondFighterMove = 2;
        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            bodyPart2.Visibility = Visibility.Visible;
            secondFighterMove = 3;
        }

        private void Simulate_Click(object sender, RoutedEventArgs e)
        {
            //обычная атака в голову
            if (firstFighterMove == 1 && bodyPart.SelectedItem == "Head")
            {
                if (bodyPart2.SelectedItem != "Head" || secondFighterMove != 3)
                {
                    firstCharacter.Attack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " бухнул по голове  " + secondCharacter.Name + "на урон " + firstCharacter.PhysicalAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокировал атаку по бошке от " + firstCharacter.Name + '\n'; }
            }
            // в тело
            if (firstFighterMove == 1 && bodyPart.SelectedItem == "Body")
            {
                if (bodyPart2.SelectedItem != "Body" || secondFighterMove != 3)
                {
                    firstCharacter.Attack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " дал тычку пузран  " + secondCharacter.Name + "он получил урон " + firstCharacter.PhysicalAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокировал атаку по тушке от " + firstCharacter.Name + '\n'; }
            }
            // в ногу
            if (firstFighterMove == 1 && bodyPart.SelectedItem == "Legs")
            {
                if (bodyPart2.SelectedItem != "Legs" || secondFighterMove != 3)
                {
                    firstCharacter.Attack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " дал втычку по ноге " + secondCharacter.Name + "и нанес урона " + firstCharacter.PhysicalAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокировал втычку по ноге от" + firstCharacter.Name + '\n'; }
            }

            //магическая атака в голову
            if (firstFighterMove == 2 && bodyPart.SelectedItem == "Head")
            {
                if (bodyPart2.SelectedItem != "Head" || secondFighterMove != 3)
                {
                    firstCharacter.MAttack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " подбоченился и влепил манным ударом по голове  " + secondCharacter.Name + "на урон " + firstCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокир магическую атаку по центру принятия решений от " + firstCharacter.Name + '\n'; }
            }
            // в тело
            if (firstFighterMove == 2 && bodyPart.SelectedItem == "Body")
            {
                if (bodyPart2.SelectedItem != "Body" || secondFighterMove != 3)
                {
                    firstCharacter.MAttack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " дал тычку пузран  " + secondCharacter.Name + "он получил урон " + firstCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокировал магическую атаку по туловищу от " + firstCharacter.Name + '\n'; }
            }
            // в ногу
            if (firstFighterMove == 2 && bodyPart.SelectedItem == "Legs")
            {
                if (bodyPart2.SelectedItem != "Legs" || secondFighterMove != 3)
                {
                    firstCharacter.MAttack(secondCharacter);
                    fightLog.Text += firstCharacter.Name + " закинул магическую подсечку " + secondCharacter.Name + "и нанес урона " + firstCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += secondCharacter.Name + " Заблокировал подсечку  " + firstCharacter.Name + '\n'; }

                //атака второго магией
            }

            if (secondFighterMove == 2 && bodyPart2.SelectedItem == "Head")
            {
                if (bodyPart.SelectedItem != "Head" || firstFighterMove != 3)
                {
                    secondCharacter.MAttack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " подбоченился и влепил манным ударом по голове  " + firstCharacter.Name + "на урон " + secondCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокир магическую атаку по центру принятия решений от " + secondCharacter.Name + '\n'; }
            }
            //  тела
            if (secondFighterMove == 2 && bodyPart2.SelectedItem == "Body")
            {
                if (bodyPart.SelectedItem != "Body" || firstFighterMove != 3)
                {
                    secondCharacter.MAttack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " дал магическую тычку в пузран  " + firstCharacter.Name + " он получил урон " + secondCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокировал магическую атаку по туловищу от " + secondCharacter.Name + '\n'; }
            }
            // ноги
            if (secondFighterMove == 2 && bodyPart2.SelectedItem == "Legs")
            {
                if (bodyPart.SelectedItem != "Legs" || firstFighterMove != 3)
                {
                    secondCharacter.MAttack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " закинул магическую подсечку " + firstCharacter.Name + "и нанес урона " + secondCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокировал подсечку  " + secondCharacter.Name + '\n'; }
            }

            if (secondFighterMove == 1 && bodyPart2.SelectedItem == "Head")
            {
                if (bodyPart.SelectedItem != "Head" || firstFighterMove != 3)
                {
                    secondCharacter.Attack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " подбоченился и влепил  ударом по голове  " + firstCharacter.Name + "на урон " + secondCharacter.PhysicalAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокировал атаку по центру принятия решений от " + secondCharacter.Name + '\n'; }
            }
            //  тела
            if (secondFighterMove == 1 && bodyPart2.SelectedItem == "Body")
            {
                if (bodyPart.SelectedItem != "Body" || firstFighterMove != 3)
                {
                    secondCharacter.Attack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " дал магическую тычку пузран  " + firstCharacter.Name + " он получил урон " + secondCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокировал магическую атаку по пузрану от " + secondCharacter.Name + '\n'; }
            }
            // ноги
            if (secondFighterMove == 1 && bodyPart2.SelectedItem == "Legs")
            {
                if (bodyPart.SelectedItem != "Legs" || firstFighterMove != 3)
                {
                    secondCharacter.Attack(firstCharacter);
                    fightLog.Text += secondCharacter.Name + " закинул подсечку " + firstCharacter.Name + " и нанес урона " + secondCharacter.MagicAttack + '\n';
                }
                else { fightLog.Text += firstCharacter.Name + " Заблокировал подсечку  " + secondCharacter.Name + '\n'; }
            }
            if (firstFighterMove == 3 && secondFighterMove == 3)
            { fightLog.Text += firstCharacter.Name + " и " + secondCharacter.Name + " решили друга друга заблокировать - вот дурачки" + '\n'; }

            fightLog.Text += "Состояние здоровья " + firstCharacter.Name + " " + firstCharacter.Hp + " HP \n";
            fightLog.Text += "Состояние маны " + firstCharacter.Name + " " + firstCharacter.Mp + " MP \n";
            fightLog.Text += "Состояние здоровья " + secondCharacter.Name + " " + secondCharacter.Hp + " HP \n";
            fightLog.Text += "Состояние маны " + secondCharacter.Name + " " + secondCharacter.Mp + " MP \n";

            if(firstCharacter.Mp == 0)
            {
                magicAttack.Visibility = Visibility.Hidden;
            }
            if(secondCharacter.Mp == 0)
            {
                magicAttack_Copy.Visibility = Visibility.Hidden;
            }

            if(firstCharacter.Hp == 0)
            {
                firstCharacter.Alive = false;
                magicAttack.Visibility = Visibility.Hidden;
                Attack.Visibility = Visibility.Hidden;
                block.Visibility = Visibility.Hidden;
                fightLog.Text += firstCharacter.Name + " умер";
                int getExp = firstCharacter.Hp * (3 * firstCharacter.Lvl);
                secondCharacter.Exp += getExp;
                fightLog.Text += secondCharacter.Name + " получил " + getExp + " опыта";
                if (secondCharacter.Exp >= secondCharacter.RequiredExp)
                { secondCharacter.LvlUp();}
            }

            if (secondCharacter.Hp == 0)
            {
                secondCharacter.Alive = false;
                magicAttack_Copy.Visibility = Visibility.Hidden;
                Attack_Copy.Visibility = Visibility.Hidden;
                Block.Visibility = Visibility.Hidden;
                fightLog.Text += secondCharacter.Name + " умер";
                int getExp = secondCharacter.Hp * (3 * secondCharacter.Lvl);
                firstCharacter.Exp += getExp;
                fightLog.Text += firstCharacter.Name + " получил " + getExp + " опыта";
                if(firstCharacter.Exp >= firstCharacter.RequiredExp)
                { firstCharacter.LvlUp(); }
            }
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            secondCharacter.Revive();
            firstCharacter.Revive();
            magicAttack.Visibility = Visibility.Visible;
            Attack.Visibility = Visibility.Visible;
            block.Visibility = Visibility.Visible;
            magicAttack_Copy.Visibility = Visibility.Hidden;
            Attack_Copy.Visibility = Visibility.Hidden;
            Block.Visibility = Visibility.Hidden;
            fightLog.Text = "";
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            List<Character> mujiki = Characters;
            Upgrade upgrade = new Upgrade(mujiki);
            upgrade.ShowDialog();
        }
    }
}

