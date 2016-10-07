﻿using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IUserRepository _userRepository;

        public AccountManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(User user)
        {
            //throw new NotImplementedException();
            var newUserId = _userRepository.GetFreeId();
            var passwordHash = ServiceLocator.Hasher.Hash(user.Password);
            _userRepository.Create(new UserEntity {Id = newUserId, Name = user.Name, PasswordHash = passwordHash});
        }
    }
}