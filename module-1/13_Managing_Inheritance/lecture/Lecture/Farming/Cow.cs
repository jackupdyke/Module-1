﻿namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        public Cow() : base("Cow", "moo")
        {
            Price = 1500;
        }
        public override string Eat()
        {
            return "Eating cow food...";

        }
    }
}
