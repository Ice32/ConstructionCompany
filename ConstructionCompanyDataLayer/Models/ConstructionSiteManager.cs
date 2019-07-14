using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class ConstructionSiteManager: IUserType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Worksheet> Worksheets { get; set; }
        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}
