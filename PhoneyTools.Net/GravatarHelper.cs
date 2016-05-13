using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using AgiliTrain.PhoneyTools.Security.Cryptography;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// Submission by J. Paul Duncan

namespace AgiliTrain.PhoneyTools.Net
{
  /// <summary>
  /// Utility class to generate a valid Gravatar URL.
  /// </summary>
  public static class GravatarHelper
  {
    /// <summary>
    /// Image type to return if no gravatar is found.
    /// </summary>
    public enum DefaultImageTypes : int
    {
      /// <summary>
      /// Do not load any image if none is associated with the email hash, instead return an HTTP 404 (File Not Found) response
      /// </summary>
      None = 0,
      /// <summary>
      /// A simple, cartoon-style silhouetted outline of a person (does not vary by email hash)
      /// </summary>
      MysteryMan,
      /// <summary>
      /// A geometric pattern based on an email hash
      /// </summary> 
      Identicon,
      /// <summary>
      /// A generated 'monster' with different colors, faces, etc
      /// </summary>
      Monster,
      /// <summary>
      /// Generated faces with differing features and backgrounds
      /// </summary>
      Wavatar,
      /// <summary>
      /// Awesome generated, 8-bit arcade-style pixelated faces
      /// </summary>
      Retro
    }

    /// <summary>
    /// Image rating type.
    /// </summary>
    public enum RatingTypes : int
    {
      /// <summary>
      /// Suitable for display on all websites with any audience type.
      /// </summary>
      G = 0,
      /// <summary>
      /// May contain rude gestures, provocatively dressed individuals, the lesser swear words, or mild violence.
      /// </summary>
      PG,
      /// <summary>
      /// May contain such things as harsh profanity, intense violence, nudity, or hard drug use.
      /// </summary>
      R,
      /// <summary>
      /// May contain hardcore sexual imagery or extremely disturbing violence.
      /// </summary>
      X
    }

    private static string _urlTemplate = @"http://www.gravatar.com/avatar/{0}?s={1}&r={2}&d={3}";
    private static string[] _imageTypes = { "404", "mm", "identicon", "monsterid", "wavatar", "retro" };
    private static string[] _ratingTypes = { "g", "pg", "r", "x" };

    /// <summary>
    /// Calculates the url for the gravatar image.
    /// </summary>
    /// <param name="email">Email address of the associated gravatar user.</param>
    /// <param name="size">Size of the image to return (1-512 px)</param>
    /// <param name="imageType">Image type to return if no gravatar is found.</param>
    /// <param name="rating">Image rating type.</param>
    /// <returns>Formatted Gravatar URL</returns>
    public static string ImageUrl(string email, int size = 80, DefaultImageTypes imageType = DefaultImageTypes.Retro, RatingTypes rating = RatingTypes.G)
    {
      string targetEmail = string.IsNullOrEmpty(email) ? "null@gravatar.com" : email;
      return string.Format(_urlTemplate, HashEmail(email), size.ToString(), _ratingTypes[(int)rating], _imageTypes[(int)imageType]);
    }

    /// <summary>
    /// Calculates the url for the gravatar image.
    /// </summary>
    /// <param name="email">Email address of the associated gravatar user.</param>
    /// <param name="size">Size of the image to return (1-512 px)</param>
    /// <param name="imageType">Image type to return if no gravatar is found.</param>
    /// <param name="rating">Image rating type.</param>
    /// <returns>Formatted Gravatar Uri Object</returns>
    public static Uri GetImageUri(string email, int size = 80, DefaultImageTypes imageType = DefaultImageTypes.Retro, RatingTypes rating = RatingTypes.G)
    {
      return new Uri(ImageUrl(email, size, imageType, rating));
    }

    /// <summary>
    /// Calculates the url for the gravatar image.
    /// </summary>
    /// <param name="email">Email address of the associated gravatar user.</param>
    /// <param name="size">Size of the image to return (1-512 px)</param>
    /// <param name="imageType">Image type to return if no gravatar is found.</param>
    /// <param name="rating">Image rating type.</param>
    /// <returns>ImageSource containing the link to the Gravatar Image</returns>
    public static ImageSource GetImageSource(string email, int size = 80, DefaultImageTypes imageType = DefaultImageTypes.Retro, RatingTypes rating = RatingTypes.G)
    {
      return new BitmapImage(GetImageUri(email, size, imageType, rating));
    }

    /// <summary>
    /// Computes the hash for the given email.
    /// </summary>
    /// <param name="email">Email address to hash.</param>
    /// <returns></returns>
    private static string HashEmail(string email)
    {
      MD5Managed md5 = new MD5Managed();

      var hasedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(email));

      var sb = new StringBuilder();

      for (var i = 0; i < hasedBytes.Length; i++)
      {
        sb.Append(hasedBytes[i].ToString("X2"));
      }

      return sb.ToString().ToLower();

    }

  }
}