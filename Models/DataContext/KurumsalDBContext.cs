﻿using KurumsalWeb1.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KurumsalWeb1.Models.DataContext
{
    public class KurumsalDBContext: DbContext
    {
        public KurumsalDBContext(): base("KurumsalDB")
        {

        }


        public DbSet<Admin> Admin { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Hakkimizda> Hakkimizda { get; set; }

        public DbSet<Hizmet> Hizmet { get; set; }

        public DbSet<Iletisim> Iletisim { get; set; }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<Kimlik> Kimlik { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<Comment> Comment { get; set; }



    }
}