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
            modelBuilder.Entity<Account>().HasData(InitializationData.Initialization.Account);
            modelBuilder.Entity<Depart>().HasData(InitializationData.Initialization.Depart);
            modelBuilder.Entity<StudentInfo>().HasData(InitializationData.Initialization.StudentInfo);
        }
    }
}
