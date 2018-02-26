using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using EntitiesLayer.DTOs;
using System.Reflection;

namespace game_of_thrones
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] classes = { "Character", "Fight", "White Walker", "House", "Territory", "War" };
            bool keepPlaying = true;
            string line;

            //Utiliser pour proposer à l'utilisateur de jouer à la version web après 5 essaies et après 50 on le félicite (gentillement)
            int counter = 0;

            Console.WriteLine("Welcome to GameOfThrones");
            Console.WriteLine("========================");

            Console.WriteLine("Notice : We recommand using the WebBased version.");

            do
            {
                Console.WriteLine("Choose an action (example W3) : ");
                for (int i = 0; i < classes.Length; i++)
                {
                    Console.WriteLine(classes[i][0] + " ) " + classes[i]);
                    Console.WriteLine("========");
                    Console.WriteLine("\t 1) List All");
                    Console.WriteLine("\t 2) By Id [ par example " + classes[i][0] + "2 <ID> ]");
                    Console.WriteLine("\t 3) Create");
                    Console.WriteLine("\t 4) Edit [ par example " + classes[i][0] + "2 <ID> ]");
                    Console.WriteLine("\t 5) Delete [ par example " + classes[i][0] + "2 <ID> ]");
                }
                Console.WriteLine("X) Fight ! [example X <IDFIGHT>");
                Console.WriteLine("Q ) Quit");

                if (counter % 5 == 0)
                    Console.WriteLine("Dude ! You should really try the SUPER Web Based version of the game !");
                else if (counter > 50)
                    Console.WriteLine("WOW ! Even the devs didn't enjoy it that much");
                line = Console.In.ReadLine();
                if (line == "Q")
                    keepPlaying = false;
                else if(line == "X")
                {

                    GameManager.Instance.StartFight(GameManager.Instance.GetFightById(Int32.Parse(line.Split('-')[1])));
                    ObjectDumper.Write(GameManager.Instance.GetFightById(Int32.Parse(line.Split('-')[1])));
                }
                else if (!"CFWHTW".Contains(line[0]) || !"12345".Contains(line[1]))
                    Console.WriteLine("Invalid Action");
                else
                {
                    /* Utilisation partielle de l'API Reflexive afin d'automatiser une grande partie de cette tache */
                    if (line[0] == 'C')
                    {
                        if (line[1] == '1')
                        {
                            List<CharacterDTO> list = GameManager.Instance.GetCharacters();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All Characters");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            CharacterDTO Character = GameManager.Instance.GetCharacterById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(Character);
                        }
                        else if (line[1] == '3')
                        {
                            CharacterDTO Character = new CharacterDTO() ;
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau Character : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Character.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Character, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Character, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddCharacter(Character);    
                        }
                        else if (line[1] == '4')
                        {
                            CharacterDTO Character = new CharacterDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au Character que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Character.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Character, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Character, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditCharacter(Character);
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteCharacter(Int32.Parse(line.Split(' ')[1]));
                        }
                    }
                    else if (line[0] == 'F')
                    {
                        if (line[1] == '1')
                        {
                            List<FightDTO> list = GameManager.Instance.GetFights();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All Fights");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            FightDTO Fight = GameManager.Instance.GetFightById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(Fight);
                        }
                        else if (line[1] == '3')
                        {
                            FightDTO Fight = new FightDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau Fight : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Fight.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Fight, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Fight, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddFight(Fight);
                        }
                        else if (line[1] == '4')
                        {
                            FightDTO Fight = new FightDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au Fight que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Fight.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Fight, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Fight, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditFight(Fight);
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteFight(Int32.Parse(line.Split(' ')[1]));
                        }
                    }
                    else if (line[0] == 'W')
                    {
                        if (line[1] == '1')
                        {
                            List<WhiteWalkerDTO> list = GameManager.Instance.GetWhiteWalkers();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All WhiteWalkers");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            WhiteWalkerDTO WhiteWalker = GameManager.Instance.GetWhiteWalkerById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(WhiteWalker);
                        }
                        else if (line[1] == '3')
                        {
                            WhiteWalkerDTO WhiteWalker = new WhiteWalkerDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau WhiteWalker : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(WhiteWalker.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(WhiteWalker, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(WhiteWalker, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddWhiteWalker(WhiteWalker);
                        }
                        else if (line[1] == '4')
                        {
                            WhiteWalkerDTO WhiteWalker = new WhiteWalkerDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au WhiteWalker que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(WhiteWalker.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(WhiteWalker, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(WhiteWalker, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditWhiteWalker(WhiteWalker);
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteWhiteWalker(Int32.Parse(line.Split(' ')[1]));
                        }
                    }
                    else if (line[0] == 'H')
                    {
                        if (line[1] == '1')
                        {
                            List<HouseDTO> list = GameManager.Instance.GetHouses();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All Houses");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            HouseDTO House = GameManager.Instance.GetHouseById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(House);
                        }
                        else if (line[1] == '3')
                        {
                            HouseDTO House = new HouseDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau House : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(House.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(House, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(House, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddHouse(House);
                        }
                        else if (line[1] == '4')
                        {
                            HouseDTO House = new HouseDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au House que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(House.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(House, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(House, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditHouse(House);
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteHouse(Int32.Parse(line.Split(' ')[1]));
                        }
                    }

                    else if (line[0] == 'T')
                    {
                        if (line[1] == '1')
                        {
                            List<TerritoryDTO> list = GameManager.Instance.GetTerritorys();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All Territorys");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            TerritoryDTO Territory = GameManager.Instance.GetTerritoryById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(Territory);
                        }
                        else if (line[1] == '3')
                        {
                            TerritoryDTO Territory = new TerritoryDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau Territory : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Territory.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Territory, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Territory, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddTerritory(Territory);
                        }
                        else if (line[1] == '4')
                        {
                            TerritoryDTO Territory = new TerritoryDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au Territory que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(Territory.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(Territory, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(Territory, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditTerritory(Territory);
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteTerritory(Int32.Parse(line.Split(' ')[1]));
                        }
                    }

                    else if (line[0] == 'W')
                    {
                        if (line[1] == '1')
                        {
                            List<WarDTO> list = GameManager.Instance.GetWars();
                            foreach (var e in list)
                            {
                                Console.WriteLine("All Wars");
                                ObjectDumper.Write(e);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else if (line[1] == '2')
                        {
                            WarDTO War = GameManager.Instance.GetWarById(Int32.Parse(line.Split(' ')[1]));
                            ObjectDumper.Write(War);
                        }
                        else if (line[1] == '3')
                        {
                            WarDTO War = new WarDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au nouveau War : ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(War.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(War, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(War, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.AddWar(War);
                        }
                        else if (line[1] == '4')
                        {
                            Console.WriteLine("You can t change the histoy of the seven kingdoms...");
                            Console.WriteLine("\t\t\t Just kidding not implemented, but hey you should really try the web based version");
                            /*WarDTO War = new WarDTO();
                            Console.WriteLine("Veuillez saisir les informations relatives au War que vous voulez modifier: ");
                            IList<PropertyInfo> props = new List<PropertyInfo>(War.GetType().GetProperties());

                            foreach (var prop in props)
                            {
                                Console.WriteLine(prop.ToString().Split(' ')[1] + " : ");
                                if (prop.ToString().Split(' ')[0] == "System.String")
                                    prop.SetValue(War, Console.ReadLine(), null);
                                else if (prop.ToString().Split(' ')[0] == "Int32")
                                    prop.SetValue(War, Int32.Parse(Console.ReadLine()), null);
                            }
                            GameManager.Instance.EditWar(War);*/
                        }
                        else if (line[1] == '5')
                        {
                            GameManager.Instance.DeleteWar(Int32.Parse(line.Split(' ')[1]));
                        }
                    }
                }

                counter++;
            } while (keepPlaying);
            
        }
    }
}