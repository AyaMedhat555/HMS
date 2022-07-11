using Domain.Models;
using Domain.Models.Pharmacy;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepositories;
using Repository.IRepositories.Pharmacy;
using Service.DTO.Pharmacy;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PharmacyService : IPharmacyService
    {
        private IMedicineRepository MedicineRepository { get; }
        private IStockMedicineRepository StockMedicineRepository { get; }
        private IStockRepository StockRepository { get; }
        private IPrescriptionRepository PrescriptionRepository { get; }
        private IIndoorPatientRepository IndoorPatientRepository { get; }
        private IBillRepository BillRepository { get; }


        public PharmacyService(IMedicineRepository medicineRepository, IStockMedicineRepository stockMedicineRepository
            , IStockRepository stockRepository, IPrescriptionRepository prescriptionRepository, IIndoorPatientRepository indoorPatientRepository
            , IBillRepository billRepository)
        {
            MedicineRepository=medicineRepository;
            StockMedicineRepository = stockMedicineRepository;
            StockRepository = stockRepository;
            PrescriptionRepository = prescriptionRepository;
            IndoorPatientRepository = indoorPatientRepository;
            BillRepository = billRepository;
        }

        #region Medicine

        public async Task<MedicineDto> AddMedicine(MedicineDto medicine)
        {
            Medicine newMedicine = new Medicine()
            {
                CommercialName = medicine.CommercialName,
                Group = medicine.Group,
                EffectiveSubstance = medicine.EffectiveSubstance,
                Description = medicine.Description,
                StockMedicines = new List<StockMedicine>()
            };
            if (medicine.StockMedicines != null)
            {
                StockMedicine stockMedicine = new StockMedicine()
                {
                    StockId = medicine.StockMedicines.StockId,
                    MedicineId = medicine.StockMedicines.MedicineId,
                    AddedDtm = medicine.StockMedicines.AddedDtm,
                    Barcode = medicine.StockMedicines.Barcode,
                    ConcentrationInMg = medicine.StockMedicines.Concentration,
                    ExpireDtm =medicine.StockMedicines.ExpireDtm,
                    Price = medicine.StockMedicines.Price,
                    Quantity = medicine.StockMedicines.Quantity
                };
                newMedicine.StockMedicines.Add(stockMedicine);
            };
            Medicine med = await MedicineRepository.Add(newMedicine);
            return new MedicineDto()
            {
                MedicineId = med.MedicineId,
                CommercialName = med.CommercialName,
                Group = med.Group,
                EffectiveSubstance = med.EffectiveSubstance,
                Description = med.Description
            };
        }

        public async Task<MedicineDto> DeleteMedicine(int medicine_id)
        {
            Medicine med = await MedicineRepository.Delete(medicine_id);
            return new MedicineDto()
            {
                MedicineId = med.MedicineId,
                CommercialName = med.CommercialName,
                Group = med.Group,
                EffectiveSubstance = med.EffectiveSubstance,
                Description = med.Description
            };
        }

        public async Task<IEnumerable<MedicineDto>> GetAllMedicines()
        {
            return await MedicineRepository.GetAll().Select(m => new MedicineDto()
            {
                MedicineId = m.MedicineId,
                CommercialName = m.CommercialName,
                Description = m.Description,
                EffectiveSubstance = m.EffectiveSubstance,
                Group = m.Group,
                StockMedicines = m.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            }).ToListAsync();
        }

        public async Task<MedicineDto> GetMedicineByCommercialName(string commercialName)
        {
            Medicine med = await MedicineRepository.GetByCommercialName(commercialName);
            return new MedicineDto()
            {
                MedicineId = med.MedicineId,
                CommercialName = med.CommercialName,
                Description = med.Description,
                EffectiveSubstance = med.EffectiveSubstance,
                Group = med.Group,
                StockMedicines = med.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            };
        }

        public async Task<MedicineDto> GetMedicineById(int medicine_id)
        {
            Medicine med = await MedicineRepository.GetMedicineById(medicine_id);
            return new MedicineDto()
            {
                MedicineId = med.MedicineId,
                CommercialName = med.CommercialName,
                Description = med.Description,
                EffectiveSubstance = med.EffectiveSubstance,
                Group = med.Group,
                StockMedicines = med.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            };
        }

        public async Task<IEnumerable<MedicineDto>> GetMedicineByGroup(string groupName)
        {
            List<Medicine> meds = await MedicineRepository.GetMedicinesByGroup(groupName).ToListAsync();
            
            return meds.Select(m => new MedicineDto()
            {
                MedicineId = m.MedicineId,
                CommercialName = m.CommercialName,
                Description = m.Description,
                EffectiveSubstance = m.EffectiveSubstance,
                Group = m.Group,
                StockMedicines = m.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            });
        }

        public async Task<IEnumerable<MedicineDto>> GetMedicineBySubstance(string substance)
        {
            List<Medicine> meds = await MedicineRepository.GetBySubstance(substance).ToListAsync();

            return meds.Select(m => new MedicineDto()
            {
                MedicineId = m.MedicineId,
                CommercialName = m.CommercialName,
                Description = m.Description,
                EffectiveSubstance = m.EffectiveSubstance,
                Group = m.Group,
                StockMedicines = m.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            });
        }

        public async Task<MedicineDto> UpdateMedicine(MedicineDto medicine_dto)
        {
            Medicine currMed = await MedicineRepository.GetMedicineById(medicine_dto.MedicineId);
            currMed.CommercialName = medicine_dto.CommercialName;
            currMed.Group = medicine_dto.Group;
            currMed.EffectiveSubstance = medicine_dto.EffectiveSubstance;
            currMed.Description = medicine_dto.Description;
            Medicine med = await MedicineRepository.Update(currMed);
            return new MedicineDto()
            {
                MedicineId = med.MedicineId,
                CommercialName = med.CommercialName,
                Group = med.Group,
                EffectiveSubstance = med.EffectiveSubstance,
                Description = med.Description
            };
        }

        #endregion

        #region StockMedicine
        public async Task<StockMedicineDto> AddStockMedicine(StockMedicineDto stockMedicine)
        {
            StockMedicine newStockMedicine = new StockMedicine()
            {
                MedicineId = stockMedicine.MedicineId,
                StockId = stockMedicine.StockId,
                AddedDtm = stockMedicine.AddedDtm,
                Barcode = stockMedicine.Barcode,
                ConcentrationInMg = stockMedicine.Concentration,
                ExpireDtm =stockMedicine.ExpireDtm,
                Quantity = stockMedicine.Quantity,
                Price =stockMedicine.Price
            };
            await StockMedicineRepository.Add(newStockMedicine);
            return stockMedicine;
        }

        public async Task<StockMedicineDto> UpdateStockMedicine(StockMedicineDto stockMedicine)
        {
            StockMedicine currStockMedicine = await StockMedicineRepository.GetById(stockMedicine.Id);

            currStockMedicine.MedicineId = stockMedicine.MedicineId;
            currStockMedicine.StockId = stockMedicine.StockId;
            currStockMedicine.AddedDtm = stockMedicine.AddedDtm;
            currStockMedicine.Barcode = stockMedicine.Barcode;
            currStockMedicine.ConcentrationInMg = stockMedicine.Concentration;
            currStockMedicine.ExpireDtm = stockMedicine.ExpireDtm;
            currStockMedicine.Quantity = stockMedicine.Quantity;
            currStockMedicine.Price = stockMedicine.Price;
            await StockMedicineRepository.Update(currStockMedicine);
            return stockMedicine;
        }

        public async Task<IEnumerable<StockMedicineDto>> GetScarceMedicine(int stockId, int quantity)
        {
            return await StockMedicineRepository.GetScarceMedicine(stockId, quantity).Select(s => new StockMedicineDto
            {
                Id = s.Id,
                MedicineId = s.MedicineId,
                Barcode = s.Barcode,
                MedicineName = s.Medicine.CommercialName,
                AddedDtm = s.AddedDtm,
                ExpireDtm = s.ExpireDtm,
                Concentration = s.ConcentrationInMg,
                Price = s.Price,
                Quantity = s.Quantity,
                StockId = s.StockId
            }).ToListAsync();
        }

        #endregion

        #region Stock
        public async Task<StockDto> AddStock(StockDto stock)
        {
            Stock newStock = new Stock()
            {
                StockLocation = stock.StockLocation
            };
            newStock = await StockRepository.Add(newStock);
            return new StockDto()
            {
                StockId = newStock.StockId,
                StockLocation = newStock.StockLocation
            };
        }

        public async Task<StockDto> DeleteStock(int stockId)
        {
            Stock deletedStock = await StockRepository.Delete(stockId);
            return new StockDto()
            {
                StockId = deletedStock.StockId,
                StockLocation = deletedStock.StockLocation
                //,
                //StockMedicines = deletedStock.StockMedicines.Select(s => new StockMedicineDto()
                //{
                //    Id = s.Id,
                //    MedicineId = s.MedicineId,
                //    Barcode = s.Barcode,
                //    AddedDtm = s.AddedDtm,
                //    ExpireDtm = s.ExpireDtm,
                //    Concentration = s.ConcentrationInMg,
                //    Price = s.Price,
                //    Quantity = s.Quantity,
                //    StockId = s.StockId
                //}).ToList()
            };
        }

        public async Task<IEnumerable<StockDto>> GetAllStocks()
        {
            return await StockRepository.GetAllStocks().Select(s => new StockDto()
            {
                StockId = s.StockId,
                StockLocation = s.StockLocation,
                StockMedicines = s.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    MedicineId = s.MedicineId,
                    Barcode = s.Barcode,
                    MedicineName = s.Medicine.CommercialName,
                    AddedDtm = s.AddedDtm,
                    ExpireDtm = s.ExpireDtm,
                    Concentration = s.ConcentrationInMg,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    StockId = s.StockId
                }).ToList()
            }).ToListAsync();
        }

        public async Task<StockDto> GetStockById(int stockId)
        {
            List<StockDto> stockDtos = await StockRepository.GetAllStocks().Where(S => S.StockId == stockId)
                .Select(S => new StockDto()
                {
                    StockId = S.StockId,
                    StockLocation = S.StockLocation,
                    StockMedicines = S.StockMedicines.Select(s => new StockMedicineDto()
                    {
                        Id = s.Id,
                        MedicineId = s.MedicineId,
                        Barcode = s.Barcode,
                        MedicineName = s.Medicine.CommercialName,
                        AddedDtm = s.AddedDtm,
                        ExpireDtm = s.ExpireDtm,
                        Concentration = s.ConcentrationInMg,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        StockId = s.StockId
                    }).ToList()
                }).ToListAsync();
            StockDto stockDto = stockDtos.FirstOrDefault();
            return stockDto;
        }

        public async Task<StockDto> GetStockByLocation(string stockLocation)
        {
            List<StockDto> stockDtos = await StockRepository.GetAllStocks().Where(S => S.StockLocation == stockLocation)
                .Select(S => new StockDto()
                {
                    StockId = S.StockId,
                    StockLocation = S.StockLocation,
                    StockMedicines = S.StockMedicines.Select(s => new StockMedicineDto()
                    {
                        Id = s.Id,
                        MedicineId = s.MedicineId,
                        Barcode = s.Barcode,
                        MedicineName = s.Medicine.CommercialName,
                        AddedDtm = s.AddedDtm,
                        ExpireDtm = s.ExpireDtm,
                        Concentration = s.ConcentrationInMg,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        StockId = s.StockId
                    }).ToList()
                }).ToListAsync();
            StockDto stockDto = stockDtos.FirstOrDefault();
            return stockDto;
        }

        #endregion

        #region Business

        public async Task<IEnumerable<MedicineDto>> GetAllPatientMedicinesForLastRecord(int patient_id)
        {
            IndoorPatientRecord Record = await IndoorPatientRepository.GetLastRecordBeforeDischarging(patient_id);
            Prescription prescription = await PrescriptionRepository.GetPrescriptionByInDoorPatient(Record.Id);
            HashSet<string> MedicineNames = new HashSet<string>(); 

            foreach (var item in prescription.PrescriptionItems)
            {
                MedicineNames.Add(item.Medicine_Name);
            }


            return await MedicineRepository.GetByNames(MedicineNames).Select(m => new MedicineDto()
            {
                MedicineId = m.MedicineId,
                CommercialName = m.CommercialName,
                Description = m.Description,
                EffectiveSubstance = m.EffectiveSubstance,
                Group = m.Group,
                StockMedicines = m.StockMedicines.Select(s => new StockMedicineDto()
                {
                    Id = s.Id,
                    StockId = s.StockId,
                    MedicineId = s.MedicineId,
                    AddedDtm = s.AddedDtm,
                    Barcode = s.Barcode,
                    Concentration = s.ConcentrationInMg,
                    ExpireDtm =s.ExpireDtm,
                    Price = s.Price,
                    Quantity = s.Quantity
                }).OrderBy(m => m.ExpireDtm).First()
            }).ToListAsync();
        }

        public async Task<IEnumerable<StockMedicineDto>> IndoorPurchase(List<MidicnePurchased> purchaseRequest, int patient_id)
        {
            IndoorPatientRecord Record = await IndoorPatientRepository.GetLastRecordBeforeDischarging(patient_id);
            Bill currBill = Record.Bill;
            double total_price = 0;
            HashSet<int> ids = new HashSet<int>();
            foreach(var med in purchaseRequest)
            {
                total_price += med.Price * med.Quantity;
                ids.Add(med.StockMedicineId);
                StockMedicine  currMed = await StockMedicineRepository.GetById(med.StockMedicineId);
                if(currMed != null)
                {
                    currMed.Quantity = currMed.Quantity - med.Quantity;
                    await StockMedicineRepository.Update(currMed);
                }
            }
            currBill.PrescriptionCharges += total_price;
            await BillRepository.Update(currBill);
            List<StockMedicineDto> meds = await StockMedicineRepository.GetByIds(ids).Select(m => new StockMedicineDto()
            {
                Id = m.Id,
                MedicineId = m.MedicineId,
                AddedDtm = m.AddedDtm,
                ExpireDtm = m.ExpireDtm,
                Barcode = m.Barcode,
                Concentration = m.ConcentrationInMg,
                Price = m.Price,
                Quantity = m.Quantity,
                StockId = m.StockId
            }).ToListAsync();
            foreach(var med in meds)
            {
                if(med.Quantity < 2)
                {
                    med.Warning = "less than 2 units available!";
                }
            }
            return meds;
        }

        public async Task<IEnumerable<StockMedicineDto>> OutdoorPurchase(List<MidicnePurchased> purchaseRequest)
        {
            double total_price = 0;
            HashSet<int> ids = new HashSet<int>();
            foreach (var med in purchaseRequest)
            {
                total_price += med.Price * med.Quantity;
                ids.Add(med.StockMedicineId);
                StockMedicine currMed = await StockMedicineRepository.GetById(med.StockMedicineId);
                if (currMed != null)
                {
                    currMed.Quantity = currMed.Quantity - med.Quantity;
                    await StockMedicineRepository.Update(currMed);
                }
            }
            List<StockMedicineDto> meds = await StockMedicineRepository.GetByIds(ids).Select(m => new StockMedicineDto()
            {
                Id = m.Id,
                MedicineId = m.MedicineId,
                AddedDtm = m.AddedDtm,
                ExpireDtm = m.ExpireDtm,
                Barcode = m.Barcode,
                Concentration = m.ConcentrationInMg,
                Price = m.Price,
                Quantity = m.Quantity,
                StockId = m.StockId
            }).ToListAsync();
            foreach (var med in meds)
            {
                if (med.Quantity < 2)
                {
                    med.Warning = "less than 2 units available!";
                }
            }
            return meds;
        }


        public Task<IEnumerable<MedicineDto>> GetAllPatientMedicinesByPrescreptionId(int prescreptionId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
