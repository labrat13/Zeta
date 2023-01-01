// Decompiled with JetBrains decompiler
// Type: RadioBase.ClipboardManager
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RadioBase
{
  internal class ClipboardManager
  {
    private static string UrlReservedChars = ";?:@$&=+,/{}|\\^~[]`\"%";

    internal static void RichTextBoxPaste(IDataObject daob, RichTextBox rtb)
    {
      string textPasted = ClipboardManager.makeTextOrLinks(daob);
      ClipboardManager.RichTextBoxPaste(rtb, textPasted);
    }

    public static void RichTextBoxPaste(RichTextBox rtb, string textPasted)
    {
      int selectionStart = rtb.SelectionStart;
      int startIndex = rtb.SelectionStart + rtb.SelectionLength;
      string str1 = rtb.Text.Substring(startIndex);
      string str2 = rtb.Text.Substring(0, selectionStart) + textPasted + str1;
      rtb.Text = str2;
      rtb.Select(selectionStart, textPasted.Length);
    }

    private static string makeTextOrLinks(IDataObject daob)
    {
      string str = "";
      if (daob.GetDataPresent(DataFormats.FileDrop, true))
      {
        string[] strArray = (string[]) daob.GetData(DataFormats.FileDrop, true);
        if (strArray != null)
        {
          StringBuilder stringBuilder = new StringBuilder();
          foreach (string pathname in strArray)
          {
            stringBuilder.Append("  ");
            stringBuilder.Append(ClipboardManager.makeFileUrlFromAbsoluteNTPath(pathname));
            stringBuilder.Append("  ");
            if (strArray.Length > 2)
              stringBuilder.AppendLine();
          }
          str = stringBuilder.ToString();
        }
      }
      else if (daob.GetDataPresent(DataFormats.UnicodeText, true))
        str = daob.GetData(DataFormats.UnicodeText, true).ToString();
      return str;
    }

    public static string makeUriFromAbsoluteFilePath(string ss)
    {
      return new UriBuilder()
      {
        Scheme = Uri.UriSchemeFile,
        Path = ss
      }.ToString();
    }

    public static string makeFileUrlFromAbsoluteNTPath(string pathname)
    {
      char[] chArray1 = new char[1]
      {
        '\\'
      };
      char[] chArray2 = new char[1]
      {
        ':'
      };
      if (pathname.IndexOf(':') == -1)
        return ClipboardManager.urlQuote(string.Join("/", pathname.Split(chArray1)), "/");
      string[] strArray1 = pathname.Split(chArray2);
      if (strArray1.Length != 2 || strArray1[0].Length > 1)
        return string.Empty;
      string str1 = ClipboardManager.urlQuote(strArray1[0].ToUpper(), "/");
      string[] strArray2 = strArray1[1].Split(chArray1);
      string str2 = "file:///" + str1 + ":";
      foreach (string path in strArray2)
      {
        if (path != string.Empty)
          str2 = str2 + "/" + ClipboardManager.urlQuote(path, "/");
      }
      return str2;
    }

    private static string urlQuote(string path, string safe)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < path.Length; ++index)
      {
        char ch = path[index];
        if (safe.IndexOf(ch) == -1 && (char.ConvertToUtf32(path, index) < 33 || ClipboardManager.UrlReservedChars.IndexOf(ch) != -1))
          stringBuilder.AppendFormat("%{0:X2}", (object) char.ConvertToUtf32(path, index));
        else
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    public static string makeUriFromRelativeFilePath(string rootpath, string text)
    {
      string str1 = string.Empty;
      try
      {
        string str2 = text.Trim();
        if (Uri.IsWellFormedUriString(str2, UriKind.Absolute))
          str2 = new UriBuilder(str2).Path;
        string str3 = str2.TrimStart('/', '\\');
        string pathRoot = Path.GetPathRoot(str3);
        if (string.IsNullOrEmpty(pathRoot))
          str3 = Path.Combine(rootpath, str3);
        else if (pathRoot.Length < 3)
          str3 = string.Empty;
        if (File.Exists(str3))
          str1 = ClipboardManager.makeUriFromAbsoluteFilePath(str3);
      }
      catch (Exception ex)
      {
        str1 = string.Empty;
      }
      return str1;
    }

    public static void PictureBox_DragEnter(DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.Bitmap))
      {
        if (e.KeyState == 9)
          e.Effect = DragDropEffects.Copy;
        else
          e.Effect = DragDropEffects.Move;
      }
      else if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.All;
      else
        e.Effect = DragDropEffects.None;
    }

    public static void PictureBox_dragDrop(object sender, DragEventArgs e)
    {
      if (sender == null)
        return;
      PictureBox pictureBox = (PictureBox) sender;
      if (e.Data.GetDataPresent(DataFormats.Bitmap))
      {
        pictureBox.Image = CImageProcessor.ResizeImage((Image) e.Data.GetData(DataFormats.Bitmap), new Size(200, 200));
      }
      else
      {
        if (!e.Data.GetDataPresent(DataFormats.FileDrop))
          return;
        string[] strArray = (string[]) e.Data.GetData(DataFormats.FileDrop);
        if (strArray.Length <= 0)
          return;
        pictureBox.Image = CImageProcessor.LoadAndResizeImage(DbObjectTypes.Container, strArray[0]);
      }
    }

    public static PictureBox getPictureBoxFromContextMenuItem(object sender)
    {
      ContextMenuStrip contextMenuStrip = (ContextMenuStrip) ((ToolStripItem) sender).Owner;
      if (contextMenuStrip.SourceControl == null || contextMenuStrip.SourceControl.GetType() != typeof (PictureBox))
        return (PictureBox) null;
      return (PictureBox) contextMenuStrip.SourceControl;
    }

    public static void ContextMenu_Copy(object sender)
    {
      PictureBox fromContextMenuItem = ClipboardManager.getPictureBoxFromContextMenuItem(sender);
      if (fromContextMenuItem == null || fromContextMenuItem.Image == null)
        return;
      Clipboard.SetImage(fromContextMenuItem.Image);
    }

    public static void ContextMenu_Paste(object sender)
    {
      PictureBox fromContextMenuItem = ClipboardManager.getPictureBoxFromContextMenuItem(sender);
      if (fromContextMenuItem == null)
        return;
      if (Clipboard.ContainsImage())
      {
        fromContextMenuItem.Image = CImageProcessor.ResizeImage(Clipboard.GetImage(), new Size(200, 200));
      }
      else
      {
        if (!Clipboard.ContainsFileDropList())
          return;
        StringCollection fileDropList = Clipboard.GetFileDropList();
        if (fileDropList.Count <= 0)
          return;
        fromContextMenuItem.Image = CImageProcessor.LoadAndResizeImage(DbObjectTypes.Container, fileDropList[0]);
      }
    }

    public static void ContextMenu_Clear(object sender)
    {
      PictureBox fromContextMenuItem = ClipboardManager.getPictureBoxFromContextMenuItem(sender);
      if (fromContextMenuItem == null)
        return;
      fromContextMenuItem.Image = (Image) null;
    }
  }
}
