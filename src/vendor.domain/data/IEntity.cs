using System.Collections.Generic;

namespace vendor.domain.data.abstracts
{
    public interface IEntity
    {
        long Id { get; set; }
    }

    public interface IEntity<TLanguage> : IEntity where TLanguage : ILanguage
    {
        IEntity Entity { get; set; }
        ICollection<TLanguage> Languages { get; set; }
    }
}
