using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekt_Beispiel.Models
{
    public enum Category
    {
        Figure, Statue, Plush, Poster, notSpecified
    }
    public class Merch
    {

        public int ArticleId { get; set; }
        public String ArticleName { get; set; }
        public decimal ArticlePrice { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Category Category { get; set; }


        public Merch() : this(0, "", 0.0m, null, Category.notSpecified) { }

        public Merch(int articleid, string articlename,
            decimal articleprice, DateTime? releaseDate, Category category)
        {
            this.ArticleId = articleid;
            this.ArticleName = articlename;
            this.ArticlePrice = articleprice;
            this.ReleaseDate = releaseDate;
            this.Category = category;
        }

        public override string ToString()
        {
            return this.ArticleId + " " + this.ArticleName + " " + this.ArticlePrice + " Euro";
        }
    }
}
