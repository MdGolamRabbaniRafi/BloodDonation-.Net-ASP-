using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class ServiceProviderService
    {
        public static ServiceProviderDTO SignUpService(ServiceProviderDTO serviceProvider)
        {
            // Hash password securely
            string hashedPassword = HashPassword(serviceProvider.Password);
            serviceProvider.Password = hashedPassword;

            // Set initial status to pending
            

            // Store service provider in the database
            var serviceProviderRepo = DataAccessFactory.ServiceProviderData().Create(MapToEntity(serviceProvider));

            // Send notification to admin for approval
            SendAdminApprovalNotification(serviceProviderRepo);

            return MapToDTO(serviceProviderRepo);
        }

        public static ServiceProviderDTO UpdateServiceProvider(int serviceProviderId, ServiceProviderDTO serviceProvider)
        {
            var existingServiceProvider = DataAccessFactory.ServiceProviderData().Read(serviceProviderId);

            if (existingServiceProvider != null)
            {
                // Update service provider properties
                
                // Update other properties as needed...

                var updatedServiceProvider = DataAccessFactory.ServiceProviderData().Update(existingServiceProvider);
                return MapToDTO(updatedServiceProvider);
            }
            else
            {
                return null; // Service provider not found
            }
        }

        public static bool DeleteServiceProvider(int serviceProviderId)
        {
            var existingServiceProvider = DataAccessFactory.ServiceProviderData().Read(serviceProviderId);

            if (existingServiceProvider != null)
            {
                var isDeleted = DataAccessFactory.ServiceProviderData().Delete(serviceProviderId);
                return isDeleted;
            }
            else
            {
                return false; // Service provider not found
            }
        }

        public static ServiceProviderDTO GetServiceProvider(int serviceProviderId)
        {
            var existingServiceProvider = DataAccessFactory.ServiceProviderData().Read(serviceProviderId);
            return MapToDTO(existingServiceProvider);
        }

        private static string HashPassword(string password)
        {
            // Use a secure hashing algorithm like bcrypt or Argon2
            using (var hmac = new HMACSHA512())
            {
                var hashedBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static void SendAdminApprovalNotification(ServiceProvider serviceProvider)
        {
            // Implement logic to send notification to admin, e.g., via email or in-app messaging
            // You can access service provider properties for notification content
        }

        private static ServiceProviderDTO MapToDTO(ServiceProvider serviceProvider)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceProvider, ServiceProviderDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<ServiceProviderDTO>(serviceProvider);
        }

        private static ServiceProvider MapToEntity(ServiceProviderDTO serviceProviderDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceProviderDTO, ServiceProvider>());
            var mapper = config.CreateMapper();
            return mapper.Map<ServiceProvider>(serviceProviderDTO);
        }

        // ... other methods with suggested updates ...
    }
}
