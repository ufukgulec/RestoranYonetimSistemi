﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public class VMPhoneOrder : EntityLayer.Concrete.PhoneOrder
    {
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());

        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());

        GenericManager<PhoneOrderDetail> detailsManager = new GenericManager<PhoneOrderDetail>(new EfGenericRepository<PhoneOrderDetail>());

        ProductManager productManager = new ProductManager(new EfProductRepository());

        public List<Product> products { get; set; }

        public VMPhoneOrder(PhoneOrder phoneOrder)
        {
            Id = phoneOrder.Id;
            Status = phoneOrder.Status;
            OrderTime = phoneOrder.OrderTime;
            PhoneOrderDetails = detailsManager.GetAll(x => x.PhoneOrderId == Id);
            foreach (var item in PhoneOrderDetails)
            {
                item.Product = productManager.Get(item.ProductId);
            }
        }
    }
}
