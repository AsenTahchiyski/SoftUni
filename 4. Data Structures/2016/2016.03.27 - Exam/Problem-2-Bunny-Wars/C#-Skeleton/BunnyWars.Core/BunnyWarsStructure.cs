namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;
    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        private OrderedDictionary<int, List<Bunny>> roomsById = 
                    new OrderedDictionary<int, List<Bunny>>();
        private int totalBunnies = 0;
        private Dictionary<string, Bunny> bunniesByName = 
                    new Dictionary<string, Bunny>();
        private SortedSet<Bunny>[] bunniesByTeam = new SortedSet<Bunny>[5];
        private OrderedSet<int> roomsSorted = new OrderedSet<int>();

        public int BunnyCount { get { return this.totalBunnies; } }

        public int RoomCount { get { return this.roomsById.Count; } }

        public void AddRoom(int roomId)
        {
            if (this.roomsById.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            this.roomsById.Add(roomId, new List<Bunny>());
            this.roomsSorted.Add(roomId);
        }

        public void AddBunny(string name, int team, int roomId)
        {
            if (!this.roomsById.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            if (this.bunniesByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            if (team < 0 || team > 4)
            {
                throw new IndexOutOfRangeException();
            }

            var bunny = new Bunny(name, team, roomId);
            this.roomsById[roomId].Add(bunny);
            this.totalBunnies++;
            this.bunniesByName.Add(name, bunny);
            
            // add to bunniesByTeam
            if (this.bunniesByTeam[team] == null)
            {
                this.bunniesByTeam[team] = new SortedSet<Bunny>();
            }

            this.bunniesByTeam[team].Add(bunny);
        }

        public void Remove(int roomId)
        {
            if (!this.roomsById.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            var bunniesHere = this.roomsById[roomId];
            foreach (Bunny bunny in bunniesHere)
            {
                this.bunniesByName.Remove(bunny.Name);
                this.bunniesByTeam[bunny.Team].Remove(bunny);
                this.totalBunnies--;
            }

            this.roomsById.Remove(roomId);
            this.roomsSorted.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = this.bunniesByName[bunnyName];
            var nextRooms = this.roomsById.RangeFrom(bunny.RoomId, false).Keys;
            int nextRoomKey;
            if (nextRooms.Count == 0)
            {
                nextRoomKey = this.roomsById.First().Key;
            }
            else
            {
                nextRoomKey = nextRooms.First();
            }

            var currentRoom = this.roomsById[bunny.RoomId];
            var nextRoom = this.roomsById[nextRoomKey];
            currentRoom.Remove(bunny);
            nextRoom.Add(bunny);
            bunny.RoomId = nextRoomKey;
        }

        public void Previous(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = this.bunniesByName[bunnyName];
            var prevRooms = this.roomsSorted.RangeTo(bunny.RoomId, false);
            int prevRoomKey;
            if (prevRooms.Count == 0)
            {
                prevRoomKey = this.roomsSorted.GetLast();
            }
            else
            {
                prevRoomKey = prevRooms.GetLast();
            }

            var currentRoom = this.roomsById[bunny.RoomId];
            var prevRoom = this.roomsById[prevRoomKey];
            currentRoom.Remove(bunny);
            prevRoom.Add(bunny);
            bunny.RoomId = prevRoomKey;
        }

        public void Detonate(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = this.bunniesByName[bunnyName];
            var allBunnies = this.roomsById[bunny.RoomId].ToArray();
            foreach (var bun in allBunnies)
            {
                if (bun.Team != bunny.Team)
                {
                    // take damage
                    bun.Health -= 30;
                    if(bun.Health <= 0)
                    {
                        this.bunniesByName.Remove(bun.Name);
                        this.roomsById[bun.RoomId].Remove(bun);
                        this.bunniesByTeam[bun.Team].Remove(bun);
                        this.totalBunnies--;

                        bunny.Score++;
                    }
                }
            }
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            if (team < 0 || team > 4)
            {
                throw new IndexOutOfRangeException();
            }

            return this.bunniesByTeam[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            var customComparer = new CustomComparer();
            var result = new SortedDictionary<string, Bunny>(customComparer);
            foreach (var bunny in this.bunniesByName.Values)
            {
                if (bunny.Name.EndsWith(suffix))
                {
                    result.Add(ReverseName(bunny.Name), bunny);
                }
            }

            foreach (var item in result)
            {
                yield return item.Value;
            }
        }

        private string ReverseName(string name)
        {
            StringBuilder result = new StringBuilder();
            for (int i = name.Length - 1; i >= 0 ; i--)
            {
                result.Append(name[i]);
            }

            return result.ToString();
        }
    }
}
