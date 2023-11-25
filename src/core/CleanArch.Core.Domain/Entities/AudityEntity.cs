namespace CleanArch.Core.Domain.Entities
{
    public abstract class AudityEntity : BaseEntity
    {
        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
