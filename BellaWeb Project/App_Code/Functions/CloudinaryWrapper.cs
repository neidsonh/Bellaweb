using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Configuration;

/// <summary>
/// Summary description for CloudinaryWrapper
/// </summary>
public class CloudinaryWrapper
{
    private static Cloudinary CloudinaryRef
    {
        get {
            Account account = new Account(
                "jonatasleon", 
                "414883337134297",
                ConfigurationManager.AppSettings["cloudinaryKey"]
            );
            return new Cloudinary(account);
        }
    }

    public static UploadResult UploadImage(string path)
    {
        var uploadParams = new ImageUploadParams()
        {
            //File = new FileDescription(path),
            File = new FileDescription(path)
        };

        return CloudinaryRef.Upload(uploadParams);
    }



}