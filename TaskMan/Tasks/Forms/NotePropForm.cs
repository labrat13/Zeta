using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class NotePropForm : Form
    {
        public NotePropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowNotePropForm(IWin32Window owner)
        {
            NotePropForm form = new NotePropForm();
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }
    }
}
