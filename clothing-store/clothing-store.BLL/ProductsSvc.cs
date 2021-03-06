
using System;
using clothing_store.Common.Rsp;
using clothing_store.Common.BLL;
using clothing_store.Common.Req;
using clothing_store.DAL.Models;
using clothing_store.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace clothing_store.BLL
{
    public class ProductsSvc : GenericSvc<ProductsRep, Products>
    {
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Products m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        #endregion

        #region -- Methods --
        
        
        public SingleRsp CreateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            Products products = new Products();
            products.ProductId = pro.ProductId;
            products.CategoryId = pro.CategoryId;
            products.ProductName = pro.ProductName;
            products.Price = pro.Price;
            products.Stock = pro.Stock;
            products.DateCreate = pro.DateCreate;
            products.Description = pro.Description;
            products.ImageSource = pro.ImageSource;
            products.PromotionId = pro.PromotionId;

            res = _rep.CreateProduct(products);
            return res;
        }

        public SingleRsp UpdateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            Products products = new Products();
            products.ProductId = pro.ProductId;
            products.CategoryId = pro.CategoryId;
            products.ProductName = pro.ProductName;
            products.Price = pro.Price;
            products.Stock = pro.Stock;
            products.DateCreate = pro.DateCreate; 
            products.Description = pro.Description;   
            products.ImageSource = pro.ImageSource;
            products.PromotionId = pro.PromotionId;

            res = _rep.UpdateProduct(products);
            return res;
        }

        public object SearchProduct(String keyword, int page, int size)
        {
            return _rep.SearchProduct(keyword, page, size);
        }
        #endregion

        public object GetAllProductByGender_Linq(bool gender)
        {
            return _rep.GetAllProductByGender_Linq(gender);
        }
        //Product-Sale
        public object GetSP_ProductSale(String keyword, int page, int size)
        {
            return _rep.GetSP_ProductSale(keyword, page, size);
        }

        //Product-Accessories
        public object GetSP_ProductAccessories(String keyword, int page, int size)
        {
            return _rep.GetSP_ProductAccessories(keyword, page, size);
        }

        //Product-get
        public object getProductsId(int id)
        {
            return _rep.getProductsId(id);
        }

        public object GetProductByCategoryName_Linq(String keyword, int page, int size, string categoryName, bool gender)
        {
            return _rep.GetProductByCategoryName_Linq(keyword, page, size, categoryName, gender);
        }

        public object GetProductByPromotion_Linq(bool gender)
        {
            return _rep.GetProductByPromotion_Linq(gender);
        }

        public SingleRsp DeleteProduct(Products pro)
        {
            var res = new SingleRsp();
            res = _rep.DeleteProduct(pro);
            return res;
        }

        public object SearchProductByGender(String keyword, int page, int size, bool gender)
        {
            return _rep.SearchProductByGender(keyword, page, size, gender);
        }

        
    }
}
