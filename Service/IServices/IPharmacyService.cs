using Domain.Models.Pharmacy;
using Repository;
using Service.DTO.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPharmacyService
    {
        Task<MedicineDto> AddMedicine(MedicineDto medicine);
        Task<MedicineDto> DeleteMedicine(int medicine_id);
        Task<MedicineDto> UpdateMedicine(MedicineDto medicine_dto);
        Task<IEnumerable<MedicineDto>> GetAllMedicines();
        Task<MedicineDto> GetMedicineById(int medicine_id);
        Task<MedicineDto> GetMedicineByCommercialName(String commercialName);
        Task<IEnumerable<MedicineDto>> GetMedicineByGroup(String groupName);
        Task<IEnumerable<MedicineDto>> GetMedicineBySubstance(String substance);


        Task<StockMedicineDto> AddStockMedicine(StockMedicineDto stockMedicine);
        Task<StockMedicineDto> UpdateStockMedicine(StockMedicineDto stockMedicine);
        Task<IEnumerable<StockMedicineDto>> GetScarceMedicine(int stockId, int quantity);


        Task<StockDto> AddStock(StockDto stockDto);
        Task<StockDto> DeleteStock(int stockId);
        Task<IEnumerable<StockDto>> GetAllStocks();
        Task<StockDto> GetStockById(int stockId);
        Task<StockDto> GetStockByLocation(string stockLocation);




        Task<IEnumerable<MedicineDto>> GetAllPatientMedicinesForLastRecord(int patient_id);
        Task<IEnumerable<MedicineDto>> GetAllPatientMedicinesByPrescreptionId(int prescreptionId);
        Task<IEnumerable<StockMedicineDto>> IndoorPurchase(List<MidicnePurchased> purchaseRequest, int patient_id);
        Task<IEnumerable<StockMedicineDto>> OutdoorPurchase(List<MidicnePurchased> purchaseRequest);

    }
}
