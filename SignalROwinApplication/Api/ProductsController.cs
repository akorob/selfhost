namespace SignalROwinApplication.Api
{
    using System.Collections.Generic;
    using System.Web.Http;
    using SignalROwinApplication.DomainModel;

    public class ProductsController : ApiController
    {


        public IHttpActionResult Get()
        {
            var list = new List<Product>();
            list.Add(new Product() { Id = 1, Name = "apple", Description = "green" });
            list.Add(new Product() { Id = 2, Name = "orange", Description = "red" });
            list.Add(new Product() { Id = 3, Name = "pineapple", Description = "brown" });
            return Ok(list);
        }
    }
}
