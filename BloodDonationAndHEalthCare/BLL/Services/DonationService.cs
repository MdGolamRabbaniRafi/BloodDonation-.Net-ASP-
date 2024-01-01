using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL;
using DAL.Interface;
using DAL.Models;
using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace BLL.Services
{
    public class DonationService
    {
        public static DonationDTO CreateDonationRequest(DonationDTO donationDTO, string token)
        {

            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);
            donationDTO.UserId = user.UserId;
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
<<<<<<< HEAD
=======

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
               
                donation.IsApproved = true;
                donation.ApprovedAt = DateTime.UtcNow;

              
                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                if (updatedDonation != null)
                {
                   
                    bool paymentResult = PaymentGateway.ProcessPayment(paymentInfo, updatedDonation.Amount);

                    if (paymentResult)
                    {
                    
                        updatedDonation.IsPaid = true;
                        DataAccessFactory.DonationData().Update(updatedDonation);

                        return true;
                    }
                    
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
            
                return false;
            }

            try
            {
                
                bool paymentSuccess = PaymentGateway.ProcessPayment(paymentInfo, donation.Amount);

                if (paymentSuccess)
                {
                    donation.IsPaid = true;
                    donation.ApprovedAt = DateTime.UtcNow;

                   
                    var donationEntity = MapperClass.MappedDonation().Map<DAL.Models.Donation>(donation);

                    
                    DataAccessFactory.DonationData().Update(donationEntity);

                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        
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
     
        public static bool MarkDonationAsPaid(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null && donation.IsApproved && !donation.IsPaid)
            {
               
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
                donation.IsPaid = true;

                var updatedDonation = DataAccessFactory.DonationData().Update(donation);

                return updatedDonation != null;
            }

            return false;
        }
        public static bool DeleteDonationRequest(int donationId)
        {
            var donation = DataAccessFactory.DonationData().Read(donationId);

            if (donation != null)
            {
                var isDeleted = DataAccessFactory.DonationData().Delete(donationId);
                return isDeleted;
            }

            return false;
        }
       



        public static List<DonationDTO> GetApprovedDonations() 
        {
            var getusers = DataAccessFactory.DonationData().ReadAccept();
            var data = MapperClass.MappedDonation();
            var mapper2 = data.Map<List<DonationDTO>>(getusers);

            return mapper2;
        }

       

       



    }
}
