using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using ZForge.Controls.XPTable.Themes;

namespace ZForge.Controls.XPTable.Renderers
{
	/// <summary>
	/// ControlRendererData
	/// </summary>
	public class ControlRendererData
    {

        #region Class Data
        private Control control;
        #endregion

        #region Contstructor
        /// <summary>
        /// Creates a ControlRendererData with the given control.
        /// </summary>
        /// <param name="cellControl"></param>
        public ControlRendererData(Control cellControl)
		{
            this.control = cellControl;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the control for the cell.
        /// </summary>
        public Control Control
        {
            get { return this.control; }
            set { this.control = value; }
        }
        #endregion
    }
}
