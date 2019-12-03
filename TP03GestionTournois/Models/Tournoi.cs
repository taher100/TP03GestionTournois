using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP03GestionTournois.Models
{
  public class Tournoi
  {
    [Key]
    public int IdTournoi { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [Required]
    public string Nom { get; set; }

    [Required]
    public int Prix { get; set; }

    [Column(TypeName = "nvarchar(250)")]
    [Required]
    public string Description { get; set; }

    [Required]
    public string Date { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [Required]
    public string Jeu { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [Required]
    public string Theme { get; set; }

  }
}
