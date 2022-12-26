using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class TaskPropForm : Form
    {
        public TaskPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowTaskPropForm(IWin32Window owner)
        {
            TaskPropForm form = new TaskPropForm();
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }

    }
}
