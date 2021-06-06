using Display_Data_from_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Display_Data_from_db.Controllers
{
 
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
         private SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        
        List<Address> addresses = new List<Address>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = Display_Data_from_db.Properties.Resources.ConnectionSring;
        }

        public IActionResult Index()
        {
            FetchData();

            return View(addresses);
        }

        private void FetchData() 
        {
            if(addresses.Count > 0)
            {
                addresses.Clear();

            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [AddressID],[AddressLine1],[AddressLine2],[City],[StateProvinceID],[PostalCode],[SpatialLocation],[rowguid],[ModifiedDate] FROM[AdventureWorks2019].[Person].[Address]";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    addresses.Add(new Address() { AddressID = dr["AddressID"].ToString() 
                    ,AddresLine = dr["AddressLine1"].ToString()
                    ,City = dr["City"].ToString()
                    ,StateProviceID = dr["StateProvinceID"].ToString()
                    ,PostalCode = dr["PostalCode"].ToString()
                    ,SpatialLocation = dr["SpatialLocation"].ToString()
                    ,RowID = dr["rowguid"].ToString()
                    ,ModifiedDate = dr["ModifiedDate"].ToString()

                    });

                }

                con.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
