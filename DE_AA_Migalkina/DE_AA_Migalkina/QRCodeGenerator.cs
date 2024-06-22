using ZXing;
using ZXing.Common;
using System.Drawing;

public class QRCodeGenerator
{
    // Метод для генерации QR-кода из текстовой строки
    public Bitmap GenerateQRCode(string text)
    {
        var writer = new BarcodeWriter();
        var encodingOptions = new EncodingOptions { Width = 300, Height = 300, Margin = 0 };
        writer.Options = encodingOptions;
        writer.Format = BarcodeFormat.QR_CODE;

        return writer.Write(text);
    }
}