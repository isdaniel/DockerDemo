using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<ProductModel> _productModels;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            using (var conn = new SqlConnection(Environment.GetEnvironmentVariable("DBConnection")))
            {
                conn.Open();
                _productModels = conn.Query<ProductModel>("SELECT TOP 10 EnglishProductName,ProductKey FROM dbo.DimProduct").ToList();
            }
        }
    }
}
