using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataProcess
{
    public static class DataProcess
    {
        public static int CreateProduct(int ProductId, string ProductName, double ProductPrice, string ProductDetails)
        {
            ProductTb data = new ProductTb
            {
                productId = ProductId,
                productName = ProductName,
                productPrice = ProductPrice,
                productDetails = ProductDetails
            };

            string sql = @"insert into tbProduct(productid,productName,productPrice,productDetails)
                           Values (@productId,@productName,@productPrice,@productDetails)";

            return DataAccess.DataAccess.SaveData(sql, data);
        }

        public static List<ProductTb> LoadData()
        {
            string sql = @"select id, productid,productName,productPrice,productDetails
                           from tbProduct";

            return DataAccess.DataAccess.LoadData<ProductTb>(sql);
        }

        public static int UpdateProduct(int Id, int ProductId, string ProductName, double ProductPrice, string ProductDetails)
        {

            ProductTb data = new ProductTb
            {
                id = Id,
                productId = ProductId,
                productName = ProductName,
                productPrice = ProductPrice,
                productDetails = ProductDetails
            };
            //TODO create alert of error in the screem when user pass Id invalid!

            if (Id > 0)
            {
                string sql = @"update tbProduct 
                               set productid = @productId,productName = @productName,productPrice = @productPrice,productDetails = @productDetails
                               where id = @Id";
                return DataAccess.DataAccess.SaveData(sql, data);
            }
            else
                throw new ArgumentException("ID IS NOT VALID!");

        }

        public static List<ProductTb> GetInformation(int Id)
        {
            //int id = Id;
            string sql = @"select id, productid,productName,productPrice,productDetails
                           from tbProduct
                            where id = "+Id;

            return DataAccess.DataAccess.LoadData<ProductTb>(sql);
        }

        public static void DeleteProduct(int Id, int ProductId, string ProductName, double ProductPrice, string ProductDetails)
        {
            ProductTb data = new ProductTb
            {
                id = Id,
                productId = ProductId,
                productName = ProductName,
                productPrice = ProductPrice,
                productDetails = ProductDetails
            };

            //TODO create alert of error in the screem when user pass Id invalid!

            if (Id > 0)
            {
                string sql = @"DELETE FROM  tbProduct                             
                               where id = @Id";
                DataAccess.DataAccess.SaveData(sql, data);
            }
            else
                throw new ArgumentException("ID IS NOT VALID!");

        }
    }
}
