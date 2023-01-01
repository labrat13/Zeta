// Decompiled with JetBrains decompiler
// Type: RadioBase.Reports.ReportData
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System.Collections.Generic;

namespace RadioBase.Reports
{
  public class ReportData
  {
    private List<ReportElement> m_list;

    public ReportData()
    {
      this.m_list = new List<ReportElement>();
    }

    public List<ReportElement> getReportDataList()
    {
      return this.m_list;
    }
  }
}
