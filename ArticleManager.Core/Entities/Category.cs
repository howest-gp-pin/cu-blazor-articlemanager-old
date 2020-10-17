using ArticleManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleManager.Core.Entities
{
    public class Category: EntityBase<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
