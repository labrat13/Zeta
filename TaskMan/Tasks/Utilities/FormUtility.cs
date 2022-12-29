using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Utilities
{
    public class FormUtility
    {

        #region Forms functions
        /// <summary>
        /// Цвет для выделения неправильного значения  фоном текстового поля
        /// </summary>
        internal static Color WrongTextBoxBackColor = Color.MistyRose;

        /// <summary>
        /// NT-Установить цвет ошибки для текстбокса и вывести сообщение в строке состояния, если она есть
        /// </summary>
        /// <param name="wrong">Флаг ошибки</param>
        /// <param name="control">Текстбокс</param>
        /// <param name="statusBarLabel">Объект текста на статусбаре или null</param>
        /// <param name="statusMsg">Сообщение об ошибке, для статусбара</param>
        public static void colorizeWrongTextBox(bool wrong, TextBox control, ToolStripStatusLabel statusBarLabel, String statusMsg)
        {
            Color backColor;
            //set error color for textbox
            if (wrong)
            {
                backColor = WrongTextBoxBackColor;
            }
            else
            {
                backColor = SystemColors.Window;//typical white?
            }
            control.BackColor = backColor;

            //set new status bar message text
            if (statusBarLabel != null)
            {
                if (wrong)  //set new text
                statusBarLabel.Text = statusMsg;;
            }

            return;
        }



        /// <summary>
        /// NT-Показать диалог сообщения об ошибке с одной кнопкой OK
        /// </summary>
        /// <param name="parentForm">Родительская форма.</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="title">Заголовок окна сообщения</param>
        public static void showErrorMessageBox(IWin32Window parentForm, string title, string text)
        {
            MessageBox.Show(parentForm, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// NT-Показать диалог сообщения об ошибке с одной кнопкой OK
        /// </summary>
        /// <param name="parentForm">Родительская форма.</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="title">Заголовок окна сообщения</param>
        public static void showWarningMessageBox(IWin32Window parentForm, string title, string text)
        {
            MessageBox.Show(parentForm, text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion


    }
}
