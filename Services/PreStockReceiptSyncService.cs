using System;
using System.Collections.Generic;
using System.Linq;
using Estore.Ce.Contracts;
using Estore.Ce.Contracts.Services;
using Estore.Ce.Helpers;
using Estore.Ce.Models;
using Estore.Ce.PreStockReceiptService;

namespace Estore.Ce.Services
{
    public class PreStockReceiptSyncService : BaseSyncService, IPreStockReceiptSyncService
    {
        private readonly IPreStockReceiptRepository _repository;

        // constructor
        public PreStockReceiptSyncService(IPreStockReceiptRepository repository)
        {
            _repository = repository;
        }
        // end: constructor

        public override void Sync()
        {
            try
            {
                IPreStockReceiptSoapService service = new IPreStockReceiptSoapService();
                service.Timeout = 100000;

                // commented for now
                // need to make sure there are no unsubmitted deliveries else existing delivered items will be corrupted
                //_repository.DeleteAll();
                //DatabaseHelper.ResetIdentity("PreStockReceipt", "Id");

                IEnumerable<GetAllPreStockReceiptQueryRequestDto> dtoList = service.GetAll();
                if (dtoList.Count() > 0)
                {
                    List<PreStockReceipt> list = new List<PreStockReceipt>();
                    PreStockReceipt entity = new PreStockReceipt();
                    foreach (GetAllPreStockReceiptQueryRequestDto dto in dtoList)
                    {
                        entity = ObjectMapper.MapTo<GetAllPreStockReceiptQueryRequestDto, PreStockReceipt>(dto);

                        PreStockReceipt row = _repository.GetById(entity.Id);
                        if (row == null)
                        {
                            list.Add(entity);
                        }
                        else
                        {
                            row.QuantityOnOrder = entity.QuantityOnOrder;
                            _repository.InsertUpdate(row);
                        }
                    }
                    if (list.Count() > 0)
                    {
                        _repository.InsertAll(list);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
