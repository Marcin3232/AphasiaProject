using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Enums.Db
{
    public enum DbConnectionsString
    {
        [Display(Name = "DbDefault")]
        DbDefault = 0,
        [Display(Name = "DbAphasia")]
        DbAphasia = 1
    }
}