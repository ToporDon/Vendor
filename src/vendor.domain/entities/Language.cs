using System;
using vendor.domain.data.abstracts;

namespace vendor.domain.entities
{
    public partial class LanguageDict : IEntity
    {
        public long Id { get; set; }
        public string Alias { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateUserId { get; set; }

        public virtual User UpdateUser { get; set; }
    }
}
