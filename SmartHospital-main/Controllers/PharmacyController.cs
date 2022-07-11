using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Pharmacy;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private IPharmacyService _medicineService { get; }

        public PharmacyController(IPharmacyService medicineService)
        {
            _medicineService=medicineService;
        }

        #region Medicine

        [HttpPost("add")]
        public async Task<IActionResult> Add(MedicineDto medicine)
        {
            return Ok(await _medicineService.AddMedicine(medicine));
        }

        [HttpDelete("delete/{medicine_id}")]
        public async Task<IActionResult> Delete([FromRoute] int medicine_id)
        {
            Console.WriteLine(medicine_id.ToString());
            return Ok(await _medicineService.DeleteMedicine(medicine_id));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(MedicineDto medicine)
        {
            Console.WriteLine(medicine.ToString());
            return Ok(await _medicineService.UpdateMedicine(medicine));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicineService.GetAllMedicines());
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _medicineService.GetMedicineById(id));
        }

        [HttpGet("getByCommercialName")]
        public async Task<IActionResult> GetByCommercialName(string Medicinename)
        {
            return Ok(await _medicineService.GetMedicineByCommercialName(Medicinename));
        }

        [HttpGet("getByGroup")]
        public async Task<IActionResult> GetByGroup(string groupName)
        {
            return Ok(await _medicineService.GetMedicineByGroup(groupName));
        }

        [HttpGet("getBysubstance")]
        public async Task<IActionResult> GetBysubstance(string substance)
        {
            return Ok(await _medicineService.GetMedicineBySubstance(substance));
        }
        #endregion

        #region StockMedicine
        [HttpPost("addStockMedicine")]
        public async Task<IActionResult> AddStockMedicine(StockMedicineDto medicine)
        {
            Console.WriteLine(medicine.ToString());
            return Ok(await _medicineService.AddStockMedicine(medicine));
        }

        [HttpPut("updateStockMedicine")]
        public async Task<IActionResult> UpdateStockMedicine(StockMedicineDto medicine)
        {
            Console.WriteLine(medicine.ToString());
            return Ok(await _medicineService.UpdateStockMedicine(medicine));
        }

        [HttpGet("getScarceMedicine")]
        public async Task<IActionResult> GetScarceMedicine(int stockId, int quantity)
        {
            return Ok(await _medicineService.GetScarceMedicine(stockId, quantity));
        }
        #endregion

        #region Stock
        [HttpPost("addStock")]
        public async Task<IActionResult> AddStock(StockDto stock)
        {
            return Ok(await _medicineService.AddStock(stock));
        }

        [HttpDelete("deleteStock")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            return Ok(await _medicineService.DeleteStock(id));
        }

        [HttpGet("getAllStocks")]
        public async Task<IActionResult> GetAllStock()
        {
            return Ok(await _medicineService.GetAllStocks());
        }

        [HttpGet("getStockById")]
        public async Task<IActionResult> GetStockById(int id)
        {
            return Ok(await _medicineService.GetStockById(id));
        }

        [HttpGet("getStockByLocation")]
        public async Task<IActionResult> GetStockByLocation(string location)
        {
            return Ok(await _medicineService.GetStockByLocation(location));
        }
        #endregion

        #region business
        [HttpGet("getAllPatientsMeds/{patient_Id}")]
        public async Task<IActionResult> GetAllPatientsMeds([FromRoute]int patient_Id)
        {
            return Ok(await _medicineService.GetAllPatientMedicinesForLastRecord(patient_Id));
        }

        [HttpPost("indoorPurchase/{patient_id}")]
        public async Task<IActionResult> MackePurchase(List<MidicnePurchased> PurchaseRequest,[FromRoute] int patient_id)
        {
            return Ok(await _medicineService.IndoorPurchase(PurchaseRequest, patient_id));
        }

        [HttpPost("outdoorPurchase")]
        public async Task<IActionResult> OutDoorPurchase(List<MidicnePurchased> PurchaseRequest)
        {
            return Ok(await _medicineService.OutdoorPurchase(PurchaseRequest));
        }
        #endregion

    }
}
