﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class TriangleWall : Wall
    {

        public TriangleWall(string name, string color, int @base, int height) : base(name, color)
        {
            Base = @base;
            Height = height;
        }
        public int Base { get; }
        public int Height { get; }

        public override int GetArea()
        {
            return (Base * Height) / 2;
        }

        public override string ToString()
        {
            return $"{Name} ({Base}x{Height}) triangle";

        }
    }
}
