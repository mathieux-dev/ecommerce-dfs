using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Repositories;
using games_ecommerce.Domain.Services;
using games_ecommerce.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUnityOfWork _unityOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IUnityOfWork unityOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<PurchaseResponse> SaveAsync(Purchase purchase)
        {
            try
            {
                await _purchaseRepository.AddAsync(purchase);
                await _unityOfWork.CompleteAsync();
                return new PurchaseResponse(purchase);
            }
            catch (Exception e)
            {
                return new PurchaseResponse($"An error ocurred {e.Message}");
            }
        }

        public async Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase)
        {
            try
            {
                var _purchase = await _purchaseRepository.FindByIdAsync(id);

                if (_purchase == null) return new PurchaseResponse($"this purchase doesn't exists by id {id}");

                _purchase.Adress = purchase.Adress;
                _purchase.Observation = purchase.Observation;
                _purchase.PostalCode = purchase.PostalCode;
                _purchase.Price = purchase.Price;
                _purchase.Products = purchase.Products;
                _purchase.PurchaseStatus = purchase.PurchaseStatus;
                _purchase.PaymentFormat = purchase.PaymentFormat;

                _purchaseRepository.Update(_purchase);
                await _unityOfWork.CompleteAsync();

                return new PurchaseResponse(_purchase);
            }
            catch (Exception e)
            {
                return new PurchaseResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<PurchaseResponse> DeleteAsync(int id)
        {
            try
            {
                var purchase = await _purchaseRepository.FindByIdAsync(id);
                if (purchase == null) return new PurchaseResponse($"this purchase doesn't exists by id {id}");

                _purchaseRepository.Delete(purchase);
                await _unityOfWork.CompleteAsync();

                return new PurchaseResponse(purchase);
            }
            catch (Exception e)
            {
                return new PurchaseResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<Purchase> FindByIdAsync(int id)
        {
            return await _purchaseRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Purchase>> ListAsync()
        {
            return await _purchaseRepository.ListAsync();
        }
    }
}
