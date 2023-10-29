using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLelo.Model
{
    public class Category
    {
        [key]
        public int Id {  get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Dispaly Order")]
        [Range(1,100,ErrorMessage ="Dispaly Order must between 1 to 100")]
        public int DisplayOrder {  get; set; }
        public DateTime DataCreated { get; set; }   


    }
}
