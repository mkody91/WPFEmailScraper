using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfEmailScraper
{
    class SiteEmailScraper
    {
        //Private Class Members
        private HashSet<MailAddress> _results = new HashSet<MailAddress>();
        private HashSet<Uri> _sitesToScrape = new HashSet<Uri>();
        private HashSet<Uri> _sitesScraped = new HashSet<Uri>();

        //Public Class Properties
        public HashSet<MailAddress> Results
        {
            get
            {
                return this._results;
            }
        }

        //Public Methods
        public void Scrape(string url)
        {
            WebClient client = new WebClient();

            try
            {
                //Step 1
                string result = client.DownloadString(url);

                //Step 2
                LinkScraper ls = new LinkScraper();
                ls.Scrape(url);
                _sitesToScrape = ls.Results;

                //Step 3
                _sitesToScrape.Add(new Uri(url));

                //Step 4
                foreach (Uri uri in _sitesToScrape)
                {
                    EmailScraper es = new EmailScraper();

                    if (uri.Authority == "www.southhills.edu")
                    {
                        es.Scrape(uri.AbsoluteUri);
                        _sitesScraped.Add(new Uri(uri.AbsoluteUri));
                        _results.UnionWith(es.Results);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
