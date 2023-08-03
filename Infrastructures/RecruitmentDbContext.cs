using Microsoft.EntityFrameworkCore;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Infrastructure;

public partial class RecruitmentDbContext : DbContext
{
    public RecruitmentDbContext()
    {
    }

    public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; } = null!;
    public virtual DbSet<Admin> Admins { get; set; } = null!;
    public virtual DbSet<Candidate> Candidates { get; set; } = null!;
    public virtual DbSet<Company> Companies { get; set; } = null!;
    public virtual DbSet<Cv> Cvs { get; set; } = null!;
    public virtual DbSet<Event> Events { get; set; } = null!;
    public virtual DbSet<Hr> Hrs { get; set; } = null!;
    public virtual DbSet<Interviewer> Interviewers { get; set; } = null!;
    public virtual DbSet<Job> Jobs { get; set; } = null!;
    public virtual DbSet<Meeting> Meetings { get; set; } = null!;
    public virtual DbSet<Operation> Operations { get; set; } = null!;
    public virtual DbSet<Position> Positions { get; set; } = null!;
    public virtual DbSet<Post> Posts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn =
            "Data Source=mssql-135694-0.cloudclusters.net,19123;Initial Catalog=Recruitment;User ID=admin;pwd=22^NkB@f<}-V8#m-;TrustServerCertificate=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(conn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164F3C8BD9A")
                .IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Account__F3DBC57293F3B493")
                .IsUnique();

            entity.Property(e => e.Accountid)
                .ValueGeneratedOnAdd()
                .HasColumnName("accountid");

            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");

            entity.Property(e => e.Image)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnName("image");

            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");

            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");

            entity.Property(e => e.Bio)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("bio");

            entity.Property(e => e.Language)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("language");

            entity.Property(e => e.Nationality)
                .IsRequired(false)
                .HasMaxLength(300)
                .HasColumnName("nationality");
            entity.Property(e => e.Address)
                .IsRequired(false)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("firstName");


            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("lastName");

            entity.Property(e => e.HashPassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("hashPassword");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");

            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("username");

        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId)
                .ValueGeneratedOnAdd()
                .HasColumnName("adminId");

            entity.Property(e => e.Accountid).HasColumnName("accountid");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Admins)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admin__accountid__3E52440B");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.ToTable("Candidate");

            entity.Property(e => e.CandidateId)
                .ValueGeneratedOnAdd()
                .HasColumnName("candidateId");

            entity.Property(e => e.Accountid).HasColumnName("accountid");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Candidates)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidate__accou__412EB0B6");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("companyId");

            entity.Property(e => e.Accountid).HasColumnName("accountid");


            entity.Property(e => e.ContactNumber).HasColumnName("contactNumber");

            entity.Property(e => e.NameCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameCompany");

            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .HasColumnName("description");

            entity.Property(e => e.Size)
                .IsRequired(false)
                .HasColumnName("size");

            entity.Property(e => e.FoundingYear)
                .IsRequired(false)
                .HasColumnType("date")
                .HasColumnName("foundingYear");

            entity.Property(e => e.Logo).IsRequired(false)
                .HasMaxLength(500)
                .HasColumnName("logo");


            entity.Property(e => e.Benefits)
                .IsRequired(false)
                .HasMaxLength(5000)
                .HasColumnName("benefits");

            entity.Property(e => e.Industry)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnName("industry");

            entity.Property(e => e.Website).IsRequired(false)
                .HasMaxLength(500)
                .HasColumnName("website");


            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Companies)
                .HasForeignKey(d => d.Accountid)
                .HasConstraintName("FK__Company__account__3B75D760");
        });

        modelBuilder.Entity<Cv>(entity =>
        {
            entity.ToTable("CV");

            entity.Property(e => e.CvId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cvID");

            entity.Property(e => e.CandidateId).HasColumnName("candidateId");

            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .HasColumnName("description");

            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("creationDate");


            entity.Property(e => e.UrlFile)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("urlFile");


            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.Cvs)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK__CV__candidateId__52593CB8");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.Property(e => e.EventId)
                .ValueGeneratedOnAdd()
                .HasColumnName("eventId");

            entity.Property(e => e.CandidateId).HasColumnName("candidateId");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.Property(e => e.EndEvent)
                .HasColumnType("date")
                .HasColumnName("endEvent");

            entity.Property(e => e.Img)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("img");

            entity.Property(e => e.StartEvent)
                .HasColumnType("date")
                .HasColumnName("startEvent");

            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.Events)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__candidate__4F7CD00D");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Events)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__companyId__4E88ABD4");
        });

        modelBuilder.Entity<Hr>(entity =>
        {
            entity.ToTable("HR");

            entity.Property(e => e.HrId)
                .ValueGeneratedOnAdd()
                .HasColumnName("hrId");

            entity.Property(e => e.Accountid).HasColumnName("accountid");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");


            entity.Property(e => e.NameHr)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nameHr");

            entity.Property(e => e.PositionId).HasColumnName("positionId");


            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Hrs)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HR__accountid__5629CD9C");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Hrs)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HR__companyId__571DF1D5");

            entity.HasOne(d => d.Position)
                .WithMany(p => p.Hrs)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__HR__positionId__5535A963");
        });

        modelBuilder.Entity<Interviewer>(entity =>
        {
            entity.ToTable("Interviewer");

            entity.Property(e => e.InterviewerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("interviewerId");

            entity.Property(e => e.Accountid).HasColumnName("accountid");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");

            entity.Property(e => e.NameInterviewer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameInterviewer");

            entity.Property(e => e.PositionId).HasColumnName("positionId");

            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Interviewers)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__accou__47DBAE45");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Interviewers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__compa__48CFD27E");

            entity.HasOne(d => d.Position)
                .WithMany(p => p.Interviewers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Interview__posit__46E78A0C");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.JobId)
                .ValueGeneratedOnAdd()
                .HasColumnName("jobId");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");

            entity.Property(e => e.NameSkill)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nameSkill");

            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Job__companyId__4BAC3F29");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.MeetId)
                .HasName("PK__Meeting__0ED7DF1BCFB2BFA1");

            entity.ToTable("Meeting");

            entity.Property(e => e.MeetId)
                .ValueGeneratedOnAdd()
                .HasColumnName("meetID");

            entity.Property(e => e.EndTime)
                .HasColumnType("date")
                .HasColumnName("endTime");

            entity.Property(e => e.HrId).HasColumnName("hrId");

            entity.Property(e => e.InterviewerId).HasColumnName("interviewerId");

            entity.Property(e => e.LinkMeet)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("linkMeet");

            entity.Property(e => e.OperationId).HasColumnName("operationId");

            entity.Property(e => e.StartTime)
                .HasColumnType("date")
                .HasColumnName("startTime");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Hr)
                .WithMany(p => p.Meetings)
                .HasForeignKey(d => d.HrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meeting__hrId__693CA210");

            entity.HasOne(d => d.Interviewer)
                .WithMany(p => p.Meetings)
                .HasForeignKey(d => d.InterviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meeting__intervi__68487DD7");

            entity.HasOne(d => d.Operation)
                .WithMany(p => p.Meetings)
                .HasForeignKey(d => d.OperationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meeting__operati__6754599E");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.ToTable("Operation");

            entity.Property(e => e.OperationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("operationId");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");

            entity.Property(e => e.CvId).HasColumnName("cvID");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");

            entity.Property(e => e.HrId).HasColumnName("hrId");

            entity.Property(e => e.PostId).HasColumnName("postId");

            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__compa__6383C8BA");

            entity.HasOne(d => d.Cv)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.CvId)
                .HasConstraintName("FK__Operation__cvID__619B8048");

            entity.HasOne(d => d.Hr)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.HrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__hrId__6477ECF3");

            entity.HasOne(d => d.Post)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__postI__628FA481");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("positionId");

            entity.Property(e => e.NamePosition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("namePosition");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .ValueGeneratedOnAdd()
                .HasColumnName("postId");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            /// <summary>

            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");

            /// </summary>

            entity.Property(e => e.PeriodDate)
                .HasColumnType("date")
                .HasColumnName("periodDate");

            entity.Property(e => e.ExpiredDate)
                .HasColumnType("date")
                .HasColumnName("expiredDate");

            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .HasColumnName("location");

            entity.Property(e => e.Salary)
                .HasColumnName("salary");

            entity.Property(e => e.EmploymentType)
                .HasMaxLength(500)
                .HasColumnName("employmentType");

            entity.Property(e => e.Requirements)
                .HasMaxLength(5000)
                .HasColumnName("requirements");

            entity.Property(e => e.HrId).HasColumnName("hrId");

            entity.Property(e => e.JobId).HasColumnName("jobId");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__companyId__59FA5E80");

            entity.HasOne(d => d.Hr)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.HrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__hrId__5BE2A6F2");

            entity.HasOne(d => d.Job)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__jobId__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}