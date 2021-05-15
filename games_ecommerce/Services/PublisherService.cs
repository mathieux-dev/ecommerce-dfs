using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Repositories;
using games_ecommerce.Domain.Services;
using games_ecommerce.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IUnityOfWork _unityOfWork;

        public PublisherService(IPublisherRepository publisherRepository, IUnityOfWork unityOfWork)
        {
            _publisherRepository = publisherRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<PublisherResponse> SaveAsync(Publisher publisher)
        {
            try
            {
                await _publisherRepository.AddAsync(publisher);
                await _unityOfWork.CompleteAsync();

                return new PublisherResponse(publisher);
            }
            catch (Exception e)
            {
                return new PublisherResponse($"An error ocurred {e.Message}");
            }
        }

        public async Task<PublisherResponse> UpdateAsync(int id, Publisher publisher)
        {
            try
            {
                var _publisher = await _publisherRepository.FindByIdAsync(id);

                if (publisher == null) return new PublisherResponse($"this publisher doesn't exist by id {id}");

                _publisher.PublicName = publisher.PublicName;
                _publisher.CorporativeName = publisher.CorporativeName;
                _publisher.Cnpj = publisher.Cnpj;
                _publisher.Products = publisher.Products;

                _publisherRepository.Update(_publisher);
                await _unityOfWork.CompleteAsync();
                return new PublisherResponse(_publisher);
            }
            catch (Exception e)
            {
                return new PublisherResponse($"An error ocurred {e.Message}");
            }
        }

        public async Task<PublisherResponse> DeleteAsync(int id)
        {
            try
            {
                var publisher = await _publisherRepository.FindByIdAsync(id);
                if (publisher == null) return new PublisherResponse($"this publisher does't exists by id {id}");

                _publisherRepository.Delete(publisher);
                await _unityOfWork.CompleteAsync();
                return new PublisherResponse(publisher);
            }
            catch (Exception e)
            {
                return new PublisherResponse($"An error ocurred {e.Message}");
            }
        }

        public async Task<Publisher> FindByIdAsync(int id)
        {
            return await _publisherRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await _publisherRepository.ListAsync();
        }
    }
}
