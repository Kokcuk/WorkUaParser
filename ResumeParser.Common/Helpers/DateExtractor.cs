using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ResumeParser.Common.Helpers
{
    public class DateExtractor
    {
        readonly Dictionary<string, int> monthsMap;

        public DateExtractor()
        {
            this.monthsMap = new Dictionary<string, int>();
            InitMonths();
        }

        public List<Tuple<int, DateTime>> ExtractDates(string text)
        {
            var result = new List<Tuple<int, DateTime>>();

            string months = String.Join("|", this.monthsMap.Keys);
            var regexps = new Regex[] {
                new Regex(@"(?<day>\d\d?)(?<sep>[.\-])(?<month>\d\d)\k<sep>(?<year>\d\d(?:\d\d)?)", RegexOptions.IgnoreCase),
                new Regex(@"(?<day>\d\d?)\s+(?<month>(?:" + months + @"))\s+(?<year>\d\d(?:\d\d)?)", RegexOptions.IgnoreCase),
                new Regex(@"\s+(?<month>\d\d?)\.(?<year>\d\d(?:\d\d)?)", RegexOptions.IgnoreCase)
            };

            foreach (var regex in regexps)
            {
                foreach (Match match in regex.Matches(text))
                {
                    try
                    {
                        int day = 1;
                        if(!string.IsNullOrEmpty(match.Groups["day"].Value))
                            day = Int32.Parse(match.Groups["day"].Value);
                        int year = Int32.Parse(match.Groups["year"].Value);
                        if (year < 100)
                        {
                            if (year > DateTime.Today.Year + 10)
                            {
                                year += 2000;
                            }
                            else
                            {
                                year += 1900;
                            }
                        }
                        int month = ParseMonth(match.Groups["month"].Value);
                        result.Add(new Tuple<int, DateTime>(match.Index, new DateTime(year, month, day)));
                    }
                    catch (FormatException)
                    {
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }
            return result;
        }

        private int ParseMonth(string month)
        {
            try
            {
                return this.monthsMap[month.ToLower()];
            }
            catch (Exception)
            {
            }

            try
            {
                return Int32.Parse(month);
            }
            catch (Exception)
            {
            }

            throw new ArgumentException("Invalid month: " + month);
        }

        private void InitMonths()
        {
            this.monthsMap["январь"] = 1;
            this.monthsMap["февраль"] = 2;
            this.monthsMap["март"] = 3;
            this.monthsMap["апрель"] = 4;
            this.monthsMap["май"] = 5;
            this.monthsMap["июнь"] = 6;
            this.monthsMap["июль"] = 7;
            this.monthsMap["август"] = 8;
            this.monthsMap["сентябрь"] = 9;
            this.monthsMap["октябрь"] = 10;
            this.monthsMap["ноябрь"] = 11;
            this.monthsMap["декабрь"] = 12;

            this.monthsMap["января"] = 1;
            this.monthsMap["февраля"] = 2;
            this.monthsMap["марта"] = 3;
            this.monthsMap["апреля"] = 4;
            this.monthsMap["мая"] = 5;
            this.monthsMap["июня"] = 6;
            this.monthsMap["июля"] = 7;
            this.monthsMap["августа"] = 8;
            this.monthsMap["сентября"] = 9;
            this.monthsMap["октября"] = 10;
            this.monthsMap["ноября"] = 11;
            this.monthsMap["декабря"] = 12;

            this.monthsMap["january"] = 1;
            this.monthsMap["february"] = 2;
            this.monthsMap["march"] = 3;
            this.monthsMap["april"] = 4;
            this.monthsMap["may"] = 5;
            this.monthsMap["june"] = 6;
            this.monthsMap["july"] = 7;
            this.monthsMap["august"] = 8;
            this.monthsMap["september"] = 9;
            this.monthsMap["october"] = 10;
            this.monthsMap["november"] = 11;
            this.monthsMap["december"] = 12;
        }
    }
}