// Decompiled with JetBrains decompiler
// Type: RadioBase.SearchFields
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;

namespace RadioBase
{
  [Flags]
  public enum SearchFields
  {
    None = 0,
    Title = 1,
    Webtitle = 2,
    Description = 4,
    Notes = 8,
  }
}
