namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants = SharedTrip.Common.ValidationConstants;

    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.TripStartPointMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(Constants.TripEndPointMaxLength)]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [Range(Constants.TripSeatsMinCount, Constants.TripSeatsMaxCount)]
        public int Seats { get; set; }

        [Required]
        [StringLength(Constants.TripDescriptionMaxLength)]
        public string Description { get; set; }

        [StringLength(Constants.TripImagePathMaxLength)]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
