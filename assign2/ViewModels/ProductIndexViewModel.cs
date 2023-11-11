using assign2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assign2.ViewModels
{
    public class ProductIndexViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public string Search { get; set; }
        public IEnumerable<TopicWithCount> CatsWithCount { get; set; }
        public string Topic { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.TopicName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }
    public class TopicWithCount
    {
        public int ProductCount { get; set; }
        public string TopicName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return TopicName + " (" + ProductCount.ToString() + ")";
            }
        }
    }
}
