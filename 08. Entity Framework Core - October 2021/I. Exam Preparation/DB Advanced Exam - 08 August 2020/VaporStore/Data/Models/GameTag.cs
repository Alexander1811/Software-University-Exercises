namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameTag
    {
        [ForeignKey(nameof(Models.Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Models.Tag))]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
