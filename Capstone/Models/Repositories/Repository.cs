using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Repositories
{
	public class Repository<T> where T : class
	{
		TournamentManagerContext context = new TournamentManagerContext();

		protected DbSet<T> DbSet
		{
			get; set;
		}

		public Repository()
		{
			DbSet = context.Set<T>();
		}

		public List<T> GetAll()
		{
			return DbSet.ToList();
		}

		public T Get(int id)
		{
			return DbSet.Find(id);
		}

		public void Add(T entity)
		{
			DbSet.Add(entity);
		}

		public void Remove(T entity)
		{
			DbSet.Remove(entity);
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}