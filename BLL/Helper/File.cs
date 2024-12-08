using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class CloudinaryHelper
{
    // دالة الرفع التي تتضمن تهيئة Cloudinary وحذف الصورة
    public static async Task<string> UploadImageAsync(IFormFile image, string publicId = null)
    {
        try
        {
            // تهيئة Cloudinary في الدالة
            
            var account = new Account("douncafln", "232282938634254", "bTOOyKlAJbN7BAutZyg_JVvx8fE");
            var cloudinary = new Cloudinary(account);

            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("No image provided.");
            }

            // تحويل الصورة من IFormFile إلى Stream
            using (var stream = image.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, stream),  // إضافة اسم الملف للصورة
                    PublicId = publicId,  // يمكنك تحديد PublicId اختياريًا
                    Overwrite = true  // استبدال الصورة إذا كانت موجودة بنفس الاسم
                };

                // رفع الصورة إلى Cloudinary
                var uploadResult = await Task.Run(() => cloudinary.Upload(uploadParams));

                // إرجاع الرابط العام للصورة
                return uploadResult.SecureUrl.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error uploading image: " + ex.Message);
            return null;
        }
    }

    // دالة لحذف الصورة
    public static async Task<bool> DeleteImageAsync(string imageUrl)
    {
        try
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentException("Image URL cannot be null or empty.");
            }

            // استخراج PublicId من الرابط الكامل
            string publicId = GetPublicIdFromUrl(imageUrl);

            if (string.IsNullOrEmpty(publicId))
            {
                throw new ArgumentException("Unable to extract PublicId from URL.");
            }

            // تهيئة Cloudinary
            var account = new Account("douncafln", "232282938634254", "bTOOyKlAJbN7BAutZyg_JVvx8fE");
            var cloudinary = new Cloudinary(account);

            // إعدادات الحذف باستخدام PublicId
            var deleteParams = new DeletionParams(publicId);

            // حذف الصورة من Cloudinary
            var deleteResult = await Task.Run(() => cloudinary.Destroy(deleteParams));
            Console.WriteLine(deleteResult.Error);
            var error = deleteResult.Error;
            // التحقق مما إذا كانت عملية الحذف ناجحة
            if (deleteResult.Result == "ok")
            {
                Console.WriteLine("Image deleted successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to delete image.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting image: " + ex.Message);
            return false;
        }
    }

  public static string GetPublicIdFromUrl(string imageUrl)
{
    try
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new ArgumentException("Image URL cannot be null or empty.");
        }

        Uri imageUri = new Uri(imageUrl);
        // استخراج الجزء بعد "/upload/"
        string publicIdWithExtension = imageUri.AbsolutePath.Split(new[] { "/upload/" }, StringSplitOptions.None).Last();

        // إزالة الإصدار (vxxxxxx) إذا كان موجودًا وأيضًا إزالة الامتداد .png أو .jpg
        string publicId = publicIdWithExtension.Split('/').Skip(1).Last().Split('.').First(); // أخذ الجزء الأخير فقط بدون الامتداد

        if (string.IsNullOrEmpty(publicId))
        {
            throw new ArgumentException("Unable to extract PublicId from URL.");
        }

        return publicId;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error extracting PublicId: " + ex.Message);
        return null;
    }
}





}
