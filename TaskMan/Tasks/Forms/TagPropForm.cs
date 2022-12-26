using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class TagPropForm : Form
    {
        public TagPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowTagPropForm(IWin32Window owner)
        {
            TagPropForm form = new TagPropForm();
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }
    }
}
