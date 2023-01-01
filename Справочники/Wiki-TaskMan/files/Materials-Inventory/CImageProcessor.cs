// Decompiled with JetBrains decompiler
// Type: RadioBase.CImageProcessor
// Assembly: Inventory, Version=1.0.6.10, Culture=neutral, PublicKeyToken=null
// MVID: 66E7676B-425A-461C-95A5-F6C6077B0D81
// Assembly location: C:\Program Files (x86)\Inventory\Inventory.exe

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RadioBase
{
  public class CImageProcessor
  {
    public static Image ImageFromBytes(byte[] bytes)
    {
      if (bytes.Length == 0)
        return (Image) null;
      MemoryStream memoryStream = new MemoryStream(bytes, false);
      Image image = Image.FromStream((Stream) memoryStream, true, true);
      memoryStream.Close();
      return image;
    }

    public static byte[] ImageToBytes(Image img)
    {
      if (img == null)
        return new byte[0];
      MemoryStream memoryStream = new MemoryStream();
      img.Save((Stream) memoryStream, ImageFormat.Png);
      byte[] buffer = memoryStream.GetBuffer();
      memoryStream.Close();
      return buffer;
    }

    public static Image CreateGrayscaleImage(Image original)
    {
      Bitmap bitmap = new Bitmap(original.Width, original.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      ImageAttributes imageAttr = new ImageAttributes();
      float[][] newColorMatrix1 = new float[5][]
      {
        new float[5]
        {
          0.3f,
          0.3f,
          0.3f,
          0.0f,
          0.0f
        },
        new float[5]
        {
          0.59f,
          0.59f,
          0.59f,
          0.0f,
          0.0f
        },
        new float[5]
        {
          0.11f,
          0.11f,
          0.11f,
          0.0f,
          0.0f
        },
        null,
        null
      };
      float[][] numArray1 = newColorMatrix1;
      int index = 3;
      float[] numArray2 = new float[5];
      numArray2[3] = 1f;
      float[] numArray3 = numArray2;
      numArray1[index] = numArray3;
      newColorMatrix1[4] = new float[5]
      {
        0.3f,
        0.3f,
        0.3f,
        0.0f,
        1f
      };
      ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix1);
      imageAttr.SetColorMatrix(newColorMatrix2);
      graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttr);
      graphics.Dispose();
      return (Image) bitmap;
    }

    public static string GetMD5Hash(Image icon)
    {
      MD5 md5 = MD5.Create();
      MemoryStream memoryStream = new MemoryStream();
      icon.Save((Stream) memoryStream, ImageFormat.Bmp);
      byte[] hash = md5.ComputeHash((Stream) memoryStream);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("x2", (IFormatProvider) CultureInfo.InvariantCulture));
      return stringBuilder.ToString();
    }

    internal static Image ResizeImage(Image image, Size pictureSize)
    {
      if (image == null)
        return (Image) null;
      int width1 = image.Width;
      int height1 = image.Height;
      float num1 = (float) pictureSize.Width / (float) width1;
      float num2 = (float) pictureSize.Height / (float) height1;
      float num3 = (double) num2 < (double) num1 ? num2 : num1;
      int width2 = Convert.ToInt32((float) width1 * num3);
      int height2 = Convert.ToInt32((float) height1 * num3);
      Image image1 = (Image) new Bitmap(width2, height2);
      using (Graphics graphics = Graphics.FromImage(image1))
      {
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(image, 0, 0, width2, height2);
      }
      return image1;
    }

    public static Image LoadAndResizeImage(DbObjectTypes dbObjectType, string filepath)
    {
      try
      {
        Size pictureSize = dbObjectType != DbObjectTypes.Category ? new Size(200, 200) : new Size(32, 32);
        return CImageProcessor.ResizeImage(Image.FromFile(filepath), pictureSize);
      }
      catch (Exception ex)
      {
        return (Image) null;
      }
    }
  }
}
