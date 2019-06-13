using DatasetBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Example
{
    public partial class DatasetForm : Form
    {
        public DatasetForm()
        {
            InitializeComponent();
            ConfigurarGrillas();
        }

        public void SetDatasets(DynamicDataset dataset)
        {
            AlimentarGrilla(gridTraining, dataset.Attributes, dataset.Training);
            AlimentarGrilla(gridValidation, dataset.Attributes, dataset.Validation);
            AlimentarGrilla(gridTest, dataset.Attributes, dataset.Test);
        }

        public void SetDatasets<TEntity, TLabel>(TypedDataset<TEntity> dataset, Expression<Func<TEntity, TLabel>> label)
            where TLabel : Enum
        {
            AlimentarGrilla(gridTraining, dataset.Training, label);
            AlimentarGrilla(gridValidation, dataset.Validation, label);
            AlimentarGrilla(gridTest, dataset.Test, label);
        }

        private void AlimentarGrilla<TEntity, TLabel>(DataGridView grid, IEnumerable<TEntity> datos, Expression<Func<TEntity, TLabel>> label)
        {
            grid.DataSource = datos;
            var labelCol = grid.Columns.OfType<DataGridViewColumn>().SingleOrDefault(c => c.DataPropertyName == (label.Body as MemberExpression).Member.Name);

            if (labelCol != null)
                labelCol.DisplayIndex = 0;
        }

        private void AlimentarGrilla(DataGridView grid, IEnumerable<string> attributes, IEnumerable<DynamicEntity> datos)
        {
            grid.DataSource = null;
            grid.Columns.Clear();

            grid.Columns.Add("LabelCol", "Label");

            foreach(var attr in attributes)
            {
                grid.Columns.Add(attr + "Col", attr);
            }

            foreach(var fila in datos)
            {
                var values = new List<object>();
                values.Add(fila.Label);
                values.AddRange(fila.Values.Cast<object>());

                grid.Rows.Add(values.ToArray());
            }
        }

        private void DatasetForm_Load(object sender, System.EventArgs e)
        {
            SetearAutoSizeGrilla(gridTraining);
            SetearAutoSizeGrilla(gridValidation);
            SetearAutoSizeGrilla(gridTest);
        }

        private void ConfigurarGrillas()
        {
            ConfigurarGrilla(gridTraining);
            ConfigurarGrilla(gridValidation);
            ConfigurarGrilla(gridTest);
        }

        private void ConfigurarGrilla(DataGridView grid)
        {
            grid.CellFormatting += OnCellFormatting;
            grid.CellPainting += OnCellPainting;
        }

        private void SetearAutoSizeGrilla(DataGridView grid)
        {
            grid.SuspendLayout();
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ResumeLayout();
        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs args)
        {
            // First row always displays
            if (args.RowIndex == 0)
                return;

            if (IsRepeatedCellValue(sender as DataGridView, args.RowIndex, args.ColumnIndex))
            {
                args.Value = string.Empty;
                args.FormattingApplied = true;
            }
        }

        private bool IsRepeatedCellValue(DataGridView grid, int rowIndex, int colIndex)
        {
            DataGridViewCell currCell = grid.Rows[rowIndex].Cells[colIndex];
            DataGridViewCell prevCell = grid.Rows[rowIndex - 1].Cells[colIndex];

            if ((currCell.Value == prevCell.Value) ||
               (currCell.Value != null && prevCell.Value != null &&
               currCell.Value.ToString() == prevCell.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs args)
        {
            var grid = sender as DataGridView;
            args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            // Ignore column and row headers and first row
            if (args.RowIndex < 1 || args.ColumnIndex < 0)
                return;

            if (IsRepeatedCellValue(grid, args.RowIndex, args.ColumnIndex))
            {
                args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                args.AdvancedBorderStyle.Top = grid.AdvancedCellBorderStyle.Top;
            }
        }
    }
}
