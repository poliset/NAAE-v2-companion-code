﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memento;
using Memento.Domain;
using Merp.Accountancy.CommandStack.Services;

namespace Merp.Accountancy.CommandStack.Events
{
    public class IncomingInvoiceRegisteredEvent : DomainEvent
    {
        public class SupplierInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public string StreetName { get; private set; }
            public string City { get; private set; }
            public string PostalCode { get; private set; }
            public string Country { get; private set; }
            public string VatIndex { get; private set; }
            public string NationalIdentificationNumber { get; private set; }

            public SupplierInfo(Guid supplierId, string supplierName, string streetName, string city, string postalCode, string country, string vatIndex, string nationalIdentificationNumber)
            {
                City = city;
                Name=supplierName;
                Country = country;
                Id = supplierId;
                NationalIdentificationNumber = nationalIdentificationNumber;
                PostalCode = postalCode;
                StreetName=streetName;
                VatIndex = vatIndex;
            }
        }
        public Guid InvoiceId { get; private set; }
        public string InvoiceNumber { get; private set; }
        public SupplierInfo Supplier { get; private set; }
        [Timestamp]
        public DateTime InvoiceDate { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Taxes { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string Description { get; private set; }
        public string PaymentTerms { get; private set; }
        public string PurchaseOrderNumber { get; private set; }

        public IncomingInvoiceRegisteredEvent(Guid invoiceId, string invoiceNumber, DateTime invoiceDate, decimal amount, decimal taxes, decimal totalPrice, string description, string paymentTerms, string purchaseOrderNumber, Guid supplierId, string supplierName, string streetName, string city, string postalCode, string country, string vatIndex, string nationalIdentificationNumber)
        {
            var supplier = new SupplierInfo(
                city: city,
                supplierName: supplierName,
                country: country,
                supplierId: supplierId,
                nationalIdentificationNumber: nationalIdentificationNumber,
                postalCode: postalCode,
                streetName: streetName,
                vatIndex: vatIndex
            );
            Supplier = supplier;
            InvoiceId = invoiceId;
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            Amount = amount;
            Taxes = taxes;
            TotalPrice = totalPrice;
            Description = description;
            PaymentTerms = paymentTerms;
            PurchaseOrderNumber = purchaseOrderNumber;
        }
    }
}
