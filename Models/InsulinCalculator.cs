using System.Collections.Generic;

namespace Insulizzy.Models
{
    public class InsulinCalculator
    {
        public string Meal { get; set; }
        public int BGLevel { get; set; } // Blood Glucose Level
        public int MealCarbs { get; set; } // Carbohydrates for the meal

        // Static meal ratios (from spreadsheet)
        private static readonly Dictionary<string, int> Ratios = new Dictionary<string, int>
        {
            { "Breakfast", 22 },
            { "Lunch", 18 },
            { "Dinner", 15 },
            { "Supper", 28 }
        };

        // Hard-coded correction table (example values)
        private static readonly List<CorrectionEntry> CorrectionTable = new List<CorrectionEntry>
        {
            new CorrectionEntry { CorrectionFactor = 1.5, LowBG = 13.5, HighBG = 14.9, ExtraUnits = 5 },
            new CorrectionEntry { CorrectionFactor = 1.5, LowBG = 15, HighBG = 16.4, ExtraUnits = 6 },
            // Add more entries here...
        };

        private class CorrectionEntry
        {
            public double CorrectionFactor { get; set; }
            public double LowBG { get; set; }
            public double HighBG { get; set; }
            public double ExtraUnits { get; set; }
        }

        public double CalculateInsulin()
        {
            if (!Ratios.ContainsKey(Meal)) return 0;

            int ratio = Ratios[Meal];
            return (double)MealCarbs / ratio;
        }

        public double CalculateInsulinCorrection()
        {
            foreach (var entry in CorrectionTable)
            {
                if (BGLevel >= entry.LowBG && BGLevel <= entry.HighBG)
                {
                    return entry.ExtraUnits;
                }
            }
            return 0;
        }

        public double CalculateInsulinTotal()
        {
            return CalculateInsulin() + CalculateInsulinCorrection();
        }
    }
}
