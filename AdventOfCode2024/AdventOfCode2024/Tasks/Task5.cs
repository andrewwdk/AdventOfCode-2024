using AdventOfCode2024.Helpers;
using AdventOfCode2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Tasks
{
    public class Task5
    {
        private List<Rule> _rules = new List<Rule>();
        private List<List<int>> _pages = new List<List<int>>();
        public Task5()
        {
            var lines = FileHelper.ReadLines("Input5.txt");

            var emptyLineFound = false;

            foreach (var line in lines) 
            {
                if (line == string.Empty)
                {
                    emptyLineFound = true;
                    continue;
                }

                if (emptyLineFound)
                {
                    var pageList = line.Split(',').Select(int.Parse).ToList();
                    _pages.Add(pageList);
                }
                else
                {
                    var rule = line.Split('|');
                    _rules.Add(new Rule { First = int.Parse(rule[0]), Last = int.Parse(rule[1]) });
                }
            }

        }

        public void Part1()
        {
            var count = 0;

            foreach (var pageSet in _pages) 
            {
                if (IsPagesInCorrectOrder(pageSet))
                {
                    var middleIndex = (pageSet.Count - 1) / 2;
                    count += pageSet[middleIndex];
                }
            }

            OutputHelper.ShowResult(5, 1, count);
        }

        public void Part2()
        {
            var count = 0;

            foreach (var pageSet in _pages)
            {
                if (!IsPagesInCorrectOrder(pageSet))
                {
                    var newPageSet = SortPagesByRules(pageSet);
                    var middleIndex = (newPageSet.Count - 1) / 2;
                    count += newPageSet[middleIndex];
                }
            }

            OutputHelper.ShowResult(5, 2, count);
        }

        private bool IsPagesInCorrectOrder(List<int> pages)
        {
            for (var i = 0; i < pages.Count - 1; i++)
                for (var j = i+1; j < pages.Count; j++)
                {
                    var first = pages[i];
                    var second = pages[j];
                    var rule = _rules.FirstOrDefault(rule => rule.First == first && rule.Last == second);

                    if(rule == null)
                        return false;
                }

            return true;
        }

        private List<int> SortPagesByRules(List<int> pages)
        {
            var newPages = pages.ToList();

            for (var i = 0; i < newPages.Count - 1; i++)
                for (var j = i + 1; j < newPages.Count; j++)
                {
                    var first = newPages[i];
                    var second = newPages[j];
                    var rule = _rules.FirstOrDefault(rule => rule.First == second && rule.Last == first);

                    if (rule != null)
                    {
                        newPages[j] = first;
                        newPages[i] = second;
                    }
                }

            return newPages;
        }
    }
}
