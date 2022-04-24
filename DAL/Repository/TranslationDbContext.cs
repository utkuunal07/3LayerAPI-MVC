using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using TransaltorApi.Repository.Entities;

#nullable disable

namespace TransaltorApi.Api.Repository
{
    public partial class TranslationDbContext : DbContext
    {
        public TranslationDbContext()
        {
        }

        public TranslationDbContext(DbContextOptions<TranslationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TTranslationsLog> TTranslationsLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=UTKU-BILGISAYAR\\MSSQLSERVER01;Initial Catalog=TranslationDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<TTranslationsLog>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Text).IsUnicode(false);

                entity.Property(e => e.Translated).IsUnicode(false);

                entity.Property(e => e.Translation).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public DataTable CallProcedure(Dictionary<string, dynamic> dic,string procedureName,string conString)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand(procedureName, conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure

                foreach (var i in dic)
                {
                    cmd.Parameters.Add(new SqlParameter(i.Key, i.Value));
                }
                //cmd.Parameters.Add(new SqlParameter("@Username", "utkuunal"));
                //cmd.Parameters.Add(new SqlParameter("@Password", "bestpwintheworld"));

                // execute the command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // this will query your database and return the result to your datatable
                    da.Fill(dataTable);
                    return dataTable;
                }

               
               
            }
        }

         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}