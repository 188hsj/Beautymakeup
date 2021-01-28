using Beautymakeup.Core.Core;
using Beautymakeup.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TblProducts");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.HasIndex(c => c.ProductName).IsUnique();//指定索引，不能重复
            builder.Property(c => c.ProductName).IsRequired().HasMaxLength(16);
            builder.Property(c => c.ProductImgUrl).IsRequired().HasMaxLength(50);
            builder.Property(c => c.StatusCode).IsRequired().HasDefaultValue(StatusCode.Enable);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);
        }
    }
}
