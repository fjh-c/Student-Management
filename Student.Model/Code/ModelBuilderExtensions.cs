using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Model.Code
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInfo>().HasData(
                new StudentInfo { Id = 1, Name = "张三", Sex = 1, NationId = 1, Phone="13902451189", Email = "zhangsan@stu.com", PersonId = "230210199802127323", Address="安三区和道街102号", Photos="stu_1.jpg" }
                );
            modelBuilder.Entity<Nation>().HasData(
                new Nation { Id = 1, Name = "汉族" },
                new Nation { Id = 2, Name = "蒙古族" },
                new Nation { Id = 3, Name = "回族" },
                new Nation { Id = 4, Name = "藏族" },
                new Nation { Id = 5, Name = "维吾尔族" },
                new Nation { Id = 6, Name = "苗族" }
                );
        }
    }
}
