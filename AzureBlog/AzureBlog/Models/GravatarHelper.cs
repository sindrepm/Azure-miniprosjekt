using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Web.Routing;

namespace AzureBlog.Models
{
    public static class GravatarHelper
    {
        private const string GRAVATAR_URL = "http://www.gravatar.com/avatar/";

        public static string Gravatar(this HtmlHelper html, 
                                      string email, 
                                      int? size = null, 
                                      GravatarRating rating = GravatarRating.Default, 
                                      GravatarDefaultImage defaultImage = GravatarDefaultImage.MysteryMan, 
                                      object htmlAttributes = null)
        {
            string gravatarUrl = BuildGravatarUrl(email, rating, defaultImage, size);

            return BuildGravatarImageTag(gravatarUrl, size, htmlAttributes);
        }

        private static string BuildGravatarImageTag(string url, int? size, object htmlAttributes = null)
        {
            var tag = new TagBuilder("img");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.Attributes.Add("src", url);

            if (size != null)
            {
                tag.Attributes.Add("width", size.Value.ToString());
                tag.Attributes.Add("height", size.Value.ToString());
            }

            return tag.ToString();
        }

        private static string BuildGravatarUrl(string email, GravatarRating rating, GravatarDefaultImage defaultImage, int? size = null)
        {
            var urlBuilder = new StringBuilder(GRAVATAR_URL, 90);
            urlBuilder.Append(GetEmailHash(email));

            var isFirst = true;
            Action<string, string> addParam = (name, value) =>
            {
                urlBuilder.Append(isFirst ? '?' : '&');
                isFirst = false;
                urlBuilder.Append(name);
                urlBuilder.Append("=");
                urlBuilder.Append(value);
            };

            if (size != null)
            {
                if (size < 1 || size > 512)
                    throw new ArgumentOutOfRangeException("size", size, "Must be null or value between 1 and 512, inclusive.");

                addParam("s", size.Value.ToString());
            }

            if (rating != GravatarRating.Default)
                addParam("r", rating.ToString().ToLower());

            if (defaultImage != GravatarDefaultImage.Default)
            {
                string imageToShow = "";

                switch (defaultImage)
                {
                    case GravatarDefaultImage.Http404:
                        imageToShow = "404";
                        break;
                    case GravatarDefaultImage.MysteryMan:
                        imageToShow = "mm";
                        break;
                    case GravatarDefaultImage.Identicon:
                        imageToShow = "identicon";
                        break;
                    case GravatarDefaultImage.MonsterId:
                        imageToShow = "monsterid";
                        break;
                    case GravatarDefaultImage.Wavatar:
                        imageToShow = "wavatar";
                        break;
                }

                addParam("d", imageToShow);
            }

            return urlBuilder.ToString();
        }

        private static string GetEmailHash(string email)
        {
            email = email.Trim().ToLower();

            var emailBytes = Encoding.ASCII.GetBytes(email);
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(emailBytes);

            var hash = new StringBuilder();

            foreach (var b in hashBytes)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }

    public enum GravatarRating
    {
        Default,
        G,
        Pg,
        R,
        X
    }

    public enum GravatarDefaultImage
    {
        Default,
        Http404,
        MysteryMan,
        Identicon,
        MonsterId,
        Wavatar
    }
}