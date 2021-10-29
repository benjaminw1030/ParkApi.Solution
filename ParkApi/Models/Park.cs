using System.ComponentModel.DataAnnotations;
using System;

namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required (ErrorMessage = "A name is required.")]
    public string Name { get; set; }
    [Required (ErrorMessage = "A category is required.")]
    public string Category { get; set; }
    [Required (ErrorMessage = "A state is required.")]
    public string State { get; set; }
    [Range (0, 180,
      ErrorMessage = "Value for Longitude must be between -180 and 180")]
    public double Longitude { get; set; }
    [Range(0, 90,
      ErrorMessage = "Value for Latitude must be between -90 and 90")]
    public double Latitude { get; set; }
    public double Area { get; set; }
    public int Visitors { get; set; }
    public DateTime EstDate { get; set; }
  }
}