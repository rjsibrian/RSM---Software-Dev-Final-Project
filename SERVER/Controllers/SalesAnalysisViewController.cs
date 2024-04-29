using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppApi.Models;

namespace CONTROLLER_BASED_API_with_ASP.NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesAnalysisViewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesAnalysisViewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesAnalysisView
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleAnalysisView>>> GetSalesAnalysisView([FromQuery] string productName = "", [FromQuery] string categoryName = "")
        {
            // Verificar si se proporciona el nombre del producto y/o el nombre de la categoría
            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(categoryName))
            {
                // Filtrar por ambos parámetros si ambos están presentes
                return await _context.SalesAnalysisView
                    .Where(s => s.ProductName == productName && s.ProductCategory == categoryName)
                    .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(productName))
            {
                // Filtrar por nombre de producto si solo se proporciona ese parámetro
                return await _context.SalesAnalysisView
                    .Where(s => s.ProductName == productName)
                    .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(categoryName))
            {
                // Filtrar por nombre de categoría si solo se proporciona ese parámetro
                return await _context.SalesAnalysisView
                    .Where(s => s.ProductCategory == categoryName)
                    .ToListAsync();
            }
            else
            {
                // Si no se proporcionan parámetros, devolver todas las filas
                return await _context.SalesAnalysisView.ToListAsync();
            }
        }

    }
}
