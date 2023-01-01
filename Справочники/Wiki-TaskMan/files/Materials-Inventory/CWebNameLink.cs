// Decompiled with JetBrains decompiler
// Type: RadioBase.CWebNameLink
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;
using System.Globalization;
using System.Text;

namespace RadioBase
{
  public class CWebNameLink
  {
    private static char[] RestrictedWebLinkSymbols = new char[27]
    {
      ' ',
      '\\',
      '/',
      '?',
      ';',
      ':',
      '@',
      '&',
      '=',
      '+',
      '$',
      ',',
      '<',
      '>',
      '"',
      '#',
      '{',
      '}',
      '|',
      '^',
      '[',
      ']',
      '‘',
      '%',
      '\n',
      '\t',
      '\r'
    };
    public static string SchemaName = "inv";
    public static string SchemaNameAlternative = "123";

    public static bool IsInvalidWebName(string text)
    {
      return text.Length < 3 || text.Length > 64 || text.IndexOfAny(CWebNameLink.RestrictedWebLinkSymbols) >= 0;
    }

    public static string ExtractWeblinkFromProgramArguments()
    {
      string[] commandLineArgs = Environment.GetCommandLineArgs();
      if (commandLineArgs.Length < 2)
        return string.Empty;
      return Uri.UnescapeDataString(commandLineArgs[1]);
    }

    public static string ExtractWebnameFromWeblink(string weblink)
    {
      if (string.IsNullOrEmpty(weblink))
        return weblink;
      string[] strArray = weblink.Split(new char[1]
      {
        ':'
      }, StringSplitOptions.RemoveEmptyEntries);
      if (!string.Equals(strArray[0], CWebNameLink.SchemaName) && !string.Equals(strArray[0], CWebNameLink.SchemaNameAlternative))
        return (string) null;
      if (strArray.Length < 2)
        return string.Empty;
      return strArray[1].Trim().Replace("\\", string.Empty);
    }

    public static string ExtractSchemaFromWeblink(string weblink)
    {
      return weblink.Split(new char[1]
      {
        ':'
      }, StringSplitOptions.RemoveEmptyEntries)[0];
    }

    public static string createWebLinkSimple(string webname)
    {
      return CWebNameLink.SchemaName + ":" + webname;
    }

    internal static string createWebnameFromTitle(string title)
    {
      char[] chArray = title.ToCharArray();
      StringBuilder stringBuilder = new StringBuilder(chArray.Length);
      foreach (char ch1 in chArray)
      {
        char ch2 = ch1;
        foreach (char ch3 in CWebNameLink.RestrictedWebLinkSymbols)
        {
          if (ch1.Equals(ch3))
            ch2 = '_';
        }
        stringBuilder.Append(ch2);
      }
      if (stringBuilder.Length > 64)
        stringBuilder.Length = 64;
      if (stringBuilder.Length < 3)
      {
        stringBuilder.Append('_');
        stringBuilder.Append(new Random().Next(10, 100).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      }
      return stringBuilder.ToString();
    }
  }
}
