using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;

namespace BLL.Services
{
    public class BloodDonationCampaignService
    {
        public static BloodDonationCampaignDTO AddBloodDonationCampaign(BloodDonationCampaignDTO campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }

            var data = MapperClass.MappedBloodDonationCampaign();
            var mapped = data.Map<BloodDonationCampaign>(campaign);
            var campaignRepo = DataAccessFactory.BloodDonationCampaignData().Create(mapped);
            var data2 = MapperClass.MappedBloodDonationCampaign();
            var mapped2 = data2.Map<BloodDonationCampaignDTO>(campaignRepo);

            return mapped2;
        }

        public static BloodDonationCampaignDTO UpdateBloodDonationCampaign(int campaignId, BloodDonationCampaignDTO campaign)
        {
            var data = MapperClass.MappedBloodDonationCampaign();
            var existingCampaign = DataAccessFactory.BloodDonationCampaignData().Read(campaignId);

            if (existingCampaign != null)
            {
                existingCampaign.CampaignName = campaign.CampaignName;
                existingCampaign.Description = campaign.Description;
                existingCampaign.StartDate = campaign.StartDate;
                existingCampaign.EndDate = campaign.EndDate;
                // Add more properties as needed

                var updatedCampaign = DataAccessFactory.BloodDonationCampaignData().Update(existingCampaign);
                var data2 = MapperClass.MappedBloodDonationCampaign();
                var mapped2 = data2.Map<BloodDonationCampaignDTO>(updatedCampaign);

                return mapped2;
            }
            else
            {
                return null;
            }
        }


        public static bool DeleteBloodDonationCampaign(int campaignId)
        {
            var getCampaign = DataAccessFactory.BloodDonationCampaignData().Read(campaignId);

            if (getCampaign != null)
            {
                var isDeleted = DataAccessFactory.BloodDonationCampaignData().Delete(campaignId);
                return isDeleted;
            }
            else
            {
                // Campaign not found, handle accordingly (e.g., throw exception or return false)
                return false;
            }
        }
        public static List<BloodDonationCampaignDTO> GetAllBloodDonationCampaigns()
        {
            var data = MapperClass.MappedBloodDonationCampaign();
            var getCampaigns = DataAccessFactory.BloodDonationCampaignData().Read();
            var mapped = data.Map<List<BloodDonationCampaignDTO>>(getCampaigns);

            return mapped;
        }
        public static bool JoinBloodDonationCampaign(int userId, int campaignId)
        {
            var user = DataAccessFactory.UserData().Read(userId);
            var campaign = DataAccessFactory.BloodDonationCampaignData().Read(campaignId);

            if (user != null && campaign != null)
            {
                // Check if the user is already joined
                if (!user.JoinedCampaigns.Any(c => c.ID == campaignId))
                {
                    // If not joined, add the campaign to the user's joined campaigns
                    user.JoinedCampaigns.Add(campaign);

                    // Increment the total members joined count
                    campaign.TotalMembersJoined++;

                    // Update both user and campaign in the database
                    DataAccessFactory.UserData().Update(user);
                    DataAccessFactory.BloodDonationCampaignData().Update(campaign);

                    return true;
                }
            }

            return false;
        }


    }
}
