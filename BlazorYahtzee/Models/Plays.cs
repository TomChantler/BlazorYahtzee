using System;
using System.Collections.Generic;
using System.Linq;
using BlazorYahtzee.Models.Categories;
using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models
{
    public class Plays
    {
        private readonly List<Play> _collection = new List<Play>();

        public ColumnType Type { get; }

        private const int UpperSectionBonus = 35;
        private const int UpperSectionBonusThreshold = 63;

        public Plays(ColumnType type)
        {
            Type = type;
        }

        public void Add(ICategory category, int points)
        {
            _collection.Add(new Play(category, points));
        }

        public void Reset()
        {
            _collection.Clear();
        }

        public bool HasPlay(Type category)
        {
            return _collection.Exists(x => x.Category.GetType().IsAssignableFrom(category));
        }

        public bool HasPlay(ICategory category)
        {
            return _collection.Select(x => x.Category).Contains(category);
        }

        public bool HasYahtzeePlay()
        {
            return NumberOfYahtzeePlays() > 0;
        }

        public bool HasYahtzeePlayForBonus()
        {
            return _collection.Any(x => x.Points > 0 && x.Category.GetType().IsAssignableFrom(typeof(Yahtzee)));
        }

        public bool HasMultipleYahtzeePlays()
        {
            return NumberOfYahtzeePlays() >= 2;
        }

        public int NumberOfYahtzeePlays()
        {
            return _collection.Count(x => x.Points > 0 && x.Category.GetType().IsAssignableFrom(typeof(Yahtzee)));
        }

        public bool HasBonus()
        {
            return _collection.Where(x => x.Category.Section == SectionType.Upper).Sum(x => x.Points) >= UpperSectionBonusThreshold;
        }

        public int ScoreFor(ICategory category)
        {
            var play = _collection.FirstOrDefault(x => x.Category == category);

            return play?.Points ?? 0;
        }

        public int ScoreForYahtzee()
        {
            return HasYahtzeePlay() ? 50 : 0;
        }

        public int ScoreForYahtzeeBonus()
        {
            return HasMultipleYahtzeePlays() ? (NumberOfYahtzeePlays() - 1) * 100 : 0;
        }

        public int ScoreForUpperSectionWithBonus()
        {
            var scoreForUpperSection = ScoreForUpperSection();

            return HasBonus() ? scoreForUpperSection + UpperSectionBonus : scoreForUpperSection;
        }

        public int ScoreForUpperSection()
        {
            return _collection.Where(x => x.Category.Section == SectionType.Upper).Sum(x => x.Points);
        }

        public int ScoreForLowerSection()
        {
            var lowerSectionPointsExcludingYahtzee = _collection.Where(x =>
                    x.Category.Section == SectionType.Lower &&
                    !x.Category.GetType().IsAssignableFrom(typeof(Yahtzee)))
                .Sum(x => x.Points);

            return lowerSectionPointsExcludingYahtzee + ScoreForYahtzee() + ScoreForYahtzeeBonus();
        }

        public int TotalScore()
        {
            return ScoreForUpperSectionWithBonus() + ScoreForLowerSection();
        }
    }
}