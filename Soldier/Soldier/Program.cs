using System;
using System.Collections.Generic;
using System.Linq;

namespace Soldier
{
    class Program
    {
        static void Main(string[] args)
        {
            SoldierList soldierList = new SoldierList();

            soldierList.ShowStats();
        }
    }

    enum Weapon
    {
        MachineGun,
        Rifle,
        Pistol
    }

    enum RankType
    {
        Lieutenant,
        Captain,
        Major,
        Row
    }

    class Soldier
    {
        private Weapon _weapon;
        private int _serviceTime;
        public string Name { get; private set; }
        public RankType Rank { get; private set; }

        public Soldier(Weapon weapon, int serviceTime, string name, RankType rank)
        {
            _weapon = weapon;
            _serviceTime = serviceTime;
            Name = name;
            Rank = rank;
        }
    }

    class SoldierData
    {
        private string _name;
        private RankType _rank;

        public SoldierData(string name, RankType rank)
        {
            _name = name;
            _rank = rank;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} - звание {_rank}");
        }
    }

    class SoldierList
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private List<SoldierData> _soldiersData = new List<SoldierData>();
        private Random _random = new Random();

        public SoldierList()
        {
            var enumWeapon = Enum.GetValues(typeof(Weapon)).Length;
            var enumRank = Enum.GetValues(typeof(RankType)).Length;
            int maxTime = 12;

            _soldiers.Add(new Soldier((Weapon)_random.Next(0, enumWeapon), _random.Next(1, maxTime), "Капитан Америка", (RankType)_random.Next(0, enumRank)));
            _soldiers.Add(new Soldier((Weapon)_random.Next(0, enumWeapon), _random.Next(1, maxTime), "Майор Пейн", (RankType)_random.Next(0, enumRank)));
            _soldiers.Add(new Soldier((Weapon)_random.Next(0, enumWeapon), _random.Next(1, maxTime), "Баки", (RankType)_random.Next(0, enumRank)));
            _soldiers.Add(new Soldier((Weapon)_random.Next(0, enumWeapon), _random.Next(1, maxTime), "Капитан Поляны", (RankType)_random.Next(0, enumRank)));
            _soldiers.Add(new Soldier((Weapon)_random.Next(0, enumWeapon), _random.Next(1, maxTime), "Генерал Озеро", (RankType)_random.Next(0, enumRank)));
        }

        public void ShowStats()
        {
            AssignData();

            foreach (var soldier in _soldiersData)
            {
                soldier.ShowStats();
            }
        }

        private void AssignData()
        {
            List<string> filtredName = new List<string>();
            List<RankType> filtredRank = new List<RankType>();

            var filtredNameSoldiers = _soldiers.Select(soldier => soldier.Name);
            var filtredRankSoldiers = _soldiers.Select(soldier => soldier.Rank);

            filtredName = filtredNameSoldiers.ToList();
            filtredRank = filtredRankSoldiers.ToList();

            for (int i = 0; i < filtredName.Count; i++)
            {
                _soldiersData.Add(new SoldierData(filtredName[i], filtredRank[i]));
            }
        }
    }
}
