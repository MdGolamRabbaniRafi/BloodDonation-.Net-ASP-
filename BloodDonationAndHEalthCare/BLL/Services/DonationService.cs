using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DonationService
    {
        public static DonationDTO CreateDonationRequest(DonationDTO donationDTO)
        {
            if (donationDTO == null)
            {
                throw new ArgumentNullException(nameof(donationDTO));
            }

            var donation = MapperClass.MappedDonation().Map<Donation>(donationDTO);
            donation.CreatedAt = DateTime.UtcNow;

            var createdDonation = DataAccessFactory.DonationData().Create(donation);

            var mappedDonationDTO = MapperClass.MappedDonation().Map<DonationDTO>(createdDonation);

            return mappedDonationDTO;
        }

        public static List<DonationDTO> GetPendingDonationRequests()
        {
            var donationEntities = DataAccessFactory.DonationData().Read().Where(d => !d.IsApproved).AsQueryable();

            var mappedDonationDTOs = MapperClass.MappedDonation().ProjectTo<DonationDTO>(donationEntities).ToList();

            return mappedDonationDTOs;
        }


        public static bool ApproveDonationRequest(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null && !donation.IsApproved)
            {
                donation.IsApproved = true;
                donation.ApprovedAt = DateTime.UtcNow;

                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                return updatedDonation != null;
            }

            return false;
        }

        
    }
}
