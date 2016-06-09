using System.ComponentModel;

namespace Models
{
    public enum ContentType
    {
        [Description("application/pdf")] pdf,
        [Description("application/zip")] zip
    }
}
