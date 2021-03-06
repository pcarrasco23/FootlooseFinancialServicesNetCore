﻿using FootlooseFS.Models;
using FootlooseFS.Service;
using FootlooseFS.Web.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootlooseFS.Web.Service.Controllers
{
    public class ContactInfoController : FootloseFSApiController
    {
        public ContactInfoController(IFootlooseFSService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor) { }

        // GET api/contactinfo        
        [HttpGet]
        public ContactInfoViewModel Get()
        {
            // Get Person data model from the data service
            var person = service.GetPersonByUsername(authenticatedUser, new PersonIncludes { Accounts = false, Addressses = true, Phones = true, AccountTransactions = false });

            // Create a Holder view model and populate data from Person data model
            var contactInfo = new ContactInfoViewModel();           
            contactInfo.EmailAddress = person.EmailAddress;

            contactInfo.Addresses = (from a in person.Addresses
                                select new AddressViewModel
                                    {
                                        AddressID = a.AddressID,
                                        Type = a.AddressType.Name,
                                        StreetAddress = a.Address.StreetAddress,
                                        City = a.Address.City,
                                        State = a.Address.State,
                                        Zip = a.Address.Zip,
                                        AddressTypeID = a.AddressTypeID
                                    }).ToList();

            contactInfo.PhoneNumbers = (from p in person.Phones
                                   select new PhoneViewModel
                                   {
                                       PhoneType = p.PhoneType.Name,
                                       PhoneTypeID = p.PhoneTypeID,
                                       Number = p.Number
                                   }).ToList();
            
            return contactInfo;
        }

        // POST: /api/contactinfo
        public OperationStatus Post([FromBody] ContactInfoViewModel contactInfoViewModel)
        {
            // Get Person data model from the data service
            // we do not need account nor transactions
            var person = service.GetPersonByUsername(authenticatedUser, new PersonIncludes { Accounts = false, Addressses = false, Phones = false, AccountTransactions = false });

            // Update the Email Address in the person model
            person.EmailAddress = contactInfoViewModel.EmailAddress;

            person.Phones = new List<Phone>();
            person.Addresses = new List<PersonAddressAssn>();

            // Add the phone numbers to the person model
            foreach(PhoneViewModel phoneViewModel in contactInfoViewModel.PhoneNumbers)
            {
                if (!string.IsNullOrEmpty(phoneViewModel.Number))
                {
                    var phone = new Phone
                    {
                        PhoneTypeID = phoneViewModel.PhoneTypeID,
                        Number = phoneViewModel.Number
                    };
                    person.Phones.Add(phone);
                }                
            }

            // Add the addresses to the person model
            foreach(AddressViewModel addressViewModel in contactInfoViewModel.Addresses)
            {
                if (!string.IsNullOrEmpty(addressViewModel.StreetAddress))
                {
                    var address = new PersonAddressAssn
                    {
                        AddressTypeID = addressViewModel.AddressTypeID,
                        Address = new Address
                        {
                            StreetAddress = addressViewModel.StreetAddress,
                            City = addressViewModel.City,
                            State = addressViewModel.State,
                            Zip = addressViewModel.Zip
                        }
                    };
                    person.Addresses.Add(address);
                }                
            }

            // Update the data store
            var oppStatus = service.UpdatePerson(person);

            return oppStatus;
        }
    }
}
