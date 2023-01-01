// Decompiled with JetBrains decompiler
// Type: RadioBase.Reports.ReportElement
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

namespace RadioBase.Reports
{
  public class ReportElement
  {
    private string m_f1;
    private string m_f2;
    private string m_f3;
    private string m_f4;
    private string m_f5;
    private string m_f6;
    private string m_f7;
    private string m_f8;

    public string Field_1
    {
      get
      {
        return this.m_f1;
      }
      set
      {
        this.m_f1 = value;
      }
    }

    public string Field_2
    {
      get
      {
        return this.m_f2;
      }
      set
      {
        this.m_f2 = value;
      }
    }

    public string Field_3
    {
      get
      {
        return this.m_f3;
      }
      set
      {
        this.m_f3 = value;
      }
    }

    public string Field_4
    {
      get
      {
        return this.m_f4;
      }
      set
      {
        this.m_f4 = value;
      }
    }

    public string Field_5
    {
      get
      {
        return this.m_f5;
      }
      set
      {
        this.m_f5 = value;
      }
    }

    public string Field_6
    {
      get
      {
        return this.m_f6;
      }
      set
      {
        this.m_f6 = value;
      }
    }

    public string Field_7
    {
      get
      {
        return this.m_f7;
      }
      set
      {
        this.m_f7 = value;
      }
    }

    public string Field_8
    {
      get
      {
        return this.m_f8;
      }
      set
      {
        this.m_f8 = value;
      }
    }

    public ReportElement()
    {
      this.m_f1 = "";
      this.m_f2 = "";
      this.m_f3 = "";
      this.m_f4 = "";
      this.m_f5 = "";
      this.m_f6 = "";
      this.m_f7 = "";
      this.m_f8 = "";
    }

    public ReportElement(string f1, string f2, string f3, string f4, string f5, string f6, string f7, string f8)
    {
      this.m_f1 = f1;
      this.m_f2 = f2;
      this.m_f3 = f3;
      this.m_f4 = f4;
      this.m_f5 = f5;
      this.m_f6 = f6;
      this.m_f7 = f7;
      this.m_f8 = f8;
    }
  }
}
