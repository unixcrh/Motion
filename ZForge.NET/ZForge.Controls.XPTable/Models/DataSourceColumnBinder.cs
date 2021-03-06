using System;
using System.ComponentModel;
using System.Text;

namespace ZForge.Controls.XPTable.Models
{
    /// <summary>
    /// Binder that creates the appropriate type of Column for a given column in a DataSource.
    /// </summary>
    public class DataSourceColumnBinder
    {
        /// <summary>
        /// Creates a DataSourceColumnBinder with default values.
        /// </summary>
        public DataSourceColumnBinder()
        {
        }

        /// <summary>
        /// Returns the type of column that is appropriate for the given property of the data source.
        /// Numbers, DateTime, Color and Boolean columns are mapped to NumberColumn, DateTimeColumn, ColorColumn and CheckBoxColumn respectively. The default
        /// is just a TextColumn.
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual Column GetColumn(PropertyDescriptor prop, int index)
        {
			Column column = null;
			switch (prop.PropertyType.Name)
			{
				case "Int32":
				case "Double":
				case "Float":
				case "Int16":
				case "Int64":
				case "Decimal":
					column = new NumberColumn(prop.Name);
					break;

				case "DateTime":
					column = new DateTimeColumn(prop.Name);
					break;

				case "Color":
					column = new ColorColumn(prop.Name);
					break;

				case "Boolean":
					column = new CheckBoxColumn(prop.Name);
					break;

				default:
					column = new TextColumn(prop.Name);
					break;
			}
            return column;
        }

		/// <summary>
		/// Returns the cell to add to a row for the given value, depending on the type of column it will be 
		/// shown in.
		/// If the column is a TextColumn then just the Text property is set. For all other
		/// column types just the Data value is set.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public virtual Cell GetCell(Column column, object val)
		{
			Cell cell = null;

			switch (column.GetType().Name)
			{
				case "TextColumn":
					cell = new Cell(val.ToString());
					break;

				case "CheckBoxColumn":
					bool check = false;
					if (val is Boolean)
						check = (bool)val;
					cell = new Cell("", check);
					break;

				default:
					cell = new Cell(val);
					break;
			}

			return cell;
		}
    }
}
