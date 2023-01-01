// Decompiled with JetBrains decompiler
// Type: RadioBase.Program
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;
using System.Windows.Forms;

namespace RadioBase
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new Form1());
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
  }
}
