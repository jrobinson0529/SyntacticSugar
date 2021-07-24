using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        //public string FormalName
        //{
        //    get
        //    {
        //        return $"{Name} the {Species}";
        //    }
        //}
        public string FormalName => $"{Name} the {Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            Name = name;
            Species = species;
            Predators = predators;
            Prey = prey;
        }

        // Convert this method to an expression member
        //public string PreyList()
        //{
        //    var commaDelimitedPrey = string.Join(",", this.Prey);
        //    return commaDelimitedPrey;
        //}
        public string PreyList() => string.Join(",", this.Prey);
        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);

        // Convert this to expression method
        //public string Eat(string food)
        //{
        //    if (this.Prey.Contains(food))
        //    {
        //        return $"{this.Name} ate the {food}.";
        //    }
        //    else
        //    {
        //        return $"{this.Name} is still hungry.";
        //    }
        //}
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}" : $"{this.Name} is still hungry.";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bugOne = new Bug("Fly", "Flisterius Epotiumus", new List<string> { "human", "bats", "cheetah" }, new List<string> { "human", "dog", "cat" });
            Console.WriteLine(bugOne.FormalName);
            Console.WriteLine(bugOne.PreyList());
            Console.WriteLine(bugOne.Eat("human"));
        }
    }
}
