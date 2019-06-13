namespace Example
{
    public class Iris
    {
        public float SepalLength { get; set; }
        public float SepalWidth { get; set; }
        public float PetalLength { get; set; }
        public float PetalWidth { get; set; }
        public IrisLabel Label { get; set; }

        public override string ToString()
        {
            return $"{this.Label}: {this.SepalLength},{this.SepalWidth},{this.PetalLength},{this.PetalWidth}";
        }
    }
}
