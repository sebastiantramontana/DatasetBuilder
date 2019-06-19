# DatasetBuilder
A simple dataset builder library to generate automatically random labeled data

## Usage:
There are two datasets classes: Typed and non-typed.

### Typed Dataset:

1- Create de labeled entity type:

```csharp

    public class Iris
    {
        public float SepalLength { get; set; }
        public float SepalWidth { get; set; }
        public float PetalLength { get; set; }
        public float PetalWidth { get; set; }
        public IrisLabel Label { get; set; } //must be an enum
    }

    public enum IrisLabel
    {
        Setosa,
        Versicolor,
        Virginica
    }
```
2- Instance the TypedDatasetBuilder in the following way:
    - Type it with Entity type: the type of data (the Iris class in this example).
    - Attribute type: type of entity's properties used as attributes (SepalLength,SepalWidth... are float in this example).
    - Label type: it must be an Enum (IrisLabel in this example).
    - Pass the property used as label as lambda (iris => iris.Label in this example)
    - Optionally, pass a overall default ordering.

```csharp
    var datasetBuilder = new TypedDatasetBuilder<Iris, float, IrisLabel>(iris => iris.Label, OrderingFactory.Random);
```

3- Configure the datasetbuilder:
    - Set de default ordering algorithm for each attributes (override the overall default ordering).
    - Set the min, max values and, optionally, the ordering (override default), for each attribute for each labels

```csharp

    datasetBuilder.Configure()
        .Ordering()
            .Attribute(iris => iris.SepalLength, OrderingFactory.MaxToCenter)
            .Attribute(iris => iris.SepalWidth, OrderingFactory.MinToCenter)
            .Attribute(iris => iris.PetalLength, OrderingFactory.Descending)
        .Label(IrisLabel.Setosa)
            .Attribute(p => p.SepalLength, 4.3, 5.8f)
            .Attribute(p => p.SepalWidth, 2.3f, 4.4f)
            .Attribute(p => p.PetalLength, 1.0f, 1.9f)
            .Attribute(p => p.PetalWidth, 0.1f, 0.6f, OrderingFactory.Ascending)
        .Label(IrisLabel.Versicolor)
            .Attribute(p => p.SepalLength, 4.9f, 7.0f, OrderingFactory.None)
            .Attribute(p => p.SepalWidth, 2.0f, 3.4f)
            .Attribute(p => p.PetalLength, 3.0f, 5.1f)
            .Attribute(p => p.PetalWidth, 1.0f, 1.8f)
        .Label(IrisLabel.Virginica)
            .Attribute(p => p.SepalLength, 4.9f, 7.9f)
            .Attribute(p => p.SepalWidth, 2.2f, 2.8f, OrderingFactory.MaxToCenter)
            .Attribute(p => p.PetalLength, 4.5f, 6.9f)
            .Attribute(p => p.PetalWidth, 1.4f, 2.5f);
```

4- Generate data: Pass the samples count for training, validation and test for each label. Each dataset is an enumerable of entity.

```csharp

var dataset = datasetBuilder.Generate(80, 20, 20);
var training = dataset.Training;
var validation = dataset.Validation;
var test = dataset.Test;

```

### Non-typed Dataset:
Dynamic (non-typed) dataset has not entity types and you can build it dynamically. So:

```csharp

    var datasetBuilder = new DynamicDatasetBuilder(OrderingFactory.Random);

    datasetBuilder.Configure()
        .Ordering()
            .Attribute("SepalLength", OrderingFactory.MaxToCenter)
            .Attribute("SepalWidth", OrderingFactory.MinToCenter)
            .Attribute("PetalLength", OrderingFactory.Descending)
        .Label("Setosa")
            .Attribute("SepalLength", 4.3, 5.8f)
            .Attribute("SepalWidth", 2.3f, 4.4f)
            .Attribute("PetalLength", 1.0f, 1.9f)
            .Attribute("PetalWidth", 0.1f, 0.6f, OrderingFactory.Ascending)
        .Label("Versicolor")
            .Attribute("SepalLength", 4.9f, 7.0f, OrderingFactory.None)
            .Attribute("SepalWidth", 2.0f, 3.4f)
            .Attribute("PetalLength", 3.0f, 5.1f)
            .Attribute("PetalWidth", 1.0f, 1.8f)
        .Label("Virginica")
            .Attribute("SepalLength", 4.9f, 7.9f)
            .Attribute("SepalWidth",2.2f, 2.8f, OrderingFactory.MaxToCenter)
            .Attribute("PetalLength", 4.5f, 6.9f)
            .Attribute("PetalWidth", 1.4f, 2.5f);

    var dataset = datasetBuilder.Generate(80, 20, 20); //Each dataset is an enumerable of DynamicEntity
    var training = dataset.Training;
    var validation = dataset.Validation;
    var test = dataset.Test;
	
```

## Extensibility
- There are some preset orderings. They were placed on OrderingFactory class, but you can implement IOrdering by yourself.
- The default IAttributeNumberGenerator is EquidistantAttributeNumberGenerator: That one generates random numbers between max and min limit attribute's values splitted by count. You can implement your own.

See the Example project!
