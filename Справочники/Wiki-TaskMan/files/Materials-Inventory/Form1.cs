// Decompiled with JetBrains decompiler
// Type: RadioBase.Form1
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using DescriptionImport;
using RadioBase.Properties;
using RadioBase.Reports;
using RadioBase.Scripts;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RadioBase
{
  public class Form1 : Form
  {
    internal static Color InvalidWebNameBackColor = Color.MistyRose;
    private IContainer components;
    private ToolStripContainer toolStripContainer1;
    private MenuStrip menuStrip1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private SplitContainer splitContainer1;
    private TreeView treeView1;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem createEntityToolStripMenuItem;
    private ToolStripMenuItem createCategoryToolStripMenuItem;
    private ToolStripMenuItem createContainerToolStripMenuItem;
    private ToolStripMenuItem clearTrashbagToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem testToolStripMenuItem;
    private TabControl tabControl_RightPane;
    private TabPage tabPage_CategoryDetails;
    private TabPage tabPage_Search;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private Label label2;
    private PictureBox pictureBox_CategoryIcon;
    private TextBox textBox_CategoryWebName;
    private TextBox textBox_CategoryParent;
    private Label label3;
    private RichTextBox richTextBox_CategoryDescription;
    private Label label4;
    private RichTextBox richTextBox_CategoryNotes;
    private Button button_CategoryCancel;
    private Button button_CategoryOk;
    private PictureBox pictureBox_CategoryShortNameIcon;
    private PictureBox pictureBox_CategoryParentIcon;
    private Label label5;
    private TextBox textBox_CategoryTitle;
    private CheckBox checkBox_CategoryInactive;
    private Button button_CategoryCopyLink;
    private TabPage tabPage_Diary;
    private TabPage tabPage_Tasks;
    private TabPage tabPage_ContainerDetails;
    private TabPage tabPage_ItemDetails;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem contentsToolStripMenuItem;
    private ToolStripMenuItem aboutInventoryToolStripMenuItem;
    private ToolTip toolTip1;
    private Button button_CategoryTab_GenerateWebName;
    private Button button_CategoryTab_IconChange;
    private Button button_CategoryTab_ParentCategoryChange;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label13;
    private Label label14;
    private Label label15;
    private Label label16;
    private PictureBox pictureBox_ContainerTab_ContainerImage;
    private Label label17;
    private CheckBox checkBox_ContainerTab_ContainerInactive;
    private Button button_ContainerTab_Cancel;
    private Button button_ContainerTab_OK;
    private TextBox textBox_ContainerTab_ContainerTitle;
    private TextBox textBox_ContainerTab_ContainerWebName;
    private TextBox textBox_ContainerTab_ParentContainerTitle;
    private Button button_ContainerTab_ParentContainerChange;
    private Button button_ContainerTab_GenerateWebName;
    private Button button_ContainerTab_ContainerImageChange;
    private PictureBox pictureBox_ContainerTab_WebNameIcon;
    private Button button_ContainerTab_CopyLink;
    private RichTextBox richTextBox_ContainerTab_Description;
    private RichTextBox richTextBox_ContainerTab_Notes;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private PictureBox pictureBox_ItemTab_ItemImage;
    private Label label18;
    private CheckBox checkBox_ItemTab_ItemInactive;
    private Button button_ItemTab_Cancel;
    private Button button_ItemTab_OK;
    private TextBox textBox_ItemTab_ItemTitle;
    private TextBox textBox_ItemTab_ItemWebName;
    private TextBox textBox_ItemTab_ParentCategoryTitle;
    private Button button_ItemTab_ParentCategoryChange;
    private Button button_ItemTab_GenerateWebName;
    private Button button_ItemTab_ItemImageChange;
    private PictureBox pictureBox_ItemTab_ItemWebNameIcon;
    private Button button_ItemTab_CopyLink;
    private RichTextBox richTextBox_ItemTab_Description;
    private RichTextBox richTextBox_ItemTab_Notes;
    private Label label19;
    private TextBox textBox_ItemTab_ParentContainerTitle;
    private NumericUpDown numericUpDown_ItemTab_ItemQuantity;
    private Button button_ItemTab_ParentContainerChange;
    private ComboBox comboBox_ItemTab_ItemUnits;
    private Label label20;
    private PictureBox pictureBox_ContainerTab_ParentIcon;
    private PictureBox pictureBox_ContainerTab_ContainerIcon;
    private PictureBox pictureBox_ItemTab_ParentCategoryIcon;
    private PictureBox pictureBox_ItemTab_ParentContainer;
    private ImageList imageList_TreeView;
    private ContextMenuStrip contextMenuStrip_RichEdits;
    private ToolStripMenuItem toolStripMenuItem_Cut;
    private ToolStripMenuItem toolStripMenuItem_Copy;
    private ToolStripMenuItem toolStripMenuItem_Paste;
    private ToolStripMenuItem ToolStripMenuItem_Undo;
    private ToolStripMenuItem ToolStripMenuItem_Redo;
    private ToolStripMenuItem ToolStripMenuItem_ContextMenuSelectAll;
    private ToolStripMenuItem ToolStripMenuItem_ContextDelete;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripMenuItem createScriptTemplateToolStripMenuItem;
    private ToolStripMenuItem executeSToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem newDbToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private TableLayoutPanel tableLayoutPanel4;
    private TextBox textBox_SearchTab_SearchString;
    private ListView listView_SearchTab_SearchResults;
    private Button button_SearchTab_Search;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader4;
    private FlowLayoutPanel flowLayoutPanel1;
    private CheckBox checkBox_SearchTab_Name;
    private CheckBox checkBox_SearchTab_Webname;
    private CheckBox checkBox_SearchTab_Description;
    private CheckBox checkBox_SearchTab_Notes;
    private Label label21;
    private ColumnHeader columnHeader5;
    private ToolStripMenuItem настройкиToolStripMenuItem;
    private ToolStripMenuItem каталогСвойствToolStripMenuItem;
    private FlowLayoutPanel flowLayoutPanel2;
    private Label label8;
    private FlowLayoutPanel flowLayoutPanel3;
    private Label label7;
    private ToolStripMenuItem отчетToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator8;
    private ImageList imageList_SearchListView;
    private ToolStripSeparator toolStripSeparator9;
    private ContextMenuStrip contextMenuStrip_PictureBoxes;
    private ToolStripMenuItem ToolStripMenuItem_PictureBoxes_Cut;
    private ToolStripMenuItem ToolStripMenuItem_PictureBoxes_Copy;
    private ToolStripMenuItem ToolStripMenuItem_PictureBoxes_Paste;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripMenuItem ToolStripMenuItem_PictureBoxes_OpenFile;
    private Button button_Item_QuantityMinus;
    private Button button_Item_QuantityPlus;
    private Panel panel1;
    private ToolStripSeparator toolStripSeparator11;
    private CDbLayer m_dblayer;
    private CDbObject m_currentElement;
    private bool m_currentElementChangedFlag;
    private bool m_currentDatabaseWriteOnceForBackup;
    private Button m_currentSaveButton;
    private CLeftPanelTreeViewManager m_treeManager;
    private CSearchPanelManager m_searchManager;
    private ImportMenuManager m_importingManager;
    private bool m_firstTimeBlockTreeSelectionHandler;

    public Form1()
    {
      this.InitializeComponent();
      this.richTextBox_CategoryNotes.AllowDrop = true;
      this.richTextBox_CategoryNotes.DragEnter += new DragEventHandler(this.richTextBox_Notes_DragEnter);
      this.richTextBox_CategoryNotes.DragDrop += new DragEventHandler(this.richTextBox_Notes_DragDrop);
      this.richTextBox_CategoryNotes.EnableAutoDragDrop = false;
      this.richTextBox_ContainerTab_Notes.AllowDrop = true;
      this.richTextBox_ContainerTab_Notes.DragEnter += new DragEventHandler(this.richTextBox_Notes_DragEnter);
      this.richTextBox_ContainerTab_Notes.DragDrop += new DragEventHandler(this.richTextBox_Notes_DragDrop);
      this.richTextBox_ContainerTab_Notes.EnableAutoDragDrop = false;
      this.richTextBox_ItemTab_Notes.AllowDrop = true;
      this.richTextBox_ItemTab_Notes.DragEnter += new DragEventHandler(this.richTextBox_Notes_DragEnter);
      this.richTextBox_ItemTab_Notes.DragDrop += new DragEventHandler(this.richTextBox_Notes_DragDrop);
      this.richTextBox_ItemTab_Notes.EnableAutoDragDrop = false;
      this.changeFormTitle(string.Empty);
      this.m_dblayer = (CDbLayer) null;
      this.pictureBox_ContainerTab_ContainerImage.AllowDrop = true;
      this.pictureBox_ItemTab_ItemImage.AllowDrop = true;
      this.m_firstTimeBlockTreeSelectionHandler = true;
      this.EnableFormControls(false);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.toolStripContainer1 = new ToolStripContainer();
      this.statusStrip1 = new StatusStrip();
      this.splitContainer1 = new SplitContainer();
      this.treeView1 = new TreeView();
      this.imageList_TreeView = new ImageList(this.components);
      this.tabControl_RightPane = new TabControl();
      this.tabPage_CategoryDetails = new TabPage();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.button_CategoryTab_GenerateWebName = new Button();
      this.button_CategoryTab_IconChange = new Button();
      this.textBox_CategoryWebName = new TextBox();
      this.textBox_CategoryParent = new TextBox();
      this.label3 = new Label();
      this.richTextBox_CategoryDescription = new RichTextBox();
      this.contextMenuStrip_RichEdits = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem_Undo = new ToolStripMenuItem();
      this.ToolStripMenuItem_Redo = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.toolStripMenuItem_Cut = new ToolStripMenuItem();
      this.toolStripMenuItem_Copy = new ToolStripMenuItem();
      this.toolStripMenuItem_Paste = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.ToolStripMenuItem_ContextMenuSelectAll = new ToolStripMenuItem();
      this.ToolStripMenuItem_ContextDelete = new ToolStripMenuItem();
      this.label4 = new Label();
      this.richTextBox_CategoryNotes = new RichTextBox();
      this.button_CategoryCancel = new Button();
      this.button_CategoryOk = new Button();
      this.pictureBox_CategoryShortNameIcon = new PictureBox();
      this.pictureBox_CategoryParentIcon = new PictureBox();
      this.label5 = new Label();
      this.textBox_CategoryTitle = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.pictureBox_CategoryIcon = new PictureBox();
      this.checkBox_CategoryInactive = new CheckBox();
      this.button_CategoryCopyLink = new Button();
      this.button_CategoryTab_ParentCategoryChange = new Button();
      this.tabPage_Search = new TabPage();
      this.tableLayoutPanel4 = new TableLayoutPanel();
      this.listView_SearchTab_SearchResults = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader4 = new ColumnHeader();
      this.columnHeader5 = new ColumnHeader();
      this.imageList_SearchListView = new ImageList(this.components);
      this.button_SearchTab_Search = new Button();
      this.textBox_SearchTab_SearchString = new TextBox();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.label21 = new Label();
      this.checkBox_SearchTab_Name = new CheckBox();
      this.checkBox_SearchTab_Webname = new CheckBox();
      this.checkBox_SearchTab_Description = new CheckBox();
      this.checkBox_SearchTab_Notes = new CheckBox();
      this.tabPage_Diary = new TabPage();
      this.flowLayoutPanel3 = new FlowLayoutPanel();
      this.label7 = new Label();
      this.tabPage_Tasks = new TabPage();
      this.flowLayoutPanel2 = new FlowLayoutPanel();
      this.label8 = new Label();
      this.tabPage_ContainerDetails = new TabPage();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.label13 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.pictureBox_ContainerTab_ContainerImage = new PictureBox();
      this.contextMenuStrip_PictureBoxes = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem_PictureBoxes_Cut = new ToolStripMenuItem();
      this.ToolStripMenuItem_PictureBoxes_Copy = new ToolStripMenuItem();
      this.ToolStripMenuItem_PictureBoxes_Paste = new ToolStripMenuItem();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this.ToolStripMenuItem_PictureBoxes_OpenFile = new ToolStripMenuItem();
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.label17 = new Label();
      this.checkBox_ContainerTab_ContainerInactive = new CheckBox();
      this.button_ContainerTab_Cancel = new Button();
      this.button_ContainerTab_OK = new Button();
      this.textBox_ContainerTab_ContainerTitle = new TextBox();
      this.textBox_ContainerTab_ContainerWebName = new TextBox();
      this.textBox_ContainerTab_ParentContainerTitle = new TextBox();
      this.button_ContainerTab_ParentContainerChange = new Button();
      this.button_ContainerTab_GenerateWebName = new Button();
      this.button_ContainerTab_ContainerImageChange = new Button();
      this.pictureBox_ContainerTab_WebNameIcon = new PictureBox();
      this.button_ContainerTab_CopyLink = new Button();
      this.richTextBox_ContainerTab_Description = new RichTextBox();
      this.richTextBox_ContainerTab_Notes = new RichTextBox();
      this.pictureBox_ContainerTab_ParentIcon = new PictureBox();
      this.pictureBox_ContainerTab_ContainerIcon = new PictureBox();
      this.tabPage_ItemDetails = new TabPage();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.pictureBox_ItemTab_ParentCategoryIcon = new PictureBox();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.pictureBox_ItemTab_ItemImage = new PictureBox();
      this.label18 = new Label();
      this.checkBox_ItemTab_ItemInactive = new CheckBox();
      this.button_ItemTab_Cancel = new Button();
      this.button_ItemTab_OK = new Button();
      this.textBox_ItemTab_ItemTitle = new TextBox();
      this.textBox_ItemTab_ItemWebName = new TextBox();
      this.textBox_ItemTab_ParentCategoryTitle = new TextBox();
      this.button_ItemTab_ParentCategoryChange = new Button();
      this.button_ItemTab_GenerateWebName = new Button();
      this.button_ItemTab_ItemImageChange = new Button();
      this.pictureBox_ItemTab_ItemWebNameIcon = new PictureBox();
      this.button_ItemTab_CopyLink = new Button();
      this.richTextBox_ItemTab_Description = new RichTextBox();
      this.richTextBox_ItemTab_Notes = new RichTextBox();
      this.label19 = new Label();
      this.textBox_ItemTab_ParentContainerTitle = new TextBox();
      this.button_ItemTab_ParentContainerChange = new Button();
      this.label20 = new Label();
      this.pictureBox_ItemTab_ParentContainer = new PictureBox();
      this.panel1 = new Panel();
      this.button_Item_QuantityMinus = new Button();
      this.numericUpDown_ItemTab_ItemQuantity = new NumericUpDown();
      this.button_Item_QuantityPlus = new Button();
      this.comboBox_ItemTab_ItemUnits = new ComboBox();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newDbToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.closeToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.createEntityToolStripMenuItem = new ToolStripMenuItem();
      this.createCategoryToolStripMenuItem = new ToolStripMenuItem();
      this.createContainerToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.clearTrashbagToolStripMenuItem = new ToolStripMenuItem();
      this.testToolStripMenuItem = new ToolStripMenuItem();
      this.createScriptTemplateToolStripMenuItem = new ToolStripMenuItem();
      this.executeSToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.отчетToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator9 = new ToolStripSeparator();
      this.настройкиToolStripMenuItem = new ToolStripMenuItem();
      this.каталогСвойствToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.contentsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.aboutInventoryToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.toolTip1 = new ToolTip(this.components);
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tabControl_RightPane.SuspendLayout();
      this.tabPage_CategoryDetails.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.contextMenuStrip_RichEdits.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_CategoryShortNameIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_CategoryParentIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_CategoryIcon).BeginInit();
      this.tabPage_Search.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.tabPage_Diary.SuspendLayout();
      this.flowLayoutPanel3.SuspendLayout();
      this.tabPage_Tasks.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      this.tabPage_ContainerDetails.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ContainerImage).BeginInit();
      this.contextMenuStrip_PictureBoxes.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_ContainerTab_WebNameIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ParentIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ContainerIcon).BeginInit();
      this.tabPage_ItemDetails.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_ItemTab_ParentCategoryIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ItemImage).BeginInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ItemWebNameIcon).BeginInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ParentContainer).BeginInit();
      this.panel1.SuspendLayout();
      this.numericUpDown_ItemTab_ItemQuantity.BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStripContainer1.BottomToolStripPanel.Controls.Add((Control) this.statusStrip1);
      this.toolStripContainer1.ContentPanel.Controls.Add((Control) this.splitContainer1);
      this.toolStripContainer1.ContentPanel.Size = new Size(670, 420);
      this.toolStripContainer1.Dock = DockStyle.Fill;
      this.toolStripContainer1.Location = new Point(0, 0);
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new Size(670, 466);
      this.toolStripContainer1.TabIndex = 0;
      this.toolStripContainer1.Text = "toolStripContainer1";
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.menuStrip1);
      this.statusStrip1.Dock = DockStyle.None;
      this.statusStrip1.Location = new Point(0, 0);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(670, 22);
      this.statusStrip1.TabIndex = 0;
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.treeView1);
      this.splitContainer1.Panel1MinSize = 100;
      this.splitContainer1.Size = new Size(670, 420);
      this.splitContainer1.Panel2.Controls.Add((Control) this.tabControl_RightPane);
      this.splitContainer1.Panel2MinSize = 300;
      this.splitContainer1.SplitterDistance = 240;
      this.splitContainer1.TabIndex = 0;
      this.treeView1.Dock = DockStyle.Fill;
      this.treeView1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.treeView1.FullRowSelect = true;
      this.treeView1.ImageIndex = 0;
      this.treeView1.ImageList = this.imageList_TreeView;
      this.treeView1.ItemHeight = 18;
      this.treeView1.Location = new Point(0, 0);
      this.treeView1.Name = "treeView1";
      this.treeView1.SelectedImageIndex = 0;
      this.treeView1.ShowNodeToolTips = true;
      this.treeView1.Size = new Size(240, 420);
      this.treeView1.TabIndex = 0;
      this.treeView1.BeforeExpand += new TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
      this.treeView1.BeforeCollapse += new TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
      this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
      this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
      this.imageList_TreeView.ColorDepth = ColorDepth.Depth32Bit;
      this.imageList_TreeView.ImageSize = new Size(16, 16);
      this.imageList_TreeView.TransparentColor = Color.Transparent;
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_CategoryDetails);
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_Search);
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_Diary);
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_Tasks);
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_ContainerDetails);
      this.tabControl_RightPane.Controls.Add((Control) this.tabPage_ItemDetails);
      this.tabControl_RightPane.Dock = DockStyle.Fill;
      this.tabControl_RightPane.Location = new Point(0, 0);
      this.tabControl_RightPane.Name = "tabControl_RightPane";
      this.tabControl_RightPane.SelectedIndex = 0;
      this.tabControl_RightPane.Size = new Size(426, 420);
      this.tabControl_RightPane.TabIndex = 0;
      this.tabPage_CategoryDetails.AutoScroll = true;
      this.tabPage_CategoryDetails.Controls.Add((Control) this.tableLayoutPanel1);
      this.tabPage_CategoryDetails.Location = new Point(4, 22);
      this.tabPage_CategoryDetails.Name = "tabPage_CategoryDetails";
      this.tabPage_CategoryDetails.Padding = new Padding(3);
      this.tabPage_CategoryDetails.Size = new Size(418, 394);
      this.tabPage_CategoryDetails.TabIndex = 0;
      this.tabPage_CategoryDetails.Text = "Категория";
      this.tabPage_CategoryDetails.UseVisualStyleBackColor = true;
      this.tableLayoutPanel1.AutoScroll = true;
      this.tableLayoutPanel1.ColumnCount = 6;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryTab_GenerateWebName, 5, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryTab_IconChange, 5, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.textBox_CategoryWebName, 2, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.textBox_CategoryParent, 2, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.label3, 0, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.richTextBox_CategoryDescription, 0, 4);
      this.tableLayoutPanel1.Controls.Add((Control) this.label4, 0, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.richTextBox_CategoryNotes, 0, 6);
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryCancel, 4, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryOk, 3, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.pictureBox_CategoryShortNameIcon, 1, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.pictureBox_CategoryParentIcon, 1, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.label5, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.textBox_CategoryTitle, 2, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.label1, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.label2, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.pictureBox_CategoryIcon, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.checkBox_CategoryInactive, 0, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryCopyLink, 5, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.button_CategoryTab_ParentCategoryChange, 5, 2);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(3, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel1.Size = new Size(412, 388);
      this.tableLayoutPanel1.TabIndex = 0;
      this.button_CategoryTab_GenerateWebName.BackgroundImage = (Image) Resources.auto;
      this.button_CategoryTab_GenerateWebName.BackgroundImageLayout = ImageLayout.Stretch;
      this.button_CategoryTab_GenerateWebName.Location = new Point(375, 24);
      this.button_CategoryTab_GenerateWebName.Margin = new Padding(3, 0, 3, 0);
      this.button_CategoryTab_GenerateWebName.Name = "button_CategoryTab_GenerateWebName";
      this.button_CategoryTab_GenerateWebName.Size = new Size(34, 23);
      this.button_CategoryTab_GenerateWebName.TabIndex = 8;
      this.toolTip1.SetToolTip((Control) this.button_CategoryTab_GenerateWebName, "Создать веб-имя из названия");
      this.button_CategoryTab_GenerateWebName.UseVisualStyleBackColor = true;
      this.button_CategoryTab_GenerateWebName.Click += new EventHandler(this.pictureBox_ShortNameIcon_Click);
      this.button_CategoryTab_IconChange.BackgroundImage = (Image) Resources.picframe;
      this.button_CategoryTab_IconChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_CategoryTab_IconChange.Location = new Point(375, 0);
      this.button_CategoryTab_IconChange.Margin = new Padding(3, 0, 3, 0);
      this.button_CategoryTab_IconChange.Name = "button_CategoryTab_IconChange";
      this.button_CategoryTab_IconChange.Size = new Size(34, 23);
      this.button_CategoryTab_IconChange.TabIndex = 7;
      this.toolTip1.SetToolTip((Control) this.button_CategoryTab_IconChange, "Изменить иконку...");
      this.button_CategoryTab_IconChange.UseVisualStyleBackColor = true;
      this.button_CategoryTab_IconChange.Click += new EventHandler(this.pictureBox_CategoryIcon_Click);
      this.tableLayoutPanel1.SetColumnSpan((Control) this.textBox_CategoryWebName, 3);
      this.textBox_CategoryWebName.Dock = DockStyle.Fill;
      this.textBox_CategoryWebName.Location = new Point((int) sbyte.MaxValue, 27);
      this.textBox_CategoryWebName.MaxLength = 64;
      this.textBox_CategoryWebName.Name = "textBox_CategoryWebName";
      this.textBox_CategoryWebName.Size = new Size(242, 20);
      this.textBox_CategoryWebName.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.textBox_CategoryWebName, "Введите уникальное имя категории здесь");
      this.textBox_CategoryWebName.TextChanged += new EventHandler(this.textBox_WebName_TextChanged);
      this.tableLayoutPanel1.SetColumnSpan((Control) this.textBox_CategoryParent, 3);
      this.textBox_CategoryParent.Dock = DockStyle.Fill;
      this.textBox_CategoryParent.Location = new Point((int) sbyte.MaxValue, 51);
      this.textBox_CategoryParent.MaxLength = 64;
      this.textBox_CategoryParent.Name = "textBox_CategoryParent";
      this.textBox_CategoryParent.ReadOnly = true;
      this.textBox_CategoryParent.Size = new Size(242, 20);
      this.textBox_CategoryParent.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.textBox_CategoryParent, "Название родительской категории");
      this.textBox_CategoryParent.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.label3.Anchor = AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.label3, 2);
      this.label3.Location = new Point(3, 77);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 24;
      this.label3.Text = "Описание:";
      this.tableLayoutPanel1.SetColumnSpan((Control) this.richTextBox_CategoryDescription, 6);
      this.richTextBox_CategoryDescription.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_CategoryDescription.Dock = DockStyle.Fill;
      this.richTextBox_CategoryDescription.Location = new Point(3, 99);
      this.richTextBox_CategoryDescription.Name = "richTextBox_CategoryDescription";
      this.richTextBox_CategoryDescription.Size = new Size(406, 42);
      this.richTextBox_CategoryDescription.TabIndex = 3;
      this.richTextBox_CategoryDescription.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_CategoryDescription, "Введите описание категории здесь");
      this.richTextBox_CategoryDescription.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.contextMenuStrip_RichEdits.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.ToolStripMenuItem_Undo,
        (ToolStripItem) this.ToolStripMenuItem_Redo,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.toolStripMenuItem_Cut,
        (ToolStripItem) this.toolStripMenuItem_Copy,
        (ToolStripItem) this.toolStripMenuItem_Paste,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.ToolStripMenuItem_ContextMenuSelectAll,
        (ToolStripItem) this.ToolStripMenuItem_ContextDelete
      });
      this.contextMenuStrip_RichEdits.Name = "contextMenuStrip_RichEdits";
      this.contextMenuStrip_RichEdits.Size = new Size(150, 170);
      this.contextMenuStrip_RichEdits.Opening += new CancelEventHandler(this.contextMenuStrip_RichEdits_Opening);
      this.ToolStripMenuItem_Undo.Name = "ToolStripMenuItem_Undo";
      this.ToolStripMenuItem_Undo.Size = new Size(149, 22);
      this.ToolStripMenuItem_Undo.Text = "Откатить";
      this.ToolStripMenuItem_Undo.Click += new EventHandler(this.undoToolStripMenuItem_Click);
      this.ToolStripMenuItem_Redo.AutoSize = false;
      this.ToolStripMenuItem_Redo.Name = "ToolStripMenuItem_Redo";
      this.ToolStripMenuItem_Redo.Size = new Size(152, 22);
      this.ToolStripMenuItem_Redo.Text = "Вернуть";
      this.ToolStripMenuItem_Redo.Click += new EventHandler(this.redoToolStripMenuItem_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(146, 6);
      this.toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
      this.toolStripMenuItem_Cut.Size = new Size(149, 22);
      this.toolStripMenuItem_Cut.Text = "Вырезать";
      this.toolStripMenuItem_Cut.Click += new EventHandler(this.toolStripMenuItem_Cut_Click);
      this.toolStripMenuItem_Copy.Name = "toolStripMenuItem_Copy";
      this.toolStripMenuItem_Copy.Size = new Size(149, 22);
      this.toolStripMenuItem_Copy.Text = "Копировать";
      this.toolStripMenuItem_Copy.Click += new EventHandler(this.toolStripMenuItem_Copy_Click);
      this.toolStripMenuItem_Paste.Name = "toolStripMenuItem_Paste";
      this.toolStripMenuItem_Paste.Size = new Size(149, 22);
      this.toolStripMenuItem_Paste.Text = "Вставить";
      this.toolStripMenuItem_Paste.Click += new EventHandler(this.toolStripMenuItem_Paste_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(146, 6);
      this.ToolStripMenuItem_ContextMenuSelectAll.Name = "ToolStripMenuItem_ContextMenuSelectAll";
      this.ToolStripMenuItem_ContextMenuSelectAll.Size = new Size(149, 22);
      this.ToolStripMenuItem_ContextMenuSelectAll.Text = "Выбрать все";
      this.ToolStripMenuItem_ContextMenuSelectAll.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
      this.ToolStripMenuItem_ContextDelete.Name = "ToolStripMenuItem_ContextDelete";
      this.ToolStripMenuItem_ContextDelete.Size = new Size(149, 22);
      this.ToolStripMenuItem_ContextDelete.Text = "Удалить все";
      this.ToolStripMenuItem_ContextDelete.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.label4.Anchor = AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.label4, 5);
      this.label4.Location = new Point(3, 149);
      this.label4.Name = "label4";
      this.label4.Size = new Size(54, 13);
      this.label4.TabIndex = 26;
      this.label4.Text = "Заметки:";
      this.richTextBox_CategoryNotes.AcceptsTab = true;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.richTextBox_CategoryNotes, 6);
      this.richTextBox_CategoryNotes.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_CategoryNotes.Dock = DockStyle.Fill;
      this.richTextBox_CategoryNotes.Location = new Point(3, 171);
      this.richTextBox_CategoryNotes.Name = "richTextBox_CategoryNotes";
      this.richTextBox_CategoryNotes.Size = new Size(406, 186);
      this.richTextBox_CategoryNotes.TabIndex = 4;
      this.richTextBox_CategoryNotes.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_CategoryNotes, "Введите текст заметок здесь");
      this.richTextBox_CategoryNotes.LinkClicked += new LinkClickedEventHandler(this.richTextBox_Notes_LinkClicked);
      this.richTextBox_CategoryNotes.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_CategoryCancel.Anchor = AnchorStyles.Left;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.button_CategoryCancel, 2);
      this.button_CategoryCancel.Location = new Point(333, 363);
      this.button_CategoryCancel.Margin = new Padding(1);
      this.button_CategoryCancel.Name = "button_CategoryCancel";
      this.button_CategoryCancel.Size = new Size(75, 22);
      this.button_CategoryCancel.TabIndex = 6;
      this.button_CategoryCancel.Text = "Отмена";
      this.toolTip1.SetToolTip((Control) this.button_CategoryCancel, "Отменить все изменения");
      this.button_CategoryCancel.UseVisualStyleBackColor = true;
      this.button_CategoryCancel.Click += new EventHandler(this.button_CategoryCancel_Click);
      this.button_CategoryOk.Anchor = AnchorStyles.Left;
      this.button_CategoryOk.Location = new Point(253, 363);
      this.button_CategoryOk.Margin = new Padding(1);
      this.button_CategoryOk.Name = "button_CategoryOk";
      this.button_CategoryOk.Size = new Size(75, 22);
      this.button_CategoryOk.TabIndex = 5;
      this.button_CategoryOk.Text = "Сохранить";
      this.toolTip1.SetToolTip((Control) this.button_CategoryOk, "Применить изменения");
      this.button_CategoryOk.UseVisualStyleBackColor = true;
      this.button_CategoryOk.Click += new EventHandler(this.button_CategoryOk_Click);
      this.pictureBox_CategoryShortNameIcon.Anchor = AnchorStyles.None;
      this.pictureBox_CategoryShortNameIcon.Cursor = Cursors.Hand;
      this.pictureBox_CategoryShortNameIcon.ErrorImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryShortNameIcon.Image = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryShortNameIcon.InitialImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryShortNameIcon.Location = new Point(104, 28);
      this.pictureBox_CategoryShortNameIcon.Margin = new Padding(1);
      this.pictureBox_CategoryShortNameIcon.Name = "pictureBox_CategoryShortNameIcon";
      this.pictureBox_CategoryShortNameIcon.Size = new Size(16, 16);
      this.pictureBox_CategoryShortNameIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_CategoryShortNameIcon.TabIndex = 31;
      this.pictureBox_CategoryShortNameIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_CategoryShortNameIcon, "Создать  веб-имя из названия");
      this.pictureBox_CategoryShortNameIcon.Click += new EventHandler(this.pictureBox_ShortNameIcon_Click);
      this.pictureBox_CategoryParentIcon.Cursor = Cursors.Hand;
      this.pictureBox_CategoryParentIcon.Dock = DockStyle.Fill;
      this.pictureBox_CategoryParentIcon.ErrorImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryParentIcon.Image = (Image) Resources.DefaultCategoryIcon;
      this.pictureBox_CategoryParentIcon.InitialImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryParentIcon.Location = new Point(100, 48);
      this.pictureBox_CategoryParentIcon.Margin = new Padding(0);
      this.pictureBox_CategoryParentIcon.Name = "pictureBox_CategoryParentIcon";
      this.pictureBox_CategoryParentIcon.Size = new Size(24, 24);
      this.pictureBox_CategoryParentIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_CategoryParentIcon.TabIndex = 32;
      this.pictureBox_CategoryParentIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_CategoryParentIcon, "Изменить категорию...");
      this.pictureBox_CategoryParentIcon.Click += new EventHandler(this.pictureBox_ParentIcon_Click);
      this.label5.Anchor = AnchorStyles.Left;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(3, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(60, 13);
      this.label5.TabIndex = 33;
      this.label5.Text = "Название:";
      this.tableLayoutPanel1.SetColumnSpan((Control) this.textBox_CategoryTitle, 3);
      this.textBox_CategoryTitle.Dock = DockStyle.Fill;
      this.textBox_CategoryTitle.Location = new Point((int) sbyte.MaxValue, 3);
      this.textBox_CategoryTitle.MaxLength = 64;
      this.textBox_CategoryTitle.Name = "textBox_CategoryTitle";
      this.textBox_CategoryTitle.Size = new Size(242, 20);
      this.textBox_CategoryTitle.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.textBox_CategoryTitle, "Введите название категории здесь");
      this.textBox_CategoryTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.label1.Anchor = AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(3, 29);
      this.label1.Name = "label1";
      this.label1.Size = new Size(52, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "Веб-имя:";
      this.label2.Anchor = AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(3, 53);
      this.label2.Name = "label2";
      this.label2.Size = new Size(63, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "Категория:";
      this.pictureBox_CategoryIcon.Cursor = Cursors.Hand;
      this.pictureBox_CategoryIcon.Dock = DockStyle.Fill;
      this.pictureBox_CategoryIcon.ErrorImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryIcon.Image = (Image) Resources.DefaultCategoryIcon;
      this.pictureBox_CategoryIcon.InitialImage = (Image) Resources.ErrorIcon;
      this.pictureBox_CategoryIcon.Location = new Point(100, 0);
      this.pictureBox_CategoryIcon.Margin = new Padding(0);
      this.pictureBox_CategoryIcon.Name = "pictureBox_CategoryIcon";
      this.pictureBox_CategoryIcon.Size = new Size(24, 24);
      this.pictureBox_CategoryIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_CategoryIcon.TabIndex = 19;
      this.pictureBox_CategoryIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_CategoryIcon, "Изменить иконку...");
      this.pictureBox_CategoryIcon.Click += new EventHandler(this.pictureBox_CategoryIcon_Click);
      this.checkBox_CategoryInactive.Anchor = AnchorStyles.Left;
      this.checkBox_CategoryInactive.AutoSize = true;
      this.checkBox_CategoryInactive.Location = new Point(3, 365);
      this.checkBox_CategoryInactive.Name = "checkBox_CategoryInactive";
      this.checkBox_CategoryInactive.Size = new Size(78, 17);
      this.checkBox_CategoryInactive.TabIndex = 10;
      this.checkBox_CategoryInactive.Text = "Выключен";
      this.toolTip1.SetToolTip((Control) this.checkBox_CategoryInactive, "Установите флажок, чтобы деактивировать категорию...");
      this.checkBox_CategoryInactive.UseVisualStyleBackColor = true;
      this.checkBox_CategoryInactive.CheckStateChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.checkBox_CategoryInactive.CheckedChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_CategoryCopyLink.Anchor = AnchorStyles.Right;
      this.button_CategoryCopyLink.Image = (Image) Resources.LinkIcon;
      this.button_CategoryCopyLink.Location = new Point(375, 72);
      this.button_CategoryCopyLink.Margin = new Padding(3, 0, 3, 0);
      this.button_CategoryCopyLink.Name = "button_CategoryCopyLink";
      this.button_CategoryCopyLink.Size = new Size(34, 24);
      this.button_CategoryCopyLink.TabIndex = 9;
      this.toolTip1.SetToolTip((Control) this.button_CategoryCopyLink, "Копировать веб-ссылку");
      this.button_CategoryCopyLink.UseVisualStyleBackColor = true;
      this.button_CategoryCopyLink.Click += new EventHandler(this.button_CategoryCopyLink_Click);
      this.button_CategoryTab_ParentCategoryChange.BackgroundImage = (Image) Resources.open;
      this.button_CategoryTab_ParentCategoryChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_CategoryTab_ParentCategoryChange.Location = new Point(375, 48);
      this.button_CategoryTab_ParentCategoryChange.Margin = new Padding(3, 0, 3, 0);
      this.button_CategoryTab_ParentCategoryChange.Name = "button_CategoryTab_ParentCategoryChange";
      this.button_CategoryTab_ParentCategoryChange.Size = new Size(34, 23);
      this.button_CategoryTab_ParentCategoryChange.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.button_CategoryTab_ParentCategoryChange, "Изменить категорию...");
      this.button_CategoryTab_ParentCategoryChange.UseVisualStyleBackColor = true;
      this.button_CategoryTab_ParentCategoryChange.Click += new EventHandler(this.pictureBox_ParentIcon_Click);
      this.tabPage_Search.Controls.Add((Control) this.tableLayoutPanel4);
      this.tabPage_Search.Location = new Point(4, 22);
      this.tabPage_Search.Name = "tabPage_Search";
      this.tabPage_Search.Padding = new Padding(3);
      this.tabPage_Search.Size = new Size(418, 394);
      this.tabPage_Search.TabIndex = 1;
      this.tabPage_Search.Text = "Поиск";
      this.tabPage_Search.UseVisualStyleBackColor = true;
      this.tableLayoutPanel4.ColumnCount = 2;
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
      this.tableLayoutPanel4.Controls.Add((Control) this.listView_SearchTab_SearchResults, 0, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.button_SearchTab_Search, 1, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.textBox_SearchTab_SearchString, 0, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.flowLayoutPanel1, 0, 0);
      this.tableLayoutPanel4.Dock = DockStyle.Fill;
      this.tableLayoutPanel4.Location = new Point(3, 3);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 3;
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel4.Size = new Size(412, 388);
      this.tableLayoutPanel4.TabIndex = 0;
      this.listView_SearchTab_SearchResults.Activation = ItemActivation.OneClick;
      this.listView_SearchTab_SearchResults.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader1,
        this.columnHeader2,
        this.columnHeader4,
        this.columnHeader5
      });
      this.tableLayoutPanel4.SetColumnSpan((Control) this.listView_SearchTab_SearchResults, 2);
      this.listView_SearchTab_SearchResults.Dock = DockStyle.Fill;
      this.listView_SearchTab_SearchResults.FullRowSelect = true;
      this.listView_SearchTab_SearchResults.GridLines = true;
      this.listView_SearchTab_SearchResults.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView_SearchTab_SearchResults.HideSelection = false;
      this.listView_SearchTab_SearchResults.LargeImageList = this.imageList_SearchListView;
      this.listView_SearchTab_SearchResults.Location = new Point(3, 63);
      this.listView_SearchTab_SearchResults.MultiSelect = false;
      this.listView_SearchTab_SearchResults.Name = "listView_SearchTab_SearchResults";
      this.listView_SearchTab_SearchResults.ShowGroups = false;
      this.listView_SearchTab_SearchResults.ShowItemToolTips = true;
      this.listView_SearchTab_SearchResults.Size = new Size(406, 322);
      this.listView_SearchTab_SearchResults.SmallImageList = this.imageList_SearchListView;
      this.listView_SearchTab_SearchResults.TabIndex = 2;
      this.listView_SearchTab_SearchResults.UseCompatibleStateImageBehavior = false;
      this.listView_SearchTab_SearchResults.View = View.Details;
      this.listView_SearchTab_SearchResults.SelectedIndexChanged += new EventHandler(this.listView_SearchTab_SearchResults_SelectedIndexChanged);
      this.columnHeader1.Text = "Название";
      this.columnHeader1.Width = 97;
      this.columnHeader2.Text = "Веб имя";
      this.columnHeader2.Width = 89;
      this.columnHeader4.Text = "Описание";
      this.columnHeader4.Width = 85;
      this.columnHeader5.Text = "Заметки";
      this.imageList_SearchListView.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList_SearchListView.ImageStream");
      this.imageList_SearchListView.TransparentColor = Color.Transparent;
      this.imageList_SearchListView.Images.SetKeyName(0, "error_20x20.png");
      this.imageList_SearchListView.Images.SetKeyName(1, "block16x16.png");
      this.imageList_SearchListView.Images.SetKeyName(2, "cont16x16.png");
      this.imageList_SearchListView.Images.SetKeyName(3, "item16x16.png");
      this.button_SearchTab_Search.Anchor = AnchorStyles.Right;
      this.button_SearchTab_Search.Location = new Point(335, 35);
      this.button_SearchTab_Search.Name = "button_SearchTab_Search";
      this.button_SearchTab_Search.Size = new Size(74, 22);
      this.button_SearchTab_Search.TabIndex = 0;
      this.button_SearchTab_Search.Text = "Поиск";
      this.toolTip1.SetToolTip((Control) this.button_SearchTab_Search, "Начать поиск");
      this.button_SearchTab_Search.UseVisualStyleBackColor = true;
      this.button_SearchTab_Search.Click += new EventHandler(this.button_SearchTab_Search_Click);
      this.textBox_SearchTab_SearchString.Dock = DockStyle.Fill;
      this.textBox_SearchTab_SearchString.Location = new Point(3, 35);
      this.textBox_SearchTab_SearchString.Name = "textBox_SearchTab_SearchString";
      this.textBox_SearchTab_SearchString.Size = new Size(326, 20);
      this.textBox_SearchTab_SearchString.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.textBox_SearchTab_SearchString, "Введите имя или часть имени элемента");
      this.textBox_SearchTab_SearchString.KeyDown += new KeyEventHandler(this.textBox_SearchTab_SearchString_KeyDown);
      this.tableLayoutPanel4.SetColumnSpan((Control) this.flowLayoutPanel1, 2);
      this.flowLayoutPanel1.Controls.Add((Control) this.label21);
      this.flowLayoutPanel1.Controls.Add((Control) this.checkBox_SearchTab_Name);
      this.flowLayoutPanel1.Controls.Add((Control) this.checkBox_SearchTab_Webname);
      this.flowLayoutPanel1.Controls.Add((Control) this.checkBox_SearchTab_Description);
      this.flowLayoutPanel1.Controls.Add((Control) this.checkBox_SearchTab_Notes);
      this.flowLayoutPanel1.Dock = DockStyle.Fill;
      this.flowLayoutPanel1.Location = new Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(406, 26);
      this.flowLayoutPanel1.TabIndex = 14;
      this.label21.Anchor = AnchorStyles.Left;
      this.label21.AutoSize = true;
      this.label21.Location = new Point(3, 5);
      this.label21.Name = "label21";
      this.label21.Size = new Size(56, 13);
      this.label21.TabIndex = 14;
      this.label21.Text = "Искать в:";
      this.checkBox_SearchTab_Name.Anchor = AnchorStyles.Left;
      this.checkBox_SearchTab_Name.AutoSize = true;
      this.checkBox_SearchTab_Name.Location = new Point(65, 3);
      this.checkBox_SearchTab_Name.Name = "checkBox_SearchTab_Name";
      this.checkBox_SearchTab_Name.Size = new Size(76, 17);
      this.checkBox_SearchTab_Name.TabIndex = 0;
      this.checkBox_SearchTab_Name.Text = "Название";
      this.checkBox_SearchTab_Name.UseVisualStyleBackColor = true;
      this.checkBox_SearchTab_Webname.Anchor = AnchorStyles.Left;
      this.checkBox_SearchTab_Webname.AutoSize = true;
      this.checkBox_SearchTab_Webname.Location = new Point(147, 3);
      this.checkBox_SearchTab_Webname.Name = "checkBox_SearchTab_Webname";
      this.checkBox_SearchTab_Webname.Size = new Size(68, 17);
      this.checkBox_SearchTab_Webname.TabIndex = 1;
      this.checkBox_SearchTab_Webname.Text = "Веб-имя";
      this.checkBox_SearchTab_Webname.UseVisualStyleBackColor = true;
      this.checkBox_SearchTab_Description.Anchor = AnchorStyles.Left;
      this.checkBox_SearchTab_Description.AutoSize = true;
      this.checkBox_SearchTab_Description.Location = new Point(221, 3);
      this.checkBox_SearchTab_Description.Name = "checkBox_SearchTab_Description";
      this.checkBox_SearchTab_Description.Size = new Size(76, 17);
      this.checkBox_SearchTab_Description.TabIndex = 2;
      this.checkBox_SearchTab_Description.Text = "Описание";
      this.checkBox_SearchTab_Description.UseVisualStyleBackColor = true;
      this.checkBox_SearchTab_Notes.Anchor = AnchorStyles.Left;
      this.checkBox_SearchTab_Notes.AutoSize = true;
      this.checkBox_SearchTab_Notes.Location = new Point(303, 3);
      this.checkBox_SearchTab_Notes.Name = "checkBox_SearchTab_Notes";
      this.checkBox_SearchTab_Notes.Size = new Size(70, 17);
      this.checkBox_SearchTab_Notes.TabIndex = 3;
      this.checkBox_SearchTab_Notes.Text = "Заметки";
      this.checkBox_SearchTab_Notes.UseVisualStyleBackColor = true;
      this.tabPage_Diary.Controls.Add((Control) this.flowLayoutPanel3);
      this.tabPage_Diary.Location = new Point(4, 22);
      this.tabPage_Diary.Name = "tabPage_Diary";
      this.tabPage_Diary.Padding = new Padding(3);
      this.tabPage_Diary.Size = new Size(418, 394);
      this.tabPage_Diary.TabIndex = 2;
      this.tabPage_Diary.Text = "Журнал";
      this.tabPage_Diary.UseVisualStyleBackColor = true;
      this.flowLayoutPanel3.Controls.Add((Control) this.label7);
      this.flowLayoutPanel3.Dock = DockStyle.Fill;
      this.flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
      this.flowLayoutPanel3.Location = new Point(3, 3);
      this.flowLayoutPanel3.Name = "flowLayoutPanel3";
      this.flowLayoutPanel3.Size = new Size(412, 388);
      this.flowLayoutPanel3.TabIndex = 0;
      this.label7.Anchor = AnchorStyles.None;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(10, 10);
      this.label7.Margin = new Padding(10);
      this.label7.Name = "label7";
      this.label7.Size = new Size(183, 26);
      this.label7.TabIndex = 5;
      this.label7.Text = "Эта вкладка журнала пока пустая.\r\n\r\n";
      this.label7.TextAlign = ContentAlignment.TopCenter;
      this.tabPage_Tasks.Controls.Add((Control) this.flowLayoutPanel2);
      this.tabPage_Tasks.Location = new Point(4, 22);
      this.tabPage_Tasks.Name = "tabPage_Tasks";
      this.tabPage_Tasks.Padding = new Padding(3);
      this.tabPage_Tasks.Size = new Size(418, 394);
      this.tabPage_Tasks.TabIndex = 3;
      this.tabPage_Tasks.Text = "Задачи";
      this.tabPage_Tasks.UseVisualStyleBackColor = true;
      this.flowLayoutPanel2.Controls.Add((Control) this.label8);
      this.flowLayoutPanel2.Dock = DockStyle.Fill;
      this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
      this.flowLayoutPanel2.Location = new Point(3, 3);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new Size(412, 388);
      this.flowLayoutPanel2.TabIndex = 0;
      this.label8.Anchor = AnchorStyles.None;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(10, 10);
      this.label8.Margin = new Padding(10);
      this.label8.Name = "label8";
      this.label8.Size = new Size(208, 39);
      this.label8.TabIndex = 2;
      this.label8.Text = "Это вкладка списка задач пока пустая.\r\n\r\n\r\n";
      this.label8.TextAlign = ContentAlignment.TopCenter;
      this.tabPage_ContainerDetails.Controls.Add((Control) this.tableLayoutPanel2);
      this.tabPage_ContainerDetails.Location = new Point(4, 22);
      this.tabPage_ContainerDetails.Name = "tabPage_ContainerDetails";
      this.tabPage_ContainerDetails.Size = new Size(418, 394);
      this.tabPage_ContainerDetails.TabIndex = 4;
      this.tabPage_ContainerDetails.Text = "Контейнер";
      this.tabPage_ContainerDetails.UseVisualStyleBackColor = true;
      this.tableLayoutPanel2.ColumnCount = 6;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel2.Controls.Add((Control) this.label13, 1, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.label14, 1, 2);
      this.tableLayoutPanel2.Controls.Add((Control) this.label15, 1, 4);
      this.tableLayoutPanel2.Controls.Add((Control) this.label16, 0, 6);
      this.tableLayoutPanel2.Controls.Add((Control) this.pictureBox_ContainerTab_ContainerImage, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.label17, 0, 8);
      this.tableLayoutPanel2.Controls.Add((Control) this.checkBox_ContainerTab_ContainerInactive, 0, 10);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_Cancel, 4, 10);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_OK, 3, 10);
      this.tableLayoutPanel2.Controls.Add((Control) this.textBox_ContainerTab_ContainerTitle, 2, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.textBox_ContainerTab_ContainerWebName, 2, 3);
      this.tableLayoutPanel2.Controls.Add((Control) this.textBox_ContainerTab_ParentContainerTitle, 2, 5);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_ParentContainerChange, 5, 5);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_GenerateWebName, 5, 3);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_ContainerImageChange, 5, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.pictureBox_ContainerTab_WebNameIcon, 1, 3);
      this.tableLayoutPanel2.Controls.Add((Control) this.button_ContainerTab_CopyLink, 5, 6);
      this.tableLayoutPanel2.Controls.Add((Control) this.richTextBox_ContainerTab_Description, 0, 7);
      this.tableLayoutPanel2.Controls.Add((Control) this.richTextBox_ContainerTab_Notes, 0, 9);
      this.tableLayoutPanel2.Controls.Add((Control) this.pictureBox_ContainerTab_ParentIcon, 1, 5);
      this.tableLayoutPanel2.Controls.Add((Control) this.pictureBox_ContainerTab_ContainerIcon, 1, 1);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 11;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.Size = new Size(418, 394);
      this.tableLayoutPanel2.TabIndex = 0;
      this.label13.Anchor = AnchorStyles.Left;
      this.label13.AutoSize = true;
      this.tableLayoutPanel2.SetColumnSpan((Control) this.label13, 4);
      this.label13.Location = new Point(171, 7);
      this.label13.Name = "label13";
      this.label13.Size = new Size(60, 13);
      this.label13.TabIndex = 0;
      this.label13.Text = "Название:";
      this.label14.Anchor = AnchorStyles.Left;
      this.label14.AutoSize = true;
      this.tableLayoutPanel2.SetColumnSpan((Control) this.label14, 4);
      this.label14.Location = new Point(171, 63);
      this.label14.Name = "label14";
      this.label14.Size = new Size(52, 13);
      this.label14.TabIndex = 1;
      this.label14.Text = "Веб-имя:";
      this.label15.Anchor = AnchorStyles.Left;
      this.label15.AutoSize = true;
      this.tableLayoutPanel2.SetColumnSpan((Control) this.label15, 4);
      this.label15.Location = new Point(171, 119);
      this.label15.Name = "label15";
      this.label15.Size = new Size(64, 13);
      this.label15.TabIndex = 2;
      this.label15.Text = "Контейнер:";
      this.label16.Anchor = AnchorStyles.Left;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(3, 175);
      this.label16.Name = "label16";
      this.label16.Size = new Size(60, 13);
      this.label16.TabIndex = 3;
      this.label16.Text = "Описание:";
      this.pictureBox_ContainerTab_ContainerImage.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox_ContainerTab_ContainerImage.ContextMenuStrip = this.contextMenuStrip_PictureBoxes;
      this.pictureBox_ContainerTab_ContainerImage.Dock = DockStyle.Fill;
      this.pictureBox_ContainerTab_ContainerImage.Image = (Image) Resources.NoPhoto;
      this.pictureBox_ContainerTab_ContainerImage.Location = new Point(3, 3);
      this.pictureBox_ContainerTab_ContainerImage.Name = "pictureBox_ContainerTab_ContainerImage";
      this.tableLayoutPanel2.SetRowSpan((Control) this.pictureBox_ContainerTab_ContainerImage, 6);
      this.pictureBox_ContainerTab_ContainerImage.Size = new Size(162, 162);
      this.pictureBox_ContainerTab_ContainerImage.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ContainerTab_ContainerImage.TabIndex = 4;
      this.pictureBox_ContainerTab_ContainerImage.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ContainerTab_ContainerImage, "Кликните, чтобы загрузить новое изображение");
      this.pictureBox_ContainerTab_ContainerImage.DragDrop += new DragEventHandler(this.pictureBox_ContainerTabOrItemTab_DragDrop);
      this.pictureBox_ContainerTab_ContainerImage.DragEnter += new DragEventHandler(this.pictureBox_ContainerTabOrItemTab_DragEnter);
      this.contextMenuStrip_PictureBoxes.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.ToolStripMenuItem_PictureBoxes_Cut,
        (ToolStripItem) this.ToolStripMenuItem_PictureBoxes_Copy,
        (ToolStripItem) this.ToolStripMenuItem_PictureBoxes_Paste,
        (ToolStripItem) this.toolStripSeparator10,
        (ToolStripItem) this.ToolStripMenuItem_PictureBoxes_OpenFile,
        (ToolStripItem) this.toolStripSeparator11
      });
      this.contextMenuStrip_PictureBoxes.Name = "contextMenuStrip_PictureBoxes";
      this.contextMenuStrip_PictureBoxes.Size = new Size(173, 104);
      this.contextMenuStrip_PictureBoxes.Opening += new CancelEventHandler(this.contextMenuStrip_PictureBoxes_Opening);
      this.ToolStripMenuItem_PictureBoxes_Cut.Image = (Image) Resources.Erase;
      this.ToolStripMenuItem_PictureBoxes_Cut.Name = "ToolStripMenuItem_PictureBoxes_Cut";
      this.ToolStripMenuItem_PictureBoxes_Cut.Size = new Size(172, 22);
      this.ToolStripMenuItem_PictureBoxes_Cut.Text = "Очистить";
      this.ToolStripMenuItem_PictureBoxes_Cut.Click += new EventHandler(this.ToolStripMenuItem_PictureBoxes_Cut_Click);
      this.ToolStripMenuItem_PictureBoxes_Copy.Name = "ToolStripMenuItem_PictureBoxes_Copy";
      this.ToolStripMenuItem_PictureBoxes_Copy.Size = new Size(172, 22);
      this.ToolStripMenuItem_PictureBoxes_Copy.Text = "Копировать";
      this.ToolStripMenuItem_PictureBoxes_Copy.Click += new EventHandler(this.ToolStripMenuItem_PictureBoxes_Copy_Click);
      this.ToolStripMenuItem_PictureBoxes_Paste.Name = "ToolStripMenuItem_PictureBoxes_Paste";
      this.ToolStripMenuItem_PictureBoxes_Paste.Size = new Size(172, 22);
      this.ToolStripMenuItem_PictureBoxes_Paste.Text = "Вставить";
      this.ToolStripMenuItem_PictureBoxes_Paste.Click += new EventHandler(this.ToolStripMenuItem_PictureBoxes_Paste_Click);
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(169, 6);
      this.ToolStripMenuItem_PictureBoxes_OpenFile.Image = (Image) Resources.picframe;
      this.ToolStripMenuItem_PictureBoxes_OpenFile.Name = "ToolStripMenuItem_PictureBoxes_OpenFile";
      this.ToolStripMenuItem_PictureBoxes_OpenFile.Size = new Size(172, 22);
      this.ToolStripMenuItem_PictureBoxes_OpenFile.Text = "Открыть файл...";
      this.ToolStripMenuItem_PictureBoxes_OpenFile.Click += new EventHandler(this.ToolStripMenuItem_PictureBoxes_OpenFile_Click);
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(169, 6);
      this.label17.Anchor = AnchorStyles.Left;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(3, 249);
      this.label17.Name = "label17";
      this.label17.Size = new Size(54, 13);
      this.label17.TabIndex = 6;
      this.label17.Text = "Заметки:";
      this.checkBox_ContainerTab_ContainerInactive.Anchor = AnchorStyles.Left;
      this.checkBox_ContainerTab_ContainerInactive.AutoSize = true;
      this.checkBox_ContainerTab_ContainerInactive.Location = new Point(3, 371);
      this.checkBox_ContainerTab_ContainerInactive.Name = "checkBox_ContainerTab_ContainerInactive";
      this.checkBox_ContainerTab_ContainerInactive.Size = new Size(78, 17);
      this.checkBox_ContainerTab_ContainerInactive.TabIndex = 10;
      this.checkBox_ContainerTab_ContainerInactive.Text = "Выключен";
      this.toolTip1.SetToolTip((Control) this.checkBox_ContainerTab_ContainerInactive, "Установите флажок, чтобы пометить контейнер неактивным");
      this.checkBox_ContainerTab_ContainerInactive.UseVisualStyleBackColor = true;
      this.checkBox_ContainerTab_ContainerInactive.CheckStateChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.checkBox_ContainerTab_ContainerInactive.CheckedChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_ContainerTab_Cancel.Anchor = AnchorStyles.Left;
      this.tableLayoutPanel2.SetColumnSpan((Control) this.button_ContainerTab_Cancel, 2);
      this.button_ContainerTab_Cancel.Location = new Point(341, 369);
      this.button_ContainerTab_Cancel.Name = "button_ContainerTab_Cancel";
      this.button_ContainerTab_Cancel.Size = new Size(74, 22);
      this.button_ContainerTab_Cancel.TabIndex = 5;
      this.button_ContainerTab_Cancel.Text = "Отмена";
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_Cancel, "Отменить изменения");
      this.button_ContainerTab_Cancel.UseVisualStyleBackColor = true;
      this.button_ContainerTab_Cancel.Click += new EventHandler(this.button_ContainerTab_Cancel_Click);
      this.button_ContainerTab_OK.Anchor = AnchorStyles.Left;
      this.button_ContainerTab_OK.Location = new Point(261, 369);
      this.button_ContainerTab_OK.Name = "button_ContainerTab_OK";
      this.button_ContainerTab_OK.Size = new Size(74, 22);
      this.button_ContainerTab_OK.TabIndex = 4;
      this.button_ContainerTab_OK.Text = "Сохранить";
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_OK, "Применить изменения");
      this.button_ContainerTab_OK.UseVisualStyleBackColor = true;
      this.button_ContainerTab_OK.Click += new EventHandler(this.button_ContainerTab_OK_Click);
      this.tableLayoutPanel2.SetColumnSpan((Control) this.textBox_ContainerTab_ContainerTitle, 3);
      this.textBox_ContainerTab_ContainerTitle.Dock = DockStyle.Fill;
      this.textBox_ContainerTab_ContainerTitle.Location = new Point(195, 31);
      this.textBox_ContainerTab_ContainerTitle.Name = "textBox_ContainerTab_ContainerTitle";
      this.textBox_ContainerTab_ContainerTitle.Size = new Size(180, 20);
      this.textBox_ContainerTab_ContainerTitle.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.textBox_ContainerTab_ContainerTitle, "Введите название категории здесь");
      this.textBox_ContainerTab_ContainerTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.tableLayoutPanel2.SetColumnSpan((Control) this.textBox_ContainerTab_ContainerWebName, 3);
      this.textBox_ContainerTab_ContainerWebName.Dock = DockStyle.Fill;
      this.textBox_ContainerTab_ContainerWebName.Location = new Point(195, 87);
      this.textBox_ContainerTab_ContainerWebName.Name = "textBox_ContainerTab_ContainerWebName";
      this.textBox_ContainerTab_ContainerWebName.Size = new Size(180, 20);
      this.textBox_ContainerTab_ContainerWebName.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.textBox_ContainerTab_ContainerWebName, "Введите уникальное веб-имя контейнера здесь");
      this.textBox_ContainerTab_ContainerWebName.TextChanged += new EventHandler(this.textBox_ContainerTab_ContainerWebName_TextChanged);
      this.tableLayoutPanel2.SetColumnSpan((Control) this.textBox_ContainerTab_ParentContainerTitle, 3);
      this.textBox_ContainerTab_ParentContainerTitle.Dock = DockStyle.Fill;
      this.textBox_ContainerTab_ParentContainerTitle.Location = new Point(195, 143);
      this.textBox_ContainerTab_ParentContainerTitle.Name = "textBox_ContainerTab_ParentContainerTitle";
      this.textBox_ContainerTab_ParentContainerTitle.ReadOnly = true;
      this.textBox_ContainerTab_ParentContainerTitle.Size = new Size(180, 20);
      this.textBox_ContainerTab_ParentContainerTitle.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.textBox_ContainerTab_ParentContainerTitle, "Название родительского контейнера");
      this.textBox_ContainerTab_ParentContainerTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_ContainerTab_ParentContainerChange.Anchor = AnchorStyles.Left;
      this.button_ContainerTab_ParentContainerChange.BackgroundImage = (Image) Resources.open;
      this.button_ContainerTab_ParentContainerChange.BackgroundImageLayout = ImageLayout.Stretch;
      this.button_ContainerTab_ParentContainerChange.Location = new Point(381, 143);
      this.button_ContainerTab_ParentContainerChange.Name = "button_ContainerTab_ParentContainerChange";
      this.button_ContainerTab_ParentContainerChange.Size = new Size(34, 22);
      this.button_ContainerTab_ParentContainerChange.TabIndex = 8;
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_ParentContainerChange, "Сменить контейнер...");
      this.button_ContainerTab_ParentContainerChange.UseVisualStyleBackColor = true;
      this.button_ContainerTab_ParentContainerChange.Click += new EventHandler(this.button_ContainerTab_ParentContainerChange_Click);
      this.button_ContainerTab_GenerateWebName.Anchor = AnchorStyles.Left;
      this.button_ContainerTab_GenerateWebName.BackgroundImage = (Image) Resources.auto;
      this.button_ContainerTab_GenerateWebName.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ContainerTab_GenerateWebName.Location = new Point(381, 87);
      this.button_ContainerTab_GenerateWebName.Name = "button_ContainerTab_GenerateWebName";
      this.button_ContainerTab_GenerateWebName.Size = new Size(34, 22);
      this.button_ContainerTab_GenerateWebName.TabIndex = 7;
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_GenerateWebName, "Создать веб-имя из названия");
      this.button_ContainerTab_GenerateWebName.UseVisualStyleBackColor = true;
      this.button_ContainerTab_GenerateWebName.Click += new EventHandler(this.button_ContainerTab_GenerateWebName_Click);
      this.button_ContainerTab_ContainerImageChange.Anchor = AnchorStyles.Left;
      this.button_ContainerTab_ContainerImageChange.BackgroundImage = (Image) Resources.picframe;
      this.button_ContainerTab_ContainerImageChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ContainerTab_ContainerImageChange.Location = new Point(381, 31);
      this.button_ContainerTab_ContainerImageChange.Name = "button_ContainerTab_ContainerImageChange";
      this.button_ContainerTab_ContainerImageChange.Size = new Size(34, 22);
      this.button_ContainerTab_ContainerImageChange.TabIndex = 6;
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_ContainerImageChange, "Изменить изображение контейнера");
      this.button_ContainerTab_ContainerImageChange.UseVisualStyleBackColor = true;
      this.button_ContainerTab_ContainerImageChange.Click += new EventHandler(this.button_ContainerTab_ContainerImageChange_Click);
      this.pictureBox_ContainerTab_WebNameIcon.Anchor = AnchorStyles.Left;
      this.pictureBox_ContainerTab_WebNameIcon.Image = (Image) Resources.ErrorIcon;
      this.pictureBox_ContainerTab_WebNameIcon.Location = new Point(171, 90);
      this.pictureBox_ContainerTab_WebNameIcon.Name = "pictureBox_ContainerTab_WebNameIcon";
      this.pictureBox_ContainerTab_WebNameIcon.Size = new Size(16, 16);
      this.pictureBox_ContainerTab_WebNameIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ContainerTab_WebNameIcon.TabIndex = 16;
      this.pictureBox_ContainerTab_WebNameIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ContainerTab_WebNameIcon, "Создать веб-имя из названия");
      this.pictureBox_ContainerTab_WebNameIcon.Click += new EventHandler(this.button_ContainerTab_GenerateWebName_Click);
      this.button_ContainerTab_CopyLink.Anchor = AnchorStyles.Left;
      this.button_ContainerTab_CopyLink.Image = (Image) Resources.LinkIcon;
      this.button_ContainerTab_CopyLink.Location = new Point(381, 170);
      this.button_ContainerTab_CopyLink.Margin = new Padding(3, 1, 3, 1);
      this.button_ContainerTab_CopyLink.Name = "button_ContainerTab_CopyLink";
      this.button_ContainerTab_CopyLink.Size = new Size(34, 23);
      this.button_ContainerTab_CopyLink.TabIndex = 9;
      this.toolTip1.SetToolTip((Control) this.button_ContainerTab_CopyLink, "Копировать веб-ссылку");
      this.button_ContainerTab_CopyLink.UseVisualStyleBackColor = true;
      this.button_ContainerTab_CopyLink.Click += new EventHandler(this.button_ContainerTab_CopyLink_Click);
      this.tableLayoutPanel2.SetColumnSpan((Control) this.richTextBox_ContainerTab_Description, 6);
      this.richTextBox_ContainerTab_Description.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_ContainerTab_Description.Dock = DockStyle.Fill;
      this.richTextBox_ContainerTab_Description.Location = new Point(3, 199);
      this.richTextBox_ContainerTab_Description.Name = "richTextBox_ContainerTab_Description";
      this.richTextBox_ContainerTab_Description.Size = new Size(412, 42);
      this.richTextBox_ContainerTab_Description.TabIndex = 2;
      this.richTextBox_ContainerTab_Description.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_ContainerTab_Description, "Введите описание контейнера здесь");
      this.richTextBox_ContainerTab_Description.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.richTextBox_ContainerTab_Notes.AcceptsTab = true;
      this.tableLayoutPanel2.SetColumnSpan((Control) this.richTextBox_ContainerTab_Notes, 6);
      this.richTextBox_ContainerTab_Notes.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_ContainerTab_Notes.Dock = DockStyle.Fill;
      this.richTextBox_ContainerTab_Notes.Location = new Point(3, 271);
      this.richTextBox_ContainerTab_Notes.Name = "richTextBox_ContainerTab_Notes";
      this.richTextBox_ContainerTab_Notes.Size = new Size(412, 92);
      this.richTextBox_ContainerTab_Notes.TabIndex = 3;
      this.richTextBox_ContainerTab_Notes.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_ContainerTab_Notes, "Введите текст заметок здесь");
      this.richTextBox_ContainerTab_Notes.LinkClicked += new LinkClickedEventHandler(this.richTextBox_Notes_LinkClicked);
      this.richTextBox_ContainerTab_Notes.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.pictureBox_ContainerTab_ParentIcon.Anchor = AnchorStyles.Left;
      this.pictureBox_ContainerTab_ParentIcon.Image = (Image) componentResourceManager.GetObject("pictureBox_ContainerTab_ParentIcon.Image");
      this.pictureBox_ContainerTab_ParentIcon.Location = new Point(171, 145);
      this.pictureBox_ContainerTab_ParentIcon.Name = "pictureBox_ContainerTab_ParentIcon";
      this.pictureBox_ContainerTab_ParentIcon.Size = new Size(18, 18);
      this.pictureBox_ContainerTab_ParentIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ContainerTab_ParentIcon.TabIndex = 20;
      this.pictureBox_ContainerTab_ParentIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ContainerTab_ParentIcon, "Сменить контейнер...");
      this.pictureBox_ContainerTab_ParentIcon.Click += new EventHandler(this.button_ContainerTab_ParentContainerChange_Click);
      this.pictureBox_ContainerTab_ContainerIcon.Anchor = AnchorStyles.Left;
      this.pictureBox_ContainerTab_ContainerIcon.Image = (Image) componentResourceManager.GetObject("pictureBox_ContainerTab_ContainerIcon.Image");
      this.pictureBox_ContainerTab_ContainerIcon.Location = new Point(171, 33);
      this.pictureBox_ContainerTab_ContainerIcon.Name = "pictureBox_ContainerTab_ContainerIcon";
      this.pictureBox_ContainerTab_ContainerIcon.Size = new Size(18, 18);
      this.pictureBox_ContainerTab_ContainerIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ContainerTab_ContainerIcon.TabIndex = 21;
      this.pictureBox_ContainerTab_ContainerIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ContainerTab_ContainerIcon, "Изменить изображение контейнера");
      this.pictureBox_ContainerTab_ContainerIcon.Click += new EventHandler(this.button_ContainerTab_ContainerImageChange_Click);
      this.tabPage_ItemDetails.Controls.Add((Control) this.tableLayoutPanel3);
      this.tabPage_ItemDetails.Location = new Point(4, 22);
      this.tabPage_ItemDetails.Name = "tabPage_ItemDetails";
      this.tabPage_ItemDetails.Size = new Size(418, 394);
      this.tabPage_ItemDetails.TabIndex = 5;
      this.tabPage_ItemDetails.Text = "Предмет";
      this.tabPage_ItemDetails.UseVisualStyleBackColor = true;
      this.tableLayoutPanel3.ColumnCount = 6;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel3.Controls.Add((Control) this.pictureBox_ItemTab_ParentCategoryIcon, 1, 5);
      this.tableLayoutPanel3.Controls.Add((Control) this.label9, 1, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.label10, 1, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.label11, 1, 4);
      this.tableLayoutPanel3.Controls.Add((Control) this.label12, 0, 9);
      this.tableLayoutPanel3.Controls.Add((Control) this.pictureBox_ItemTab_ItemImage, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.label18, 0, 11);
      this.tableLayoutPanel3.Controls.Add((Control) this.checkBox_ItemTab_ItemInactive, 0, 13);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_Cancel, 4, 13);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_OK, 3, 13);
      this.tableLayoutPanel3.Controls.Add((Control) this.textBox_ItemTab_ItemTitle, 2, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.textBox_ItemTab_ItemWebName, 2, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.textBox_ItemTab_ParentCategoryTitle, 2, 5);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_ParentCategoryChange, 5, 5);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_GenerateWebName, 5, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_ItemImageChange, 5, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.pictureBox_ItemTab_ItemWebNameIcon, 1, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_CopyLink, 5, 9);
      this.tableLayoutPanel3.Controls.Add((Control) this.richTextBox_ItemTab_Description, 0, 10);
      this.tableLayoutPanel3.Controls.Add((Control) this.richTextBox_ItemTab_Notes, 0, 12);
      this.tableLayoutPanel3.Controls.Add((Control) this.label19, 1, 6);
      this.tableLayoutPanel3.Controls.Add((Control) this.textBox_ItemTab_ParentContainerTitle, 2, 7);
      this.tableLayoutPanel3.Controls.Add((Control) this.button_ItemTab_ParentContainerChange, 5, 7);
      this.tableLayoutPanel3.Controls.Add((Control) this.label20, 0, 8);
      this.tableLayoutPanel3.Controls.Add((Control) this.pictureBox_ItemTab_ParentContainer, 1, 7);
      this.tableLayoutPanel3.Controls.Add((Control) this.panel1, 2, 8);
      this.tableLayoutPanel3.Dock = DockStyle.Fill;
      this.tableLayoutPanel3.Location = new Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 14;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.Size = new Size(418, 394);
      this.tableLayoutPanel3.TabIndex = 1;
      this.pictureBox_ItemTab_ParentCategoryIcon.Cursor = Cursors.Hand;
      this.pictureBox_ItemTab_ParentCategoryIcon.Dock = DockStyle.Fill;
      this.pictureBox_ItemTab_ParentCategoryIcon.ErrorImage = (Image) Resources.ErrorIcon;
      this.pictureBox_ItemTab_ParentCategoryIcon.Image = (Image) Resources.DefaultItemIcon;
      this.pictureBox_ItemTab_ParentCategoryIcon.InitialImage = (Image) Resources.ErrorIcon;
      this.pictureBox_ItemTab_ParentCategoryIcon.Location = new Point(168, 120);
      this.pictureBox_ItemTab_ParentCategoryIcon.Margin = new Padding(0);
      this.pictureBox_ItemTab_ParentCategoryIcon.Name = "pictureBox_ItemTab_ParentCategoryIcon";
      this.pictureBox_ItemTab_ParentCategoryIcon.Size = new Size(24, 24);
      this.pictureBox_ItemTab_ParentCategoryIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ItemTab_ParentCategoryIcon.TabIndex = 33;
      this.pictureBox_ItemTab_ParentCategoryIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ItemTab_ParentCategoryIcon, "Сменить категорию");
      this.pictureBox_ItemTab_ParentCategoryIcon.Click += new EventHandler(this.button_ItemTab_ParentCategoryChange_Click);
      this.label9.Anchor = AnchorStyles.Left;
      this.label9.AutoSize = true;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.label9, 4);
      this.label9.Location = new Point(171, 5);
      this.label9.Name = "label9";
      this.label9.Size = new Size(60, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Название:";
      this.label10.Anchor = AnchorStyles.Left;
      this.label10.AutoSize = true;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.label10, 4);
      this.label10.Location = new Point(171, 53);
      this.label10.Name = "label10";
      this.label10.Size = new Size(52, 13);
      this.label10.TabIndex = 1;
      this.label10.Text = "Веб-имя:";
      this.label11.Anchor = AnchorStyles.Left;
      this.label11.AutoSize = true;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.label11, 4);
      this.label11.Location = new Point(171, 101);
      this.label11.Name = "label11";
      this.label11.Size = new Size(63, 13);
      this.label11.TabIndex = 2;
      this.label11.Text = "Категория:";
      this.label12.Anchor = AnchorStyles.Left;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(3, 221);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 13);
      this.label12.TabIndex = 3;
      this.label12.Text = "Описание:";
      this.pictureBox_ItemTab_ItemImage.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox_ItemTab_ItemImage.ContextMenuStrip = this.contextMenuStrip_PictureBoxes;
      this.pictureBox_ItemTab_ItemImage.Dock = DockStyle.Fill;
      this.pictureBox_ItemTab_ItemImage.Image = (Image) Resources.NoPhoto;
      this.pictureBox_ItemTab_ItemImage.Location = new Point(3, 3);
      this.pictureBox_ItemTab_ItemImage.Name = "pictureBox_ItemTab_ItemImage";
      this.tableLayoutPanel3.SetRowSpan((Control) this.pictureBox_ItemTab_ItemImage, 7);
      this.pictureBox_ItemTab_ItemImage.Size = new Size(162, 162);
      this.pictureBox_ItemTab_ItemImage.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ItemTab_ItemImage.TabIndex = 4;
      this.pictureBox_ItemTab_ItemImage.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ItemTab_ItemImage, "Кликните, чтобы загрузитьновое изображение предмета");
      this.pictureBox_ItemTab_ItemImage.DragDrop += new DragEventHandler(this.pictureBox_ContainerTabOrItemTab_DragDrop);
      this.pictureBox_ItemTab_ItemImage.DragEnter += new DragEventHandler(this.pictureBox_ContainerTabOrItemTab_DragEnter);
      this.label18.Anchor = AnchorStyles.Left;
      this.label18.AutoSize = true;
      this.label18.Location = new Point(3, 293);
      this.label18.Name = "label18";
      this.label18.Size = new Size(54, 13);
      this.label18.TabIndex = 6;
      this.label18.Text = "Заметки:";
      this.checkBox_ItemTab_ItemInactive.Anchor = AnchorStyles.Left;
      this.checkBox_ItemTab_ItemInactive.AutoSize = true;
      this.checkBox_ItemTab_ItemInactive.Location = new Point(3, 371);
      this.checkBox_ItemTab_ItemInactive.Name = "checkBox_ItemTab_ItemInactive";
      this.checkBox_ItemTab_ItemInactive.Size = new Size(78, 17);
      this.checkBox_ItemTab_ItemInactive.TabIndex = 13;
      this.checkBox_ItemTab_ItemInactive.Text = "Выключен";
      this.toolTip1.SetToolTip((Control) this.checkBox_ItemTab_ItemInactive, "Поставьте галочку, чтобы сделать предмет неактивным");
      this.checkBox_ItemTab_ItemInactive.UseVisualStyleBackColor = true;
      this.checkBox_ItemTab_ItemInactive.CheckStateChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.checkBox_ItemTab_ItemInactive.CheckedChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_ItemTab_Cancel.Anchor = AnchorStyles.Left;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.button_ItemTab_Cancel, 2);
      this.button_ItemTab_Cancel.Location = new Point(341, 369);
      this.button_ItemTab_Cancel.Name = "button_ItemTab_Cancel";
      this.button_ItemTab_Cancel.Size = new Size(74, 22);
      this.button_ItemTab_Cancel.TabIndex = 9;
      this.button_ItemTab_Cancel.Text = "Отмена";
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_Cancel, "Отменить изменения");
      this.button_ItemTab_Cancel.UseVisualStyleBackColor = true;
      this.button_ItemTab_Cancel.Click += new EventHandler(this.button_ItemTab_Cancel_Click);
      this.button_ItemTab_OK.Anchor = AnchorStyles.Left;
      this.button_ItemTab_OK.Location = new Point(261, 369);
      this.button_ItemTab_OK.Name = "button_ItemTab_OK";
      this.button_ItemTab_OK.Size = new Size(74, 22);
      this.button_ItemTab_OK.TabIndex = 8;
      this.button_ItemTab_OK.Text = "Сохранить";
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_OK, "Принять изменения");
      this.button_ItemTab_OK.UseVisualStyleBackColor = true;
      this.button_ItemTab_OK.Click += new EventHandler(this.button_ItemTab_OK_Click);
      this.tableLayoutPanel3.SetColumnSpan((Control) this.textBox_ItemTab_ItemTitle, 3);
      this.textBox_ItemTab_ItemTitle.Dock = DockStyle.Fill;
      this.textBox_ItemTab_ItemTitle.Location = new Point(195, 27);
      this.textBox_ItemTab_ItemTitle.Name = "textBox_ItemTab_ItemTitle";
      this.textBox_ItemTab_ItemTitle.Size = new Size(180, 20);
      this.textBox_ItemTab_ItemTitle.TabIndex = 0;
      this.toolTip1.SetToolTip((Control) this.textBox_ItemTab_ItemTitle, "Введите название предмета здесь");
      this.textBox_ItemTab_ItemTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.tableLayoutPanel3.SetColumnSpan((Control) this.textBox_ItemTab_ItemWebName, 3);
      this.textBox_ItemTab_ItemWebName.Dock = DockStyle.Fill;
      this.textBox_ItemTab_ItemWebName.Location = new Point(195, 75);
      this.textBox_ItemTab_ItemWebName.Name = "textBox_ItemTab_ItemWebName";
      this.textBox_ItemTab_ItemWebName.Size = new Size(180, 20);
      this.textBox_ItemTab_ItemWebName.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.textBox_ItemTab_ItemWebName, "Введите уникальное имя предмета здесь");
      this.textBox_ItemTab_ItemWebName.TextChanged += new EventHandler(this.textBox_ItemTab_ItemWebName_TextChanged);
      this.tableLayoutPanel3.SetColumnSpan((Control) this.textBox_ItemTab_ParentCategoryTitle, 3);
      this.textBox_ItemTab_ParentCategoryTitle.Dock = DockStyle.Fill;
      this.textBox_ItemTab_ParentCategoryTitle.Location = new Point(195, 123);
      this.textBox_ItemTab_ParentCategoryTitle.Name = "textBox_ItemTab_ParentCategoryTitle";
      this.textBox_ItemTab_ParentCategoryTitle.ReadOnly = true;
      this.textBox_ItemTab_ParentCategoryTitle.Size = new Size(180, 20);
      this.textBox_ItemTab_ParentCategoryTitle.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.textBox_ItemTab_ParentCategoryTitle, "Родительская категория");
      this.textBox_ItemTab_ParentCategoryTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_ItemTab_ParentCategoryChange.Anchor = AnchorStyles.Left;
      this.button_ItemTab_ParentCategoryChange.BackgroundImage = (Image) Resources.open;
      this.button_ItemTab_ParentCategoryChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ItemTab_ParentCategoryChange.Location = new Point(381, 121);
      this.button_ItemTab_ParentCategoryChange.Margin = new Padding(3, 1, 3, 1);
      this.button_ItemTab_ParentCategoryChange.Name = "button_ItemTab_ParentCategoryChange";
      this.button_ItemTab_ParentCategoryChange.Size = new Size(34, 22);
      this.button_ItemTab_ParentCategoryChange.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_ParentCategoryChange, "Сменить категорию");
      this.button_ItemTab_ParentCategoryChange.UseVisualStyleBackColor = true;
      this.button_ItemTab_ParentCategoryChange.Click += new EventHandler(this.button_ItemTab_ParentCategoryChange_Click);
      this.button_ItemTab_GenerateWebName.Anchor = AnchorStyles.Left;
      this.button_ItemTab_GenerateWebName.BackgroundImage = (Image) Resources.auto;
      this.button_ItemTab_GenerateWebName.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ItemTab_GenerateWebName.Location = new Point(381, 73);
      this.button_ItemTab_GenerateWebName.Margin = new Padding(3, 1, 3, 1);
      this.button_ItemTab_GenerateWebName.Name = "button_ItemTab_GenerateWebName";
      this.button_ItemTab_GenerateWebName.Size = new Size(34, 22);
      this.button_ItemTab_GenerateWebName.TabIndex = 11;
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_GenerateWebName, "Создать веб-имя из названия");
      this.button_ItemTab_GenerateWebName.UseVisualStyleBackColor = true;
      this.button_ItemTab_GenerateWebName.Click += new EventHandler(this.button_ItemTab_GenerateWebName_Click);
      this.button_ItemTab_ItemImageChange.Anchor = AnchorStyles.Left;
      this.button_ItemTab_ItemImageChange.BackgroundImage = (Image) Resources.picframe;
      this.button_ItemTab_ItemImageChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ItemTab_ItemImageChange.Location = new Point(381, 25);
      this.button_ItemTab_ItemImageChange.Margin = new Padding(3, 1, 3, 1);
      this.button_ItemTab_ItemImageChange.Name = "button_ItemTab_ItemImageChange";
      this.button_ItemTab_ItemImageChange.Size = new Size(34, 22);
      this.button_ItemTab_ItemImageChange.TabIndex = 10;
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_ItemImageChange, "Изменить изображение предмета");
      this.button_ItemTab_ItemImageChange.UseVisualStyleBackColor = true;
      this.button_ItemTab_ItemImageChange.Click += new EventHandler(this.button_ItemTab_ItemImageChange_Click);
      this.pictureBox_ItemTab_ItemWebNameIcon.Anchor = AnchorStyles.Left;
      this.pictureBox_ItemTab_ItemWebNameIcon.Image = (Image) Resources.ErrorIcon;
      this.pictureBox_ItemTab_ItemWebNameIcon.Location = new Point(171, 76);
      this.pictureBox_ItemTab_ItemWebNameIcon.Name = "pictureBox_ItemTab_ItemWebNameIcon";
      this.pictureBox_ItemTab_ItemWebNameIcon.Size = new Size(16, 16);
      this.pictureBox_ItemTab_ItemWebNameIcon.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ItemTab_ItemWebNameIcon.TabIndex = 16;
      this.pictureBox_ItemTab_ItemWebNameIcon.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ItemTab_ItemWebNameIcon, "Создать веб-имя из названия");
      this.pictureBox_ItemTab_ItemWebNameIcon.Click += new EventHandler(this.button_ItemTab_GenerateWebName_Click);
      this.button_ItemTab_CopyLink.Anchor = AnchorStyles.Left;
      this.button_ItemTab_CopyLink.Image = (Image) Resources.LinkIcon;
      this.button_ItemTab_CopyLink.Location = new Point(381, 217);
      this.button_ItemTab_CopyLink.Margin = new Padding(3, 1, 3, 1);
      this.button_ItemTab_CopyLink.Name = "button_ItemTab_CopyLink";
      this.button_ItemTab_CopyLink.Size = new Size(34, 22);
      this.button_ItemTab_CopyLink.TabIndex = 12;
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_CopyLink, "Копировать веб-ссылку");
      this.button_ItemTab_CopyLink.UseVisualStyleBackColor = true;
      this.button_ItemTab_CopyLink.Click += new EventHandler(this.button_ItemTab_CopyLink_Click);
      this.tableLayoutPanel3.SetColumnSpan((Control) this.richTextBox_ItemTab_Description, 6);
      this.richTextBox_ItemTab_Description.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_ItemTab_Description.Dock = DockStyle.Fill;
      this.richTextBox_ItemTab_Description.Location = new Point(3, 243);
      this.richTextBox_ItemTab_Description.Name = "richTextBox_ItemTab_Description";
      this.richTextBox_ItemTab_Description.Size = new Size(412, 42);
      this.richTextBox_ItemTab_Description.TabIndex = 6;
      this.richTextBox_ItemTab_Description.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_ItemTab_Description, "Введите описание предмета здесь");
      this.richTextBox_ItemTab_Description.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.richTextBox_ItemTab_Notes.AcceptsTab = true;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.richTextBox_ItemTab_Notes, 6);
      this.richTextBox_ItemTab_Notes.ContextMenuStrip = this.contextMenuStrip_RichEdits;
      this.richTextBox_ItemTab_Notes.Dock = DockStyle.Fill;
      this.richTextBox_ItemTab_Notes.Location = new Point(3, 315);
      this.richTextBox_ItemTab_Notes.Name = "richTextBox_ItemTab_Notes";
      this.richTextBox_ItemTab_Notes.Size = new Size(412, 48);
      this.richTextBox_ItemTab_Notes.TabIndex = 7;
      this.richTextBox_ItemTab_Notes.Text = "";
      this.toolTip1.SetToolTip((Control) this.richTextBox_ItemTab_Notes, "Введите текст заметок здесь");
      this.richTextBox_ItemTab_Notes.LinkClicked += new LinkClickedEventHandler(this.richTextBox_Notes_LinkClicked);
      this.richTextBox_ItemTab_Notes.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.label19.Anchor = AnchorStyles.Left;
      this.label19.AutoSize = true;
      this.tableLayoutPanel3.SetColumnSpan((Control) this.label19, 4);
      this.label19.Location = new Point(171, 149);
      this.label19.Name = "label19";
      this.label19.Size = new Size(64, 13);
      this.label19.TabIndex = 20;
      this.label19.Text = "Контейнер:";
      this.tableLayoutPanel3.SetColumnSpan((Control) this.textBox_ItemTab_ParentContainerTitle, 3);
      this.textBox_ItemTab_ParentContainerTitle.Dock = DockStyle.Fill;
      this.textBox_ItemTab_ParentContainerTitle.Location = new Point(195, 171);
      this.textBox_ItemTab_ParentContainerTitle.Name = "textBox_ItemTab_ParentContainerTitle";
      this.textBox_ItemTab_ParentContainerTitle.ReadOnly = true;
      this.textBox_ItemTab_ParentContainerTitle.Size = new Size(180, 20);
      this.textBox_ItemTab_ParentContainerTitle.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.textBox_ItemTab_ParentContainerTitle, "Родительский контейнер");
      this.textBox_ItemTab_ParentContainerTitle.TextChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_ItemTab_ParentContainerChange.BackgroundImage = (Image) Resources.open;
      this.button_ItemTab_ParentContainerChange.BackgroundImageLayout = ImageLayout.Zoom;
      this.button_ItemTab_ParentContainerChange.Location = new Point(381, 169);
      this.button_ItemTab_ParentContainerChange.Margin = new Padding(3, 1, 3, 1);
      this.button_ItemTab_ParentContainerChange.Name = "button_ItemTab_ParentContainerChange";
      this.button_ItemTab_ParentContainerChange.Size = new Size(34, 22);
      this.button_ItemTab_ParentContainerChange.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.button_ItemTab_ParentContainerChange, "Сменить контейнер");
      this.button_ItemTab_ParentContainerChange.UseVisualStyleBackColor = true;
      this.button_ItemTab_ParentContainerChange.Click += new EventHandler(this.button_ItemTab_ParentContainerChange_Click);
      this.label20.Anchor = AnchorStyles.Left;
      this.label20.AutoSize = true;
      this.label20.Location = new Point(3, 197);
      this.label20.Name = "label20";
      this.label20.Size = new Size(69, 13);
      this.label20.TabIndex = 28;
      this.label20.Text = "Количество:";
      this.pictureBox_ItemTab_ParentContainer.Anchor = AnchorStyles.Left;
      this.pictureBox_ItemTab_ParentContainer.Image = (Image) componentResourceManager.GetObject("pictureBox_ItemTab_ParentContainer.Image");
      this.pictureBox_ItemTab_ParentContainer.Location = new Point(171, 171);
      this.pictureBox_ItemTab_ParentContainer.Name = "pictureBox_ItemTab_ParentContainer";
      this.pictureBox_ItemTab_ParentContainer.Size = new Size(18, 18);
      this.pictureBox_ItemTab_ParentContainer.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox_ItemTab_ParentContainer.TabIndex = 29;
      this.pictureBox_ItemTab_ParentContainer.TabStop = false;
      this.toolTip1.SetToolTip((Control) this.pictureBox_ItemTab_ParentContainer, "Сменить контейнер");
      this.pictureBox_ItemTab_ParentContainer.Click += new EventHandler(this.button_ItemTab_ParentContainerChange_Click);
      this.tableLayoutPanel3.SetColumnSpan((Control) this.panel1, 3);
      this.panel1.Controls.Add((Control) this.button_Item_QuantityMinus);
      this.panel1.Controls.Add((Control) this.numericUpDown_ItemTab_ItemQuantity);
      this.panel1.Controls.Add((Control) this.button_Item_QuantityPlus);
      this.panel1.Controls.Add((Control) this.comboBox_ItemTab_ItemUnits);
      this.panel1.Location = new Point(192, 192);
      this.panel1.Margin = new Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(186, 24);
      this.panel1.TabIndex = 36;
      this.button_Item_QuantityMinus.Location = new Point(3, 1);
      this.button_Item_QuantityMinus.Margin = new Padding(1);
      this.button_Item_QuantityMinus.Name = "button_Item_QuantityMinus";
      this.button_Item_QuantityMinus.Size = new Size(22, 22);
      this.button_Item_QuantityMinus.TabIndex = 34;
      this.button_Item_QuantityMinus.Text = "-";
      this.button_Item_QuantityMinus.UseVisualStyleBackColor = true;
      this.button_Item_QuantityMinus.Click += new EventHandler(this.button_Item_QuantityMinus_Click);
      this.numericUpDown_ItemTab_ItemQuantity.BorderStyle = BorderStyle.FixedSingle;
      this.numericUpDown_ItemTab_ItemQuantity.DecimalPlaces = 3;
      this.numericUpDown_ItemTab_ItemQuantity.Location = new Point(27, 2);
      NumericUpDown numericUpDown = this.numericUpDown_ItemTab_ItemQuantity;
      int[] bits = new int[4];
      bits[0] = 1000000;
      Decimal num = new Decimal(bits);
      numericUpDown.Maximum = num;
      this.numericUpDown_ItemTab_ItemQuantity.Name = "numericUpDown_ItemTab_ItemQuantity";
      this.numericUpDown_ItemTab_ItemQuantity.Size = new Size(75, 20);
      this.numericUpDown_ItemTab_ItemQuantity.TabIndex = 4;
      this.toolTip1.SetToolTip((Control) this.numericUpDown_ItemTab_ItemQuantity, "Количество предмета");
      this.numericUpDown_ItemTab_ItemQuantity.ValueChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.button_Item_QuantityPlus.Location = new Point(105, 1);
      this.button_Item_QuantityPlus.Margin = new Padding(1);
      this.button_Item_QuantityPlus.Name = "button_Item_QuantityPlus";
      this.button_Item_QuantityPlus.Size = new Size(22, 22);
      this.button_Item_QuantityPlus.TabIndex = 35;
      this.button_Item_QuantityPlus.Text = "+";
      this.button_Item_QuantityPlus.UseVisualStyleBackColor = true;
      this.button_Item_QuantityPlus.Click += new EventHandler(this.button_Item_QuantityPlus_Click);
      this.comboBox_ItemTab_ItemUnits.FormattingEnabled = true;
      this.comboBox_ItemTab_ItemUnits.Location = new Point(132, 2);
      this.comboBox_ItemTab_ItemUnits.Margin = new Padding(1);
      this.comboBox_ItemTab_ItemUnits.Name = "comboBox_ItemTab_ItemUnits";
      this.comboBox_ItemTab_ItemUnits.Size = new Size(51, 21);
      this.comboBox_ItemTab_ItemUnits.TabIndex = 5;
      this.toolTip1.SetToolTip((Control) this.comboBox_ItemTab_ItemUnits, "Единица измерения ");
      this.comboBox_ItemTab_ItemUnits.SelectedIndexChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.comboBox_ItemTab_ItemUnits.SelectedValueChanged += new EventHandler(this.CurrentElementControlValueChanged);
      this.menuStrip1.Dock = DockStyle.None;
      this.menuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.editToolStripMenuItem,
        (ToolStripItem) this.testToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(670, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.newDbToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.closeToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(45, 20);
      this.fileToolStripMenuItem.Text = "Файл";
      this.newDbToolStripMenuItem.Image = (Image) Resources.database_32;
      this.newDbToolStripMenuItem.Name = "newDbToolStripMenuItem";
      this.newDbToolStripMenuItem.Size = new Size(208, 22);
      this.newDbToolStripMenuItem.Text = "Создать базу данных...";
      this.newDbToolStripMenuItem.Click += new EventHandler(this.newDbToolStripMenuItem_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(140, 6);
      this.openToolStripMenuItem.Image = (Image) Resources.database_connect;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new Size(143, 22);
      this.openToolStripMenuItem.Text = "Открыть...";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.closeToolStripMenuItem.Image = (Image) Resources.database_close_32;
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new Size(143, 22);
      this.closeToolStripMenuItem.Text = "Закрыть";
      this.closeToolStripMenuItem.Click += new EventHandler(this.closeToolStripMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(140, 6);
      this.exitToolStripMenuItem.Image = (Image) Resources.Exit;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(143, 22);
      this.exitToolStripMenuItem.Text = "Выход";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.createEntityToolStripMenuItem,
        (ToolStripItem) this.createCategoryToolStripMenuItem,
        (ToolStripItem) this.createContainerToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.clearTrashbagToolStripMenuItem
      });
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(56, 20);
      this.editToolStripMenuItem.Text = "Правка";
      this.createEntityToolStripMenuItem.Image = (Image) Resources.DefaultItemIcon;
      this.createEntityToolStripMenuItem.Name = "createEntityToolStripMenuItem";
      this.createEntityToolStripMenuItem.Size = new Size(246, 22);
      this.createEntityToolStripMenuItem.Text = "Создать предмет...";
      this.createEntityToolStripMenuItem.Click += new EventHandler(this.createEntityToolStripMenuItem_Click);
      this.createCategoryToolStripMenuItem.Image = (Image) Resources.DefaultCategoryIcon;
      this.createCategoryToolStripMenuItem.Name = "createCategoryToolStripMenuItem";
      this.createCategoryToolStripMenuItem.Size = new Size(246, 22);
      this.createCategoryToolStripMenuItem.Text = "Создать категорию...";
      this.createCategoryToolStripMenuItem.Click += new EventHandler(this.createCategoryToolStripMenuItem_Click);
      this.createContainerToolStripMenuItem.Image = (Image) Resources.DefaultContainerIcon;
      this.createContainerToolStripMenuItem.Name = "createContainerToolStripMenuItem";
      this.createContainerToolStripMenuItem.Size = new Size(246, 22);
      this.createContainerToolStripMenuItem.Text = "Создать контейнер...";
      this.createContainerToolStripMenuItem.Click += new EventHandler(this.createContainerToolStripMenuItem_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(243, 6);
      this.clearTrashbagToolStripMenuItem.Image = (Image) Resources.Erase;
      this.clearTrashbagToolStripMenuItem.Name = "clearTrashbagToolStripMenuItem";
      this.clearTrashbagToolStripMenuItem.Size = new Size(246, 22);
      this.clearTrashbagToolStripMenuItem.Text = "Удалить неактивные элементы";
      this.clearTrashbagToolStripMenuItem.Click += new EventHandler(this.clearTrashbagToolStripMenuItem_Click);
      this.testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.createScriptTemplateToolStripMenuItem,
        (ToolStripItem) this.executeSToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.отчетToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this.настройкиToolStripMenuItem
      });
      this.testToolStripMenuItem.Name = "testToolStripMenuItem";
      this.testToolStripMenuItem.Size = new Size(87, 20);
      this.testToolStripMenuItem.Text = "Инструменты";
      this.createScriptTemplateToolStripMenuItem.Image = (Image) Resources.script_green;
      this.createScriptTemplateToolStripMenuItem.Name = "createScriptTemplateToolStripMenuItem";
      this.createScriptTemplateToolStripMenuItem.Size = new Size(233, 22);
      this.createScriptTemplateToolStripMenuItem.Text = "Создать шаблон скрипта...";
      this.createScriptTemplateToolStripMenuItem.ToolTipText = "Шаблон для легкого создания скрипта";
      this.createScriptTemplateToolStripMenuItem.Click += new EventHandler(this.createScriptTemplateToolStripMenuItem_Click);
      this.executeSToolStripMenuItem.Image = (Image) Resources.script_red;
      this.executeSToolStripMenuItem.Name = "executeSToolStripMenuItem";
      this.executeSToolStripMenuItem.Size = new Size(233, 22);
      this.executeSToolStripMenuItem.Text = "Выполнить скрипт";
      this.executeSToolStripMenuItem.ToolTipText = "Создание удаление и изменение объектов текстом";
      this.executeSToolStripMenuItem.Click += new EventHandler(this.testParserToolStripMenuItem_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(230, 6);
      this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
      this.отчетToolStripMenuItem.Size = new Size(233, 22);
      this.отчетToolStripMenuItem.Text = "Отчет Наличие предметов...";
      this.отчетToolStripMenuItem.Click += new EventHandler(this.отчетToolStripMenuItem_Click);
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new Size(230, 6);
      this.настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.каталогСвойствToolStripMenuItem
      });
      this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
      this.настройкиToolStripMenuItem.Size = new Size(233, 22);
      this.настройкиToolStripMenuItem.Text = "Настройки";
      this.каталогСвойствToolStripMenuItem.Name = "каталогСвойствToolStripMenuItem";
      this.каталогСвойствToolStripMenuItem.Size = new Size(182, 22);
      this.каталогСвойствToolStripMenuItem.Text = "Каталог свойств...";
      this.каталогСвойствToolStripMenuItem.Click += new EventHandler(this.каталогСвойствToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.contentsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.aboutInventoryToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(62, 20);
      this.helpToolStripMenuItem.Text = "Справка";
      this.contentsToolStripMenuItem.Image = (Image) Resources.Help_book;
      this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
      this.contentsToolStripMenuItem.Size = new Size(149, 22);
      this.contentsToolStripMenuItem.Text = "Содержание";
      this.contentsToolStripMenuItem.Click += new EventHandler(this.contentsToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(146, 6);
      this.aboutInventoryToolStripMenuItem.Name = "aboutInventoryToolStripMenuItem";
      this.aboutInventoryToolStripMenuItem.Size = new Size(149, 22);
      this.aboutInventoryToolStripMenuItem.Text = "О программе";
      this.aboutInventoryToolStripMenuItem.Click += new EventHandler(this.aboutInventoryToolStripMenuItem_Click);
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(19, 17);
      this.toolStripStatusLabel1.Text = "...";
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(230, 6);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(670, 466);
      this.Controls.Add((Control) this.toolStripContainer1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new Size(600, 500);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new EventHandler(this.Form1_Load);
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout(false);
      this.toolStripContainer1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.tabControl_RightPane.ResumeLayout(false);
      this.tabPage_CategoryDetails.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.contextMenuStrip_RichEdits.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox_CategoryShortNameIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_CategoryParentIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_CategoryIcon).EndInit();
      this.tabPage_Search.ResumeLayout(false);
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel4.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.tabPage_Diary.ResumeLayout(false);
      this.flowLayoutPanel3.ResumeLayout(false);
      this.flowLayoutPanel3.PerformLayout();
      this.tabPage_Tasks.ResumeLayout(false);
      this.flowLayoutPanel2.ResumeLayout(false);
      this.flowLayoutPanel2.PerformLayout();
      this.tabPage_ContainerDetails.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ContainerImage).EndInit();
      this.contextMenuStrip_PictureBoxes.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox_ContainerTab_WebNameIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ParentIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_ContainerTab_ContainerIcon).EndInit();
      this.tabPage_ItemDetails.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      ((ISupportInitialize) this.pictureBox_ItemTab_ParentCategoryIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ItemImage).EndInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ItemWebNameIcon).EndInit();
      ((ISupportInitialize) this.pictureBox_ItemTab_ParentContainer).EndInit();
      this.panel1.ResumeLayout(false);
      this.numericUpDown_ItemTab_ItemQuantity.EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      CWebNameLink.SchemaName = Settings.Default.WebSchema;
      CWebNameLink.SchemaNameAlternative = Settings.Default.WebSchemaAlternative;
      string lastBaseFile = Settings.Default.LastBaseFile;
      if (File.Exists(lastBaseFile))
        this.OpenDatabaseFile(lastBaseFile);
      this.CreateImportingManager();
      if (this.m_dblayer == null)
      {
        this.setStatusStripText("Откройте БД для начала работы");
        this.ShowHelp();
      }
      else
      {
        this.setStatusStripText("");
        this.ShowElementByLink(CWebNameLink.ExtractWeblinkFromProgramArguments());
      }
    }

    private void setStatusStripText(string text)
    {
      this.toolStripStatusLabel1.Text = text;
    }

    private void CreateBackupCopyDb(string basefilename)
    {
      try
      {
        string destFileName = basefilename + ".backup";
        File.Copy(basefilename, destFileName, true);
      }
      catch (Exception ex)
      {
        this.ShowMessageBox("Ошибка", string.Format("Не удалось создать резервную копию базы данных! \n {0}", (object) ex.GetType().ToString()));
      }
    }

    private void CreateImportingManager()
    {
      this.m_importingManager = new ImportMenuManager(Settings.Default.ImportsFolderPath);
      this.m_importingManager.SetIcons((Image) Resources.Import, (Image) Resources.database_32, (Image) Resources.DefaultCategoryIcon, (Image) Resources.DefaultItemIcon, (Image) Resources.Descr, (Image) Resources.Pdfdoc, (Image) Resources.Picture);
      this.m_importingManager.Results += new ImportMenuManagerResultsEventHandler(this.importingManager_Results);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.CloseDatabaseFile();
    }

    private void EnableFormControls(bool enable)
    {
      this.treeView1.Nodes.Clear();
      this.treeView1.Enabled = enable;
      this.tabControl_RightPane.TabPages.Clear();
      this.tabControl_RightPane.Enabled = enable;
      this.openToolStripMenuItem.Enabled = !enable;
      this.closeToolStripMenuItem.Enabled = enable;
      this.editToolStripMenuItem.Enabled = enable;
      this.testToolStripMenuItem.Enabled = enable;
      this.createCategoryToolStripMenuItem.Enabled = enable;
      this.createContainerToolStripMenuItem.Enabled = enable;
      this.createEntityToolStripMenuItem.Enabled = enable;
      this.clearTrashbagToolStripMenuItem.Enabled = enable;
    }

    private void OpenDatabaseFile(string basefilename)
    {
      if (this.m_dblayer != null)
        this.CloseDatabaseFile();
      this.m_dblayer = CDbLayer.SetupDbLayer(CDbLayer.createConnectionString(basefilename));
      this.changeFormTitle(Path.GetFileName(basefilename));
      Settings.Default.LastBaseFile = basefilename;
      Settings.Default.Save();
      this.m_currentDatabaseWriteOnceForBackup = true;
      this.m_treeManager = new CLeftPanelTreeViewManager(this.treeView1, this.m_dblayer);
      this.m_searchManager = new CSearchPanelManager(this.listView_SearchTab_SearchResults, this.m_dblayer, (SearchFields) Settings.Default.SearchFields);
      this.EnableFormControls(true);
    }

    private void CloseDatabaseFile()
    {
      if (this.m_searchManager != null)
        Settings.Default.SearchFields = this.m_searchManager.getSearchFieldsAsInt32();
      Settings.Default.Save();
      if (this.m_dblayer != null)
        this.m_dblayer.Disconnect();
      this.m_dblayer = (CDbLayer) null;
      if (this.m_treeManager != null)
      {
        this.m_treeManager.ClearTree();
        this.m_treeManager = (CLeftPanelTreeViewManager) null;
      }
      this.EnableFormControls(false);
      this.changeFormTitle("");
    }

    private void changeFormTitle(string p)
    {
      if (string.IsNullOrEmpty(p))
        this.Text = Resources.MainFormTitle;
      else
        this.Text = p + " - " + Resources.MainFormTitle;
    }

    private void newDbToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string sourceFileName = Path.Combine(Application.StartupPath, "template_db.mdb");
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".mdb";
      saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      saveFileDialog.Title = "Создать файл базы данных";
      saveFileDialog.Filter = "Файлы баз данных (*.mdb)|*.mdb|Все файлы (*.*)|*.*";
      saveFileDialog.OverwritePrompt = true;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      File.Copy(sourceFileName, saveFileDialog.FileName, true);
      this.OpenDatabaseFile(saveFileDialog.FileName);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      openFileDialog.Multiselect = false;
      openFileDialog.Title = "Открыть файл базы данных";
      openFileDialog.Filter = "Файлы баз данных (*.mdb)|*.mdb|Все файлы (*.*)|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.OpenDatabaseFile(openFileDialog.FileName);
      this.ShowElementByLink(string.Empty);
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.CloseDatabaseFile();
    }

    private void clearTrashbagToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show((IWin32Window) this, "Вы действительно хотите удалить все неактивные элементы?", "Требуется подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        this.m_dblayer.DeleteInactiveElements2();
      this.m_treeManager.UpdateTree();
      int num = (int) MessageBox.Show((IWin32Window) this, "Неактивные элементы удалены.", "Операция завершена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void createContainerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.createContainer();
    }

    private void createContainer()
    {
      CContainer ccontainer = new CContainer();
      ccontainer.Deleted = false;
      ccontainer.Description = "Добавьте краткое описание...";
      ccontainer.LastChangeDate = DateTime.Now;
      ccontainer.Notes = "Добавьте заметки...";
      ccontainer.Picture = (Image) null;
      ccontainer.setParents(this.m_currentElement);
      ccontainer.Title = "Новый контейнер";
      ccontainer.WebTitle = this.m_dblayer.WebNameCreateFromTitle(ccontainer.Title, "Box");
      this.ShowElementProperties((CDbObject) ccontainer, true, ccontainer.Title);
    }

    private void createCategoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.createCategory();
    }

    private void createCategory()
    {
      CCategory ccategory = new CCategory();
      ccategory.Deleted = false;
      ccategory.Description = "Добавьте краткое описание...";
      ccategory.LastChangeDate = DateTime.Now;
      ccategory.Notes = "Добавьте заметки...";
      ccategory.Picture = (Image) null;
      ccategory.setParents(this.m_currentElement);
      ccategory.Title = "Новая категория";
      ccategory.WebTitle = this.m_dblayer.WebNameCreateFromTitle(ccategory.Title, "Category");
      this.ShowElementProperties((CDbObject) ccategory, true, ccategory.Title);
    }

    private void createEntityToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.createItem();
    }

    private void createItem()
    {
      CItem citem = new CItem();
      citem.Deleted = false;
      citem.Description = "Добавьте краткое описание...";
      citem.LastChangeDate = DateTime.Now;
      citem.Notes = "Добавьте заметки...";
      citem.Picture = (Image) null;
      citem.setParents(this.m_currentElement);
      citem.Title = "Новый предмет";
      citem.WebTitle = this.m_dblayer.WebNameCreateFromTitle(citem.Title, "Item");
      UnitCollectionItem firstItem = this.m_dblayer.QuantityUnits.getFirstItem();
      if (firstItem == null)
      {
        this.ShowMessageBox("Ошибка", "Не найдены единицы измерения в БД");
        Application.Exit();
      }
      citem.UnitCode = firstItem.m_code;
      citem.Quantity = 0.0;
      this.ShowElementProperties((CDbObject) citem, true, citem.Title);
    }

    private void createScriptTemplateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".txt";
      saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      saveFileDialog.Title = "Создать файл скрипта";
      saveFileDialog.Filter = "Файлы скрипта (*.txt)|*.txt|Все файлы (*.*)|*.*";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      new ScriptGenerator(this.m_dblayer).WriteTemplate(saveFileDialog.FileName);
    }

    private void testParserToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      openFileDialog.Multiselect = false;
      openFileDialog.Title = "Открыть файл скрипта";
      openFileDialog.Filter = "Файлы скрипта (*.txt)|*.txt|Все файлы (*.*)|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.Default);
      string script = streamReader.ReadToEnd();
      streamReader.Close();
      Scanner scanner = new Scanner();
      string text1 = scanner.ReadScript(script);
      if (text1 != null)
      {
        this.ShowMessageBox("Ошибка скрипта", text1);
      }
      else
      {
        bool useScriptLog = Settings.Default.UseScriptLog;
        string text2 = new Analyzer(scanner.LexemList, useScriptLog)
        {
          DatabaseAdapter = CDbLayer.SetupDbLayer(CDbLayer.ConnectionString)
        }.Execute();
        if (text2 != null)
        {
          this.ShowMessageBox("Ошибка скрипта", text2);
        }
        else
        {
          this.m_treeManager.UpdateTree();
          int num = (int) MessageBox.Show((IWin32Window) this, string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Скрипт {0} выполнен", new object[1]
          {
            (object) openFileDialog.FileName
          }), "Скрипт завершен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        CDbObject cdbObject = SelectTreeForm2.ShowSelectionForm((Form) this, "Укажите элемент для отчета", DbObjectTypes.Category | DbObjectTypes.Container, this.m_dblayer, (CDbObject) null);
        if (cdbObject == null)
          return;
        int num = (int) new ItemReportForm(CDbLayer.ConnectionString, cdbObject.WebTitle).ShowDialog();
      }
      catch (Exception ex)
      {
        this.ShowMessageBox("Ошибка", string.Format("{0}: {1}", (object) ex.GetType().ToString(), (object) ex.Message));
      }
    }

    private void каталогСвойствToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.Description = "Укажите каталог, содержащий БД свойств";
      folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
      folderBrowserDialog.SelectedPath = Settings.Default.ImportsFolderPath;
      folderBrowserDialog.ShowNewFolderButton = false;
      if (folderBrowserDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      Settings.Default.ImportsFolderPath = folderBrowserDialog.SelectedPath;
      Settings.Default.Save();
      this.m_importingManager = (ImportMenuManager) null;
      this.CreateImportingManager();
    }

    private void aboutInventoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBox aboutBox = new AboutBox();
      int num = (int) aboutBox.ShowDialog((IWin32Window) this);
      aboutBox.Dispose();
    }

    private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowHelp();
    }

    private void ShowHelp()
    {
      Help.ShowHelp((Control) this, Path.Combine(Application.StartupPath, "Инвентарь.chm"));
    }

    private void ShowElementByLink(string weblink)
    {
      if (string.IsNullOrEmpty(weblink))
      {
        this.ShowElementByWebname(string.Empty);
      }
      else
      {
        string webnameFromWeblink = CWebNameLink.ExtractWebnameFromWeblink(weblink);
        if (string.IsNullOrEmpty(webnameFromWeblink))
        {
          int num = (int) MessageBox.Show((IWin32Window) this, string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Неправильная ссылка: {0}", new object[1]
          {
            (object) weblink
          }), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.ShowElementByWebname(string.Empty);
        }
        else if (CWebNameLink.IsInvalidWebName(webnameFromWeblink))
        {
          int num = (int) MessageBox.Show((IWin32Window) this, string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Неправильная ссылка: {0}", new object[1]
          {
            (object) weblink
          }), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.ShowElementByWebname(string.Empty);
        }
        else
          this.ShowElementByWebname(webnameFromWeblink);
      }
    }

    private void ShowElementByWebname(string webname)
    {
      CDbObject cdbObject = this.m_dblayer.LoadElement(webname);
      if (cdbObject == null)
        this.ShowElementProperties((CDbObject) null, false, webname);
      this.m_treeManager.ShowTree(cdbObject);
    }

    private void CurrentElementSetChangedFlag()
    {
      this.m_currentElementChangedFlag = true;
      if (this.m_currentSaveButton == null)
        return;
      this.m_currentSaveButton.Enabled = true;
    }

    private void CurrentElementClearChangedFlag()
    {
      this.m_currentElementChangedFlag = false;
      if (this.m_currentSaveButton == null)
        return;
      this.m_currentSaveButton.Enabled = false;
    }

    private void CurrentElementSaveChanges2()
    {
      if (this.m_currentElement != null && this.m_currentElementChangedFlag)
      {
        if (this.m_currentDatabaseWriteOnceForBackup)
        {
          this.CreateBackupCopyDb(Settings.Default.LastBaseFile);
          this.m_currentDatabaseWriteOnceForBackup = false;
        }
        this.StoreDataFromControls();
        this.m_dblayer.StoreElement(this.m_currentElement);
        this.CurrentElementClearChangedFlag();
        this.m_treeManager.UpdateTree();
      }
      this.CurrentElementClearChangedFlag();
    }

    private void ShowMessageBox(string title, string text)
    {
      int num = (int) MessageBox.Show((IWin32Window) this, text, title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void ShowElementProperties(CDbObject element, bool saveOldElement, string webname)
    {
      DbObjectTypes elementType = CDbObject.getElementType(element);
      if (saveOldElement)
        this.CurrentElementSaveChanges2();
      this.m_currentElement = element;
      this.showElementTabPages(elementType);
      this.LoadDataToControls(element, elementType, webname);
      this.CurrentElementClearChangedFlag();
    }

    private void LoadDataToControls(CDbObject element, DbObjectTypes elementType, string webname)
    {
      switch (elementType)
      {
        case DbObjectTypes.Category:
          this.LoadDataToCategoryControls(element);
          break;
        case DbObjectTypes.Container:
          this.LoadDataToContainerControls(element);
          break;
        case DbObjectTypes.Item:
          this.LoadDataToItemControls(element);
          break;
      }
      this.LoadDataToDiaryTab((object) null);
      this.LoadDataToSearchTab((object) null, webname);
      this.LoadDataToTaskTab((object) null);
    }

    private void StoreDataFromControls()
    {
      switch (CDbObject.getElementType(this.m_currentElement))
      {
        case DbObjectTypes.Category:
          this.StoreDataFromCategoryControls();
          break;
        case DbObjectTypes.Container:
          this.StoreDataFromContainerControls();
          break;
        case DbObjectTypes.Item:
          this.StoreDataFromItemControls();
          break;
      }
    }

    private void showElementTabPages(DbObjectTypes elementType)
    {
      this.ClearAndRemoveTabPages();
      switch (elementType)
      {
        case DbObjectTypes.Category:
          this.tabControl_RightPane.TabPages.Add(this.tabPage_CategoryDetails);
          break;
        case DbObjectTypes.Container:
          this.tabControl_RightPane.TabPages.Add(this.tabPage_ContainerDetails);
          break;
        case DbObjectTypes.Item:
          this.tabControl_RightPane.TabPages.Add(this.tabPage_ItemDetails);
          break;
      }
      this.tabControl_RightPane.TabPages.Add(this.tabPage_Search);
      this.tabControl_RightPane.TabPages.Add(this.tabPage_Tasks);
      this.tabControl_RightPane.TabPages.Add(this.tabPage_Diary);
      this.tabControl_RightPane.SelectedIndex = 0;
    }

    private void ClearAndRemoveTabPages()
    {
      foreach (TabPage tabPage in this.tabControl_RightPane.TabPages)
      {
        if (tabPage == this.tabPage_CategoryDetails)
          this.LoadDataToCategoryControls((CDbObject) null);
        else if (tabPage == this.tabPage_ContainerDetails)
          this.LoadDataToContainerControls((CDbObject) null);
        else if (tabPage == this.tabPage_Diary)
          this.LoadDataToDiaryTab((object) null);
        else if (tabPage == this.tabPage_ItemDetails)
          this.LoadDataToItemControls((CDbObject) null);
        else if (tabPage == this.tabPage_Search)
          this.LoadDataToSearchTab((object) null, string.Empty);
        else if (tabPage == this.tabPage_Tasks)
          this.LoadDataToTaskTab((object) null);
      }
      this.tabControl_RightPane.TabPages.Clear();
    }

    private void LoadDataToTaskTab(object ob)
    {
    }

    private void LoadDataToDiaryTab(object ob)
    {
    }

    private void CurrentElementControlValueChanged(object sender, EventArgs e)
    {
      this.CurrentElementSetChangedFlag();
    }

    private void ReloadCurrentElement()
    {
      if (this.m_currentElement == null)
        return;
      if (!this.m_currentElement.ObjectId.IsInvalidIdentifier())
        this.ShowElementProperties(this.m_currentElement, false, this.m_currentElement.Title);
      else
        this.ShowElementProperties((CDbObject) null, false, string.Empty);
    }

    private Image loadNewImage(DbObjectTypes objType)
    {
      string path;
      string str;
      switch (objType)
      {
        case DbObjectTypes.Category:
          path = Settings.Default.IconsFolderPath;
          str = "Открыть файл иконки для категории";
          break;
        case DbObjectTypes.Container:
        case DbObjectTypes.Item:
          path = Settings.Default.PhotosFolderPath;
          str = "Открыть файл изображения объекта";
          break;
        default:
          return (Image) null;
      }
      if (!Directory.Exists(path))
        path = Application.StartupPath;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = str;
      openFileDialog.CheckFileExists = true;
      openFileDialog.Filter = "Файлы изображений (*.bmp;*.jpg;*.gif;*.ico;*.png)|*.bmp;*.jpg;*.gif;*.ico;*.png|Все файлы (*.*)|*.*";
      openFileDialog.FilterIndex = 0;
      openFileDialog.InitialDirectory = path;
      openFileDialog.Multiselect = false;
      openFileDialog.RestoreDirectory = true;
      if (openFileDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return (Image) null;
      string fileName = openFileDialog.FileName;
      Image image = CImageProcessor.LoadAndResizeImage(objType, fileName);
      if (image == null)
        return (Image) null;
      if (objType == DbObjectTypes.Category)
        Settings.Default.IconsFolderPath = Path.GetDirectoryName(fileName);
      else
        Settings.Default.PhotosFolderPath = Path.GetDirectoryName(fileName);
      return image;
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Form1.ShellExecute(((Control) sender).Text);
    }

    private void LoadDataToContainerControls(CDbObject ob)
    {
      if (ob == null)
      {
        this.pictureBox_ContainerTab_ContainerIcon.Image = (Image) null;
        this.pictureBox_ContainerTab_ParentIcon.Image = (Image) null;
        this.pictureBox_ContainerTab_ContainerImage.Image = (Image) null;
        this.checkBox_ContainerTab_ContainerInactive.Checked = false;
        this.richTextBox_ContainerTab_Description.Text = string.Empty;
        this.richTextBox_ContainerTab_Notes.Text = string.Empty;
        this.textBox_ContainerTab_ContainerTitle.Text = string.Empty;
        this.textBox_ContainerTab_ContainerWebName.Text = string.Empty;
        this.textBox_ContainerTab_ParentContainerTitle.Text = string.Empty;
        this.button_ContainerTab_Cancel.Enabled = false;
        this.button_ContainerTab_OK.Enabled = false;
      }
      else
      {
        CContainer containerByTableId = this.m_dblayer.getContainerByTableId(ob.ObjectId.ParentContainerId, false);
        this.textBox_ContainerTab_ParentContainerTitle.Text = containerByTableId.Title;
        this.pictureBox_ContainerTab_ParentIcon.Image = containerByTableId.getStatedIcon();
        this.pictureBox_ContainerTab_ContainerIcon.Image = ob.getStatedIcon();
        this.pictureBox_ContainerTab_ContainerImage.Image = ob.Picture;
        this.checkBox_ContainerTab_ContainerInactive.Checked = ob.Deleted;
        this.richTextBox_ContainerTab_Description.Text = ob.Description;
        this.richTextBox_ContainerTab_Notes.Text = ob.Notes;
        this.textBox_ContainerTab_ContainerTitle.Text = ob.Title;
        this.textBox_ContainerTab_ContainerWebName.Text = ob.WebTitle;
        this.button_ContainerTab_Cancel.Enabled = true;
        this.button_ContainerTab_OK.Enabled = false;
        this.m_currentSaveButton = this.button_ContainerTab_OK;
      }
    }

    private void StoreDataFromContainerControls()
    {
      this.m_currentElement.Deleted = this.checkBox_ContainerTab_ContainerInactive.Checked;
      this.m_currentElement.Description = this.richTextBox_ContainerTab_Description.Text;
      this.m_currentElement.Picture = this.pictureBox_ContainerTab_ContainerImage.Image;
      this.m_currentElement.LastChangeDate = DateTime.Now;
      this.m_currentElement.Notes = this.richTextBox_ContainerTab_Notes.Text;
      this.m_currentElement.Title = this.textBox_ContainerTab_ContainerTitle.Text;
      this.m_currentElement.WebTitle = this.textBox_ContainerTab_ContainerWebName.Text;
    }

    private void button_ContainerTab_ContainerImageChange_Click(object sender, EventArgs e)
    {
      this.LoadNewContainerOrItemImage(this.pictureBox_ContainerTab_ContainerImage);
    }

    private void LoadNewContainerOrItemImage(PictureBox control)
    {
      Image image = this.loadNewImage(this.m_currentElement.ObjectId.ElementType);
      if (image == null)
        return;
      control.Image = image;
      this.CurrentElementSetChangedFlag();
    }

    private void button_ContainerTab_GenerateWebName_Click(object sender, EventArgs e)
    {
      this.textBox_ContainerTab_ContainerWebName.Text = this.m_dblayer.WebNameCreateFromTitle(this.textBox_ContainerTab_ContainerTitle.Text, "Box");
    }

    private void button_ContainerTab_ParentContainerChange_Click(object sender, EventArgs e)
    {
      CDbObject cdbObject = SelectTreeForm2.ShowSelectionForm((Form) this, "Выбрать контейнер", DbObjectTypes.Container, this.m_dblayer, (CDbObject) this.m_dblayer.getContainerByTableId(this.m_currentElement.ObjectId.ParentContainerId, false));
      if (cdbObject == null)
        return;
      this.m_currentElement.ObjectId.ParentContainerId = cdbObject.ObjectId.ElementId;
      this.pictureBox_ContainerTab_ParentIcon.Image = cdbObject.getStatedIcon();
      this.textBox_ContainerTab_ParentContainerTitle.Text = cdbObject.Title;
      this.CurrentElementSetChangedFlag();
    }

    private void button_ContainerTab_CopyLink_Click(object sender, EventArgs e)
    {
      Clipboard.SetDataObject((object) CWebNameLink.createWebLinkSimple(this.textBox_ContainerTab_ContainerWebName.Text));
    }

    private void button_ContainerTab_Cancel_Click(object sender, EventArgs e)
    {
      this.ReloadCurrentElement();
    }

    private void button_ContainerTab_OK_Click(object sender, EventArgs e)
    {
      this.CurrentElementSaveChanges2();
    }

    private void textBox_ContainerTab_ContainerWebName_TextChanged(object sender, EventArgs e)
    {
      this.WebNameTextBox_TextCnanged(this.textBox_ContainerTab_ContainerWebName, this.pictureBox_ContainerTab_WebNameIcon, this.button_ContainerTab_CopyLink);
    }

    private void WebNameTextBox_TextCnanged(TextBox webNameTextBox, PictureBox errorIcon, Button CopyLinkButton)
    {
      if (this.m_currentElement == null)
        return;
      if (this.m_dblayer.WebNameCheck(webNameTextBox.Text, this.m_currentElement.WebTitle))
      {
        errorIcon.Visible = false;
        webNameTextBox.BackColor = Color.White;
        CopyLinkButton.Enabled = true;
      }
      else
      {
        errorIcon.Visible = true;
        webNameTextBox.BackColor = Form1.InvalidWebNameBackColor;
        CopyLinkButton.Enabled = false;
      }
      this.CurrentElementSetChangedFlag();
    }

    private void button_Item_QuantityMinus_Click(object sender, EventArgs e)
    {
      this.numericUpDown_ItemTab_ItemQuantity.DownButton();
    }

    private void button_Item_QuantityPlus_Click(object sender, EventArgs e)
    {
      this.numericUpDown_ItemTab_ItemQuantity.UpButton();
    }

    private void LoadDataToItemControls(CDbObject ob)
    {
      if (ob == null)
      {
        this.pictureBox_ItemTab_ItemImage.Image = (Image) null;
        this.pictureBox_ItemTab_ParentCategoryIcon.Image = (Image) null;
        this.textBox_ItemTab_ItemTitle.Text = string.Empty;
        this.textBox_ItemTab_ItemWebName.Text = string.Empty;
        this.textBox_ItemTab_ParentCategoryTitle.Text = string.Empty;
        this.textBox_ItemTab_ParentContainerTitle.Text = string.Empty;
        this.numericUpDown_ItemTab_ItemQuantity.Value = new Decimal(0);
        this.richTextBox_ItemTab_Description.Text = string.Empty;
        this.richTextBox_ItemTab_Notes.Text = string.Empty;
        this.checkBox_ItemTab_ItemInactive.Checked = false;
        this.comboBox_ItemTab_ItemUnits.Items.Clear();
      }
      else
      {
        CCategory categoryByTableId = this.m_dblayer.getCategoryByTableId(ob.ObjectId.ParentCategoryId, false);
        this.pictureBox_ItemTab_ParentCategoryIcon.Image = categoryByTableId.getStatedIcon();
        this.textBox_ItemTab_ParentCategoryTitle.Text = categoryByTableId.Title;
        CContainer containerByTableId = this.m_dblayer.getContainerByTableId(ob.ObjectId.ParentContainerId, false);
        this.pictureBox_ItemTab_ParentContainer.Image = containerByTableId.getStatedIcon();
        this.textBox_ItemTab_ParentContainerTitle.Text = containerByTableId.Title;
        CItem citem = (CItem) ob;
        this.pictureBox_ItemTab_ItemImage.Image = citem.Picture;
        this.textBox_ItemTab_ItemTitle.Text = citem.Title;
        this.textBox_ItemTab_ItemWebName.Text = citem.WebTitle;
        this.numericUpDown_ItemTab_ItemQuantity.Value = (Decimal) citem.Quantity;
        this.richTextBox_ItemTab_Description.Text = citem.Description;
        this.richTextBox_ItemTab_Notes.Text = citem.Notes;
        this.checkBox_ItemTab_ItemInactive.Checked = citem.Deleted;
        UnitCollectionItem[] array = this.m_dblayer.QuantityUnits.getArray();
        UnitCollectionItem unitCollectionItem1 = array[0];
        foreach (UnitCollectionItem unitCollectionItem2 in array)
        {
          this.comboBox_ItemTab_ItemUnits.Items.Add((object) unitCollectionItem2);
          if (unitCollectionItem2.m_code == citem.UnitCode)
            unitCollectionItem1 = unitCollectionItem2;
        }
        this.comboBox_ItemTab_ItemUnits.SelectedItem = (object) unitCollectionItem1;
        this.button_ItemTab_Cancel.Enabled = true;
        this.button_ItemTab_OK.Enabled = false;
        this.m_currentSaveButton = this.button_ItemTab_OK;
      }
    }

    private void StoreDataFromItemControls()
    {
      CItem citem = (CItem) this.m_currentElement;
      citem.Deleted = this.checkBox_ItemTab_ItemInactive.Checked;
      citem.Description = this.richTextBox_ItemTab_Description.Text;
      citem.Picture = this.pictureBox_ItemTab_ItemImage.Image;
      citem.LastChangeDate = DateTime.Now;
      citem.Notes = this.richTextBox_ItemTab_Notes.Text;
      citem.Title = this.textBox_ItemTab_ItemTitle.Text;
      citem.WebTitle = this.textBox_ItemTab_ItemWebName.Text;
      citem.Quantity = (double) this.numericUpDown_ItemTab_ItemQuantity.Value;
      UnitCollectionItem unitCollectionItem = (UnitCollectionItem) this.comboBox_ItemTab_ItemUnits.SelectedItem;
      citem.UnitCode = unitCollectionItem.m_code;
    }

    private void button_ItemTab_ParentCategoryChange_Click(object sender, EventArgs e)
    {
      CDbObject cdbObject = SelectTreeForm2.ShowSelectionForm((Form) this, "Выбрать категорию", DbObjectTypes.Category, this.m_dblayer, (CDbObject) this.m_dblayer.getCategoryByTableId(this.m_currentElement.ObjectId.ParentCategoryId, false));
      if (cdbObject == null)
        return;
      this.m_currentElement.ObjectId.ParentCategoryId = cdbObject.ObjectId.ElementId;
      this.pictureBox_ItemTab_ParentCategoryIcon.Image = cdbObject.getStatedIcon();
      this.textBox_ItemTab_ParentCategoryTitle.Text = cdbObject.Title;
      this.CurrentElementSetChangedFlag();
    }

    private void button_ItemTab_ParentContainerChange_Click(object sender, EventArgs e)
    {
      CDbObject cdbObject = SelectTreeForm2.ShowSelectionForm((Form) this, "Выбрать контейнер", DbObjectTypes.Container, this.m_dblayer, (CDbObject) this.m_dblayer.getContainerByTableId(this.m_currentElement.ObjectId.ParentContainerId, false));
      if (cdbObject == null)
        return;
      this.m_currentElement.ObjectId.ParentContainerId = cdbObject.ObjectId.ElementId;
      this.pictureBox_ItemTab_ParentContainer.Image = cdbObject.getStatedIcon();
      this.textBox_ItemTab_ParentContainerTitle.Text = cdbObject.Title;
      this.CurrentElementSetChangedFlag();
    }

    private void button_ItemTab_GenerateWebName_Click(object sender, EventArgs e)
    {
      this.textBox_ItemTab_ItemWebName.Text = this.m_dblayer.WebNameCreateFromTitle(this.textBox_ItemTab_ItemTitle.Text, this.textBox_ItemTab_ParentCategoryTitle.Text);
    }

    private void button_ItemTab_ItemImageChange_Click(object sender, EventArgs e)
    {
      this.LoadNewContainerOrItemImage(this.pictureBox_ItemTab_ItemImage);
    }

    private void button_ItemTab_CopyLink_Click(object sender, EventArgs e)
    {
      Clipboard.SetDataObject((object) CWebNameLink.createWebLinkSimple(this.textBox_ItemTab_ItemWebName.Text));
    }

    private void button_ItemTab_Cancel_Click(object sender, EventArgs e)
    {
      this.ReloadCurrentElement();
    }

    private void button_ItemTab_OK_Click(object sender, EventArgs e)
    {
      this.CurrentElementSaveChanges2();
    }

    private void textBox_ItemTab_ItemWebName_TextChanged(object sender, EventArgs e)
    {
      this.WebNameTextBox_TextCnanged(this.textBox_ItemTab_ItemWebName, this.pictureBox_ItemTab_ItemWebNameIcon, this.button_ItemTab_CopyLink);
    }

    private void pictureBox_ShortNameIcon_Click(object sender, EventArgs e)
    {
      this.textBox_CategoryWebName.Text = this.m_dblayer.WebNameCreateFromTitle(this.textBox_CategoryTitle.Text, this.textBox_CategoryParent.Text);
    }

    private void pictureBox_ParentIcon_Click(object sender, EventArgs e)
    {
      CDbObject cdbObject = SelectTreeForm2.ShowSelectionForm((Form) this, "Выбрать категорию", DbObjectTypes.Category, this.m_dblayer, (CDbObject) this.m_dblayer.getCategoryByTableId(this.m_currentElement.ObjectId.ParentCategoryId, false));
      if (cdbObject == null)
        return;
      if (cdbObject.ObjectId.ElementId == this.m_currentElement.ObjectId.ElementId && cdbObject.ObjectId.ElementType == this.m_currentElement.ObjectId.ElementType)
      {
        this.ShowMessageBox("Ошибка", "Ошибка вложенности категории");
      }
      else
      {
        this.m_currentElement.ObjectId.ParentCategoryId = cdbObject.ObjectId.ElementId;
        this.pictureBox_CategoryIcon.Image = cdbObject.getStatedIcon();
        this.textBox_CategoryParent.Text = cdbObject.Title;
        this.CurrentElementSetChangedFlag();
      }
    }

    private void pictureBox_CategoryIcon_Click(object sender, EventArgs e)
    {
      Image image = this.loadNewImage(this.m_currentElement.ObjectId.ElementType);
      if (image == null)
        return;
      this.pictureBox_CategoryIcon.Image = image;
      this.CurrentElementSetChangedFlag();
    }

    private void textBox_WebName_TextChanged(object sender, EventArgs e)
    {
      this.WebNameTextBox_TextCnanged(this.textBox_CategoryWebName, this.pictureBox_CategoryShortNameIcon, this.button_CategoryCopyLink);
    }

    private void button_CategoryCancel_Click(object sender, EventArgs e)
    {
      this.ReloadCurrentElement();
    }

    private void button_CategoryOk_Click(object sender, EventArgs e)
    {
      this.CurrentElementSaveChanges2();
    }

    private void LoadDataToCategoryControls(CDbObject cat)
    {
      if (cat == null)
      {
        this.textBox_CategoryParent.Text = string.Empty;
        this.pictureBox_CategoryParentIcon.Image = (Image) null;
        this.textBox_CategoryTitle.Text = string.Empty;
        this.textBox_CategoryWebName.Text = string.Empty;
        this.richTextBox_CategoryDescription.Text = string.Empty;
        this.richTextBox_CategoryNotes.Text = string.Empty;
        this.checkBox_CategoryInactive.Checked = false;
        this.pictureBox_CategoryIcon.Image = (Image) null;
      }
      else
      {
        CCategory ccategory = (CCategory) cat;
        CCategory categoryByTableId = this.m_dblayer.getCategoryByTableId(ccategory.ObjectId.ParentCategoryId, false);
        this.textBox_CategoryParent.Text = categoryByTableId.Title;
        this.pictureBox_CategoryParentIcon.Image = categoryByTableId.getStatedIcon();
        this.textBox_CategoryTitle.Text = ccategory.Title;
        this.textBox_CategoryWebName.Text = ccategory.WebTitle;
        this.richTextBox_CategoryDescription.Text = ccategory.Description;
        this.richTextBox_CategoryNotes.Text = ccategory.Notes;
        this.checkBox_CategoryInactive.Checked = ccategory.Deleted;
        this.pictureBox_CategoryIcon.Image = ccategory.Picture;
        this.button_CategoryCancel.Enabled = true;
        this.button_CategoryOk.Enabled = false;
        this.m_currentSaveButton = this.button_CategoryOk;
      }
    }

    private void StoreDataFromCategoryControls()
    {
      this.m_currentElement.Deleted = this.checkBox_CategoryInactive.Checked;
      this.m_currentElement.Description = this.richTextBox_CategoryDescription.Text;
      this.m_currentElement.Picture = this.pictureBox_CategoryIcon.Image;
      this.m_currentElement.LastChangeDate = DateTime.Now;
      this.m_currentElement.Notes = this.richTextBox_CategoryNotes.Text;
      this.m_currentElement.Title = this.textBox_CategoryTitle.Text;
      this.m_currentElement.WebTitle = this.textBox_CategoryWebName.Text;
    }

    private void button_CategoryCopyLink_Click(object sender, EventArgs e)
    {
      Clipboard.SetDataObject((object) CWebNameLink.createWebLinkSimple(this.textBox_CategoryWebName.Text));
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void ShellExecute(string path)
    {
      try
      {
        Process.Start(path);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("{0}: {1}", (object) ex.GetType().ToString(), (object) ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
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
      if (this.m_firstTimeBlockTreeSelectionHandler)
      {
        this.m_firstTimeBlockTreeSelectionHandler = false;
      }
      else
      {
        CDbObject element = this.m_treeManager.NodeSelect(e);
        this.ShowElementProperties(element, true, element.Title);
      }
    }

    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
    }

    private void LoadDataToSearchTab(object ob, string webname)
    {
      this.m_searchManager.setupCheckboxes(this.checkBox_SearchTab_Name, this.checkBox_SearchTab_Webname, this.checkBox_SearchTab_Description, this.checkBox_SearchTab_Notes);
      if (webname.Length == 0)
        return;
      this.textBox_SearchTab_SearchString.Text = webname;
      this.button_SearchTab_Search.Select();
    }

    private void textBox_SearchTab_SearchString_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      e.Handled = true;
      this.button_SearchTab_Search_Click(sender, new EventArgs());
    }

    private void button_SearchTab_Search_Click(object sender, EventArgs e)
    {
      try
      {
        string searchText = this.textBox_SearchTab_SearchString.Text.Trim();
        if (searchText.Length == 0)
          return;
        SearchFields sf = CSearchPanelManager.makeFlags(this.checkBox_SearchTab_Name, this.checkBox_SearchTab_Webname, this.checkBox_SearchTab_Description, this.checkBox_SearchTab_Notes);
        this.m_searchManager.Search(searchText, sf);
      }
      catch (Exception ex)
      {
        this.ShowMessageBox(ex.GetType().ToString(), ex.Message);
      }
    }

    private void listView_SearchTab_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listView_SearchTab_SearchResults.SelectedItems.Count <= 0)
        return;
      this.ShowElementByWebname((string) this.listView_SearchTab_SearchResults.SelectedItems[0].Tag);
    }

    private void contextMenuStrip_RichEdits_Opening(object sender, CancelEventArgs e)
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) sender;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      RichTextBox richTextBox = (RichTextBox) contextMenuStrip.SourceControl;
      this.toolStripMenuItem_Paste.Enabled = dataObject.GetDataPresent(DataFormats.Text, true) || dataObject.GetDataPresent(DataFormats.FileDrop, true);
      if (richTextBox.SelectionLength == 0)
      {
        this.toolStripMenuItem_Copy.Enabled = false;
        this.toolStripMenuItem_Cut.Enabled = false;
      }
      else
      {
        this.toolStripMenuItem_Copy.Enabled = true;
        this.toolStripMenuItem_Cut.Enabled = true;
      }
      this.ToolStripMenuItem_Redo.Enabled = richTextBox.CanRedo;
      this.ToolStripMenuItem_Undo.Enabled = richTextBox.CanUndo;
      if (richTextBox != this.richTextBox_ItemTab_Description && richTextBox != this.richTextBox_ItemTab_Notes)
        return;
      ToolStripMenuItem toolStripMenuItem = this.m_importingManager.Run((object) richTextBox, "Импорт...", this.m_currentElement.Title, AllowedContentTypes.Description | AllowedContentTypes.Documents);
      if (toolStripMenuItem == null)
        return;
      contextMenuStrip.Items.Add((ToolStripItem) toolStripMenuItem);
    }

    private void toolStripMenuItem_Cut_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((TextBoxBase) contextMenuStrip.SourceControl).Cut();
    }

    private void toolStripMenuItem_Copy_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((TextBoxBase) contextMenuStrip.SourceControl).Copy();
    }

    private void toolStripMenuItem_Paste_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ClipboardManager.RichTextBoxPaste(Clipboard.GetDataObject(), (RichTextBox) contextMenuStrip.SourceControl);
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((TextBoxBase) contextMenuStrip.SourceControl).Undo();
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((RichTextBox) contextMenuStrip.SourceControl).Redo();
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((TextBoxBase) contextMenuStrip.SourceControl).SelectAll();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (RichTextBox))
        return;
      ((TextBoxBase) contextMenuStrip.SourceControl).Clear();
    }

    private void richTextBox_Notes_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      Form1.ShellExecute(Uri.UnescapeDataString(e.LinkText));
    }

    private void richTextBox_Notes_DragDrop(object sender, DragEventArgs e)
    {
      RichTextBox rtb = (RichTextBox) sender;
      ClipboardManager.RichTextBoxPaste(e.Data, rtb);
    }

    private void richTextBox_Notes_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.Text))
        e.Effect = DragDropEffects.Copy;
      else if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void importingManager_Results(object sender, ImportMenuManagerEventArgs e)
    {
      if (e.Target == null)
        return;
      if (e.Target.GetType().Equals(typeof (RichTextBox)))
      {
        ClipboardManager.RichTextBoxPaste((RichTextBox) e.Target, this.preparePastedText(e.ContentType, e.ContentText));
      }
      else
      {
        if (!e.Target.GetType().Equals(typeof (PictureBox)))
          return;
        ((PictureBox) e.Target).Image = CImageProcessor.LoadAndResizeImage(DbObjectTypes.Container, e.ContentText);
      }
    }

    private string preparePastedText(AllowedContentTypes type, string text)
    {
      switch (type)
      {
        case AllowedContentTypes.Description:
          return text;
        case AllowedContentTypes.Documents:
        case AllowedContentTypes.Picture:
          return ClipboardManager.makeUriFromRelativeFilePath(this.m_importingManager.DatabasesFolder, text);
        default:
          return "";
      }
    }

    private void ToolStripMenuItem_PictureBoxes_OpenFile_Click(object sender, EventArgs e)
    {
      PictureBox fromContextMenuItem = ClipboardManager.getPictureBoxFromContextMenuItem(sender);
      if (fromContextMenuItem == null)
        return;
      this.LoadNewContainerOrItemImage(fromContextMenuItem);
    }

    private void ToolStripMenuItem_PictureBoxes_Paste_Click(object sender, EventArgs e)
    {
      ClipboardManager.ContextMenu_Paste(sender);
      this.CurrentElementSetChangedFlag();
    }

    private void ToolStripMenuItem_PictureBoxes_Copy_Click(object sender, EventArgs e)
    {
      ClipboardManager.ContextMenu_Copy(sender);
    }

    private void ToolStripMenuItem_PictureBoxes_Cut_Click(object sender, EventArgs e)
    {
      ClipboardManager.ContextMenu_Clear(sender);
      this.CurrentElementSetChangedFlag();
    }

    private void contextMenuStrip_PictureBoxes_Opening(object sender, CancelEventArgs e)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) sender;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (PictureBox))
        return;
      PictureBox pictureBox = (PictureBox) contextMenuStrip.SourceControl;
      this.ToolStripMenuItem_PictureBoxes_Paste.Enabled = Clipboard.ContainsImage() || Clipboard.ContainsFileDropList();
      bool flag = pictureBox.Image != null;
      this.ToolStripMenuItem_PictureBoxes_Cut.Enabled = flag;
      this.ToolStripMenuItem_PictureBoxes_Copy.Enabled = flag;
      ToolStripMenuItem toolStripMenuItem = this.m_importingManager.Run((object) pictureBox, "Импорт...", this.m_currentElement.Title, AllowedContentTypes.Picture);
      if (toolStripMenuItem == null)
        return;
      contextMenuStrip.Items.Add((ToolStripItem) toolStripMenuItem);
    }

    private void pictureBox_ContainerTabOrItemTab_DragEnter(object sender, DragEventArgs e)
    {
      ClipboardManager.PictureBox_DragEnter(e);
    }

    private void pictureBox_ContainerTabOrItemTab_DragDrop(object sender, DragEventArgs e)
    {
      ClipboardManager.PictureBox_dragDrop(sender, e);
      this.CurrentElementSetChangedFlag();
    }
  }
}
