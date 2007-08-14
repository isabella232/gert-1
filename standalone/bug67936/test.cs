using System;
using System.Drawing;
using System.Globalization;

public class EntryPoint {
    [STAThread]
    static void Main(string[] args) {
        using (Image image = Image.FromFile("peace.jpg")) {
            Console.WriteLine(image.HorizontalResolution.ToString(
                CultureInfo.InvariantCulture));
        }
    }
}

