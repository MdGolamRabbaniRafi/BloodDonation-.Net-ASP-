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

        public static bool ApproveAndProcessDonation(int donationId, PaymentInfoDTO paymentInfo)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null && !donation.IsApproved && !donation.IsPaid)
            {
                // Approve the donation
                donation.IsApproved = true;
                donation.ApprovedAt = DateTime.UtcNow;

                // Update the donation
                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                if (updatedDonation != null)
                {
                    // Process the payment
                    bool paymentResult = PaymentGateway.ProcessPayment(paymentInfo, updatedDonation.Amount);

                    if (paymentResult)
                    {
                        // If payment is successful, update the donation status to paid
                        updatedDonation.IsPaid = true;
                        DataAccessFactory.DonationData().Update(updatedDonation);

                        return true;
                    }
                    // Handle payment failure (log, notify user, etc.)
                }
            }

            return false;
        }

        public static List<DonationDTO> GetApprovedDonations()
        {
            var donationEntities = DataAccessFactory.DonationData().Read().Where(d => d.IsApproved && !d.IsPaid).AsQueryable();
            var mappedDonationDTOs = MapperClass.MappedDonation().ProjectTo<DonationDTO>(donationEntities).ToList();

            return mappedDonationDTOs;
        }
        public static bool ProcessDonationPayment(DonationDTO donation, PaymentInfoDTO paymentInfo)
        {
            if (donation.Amount <= 0)
            {
                // Handle invalid donation amount
                return false;
            }

            try
            {
                // Process the payment using Stripe
                bool paymentSuccess = PaymentGateway.ProcessPayment(paymentInfo, donation.Amount);

                if (paymentSuccess)
                {
                    // If payment is successful, update the donation status to paid
                    donation.IsPaid = true;
                    donation.ApprovedAt = DateTime.UtcNow;

                    // Map DonationDTO to Donation (assuming you're using AutoMapper)
                    var donationEntity = MapperClass.MappedDonation().Map<DAL.Models.Donation>(donation);

                    // Update the donation in the data store
                    DataAccessFactory.DonationData().Update(donationEntity);

                    return true;
                }
                else
                {
                    // Handle payment failure (log, notify user, etc.)
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        // Inside DonationService class
        public static DonationDTO GetApprovedDonationById(int donationId)
        {
            var donationEntity = DataAccessFactory.DonationData().Read(donationId);

            if (donationEntity != null && donationEntity.IsApproved && !donationEntity.IsPaid)
            {
                var mappedDonationDTO = MapperClass.MappedDonation().Map<DonationDTO>(donationEntity);
                return mappedDonationDTO;
            }

            return null;
        }
        // Inside DonationService class
        public static bool MarkDonationAsPaid(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null && donation.IsApproved && !donation.IsPaid)
            {
                // Update the donation status to paid
                donation.IsPaid = true;
                donation.ApprovedAt = DateTime.UtcNow;

                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                return updatedDonation != null;
            }

            return false;
        }







    }
}
