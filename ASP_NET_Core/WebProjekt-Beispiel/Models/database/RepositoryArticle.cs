using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models.database.sricpts
{
    public class RepositoryArticle : IRepositoryArticle
    {

        private string _connectionString = "server=localhost;database=db_shop;user=root;pwd=pokemon03";
        private MySqlConnection _conn = null;


        public void Open()
        {
            if (this._conn == null)
            {
                this._conn = new MySqlConnection(this._connectionString);
            }
            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }

        public void Close()
        {
            if ((this._conn != null) && (this._conn.State == ConnectionState.Open))
            {
                this._conn.Close();
            }
        }

        public bool Delete(int articleId)
        {
            if (this._conn.State == ConnectionState.Open)
            {
                DbCommand cmdDelete = this._conn.CreateCommand();
                cmdDelete.CommandText = "delete from articles where articleid = " + articleId;

                return cmdDelete.ExecuteNonQuery() == 1;
            }
            throw new Exception("Verbindung zur DB ist nicht geöffnet!");
        }

        public List<Merch> GetAllArticles()
        {

            if (this._conn.State == ConnectionState.Open)
            {
                List<Merch> articles = new List<Merch>();

                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select * from articles";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Merch
                        {
                        
                            ArticleId = Convert.ToInt32(reader["articleid"]),
                            ArticleName = Convert.ToString(reader["name"]),
                            ArticlePrice = Convert.ToDecimal(reader["price"]),
                            ReleaseDate = reader["releasedate"] == DBNull.Value ? Convert.ToDateTime(null) : Convert.ToDateTime(reader["releasedate"]),
                            Category = (Category)Convert.ToInt32(reader["category"]),
                            Image = Convert.ToString(reader["image"]),

                        });
                    }

                }  

                if (articles.Count == 0)
                {
                    return null;
                }

                return articles;
            }
            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }


        public Merch GetArticleById(int articleId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Merch article)
        {
            if (article == null)
            {
                return false;
            }
            if (this._conn.State != ConnectionState.Open)
            {
                return false;
            }
            DbCommand cmdInsert = this._conn.CreateCommand();

            cmdInsert.CommandText = "insert into articles values(null, @articlename, @price, @releasedate, @category, @image);";

            DbParameter paramArticlename = cmdInsert.CreateParameter();
            paramArticlename.ParameterName = "articlename";
            paramArticlename.DbType = DbType.String;
            paramArticlename.Value = article.ArticleName;

            DbParameter paramPrice = cmdInsert.CreateParameter();
            paramPrice.ParameterName = "price";
            paramPrice.DbType = DbType.Decimal;
            paramPrice.Value = article.ArticlePrice;

            DbParameter paramReleasedate = cmdInsert.CreateParameter();
            paramReleasedate.ParameterName = "releasedate";
            paramReleasedate.DbType = DbType.DateTime;
            paramReleasedate.Value = article.ReleaseDate;

            DbParameter paramCategory = cmdInsert.CreateParameter();
            paramCategory.ParameterName = "category";
            paramCategory.DbType = DbType.Int32;
            paramCategory.Value = article.Category;

            DbParameter paramImage = cmdInsert.CreateParameter();
            paramImage.ParameterName = "image";
            paramImage.DbType = DbType.String;
            paramImage.Value = article.Image;

            cmdInsert.Parameters.Add(paramArticlename);
            cmdInsert.Parameters.Add(paramPrice);
            cmdInsert.Parameters.Add(paramReleasedate);
            cmdInsert.Parameters.Add(paramCategory);
            cmdInsert.Parameters.Add(paramImage);

            return cmdInsert.ExecuteNonQuery() == 1;
        }

        public bool Update(int articleId, Merch newArticleData)
        {
            throw new NotImplementedException();
        }
    }
}
