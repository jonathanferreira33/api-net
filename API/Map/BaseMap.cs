﻿using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        private readonly string _tableName;
        public BaseMap(string tableName)
        {
            _tableName = tableName;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if(!string.IsNullOrEmpty(_tableName))
                builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
