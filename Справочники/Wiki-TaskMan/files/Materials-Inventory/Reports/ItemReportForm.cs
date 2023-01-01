// Decompiled with JetBrains decompiler
// Type: RadioBase.Reports.ItemReportForm
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using Microsoft.Reporting.WinForms;
using RadioBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RadioBase.Reports
{
  public class ItemReportForm : Form
  {
    private IContainer components;
    private ReportViewer reportViewer1;
    private CDbLayer m_dblayer;
    private string m_rootItemWebName;
    public ReportData m_reportData;

    public ItemReportForm(string connStr, string rootElementWebName)
    {
      this.InitializeComponent();
      this.m_dblayer = CDbLayer.SetupDbLayer(connStr);
      this.m_rootItemWebName = rootElementWebName;
      this.m_reportData = new ReportData();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.reportViewer1 = new ReportViewer();
      this.SuspendLayout();
      ((Control) this.reportViewer1).Dock = DockStyle.Fill;
      ((Control) this.reportViewer1).Location = new Point(0, 0);
      ((Control) this.reportViewer1).Name = "reportViewer1";
      ((Control) this.reportViewer1).Size = new Size(429, 300);
      ((Control) this.reportViewer1).TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(429, 300);
      this.Controls.Add((Control) this.reportViewer1);
      this.Name = "ItemReportForm";
      this.Text = "ItemReportForm";
      this.Load += new EventHandler(this.ItemReportForm_Load);
      this.ResumeLayout(false);
    }

    private void ItemReportForm_Load(object sender, EventArgs e)
    {
      this.ShowReport();
    }

    private void ShowReport()
    {
      this.m_reportData.getReportDataList().Clear();
      CDbObject root = this.m_dblayer.LoadElement(this.m_rootItemWebName);
      if (root != null)
        this.CreateReportItemRecursively(root);
      this.m_dblayer.Disconnect();
      ReportDataSource reportDataSource = new ReportDataSource();
      reportDataSource.set_Name("ReportElement");
      reportDataSource.set_Value((object) this.m_reportData.getReportDataList());
      ((Collection<ReportDataSource>) this.reportViewer1.get_LocalReport().get_DataSources()).Add(reportDataSource);
      this.reportViewer1.get_LocalReport().set_ReportEmbeddedResource("RadioBase.Report1.rdlc");
      List<ReportParameter> list = new List<ReportParameter>();
      string format;
      switch (root.ObjectId.ElementType)
      {
        case DbObjectTypes.Category:
          format = "Категория {0}";
          break;
        case DbObjectTypes.Container:
          format = "Контейнер {0}";
          break;
        case DbObjectTypes.Item:
          format = "Предмет {0}";
          break;
        default:
          format = "Список предметов для {0}";
          break;
      }
      list.Add(new ReportParameter("Report_Parameter_HeaderText", string.Format(format, (object) this.m_rootItemWebName)));
      ((Report) this.reportViewer1.get_LocalReport()).SetParameters((IEnumerable<ReportParameter>) list);
      ((Report) this.reportViewer1.get_LocalReport()).Refresh();
      this.reportViewer1.RefreshReport();
    }

    private void CreateReportItemRecursively(CDbObject root)
    {
      DbObjectTypes dbType = root.getDbType();
      ReportElement reportElement = new ReportElement();
      this.m_reportData.getReportDataList().Add(reportElement);
      reportElement.Field_2 = root.Title;
      reportElement.Field_3 = root.WebTitle;
      if (!root.Deleted)
        reportElement.Field_4 = "+";
      reportElement.Field_7 = root.Description;
      List<CItem> list;
      switch (dbType)
      {
        case DbObjectTypes.Category:
          reportElement.Field_1 = "cat";
          List<CItem> itemsByParentId1 = this.m_dblayer.getItemsByParentId(root.ObjectId.ElementId, -1, false);
          itemsByParentId1.Sort(new Comparison<CItem>(CDbObject.SortByName));
          foreach (CDbObject root1 in itemsByParentId1)
            this.CreateReportItemRecursively(root1);
          list = (List<CItem>) null;
          List<CCategory> categoriesByParentId = this.m_dblayer.getCategoriesByParentId(root.ObjectId.ElementId, false);
          categoriesByParentId.Sort(new Comparison<CCategory>(CDbObject.SortByName));
          foreach (CDbObject root1 in categoriesByParentId)
            this.CreateReportItemRecursively(root1);
          break;
        case DbObjectTypes.Container:
          reportElement.Field_1 = "cont";
          List<CItem> itemsByParentId2 = this.m_dblayer.getItemsByParentId(-1, root.ObjectId.ElementId, false);
          itemsByParentId2.Sort(new Comparison<CItem>(CDbObject.SortByName));
          foreach (CDbObject root1 in itemsByParentId2)
            this.CreateReportItemRecursively(root1);
          list = (List<CItem>) null;
          List<CContainer> containersByParentId = this.m_dblayer.getContainersByParentId(root.ObjectId.ElementId, false);
          containersByParentId.Sort(new Comparison<CContainer>(CDbObject.SortByName));
          foreach (CDbObject root1 in containersByParentId)
            this.CreateReportItemRecursively(root1);
          break;
        case DbObjectTypes.Item:
          CItem citem = (CItem) root;
          reportElement.Field_1 = "item";
          reportElement.Field_5 = citem.Quantity.ToString();
          reportElement.Field_6 = this.m_dblayer.QuantityUnits.getUnitText(citem.UnitCode);
          break;
      }
    }
  }
}
