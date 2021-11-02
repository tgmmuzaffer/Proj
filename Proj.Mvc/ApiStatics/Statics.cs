namespace Proj.Mvc.ApiStatics
{
    public static class Statics
    {
        public static string BaseUrl= "https://localhost:44361/";
        public static string CreateCategory=BaseUrl + "api/category/createcategory";
        public static string GetCategories=BaseUrl+ "api/category/getcategories";
        public static string GetCategory = BaseUrl + "api/category/getcategory/";
        public static string UpdateCategory = BaseUrl+ "api/category/updatecategory";
        public static string DeleteCategory = BaseUrl+ "api/category/deletecategory";
        public static string GetProducts = BaseUrl+ "api/Product/getproducts";
        public static string GetProductsWithRange = BaseUrl+ "api/product/getproductswithrange/";
        public static string GetProduct = BaseUrl+ "api/product/getproduct/";
        public static string CreateProduct = BaseUrl+ "api/product/createproduct";
        public static string UpdateProduct = BaseUrl+ "api/product/updateproduct";
        public static string DeleteProduct = BaseUrl+ "api/product/deleteproduct";
    }
}
