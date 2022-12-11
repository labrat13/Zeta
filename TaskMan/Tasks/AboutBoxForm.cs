using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Tasks
{
    /// <summary>
    /// NT-Диалог "О программе"
    /// </summary>
    partial class AboutBoxForm : Form
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parent">Главная форма приложения.</param>
        public AboutBoxForm(MainForm parent)
        {
            InitializeComponent();

            this.Text = String.Format(CultureInfo.CurrentCulture, "О программе {0}", AssemblyTitle);
            this.labelProductName.Text = "Продукт: " + AssemblyProduct;
            this.labelVersion.Text = "Версия: " + AssemblyVersion;
            this.labelCopyright.Text = "Авторское право: " + AssemblyCopyright;
            this.labelCompanyName.Text = "Производитель: " + AssemblyCompany;

            //set app description text
            //Тут вывести версию движка менеджера проектов, раз уж от него все тут зависит.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(AssemblyDescription);
            if (parent.Engine != null)
            {
                sb.Append("Версия движка менеджера задач: ");
                sb.AppendLine(parent.Engine.Settings.getCurrentEngineVersionString());
            }
            this.textBoxDescription.Text = sb.ToString();
            //лучше было вставить ричтекст контрол вместо текстбокса, в нем ссылки включить, они бы тогда нормально работали и все красиво было бы и удобно
            return;
        }

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public AboutBoxForm()
        {
            InitializeComponent();
            this.Text = String.Format("О программе {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Версия {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;

            return;
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
