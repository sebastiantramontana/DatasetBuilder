using DatasetBuilder;
using DatasetBuilder.Orderings;
using System;
using System.Windows.Forms;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAllOrderingCombos();
        }

        private void LoadAllOrderingCombos()
        {
            LoadOrderingCombo(OverallDefaultOrdering);
            LoadOrderingCombo(SepalLengthDefaultOrdering);
            LoadOrderingCombo(SepalWidthDefaultOrdering);
            LoadOrderingCombo(PetalLengthDefaultOrdering);
            LoadOrderingCombo(PetalWidthDefaultOrdering);

            LoadOrderingCombo(SetosaSepalLengthOrdering);
            LoadOrderingCombo(SetosaSepalWidthOrdering);
            LoadOrderingCombo(SetosaPetalLengthOrdering);
            LoadOrderingCombo(SetosaPetalWidthOrdering);

            LoadOrderingCombo(VersicolorSepalLengthOrdering);
            LoadOrderingCombo(VersicolorSepalWidthOrdering);
            LoadOrderingCombo(VersicolorPetalLengthOrdering);
            LoadOrderingCombo(VersicolorPetalWidthOrdering);

            LoadOrderingCombo(VirginicaSepalLengthOrdering);
            LoadOrderingCombo(VirginicaSepalWidthOrdering);
            LoadOrderingCombo(VirginicaPetalLengthOrdering);
            LoadOrderingCombo(VirginicaPetalWidthOrdering);
        }

        private void LoadOrderingCombo(ComboBox comboBox)
        {
            comboBox.Items.AddRange(OrderingFactory.All);
            comboBox.SelectedIndex = 0;
        }

        private void btnGenerateTyped_Click(object sender, EventArgs e)
        {
            var builder = CreateBuilderTyped();
            var dataset = GenerateTyped(builder);

            using (var form = new DatasetForm())
            {
                form.SetDatasets(dataset, iris => iris.Label);
                form.ShowDialog();
            }
        }

        private void btnGenerateDynamic_Click(object sender, EventArgs e)
        {
            var builder = CreateBuilderDynamic();
            var dataset = GenerateDynamic(builder);

            using (var form = new DatasetForm())
            {
                form.SetDatasets(dataset);
                form.ShowDialog();
            }
        }

        private TypedDatasetBuilder<Iris, float, IrisLabel> CreateBuilderTyped()
        {
            var datasetBuilder = new TypedDatasetBuilder<Iris, float, IrisLabel>(iris => iris.Label, GetSelectedOrdering(OverallDefaultOrdering), null);

            datasetBuilder.Configure()
                .Ordering()
                    .Attribute(iris => iris.SepalLength, GetSelectedOrdering(SepalLengthDefaultOrdering))
                    .Attribute(iris => iris.SepalWidth, GetSelectedOrdering(SepalWidthDefaultOrdering))
                    .Attribute(iris => iris.PetalLength, GetSelectedOrdering(PetalLengthDefaultOrdering))
                    .Attribute(iris => iris.PetalWidth, GetSelectedOrdering(PetalWidthDefaultOrdering))
                .Label(IrisLabel.Setosa)
                    .Attribute(p => p.SepalLength, (float)SetosaSepalLengthMin.Value, (float)SetosaSepalLengthMax.Value, GetSelectedOrdering(SetosaSepalLengthOrdering))
                    .Attribute(p => p.SepalWidth, (float)SetosaSepalWidthMin.Value, (float)SetosaSepalWidthMax.Value, GetSelectedOrdering(SetosaSepalWidthOrdering))
                    .Attribute(p => p.PetalLength, (float)SetosaPetalLengthMin.Value, (float)SetosaPetalLengthMax.Value, GetSelectedOrdering(SetosaPetalLengthOrdering))
                    .Attribute(p => p.PetalWidth, (float)SetosaPetalWidthMin.Value, (float)SetosaPetalWidthMax.Value, GetSelectedOrdering(SetosaPetalWidthOrdering))
                .Label(IrisLabel.Versicolor)
                    .Attribute(p => p.SepalLength, (float)VersicolorSepalLengthMin.Value, (float)VersicolorSepalLengthMax.Value, GetSelectedOrdering(VersicolorSepalLengthOrdering))
                    .Attribute(p => p.SepalWidth, (float)VersicolorSepalWidthMin.Value, (float)VersicolorSepalWidthMax.Value, GetSelectedOrdering(VersicolorSepalWidthOrdering))
                    .Attribute(p => p.PetalLength, (float)VersicolorPetalLengthMin.Value, (float)VersicolorPetalLengthMax.Value, GetSelectedOrdering(VersicolorPetalLengthOrdering))
                    .Attribute(p => p.PetalWidth, (float)VersicolorPetalWidthMin.Value, (float)VersicolorPetalWidthMax.Value, GetSelectedOrdering(VersicolorPetalWidthOrdering))
                .Label(IrisLabel.Virginica)
                    .Attribute(p => p.SepalLength, (float)VirginicaSepalLengthMin.Value, (float)VirginicaSepalLengthMax.Value, GetSelectedOrdering(VirginicaSepalLengthOrdering))
                    .Attribute(p => p.SepalWidth, (float)VirginicaSepalWidthMin.Value, (float)VirginicaSepalWidthMax.Value, GetSelectedOrdering(VirginicaSepalWidthOrdering))
                    .Attribute(p => p.PetalLength, (float)VirginicaPetalLengthMin.Value, (float)VirginicaPetalLengthMax.Value, GetSelectedOrdering(VirginicaPetalLengthOrdering))
                    .Attribute(p => p.PetalWidth, (float)VirginicaPetalWidthMin.Value, (float)VirginicaPetalWidthMax.Value, GetSelectedOrdering(VirginicaPetalWidthOrdering));

            return datasetBuilder;
        }

        private DynamicDatasetBuilder CreateBuilderDynamic()
        {
            var datasetBuilder = new DynamicDatasetBuilder(GetSelectedOrdering(OverallDefaultOrdering));

            datasetBuilder.Configure()
                .Ordering()
                    .Attribute("Sepal Length", GetSelectedOrdering(SepalLengthDefaultOrdering))
                    .Attribute("Sepal Width", GetSelectedOrdering(SepalWidthDefaultOrdering))
                    .Attribute("Petal Length", GetSelectedOrdering(PetalLengthDefaultOrdering))
                    .Attribute("Petal Width", GetSelectedOrdering(PetalWidthDefaultOrdering))
                .Label("Setosa")
                    .Attribute("Sepal Length", (float)SetosaSepalLengthMin.Value, (float)SetosaSepalLengthMax.Value, GetSelectedOrdering(SetosaSepalLengthOrdering))
                    .Attribute("Sepal Width", (float)SetosaSepalWidthMin.Value, (float)SetosaSepalWidthMax.Value, GetSelectedOrdering(SetosaSepalWidthOrdering))
                    .Attribute("Petal Length", (float)SetosaPetalLengthMin.Value, (float)SetosaPetalLengthMax.Value, GetSelectedOrdering(SetosaPetalLengthOrdering))
                    .Attribute("Petal Width", (float)SetosaPetalWidthMin.Value, (float)SetosaPetalWidthMax.Value, GetSelectedOrdering(SetosaPetalWidthOrdering))
                .Label("Versicolor")
                    .Attribute("Sepal Length", (float)VersicolorSepalLengthMin.Value, (float)VersicolorSepalLengthMax.Value, GetSelectedOrdering(VersicolorSepalLengthOrdering))
                    .Attribute("Sepal Width", (float)VersicolorSepalWidthMin.Value, (float)VersicolorSepalWidthMax.Value, GetSelectedOrdering(VersicolorSepalWidthOrdering))
                    .Attribute("Petal Length", (float)VersicolorPetalLengthMin.Value, (float)VersicolorPetalLengthMax.Value, GetSelectedOrdering(VersicolorPetalLengthOrdering))
                    .Attribute("Petal Width", (float)VersicolorPetalWidthMin.Value, (float)VersicolorPetalWidthMax.Value, GetSelectedOrdering(VersicolorPetalWidthOrdering))
                .Label("Virginica")
                    .Attribute("Sepal Length", (float)VirginicaSepalLengthMin.Value, (float)VirginicaSepalLengthMax.Value, GetSelectedOrdering(VirginicaSepalLengthOrdering))
                    .Attribute("Sepal Width", (float)VirginicaSepalWidthMin.Value, (float)VirginicaSepalWidthMax.Value, GetSelectedOrdering(VirginicaSepalWidthOrdering))
                    .Attribute("Petal Length", (float)VirginicaPetalLengthMin.Value, (float)VirginicaPetalLengthMax.Value, GetSelectedOrdering(VirginicaPetalLengthOrdering))
                    .Attribute("Petal Width", (float)VirginicaPetalWidthMin.Value, (float)VirginicaPetalWidthMax.Value, GetSelectedOrdering(VirginicaPetalWidthOrdering));

            return datasetBuilder;
        }

        private TypedDataset<Iris> GenerateTyped(TypedDatasetBuilder<Iris, float, IrisLabel> datasetBuilder)
        {
            var dataset = datasetBuilder.Generate((int)TrainingSamplesCount.Value, (int)ValidationSamplesCount.Value, (int)TestSamplesCount.Value);
            return dataset;
        }

        private DynamicDataset GenerateDynamic(DynamicDatasetBuilder datasetBuilder)
        {
            var dataset = datasetBuilder.Generate((int)TrainingSamplesCount.Value, (int)ValidationSamplesCount.Value, (int)TestSamplesCount.Value);
            return dataset;
        }

        private IOrdering GetSelectedOrdering(ComboBox combo)
        {
            return combo.SelectedItem as IOrdering;
        }
    }
}
