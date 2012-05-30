using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RingtoneSaver.Infrastructure.Common
{
    public static class FileNameResolver
    {
        public static string GetFileNameWithExtensionFromUri(Uri uri)
        {
            int indexOfLastSlash = uri.OriginalString.LastIndexOf('/');
            string fileName = uri.OriginalString.Substring(indexOfLastSlash + 1);
            return fileName;
        }
    }
}
