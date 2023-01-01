// Decompiled with JetBrains decompiler
// Type: RadioBase.SelectTreeForm2
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using RadioBase.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RadioBase
{
  public class SelectTreeForm2 : Form
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private TreeView treeView1;
    private TextBox textBox_ElementProperties;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button button_Cancel;
    private Button button_OK;
    private ImageList imageList1;
    private CTreeViewManager m_treeManager;

    public SelectTreeForm2(string title, DbObjectTypes type, CDbLayer dblayer, CDbObject startElement)
    {
      this.InitializeComponent();
      this.m_treeManager = new CTreeViewManager(this.treeView1, dblayer, startElement, type);
      this.Text = title;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.treeView1 = new TreeView();
      this.imageList1 = new ImageList(this.components);
      this.textBox_ElementProperties = new TextBox();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.button_Cancel = new Button();
      this.button_OK = new Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.treeView1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.textBox_ElementProperties, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.flowLayoutPanel1, 0, 2);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33f));
      this.tableLayoutPanel1.Size = new Size(244, 256);
      this.tableLayoutPanel1.TabIndex = 0;
      this.treeView1.Dock = DockStyle.Fill;
      this.treeView1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.treeView1.ImageIndex = 0;
      this.treeView1.ImageList = this.imageList1;
      this.treeView1.Location = new Point(3, 3);
      this.treeView1.Name = "treeView1";
      this.treeView1.SelectedImageIndex = 0;
      this.treeView1.ShowNodeToolTips = true;
      this.treeView1.Size = new Size(238, 137);
      this.treeView1.TabIndex = 0;
      this.treeView1.BeforeExpand += new TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
      this.treeView1.BeforeCollapse += new TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
      this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
      this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
      this.imageList1.ImageSize = new Size(16, 16);
      this.imageList1.TransparentColor = Color.Transparent;
      this.textBox_ElementProperties.Dock = DockStyle.Fill;
      this.textBox_ElementProperties.Location = new Point(3, 146);
      this.textBox_ElementProperties.Multiline = true;
      this.textBox_ElementProperties.Name = "textBox_ElementProperties";
      this.textBox_ElementProperties.ReadOnly = true;
      this.textBox_ElementProperties.ScrollBars = ScrollBars.Both;
      this.textBox_ElementProperties.Size = new Size(238, 74);
      this.textBox_ElementProperties.TabIndex = 1;
      this.textBox_ElementProperties.Text = "Свойства выбранного элемента";
      this.textBox_ElementProperties.WordWrap = false;
      this.flowLayoutPanel1.Controls.Add((Control) this.button_Cancel);
      this.flowLayoutPanel1.Controls.Add((Control) this.button_OK);
      this.flowLayoutPanel1.Dock = DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
      this.flowLayoutPanel1.Location = new Point(3, 226);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(238, 27);
      this.flowLayoutPanel1.TabIndex = 2;
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(160, 3);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(75, 23);
      this.button_Cancel.TabIndex = 1;
      this.button_Cancel.Text = "Отмена";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new EventHandler(this.button_Cancel_Click);
      this.button_OK.Location = new Point(79, 3);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(75, 23);
      this.button_OK.TabIndex = 0;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(244, 256);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = "SelectTreeForm2";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Дерево выбора";
      this.Load += new EventHandler(this.SelectTreeForm2_Load);
      this.FormClosing += new FormClosingEventHandler(this.SelectTreeForm2_FormClosing);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public static CDbObject ShowSelectionForm(Form parent, string title, DbObjectTypes type, CDbLayer dblayer, CDbObject startElement)
    {
      SelectTreeForm2 selectTreeForm2 = new SelectTreeForm2(title, type, dblayer, startElement);
	  
      Size selectTreeFormSize = Settings.Default.SelectTreeFormSize;
      if (selectTreeFormSize.Height < 300)
        selectTreeFormSize.Height = 300;
      if (selectTreeFormSize.Width < 200)
        selectTreeFormSize.Width = 200;
      selectTreeForm2.Size = selectTreeFormSize;
	  
      DialogResult dialogResult = selectTreeForm2.ShowDialog((IWin32Window) parent);
	  
      CDbObject cdbObject = (CDbObject) null;
      if (dialogResult == DialogResult.OK)
        cdbObject = selectTreeForm2.m_treeManager.SelectedElement;
      
	  Settings.Default.SelectTreeFormSize = selectTreeForm2.Size;
      Settings.Default.SelectTreeFormPosition = selectTreeForm2.Location;
      
	  return cdbObject;
    }

    private void SelectTreeForm2_Load(object sender, EventArgs e)
    {
      Point treeFormPosition = Settings.Default.SelectTreeFormPosition;
      if (treeFormPosition.X > 1000)
        treeFormPosition.X = 1000;
      if (treeFormPosition.Y > 1000)
        treeFormPosition.Y = 1000;
      this.Location = treeFormPosition;
	  
      this.m_treeManager.ShowTree();
    }

    private void SelectTreeForm2_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.m_treeManager.ClearTree();
    }

    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      this.m_treeManager.NodeExpand(e);
    }

    private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
    {
      this.m_treeManager.NodeCollapse(e);
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      CDbObject cdbObject = this.m_treeManager.NodeSelected(e);
      this.button_OK.Enabled = this.m_treeManager.AllowedElementType(cdbObject.ObjectId.ElementType);
      this.textBox_ElementProperties.Text = cdbObject.getElementPropertiesText();
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
