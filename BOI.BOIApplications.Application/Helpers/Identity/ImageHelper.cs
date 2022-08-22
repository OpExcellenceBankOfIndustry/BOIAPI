using System.Drawing;
using System.Drawing.Imaging;

namespace BOI.BOIApplications.Domain.Utils
{
    public class ImageHelper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static string ConvertImage(Byte[] ImageBytes)
        {
            var base64String = string.Empty;
            try
            {
                MemoryStream ms = new MemoryStream(ImageBytes);
                Image returnImage = Image.FromStream(ms);
                using (MemoryStream m = new MemoryStream())
                {
                    returnImage.Save(m, ImageFormat.Png);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    base64String = string.Format("data:image/png;base64,{0}", base64String);
                }
                return base64String;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
