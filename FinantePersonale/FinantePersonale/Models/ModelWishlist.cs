
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinantePersonale.Models
{
    //[Table("WishlistItems")]
    public class ModelWishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25), NotNull]
        public string ItemName { get; set; }
        public float ItemValue { get; set; }        
        public ModelWishlist()
        {

        }
    }
}
