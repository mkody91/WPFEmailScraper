using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Xml;

namespace WpfEmailScraper
{
    class LinkScraper
    {
        //Private Class Members
        private HashSet<Uri> _results = new HashSet<Uri>();

        //Public Class Properties
        public HashSet<Uri> Results
        {
            get
            {
                return this._results;
            }
        }

        //Public Methods
        public void Scrape(string url)
        {            
            

            try
            {
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc = hw.Load(url);   
    
                foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    try
                    {
                        HtmlAttribute att = link.Attributes["href"];
                        Console.WriteLine(att.Value);
                        this._results.Add(new Uri(att.Value));
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                //What Should I Do Here?
                //Maybe Nothing for Now
            }
        }
    }
}
