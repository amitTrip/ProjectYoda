using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeProject.WebFrontEnd.Models
{
    /// <summary>
    /// Prodct View Model
    /// </summary>
    public class ProductViewModel : TransactionalInformation
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
       
        public List<Product> Products { get; set; }

    }

}

