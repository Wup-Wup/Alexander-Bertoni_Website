using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekt_Beispiel.Models.database
{
    interface IRepositoryArticle
    {

        void Open();
        void Close();

        Merch GetArticleById(int articleId);
        List<Merch> GetAllArticles();
        bool Insert(Merch article);
        bool Delete(int articleId);
        bool Update(int articleId, Merch newArticleData);
    }

}
