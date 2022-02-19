namespace SharedTrip.Models.Trips
{
    using System.ComponentModel.DataAnnotations;
    using Constants = SharedTrip.Common.ValidationConstants;
    using Errors = SharedTrip.Common.ErrorMessages;

    public class TripAddViewModel
    {
        [Required]
        [StringLength(Constants.TripStartPointMaxLength, ErrorMessage = Errors.TripInvalidStartPoint)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(Constants.TripEndPointMaxLength, ErrorMessage = Errors.TripInvalidEndPoint)]
        public string EndPoint { get; set; }

        [Required(ErrorMessage = Errors.TripMissingDepartureTime)]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = Errors.TripMissingSeats)]
        public string Seats { get; set; }

        [Required(ErrorMessage = Errors.TripInvalidStartPoint)]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
