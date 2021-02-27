using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlazorYahtzee.Models
{
    public class Dice
    {
        private readonly List<Die> _collection = new List<Die>();
        public ReadOnlyCollection<Die> Collection => _collection.AsReadOnly();
        public IEnumerable<Die> NotHeldCollection => _collection.Where(x => x.IsHeld == false);

        private const int NumberOfDice = 5;

        public Dice()
        {
            for (var i = 0; i < NumberOfDice; i++)
            {
                _collection.Add(new Die());
            }
        }

        public void Release()
        {
            foreach (var die in _collection)
            {
                die.Release();
            }
        }

        public bool HasPairOf(int value)
        {
            return _collection.Count(x => x.Value == value) >= 2;
        }

        public bool HasThreeOfAKind(int value)
        {
            return _collection.Count(x => x.Value == value) >= 3;
        }

        public bool HasFourOfAKind(int value)
        {
            return _collection.Count(x => x.Value == value) >= 4;
        }

        public bool HasAnyPair()
        {
            return HasPairOf(1)
                   || HasPairOf(2)
                   || HasPairOf(3)
                   || HasPairOf(4)
                   || HasPairOf(5)
                   || HasPairOf(6);
        }

        public bool HasTwoPair()
        {
            var groups = _collection
                .GroupBy(x => x.Value)
                .Select(group => new
                {
                    Value = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count);

            if (groups.Count() == 2 &&
                groups.ElementAt(0).Count == 3 &&
                groups.ElementAt(1).Count == 2)
            {
                return true;
            }

            if (groups.Count() == 3 &&
                groups.ElementAt(0).Count == 2 &&
                groups.ElementAt(1).Count == 2)
            {
                return true;
            }

            return false;
        }

        public bool HasAnyThreeOfAKind()
        {
            return HasThreeOfAKind(1)
                   || HasThreeOfAKind(2)
                   || HasThreeOfAKind(3)
                   || HasThreeOfAKind(4)
                   || HasThreeOfAKind(5)
                   || HasThreeOfAKind(6);
        }

        public bool HasAnyFourOfAKind()
        {
            return HasFourOfAKind(1)
                   || HasFourOfAKind(2)
                   || HasFourOfAKind(3)
                   || HasFourOfAKind(4)
                   || HasFourOfAKind(5)
                   || HasFourOfAKind(6);
        }

        public bool HasFullHouse()
        {
            var groups = _collection
                .GroupBy(x => x.Value)
                .Select(group => new
                {
                    Value = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count);

            if (groups.Count() != 2)
            {
                return false;
            }

            if (groups.ElementAt(0).Count == 3 && groups.ElementAt(1).Count == 2)
            {
                return true;
            }

            return false;
        }

        public bool HasSmallStraight()
        {
            var hasOne = _collection.Exists(x => x.Value == 1);
            var hasTwo = _collection.Exists(x => x.Value == 2);
            var hasThree = _collection.Exists(x => x.Value == 3);
            var hasFour = _collection.Exists(x => x.Value == 4);
            var hasFive = _collection.Exists(x => x.Value == 5);
            var hasSix = _collection.Exists(x => x.Value == 6);

            return hasOne && hasTwo && hasThree && hasFour ||
                   hasTwo && hasThree && hasFour && hasFive ||
                   hasThree && hasFour && hasFive && hasSix;
        }

        public bool HasLargeStraight()
        {
            var hasOne = _collection.Exists(x => x.Value == 1);
            var hasTwo = _collection.Exists(x => x.Value == 2);
            var hasThree = _collection.Exists(x => x.Value == 3);
            var hasFour = _collection.Exists(x => x.Value == 4);
            var hasFive = _collection.Exists(x => x.Value == 5);
            var hasSix = _collection.Exists(x => x.Value == 6);

            return hasOne && hasTwo && hasThree && hasFour && hasFive ||
                   hasTwo && hasThree && hasFour && hasFive && hasSix;
        }

        public bool HasYahtzee()
        {
            var value = _collection.First().Value;

            return _collection.All(x => x.Value == value);
        }

        public int SumOf(int value)
        {
            return _collection.Where(x => x.Value == value).Sum(x => x.Value);
        }

        public int SumOfTwoPair()
        {
            var groups = _collection
                .GroupBy(x => x.Value)
                .Select(group => new
                {
                    Value = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count);

            var isFullHouse = groups.Count() == 2 &&
                              groups.ElementAt(0).Count == 3 &&
                              groups.ElementAt(1).Count == 2;

            var isTwoPair = groups.Count() == 3 &&
                            groups.ElementAt(0).Count == 2 &&
                            groups.ElementAt(1).Count == 2;

            if (isFullHouse || isTwoPair)
            {
                return (groups.ElementAt(0).Value + groups.ElementAt(1).Value) * 2;
            }

            return 0;
        }

        public int SumOfAKind(int count)
        {
            var groups = _collection
                .GroupBy(x => x.Value)
                .Select(group => new
                {
                    Value = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenByDescending(x => x.Value);
            
            var value = count == 2 
                ? groups.OrderByDescending(x => x.Value).First().Value 
                : groups.First().Value;

            return _collection.Count(x => x.Value == value) >= count
                ? _collection.Where(x => x.Value == value).Sum(x => x.Value)
                : 0;
        }

        public int SumOfAll()
        {
            return _collection.Sum(x => x.Value);
        }
    }
}