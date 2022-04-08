using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesApi.Domain
{
    /// <summary>
    /// POCO representing a diff entry in our backend store
    /// </summary>
    [Table("DiffEntry")]
    public class DiffEntry
    {
        //We will create entries as specified by the user for now.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? Left { get; set; }

        public string? Right { get; set; }

    }
}
