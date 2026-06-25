namespace Pleer.Ext;


public static class ImageExtensions
{
    public static Icon ToIcon(this Image img)
    {
        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Icon);
        var i = new Icon(ms);
        return i;
    }
}
