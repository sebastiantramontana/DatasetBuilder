using System;

namespace DatasetBuilder
{
    public class Limits
    {
        public Limits(double min, double max)
        {
            if (min >= max)
            {
                throw new ArgumentException($"{nameof(min)} arg must be less than {nameof(max)}");
            }

            this.Min = min;
            this.Max = max;
        }

        public double Min { get; }
        public double Max { get; }

        public override string ToString()
        {
            return $"{this.Min} - {this.Max}";
        }
    }
}
