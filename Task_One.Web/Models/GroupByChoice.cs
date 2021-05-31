using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_One.Web.Models
{
    public class GroupByChoice
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public GroupByChoice(int value,string text)
        {
            Text = text;
            Value = value;
        }

        public static List<GroupByChoice> GetChoices()
        {
            List<GroupByChoice> choices = new List<GroupByChoice>();
            choices.Add(new GroupByChoice(1,"Price"));
            choices.Add(new GroupByChoice(2,"Store"));
            choices.Add(new GroupByChoice(3,"Sold Date"));

            return choices;
        }
    }
}
