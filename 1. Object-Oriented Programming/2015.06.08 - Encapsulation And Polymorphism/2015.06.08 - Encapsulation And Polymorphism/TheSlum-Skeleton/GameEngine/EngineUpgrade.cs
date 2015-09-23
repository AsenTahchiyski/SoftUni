namespace TheSlum.GameEngine
{
    using System;
    using System.Linq;
    using Items;
    using Characters;

    public class EngineUpgrade : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            // create characterClass id x y team
            string type = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            string teamTmp = inputParams[5];
            
            Team team;
            if(teamTmp.ToLower() == "red")
                team = Team.Red;
            else if(teamTmp.ToLower() == "blue")
                team = Team.Blue;
            else throw new ArgumentOutOfRangeException("No such team, please choose either red or blue.");

            switch (type.ToLower())
            {
                case "warrior":
                    Character warrior = new Warrior(id, x, y, team);
                    characterList.Add(warrior);
                    break;
                case "mage":
                    Character mage = new Mage(id, x, y, team);
                    characterList.Add(mage);
                    break;
                case "healer":
                    Character healer = new Healer(id, x, y, team);
                    characterList.Add(healer);
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            // add character itemClass itemId
            string hero = inputParams[1];
            string itemClass = inputParams[2];
            string itemID = inputParams[3];
            Character temp = GetCharacterById(hero);
            
            switch (itemClass.ToLower())
            {
                case "axe":
                    Axe axe = new Axe(itemID);
                    temp.AddToInventory(axe);
                    break;
                case "shield":
                    Shield shield = new Shield(itemID);
                    temp.AddToInventory(shield);
                    break;
                case "injection":
                    Injection inj = new Injection(itemID);
                    temp.AddToInventory(inj);
                    break;
                case "pill":
                    Pill pill = new Pill(itemID);
                    temp.AddToInventory(pill);
                    break;
                default:
                    break;
            }
        }
    }
}
