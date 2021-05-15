using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Repositories;
using games_ecommerce.Domain.Services;
using games_ecommerce.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnityOfWork _unityOfWork;

        public UserService(IUserRepository userRepository, IUnityOfWork unityOfWork)
        {
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            try
            {
                var _user = await _userRepository.FindByIdAsync(id);

                if (_user == null) return new UserResponse($"this user not found by id {id}");

                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.Cpf = user.Cpf;
                _user.Password = user.Password;
                _user.Purchases = user.Purchases;

                _userRepository.Update(_user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(_user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred {e.Message}");
            }

        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            try
            {
                var user = await _userRepository.FindByIdAsync(id);
                if (user == null) return new UserResponse($"this user doesn't exists by id {id}");

                _userRepository.Delete(user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occured {e.Message}");
            }
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
    }
}
