using System.Drawing;
using TaskEngine;

namespace Tasks.Forms
{


    /// <summary>
    /// NT-Шрифты и цвета надписей элементов
    /// </summary>
    internal static class ElementColorsAndFonts
    {

        #region *** Константы цвета текста ***

        /// <summary>
        /// Цвет надписи обычных элементов
        /// </summary>
        public static Color Color_NormalElement = Color.Black;

        /// <summary>
        /// Цвет надписи неактивных элементов
        /// </summary>
        public static Color Color_InactiveElement = Color.Gray;

        /// <summary>
        /// Цвет надписи приоритетных задач
        /// </summary>
        public static Color Color_PriorityTask = Color.Red;

        /// <summary>
        /// Цвет надписи неприоритетных задач
        /// </summary>
        public static Color Color_NotPriorityTask = Color.Red;

        #endregion

        #region *** Константы шрифта текста ***

        /// <summary>
        ///Шрифт нормальный, используется по умолчанию для всех типов элементов.
        /// </summary>
        public static Font FontNormal = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Regular);

        /// <summary>
        /// Шрифт курсивный.
        /// </summary>
        public static Font FontItalic = new Font(FontNormal, FontStyle.Italic);

        /// <summary>
        /// Шрифт курсивный зачеркнутый.
        /// </summary>
        public static Font FontItalicStrike = new Font(FontNormal, FontStyle.Italic | FontStyle.Strikeout);

        #endregion

        #region *** Функции получения цвета и шрифта элемента ***
        
        /// <summary>
        /// NT-Selects the color for the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Color SelectElementColor(CElement element)
        {
            //set color as Normal 
            Color result = ElementColorsAndFonts.Color_NormalElement;

            //deleted element color
            if (element.IsDeleted())
                result = ElementColorsAndFonts.Color_InactiveElement;
            else
            {
                //если это Задача, то цвет определяется ее важностью.
                if (element.ElementType == EnumElementType.Task)
                {
                    CTask ct = (CTask)element;
                    //task priority
                    if (ct.TaskPriority == EnumTaskPriority.High)
                        result = ElementColorsAndFonts.Color_PriorityTask;
                    else if (ct.TaskPriority >= EnumTaskPriority.Low)
                        result = ElementColorsAndFonts.Color_NotPriorityTask;
                } 
            }
            return result;
        }

        /// <summary>
        /// NT-Selects the font for the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Font SelectElementFont(CElement element)
        {
            Font result = null;

            //deleted element color
            if (element.IsDeleted())
                result = ElementColorsAndFonts.FontItalic;//курсив серый
            else
            {
                result = ElementColorsAndFonts.FontNormal;
                //если это Задача, то шрифт определяется ее состоянием выполнения.
                if (element.ElementType == EnumElementType.Task)
                {
                    CTask ct = (CTask)element;
                    //task state
                    if (ct.IsCompleted())
                        result = ElementColorsAndFonts.FontItalicStrike;//зачеркнутый курсив 
                    else if (ct.IsPaused())
                        result = ElementColorsAndFonts.FontItalic;//курсив 
                }
            }

            return result;
        }

        #endregion

    }
}
