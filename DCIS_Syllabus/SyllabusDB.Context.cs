﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCIS_Syllabus
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Syllabus_ManagementEntities2 : DbContext
    {
        public Syllabus_ManagementEntities2()
            : base("name=Syllabus_ManagementEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Active_Values> Active_Values { get; set; }
        public virtual DbSet<Assessment_Criteria> Assessment_Criteria { get; set; }
        public virtual DbSet<Bibliography> Bibliographies { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Class_Policy> Class_Policy { get; set; }
        public virtual DbSet<Core_Value> Core_Value { get; set; }
        public virtual DbSet<Course_Deliverable> Course_Deliverable { get; set; }
        public virtual DbSet<Course_Information> Course_Information { get; set; }
        public virtual DbSet<Course_Outcome_Addressed> Course_Outcome_Addressed { get; set; }
        public virtual DbSet<Course_Outcomes> Course_Outcomes { get; set; }
        public virtual DbSet<Grading_Rubrics> Grading_Rubrics { get; set; }
        public virtual DbSet<Grading_System> Grading_System { get; set; }
        public virtual DbSet<Learning_Plan> Learning_Plan { get; set; }
        public virtual DbSet<Online_Sources> Online_Sources { get; set; }
        public virtual DbSet<Program_Educational_Objs> Program_Educational_Objs { get; set; }
        public virtual DbSet<Program_Outcomes> Program_Outcomes { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<Revision> Revisions { get; set; }
        public virtual DbSet<Revisions_Log> Revisions_Log { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Software_Used> Software_Used { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Syllabu> Syllabus { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
