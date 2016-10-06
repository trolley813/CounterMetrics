﻿using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Create(UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Create", this.GetType().FullName));
                this.databaseContext.UserEntity.Add(userEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Created user {0} with ID {1} and password hash {2}", userEntity.Name,
                userEntity.ID, userEntity.PasswordHash));
        }
        public void Delete(UserEntity userEntity)
        {
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Delete", this.GetType().FullName));
                this.databaseContext.UserEntity.Remove(userEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Deleted user {0} with ID {1}", userEntity.Name,
                userEntity.ID));
        }
    }
}
