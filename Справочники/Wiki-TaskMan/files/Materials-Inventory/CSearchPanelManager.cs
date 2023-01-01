// Decompiled with JetBrains decompiler
// Type: RadioBase.CSearchPanelManager
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RadioBase
{
  public class CSearchPanelManager
  {
    private const int m_ResultsMaxLimit = 100;
    private CDbLayer m_dblayer;
    private SearchFields m_SearchFields;
    private ListView m_ListViewResults;

    public CSearchPanelManager(ListView lv, CDbLayer db, SearchFields sf)
    {
      this.m_dblayer = db;
      this.m_ListViewResults = lv;
      this.m_SearchFields = sf;
    }

    internal static SearchFields makeFlags(CheckBox cbName, CheckBox cbWebname, CheckBox cbDescription, CheckBox cbNotes)
    {
      SearchFields searchFields = SearchFields.None;
      if (cbName.Checked)
        searchFields |= SearchFields.Title;
      if (cbWebname.Checked)
        searchFields |= SearchFields.Webtitle;
      if (cbDescription.Checked)
        searchFields |= SearchFields.Description;
      if (cbNotes.Checked)
        searchFields |= SearchFields.Notes;
      return searchFields;
    }

    internal void setupCheckboxes(CheckBox cbName, CheckBox cbWebname, CheckBox cbDescription, CheckBox cbNotes)
    {
      cbName.Checked = (this.m_SearchFields & SearchFields.Title) != SearchFields.None;
      cbWebname.Checked = (this.m_SearchFields & SearchFields.Webtitle) != SearchFields.None;
      cbDescription.Checked = (this.m_SearchFields & SearchFields.Description) != SearchFields.None;
      cbNotes.Checked = (this.m_SearchFields & SearchFields.Notes) != SearchFields.None;
    }

    internal void Search(string searchText, SearchFields sf)
    {
      this.m_SearchFields = sf;
      this.m_ListViewResults.Items.Clear();
      List<CDbObject> list = new List<CDbObject>();
      List<CDbObject> items = this.m_dblayer.FindItems(searchText, sf, 100);
      items.Sort(new Comparison<CDbObject>(CDbObject.SortByName));
      list.AddRange((IEnumerable<CDbObject>) items);
      List<CDbObject> containers = this.m_dblayer.FindContainers(searchText, sf, 100);
      containers.Sort(new Comparison<CDbObject>(CDbObject.SortByName));
      list.AddRange((IEnumerable<CDbObject>) containers);
      List<CDbObject> categories = this.m_dblayer.FindCategories(searchText, sf, 100);
      categories.Sort(new Comparison<CDbObject>(CDbObject.SortByName));
      list.AddRange((IEnumerable<CDbObject>) categories);
      int num1 = 0;
      this.m_ListViewResults.BeginUpdate();
      foreach (CDbObject cdbObject in list)
      {
        this.m_ListViewResults.Items.Add(this.makeListViewItem(cdbObject, searchText));
        ++num1;
        if (num1 >= 100)
          break;
      }
      this.m_ListViewResults.EndUpdate();
      if (list.Count > 100)
      {
        int num2 = (int) MessageBox.Show(string.Format("Показаны только первые {0} элементов из {1}.", (object) 100, (object) list.Count), "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (list.Count != 0)
          return;
        this.m_ListViewResults.Items.Add(this.getEmptyMsgItem());
      }
    }

    private ListViewItem makeListViewItem(CDbObject obj, string pattern)
    {
      ListViewItem listViewItem = new ListViewItem(obj.Title);
      listViewItem.SubItems.Add(obj.WebTitle);
      switch (obj.getDbType())
      {
        case DbObjectTypes.Category:
          listViewItem.ImageIndex = 1;
          break;
        case DbObjectTypes.Container:
          listViewItem.ImageIndex = 2;
          break;
        case DbObjectTypes.Item:
          listViewItem.ImageIndex = 3;
          break;
        default:
          listViewItem.ImageIndex = 0;
          break;
      }
      string text1 = obj.Description.Trim();
      if (text1.Length > 128)
        text1 = text1.Substring(0, 128);
      listViewItem.SubItems.Add(text1);
      string text2 = this.cutText(obj.Notes, pattern);
      listViewItem.SubItems.Add(text2);
      listViewItem.Tag = (object) obj.WebTitle;
      return listViewItem;
    }

    private string cutText(string tmp, string pattern)
    {
      int index = Regex.Match(tmp, pattern, RegexOptions.ECMAScript | RegexOptions.CultureInvariant).Index;
      string str = string.Copy(tmp);
      if (tmp.Length > index + 30)
        str = str.Substring(0, index + 30);
      if (index > 30)
        str = str.Remove(0, index - 30);
      return str;
    }

    private ListViewItem getEmptyMsgItem()
    {
      return new ListViewItem()
      {
        Text = "Не найдено",
        SubItems = {
          "",
          "",
          "",
          ""
        }
      };
    }

    internal int getSearchFieldsAsInt32()
    {
      return (int) this.m_SearchFields;
    }
  }
}
