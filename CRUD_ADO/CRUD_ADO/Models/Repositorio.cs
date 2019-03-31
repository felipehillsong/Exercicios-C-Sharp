using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CRUD_ADO.Models {
    public abstract class Repositorio<TEntity, TKey>
    where TEntity : class {
        protected string StringConnection { get; } = @"Data Source=FELIPE-HP\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=ExemploBD; Initial Catalog=ExemploBD";

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract TEntity DeleteById(TKey id);
    }
}