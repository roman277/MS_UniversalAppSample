using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;

namespace UniversalHello
{
        public class Flickr
        {

        List<BitmapImage> list = new List<BitmapImage>();

        public Flickr()
        {
            var xdoc = XDocument.Load("http://api.flickr.com/services/feeds/photos_public.gne");
            XNamespace xn = "http://www.w3.org/2005/Atom";
            var res = from z in xdoc.Descendants(xn + "entry")
                        let l =
                            (from x in z.Descendants(xn + "link")
                            where x.Attribute("rel").Value == "enclosure"
                            select x.Attribute("href").Value).FirstOrDefault()
                        where (l!=null) && (l!="")
                        select l;

            foreach (var x in res)
            {
                list.Add(new BitmapImage(new Uri(x)));
            }
        }

        public List<BitmapImage> Images
        {
            get
            {
                return list;
            }
        }

    }
}
