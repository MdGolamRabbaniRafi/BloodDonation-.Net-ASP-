import React, { useState, useEffect } from 'react';

// import { MdNotifications,MdDelete } from 'react-icons/md';

import Link from 'next/link';
import Image from 'next/image';
import { useRouter } from 'next/router';
import axios from 'axios';
import { useAuth } from './AuthContext';


const UserNav = () => {

//   const [profile, setProfile] = useState({});
 
//   const [allNotification, setAllNotification] = useState([]);
//   const [error, setError] = useState('');
//   const router = useRouter();
 
  const [isDropdownOpen, setDropdownOpen] = useState(false);
  const [isDropdown, setDropdown] = useState(false);

  const toggleDropdown = (event) => {
    event.stopPropagation();
    setDropdownOpen(!isDropdownOpen);
  };

  const toggleProfile = (event) => {
    event.stopPropagation();
    setDropdown(!isDropdown);
  };

 
//   useEffect(() => {
//     // Check if the user is authenticated before fetching the profile
//     if (user && login) {
//       GetProfile();
//       GetNotification();
//     } else {
//       // Redirect to login page or handle unauthenticated user
//       router.push('/Auth/Login');
//     }
//   }, [user]);

//   const GetNotification = async () => {
//     try {
//       const response = await axios.get('http://localhost:7000/manager/notification', {
//         headers: {
//           'Content-Type': 'application/json',
//         },
//       });
//       console.log(response.data);
//       console.log(response.success);
//       if (response.data) {
//         console.log('notification:', response.data);
//         console.log(response.data.data);
//         setAllNotification(response.data);
//       } else {
//         console.log('No products available');
//         setError('No products available');
//       }
//     } catch (error) {
//       console.error('Failed:', error);
//       setError(`An error occurred trying to fetch products: ${error.message}`);
//     }
//   };
  
 
//   const GetProfile = async () => {
//     try {
//       const response = await axios.get('http://localhost:7000/manager/profile', {
//         withCredentials: true,
//       });
  
//       console.log('Full Response:', response.data);
  
//       if (response.data) {
//         console.log('Profile:', response.data);
//         setProfile(response.data);
//       } else {
//         console.log('No profile available');
//         setError('No profile available');
//       }
//     } catch (error) {
//       console.error('Failed:', error);
//       // setError(`An error occurred trying to fetch profile: ${error.message}`);
//     }
//   };

//   const handleEditClick = (profile) => {

//     router.push({
//         pathname: '/Manager/EditProfile',
//         query: {
//           id: profile.id,
//           firstName: profile.firstName,
//           phoneNumber:profile.phoneNumber,
//           profilePic:profile.profilePic,
          
//         },
//       });
      
//   };
//   const handleDeleteClick = async (Serial) => {
//     console.log(`Delete clicked for product with ID: ${Serial}`);
//     try {
//       const respons = await axios.delete(`http://localhost:7000/manager/deleteNotification/${Serial}`);

//       GetNotification();
//       if (respons.data.success) {
//         console.log('Notification deleted successfully');
        
//         // Update the UI state to remove the deleted product
//         setAllNotification(prevNotification => prevNotification.filter(notification => notification.Serial !== Serial));
//       } else {
        
//         console.log('Failed to delete notification');
        
//         setError('');
//       }
//     } catch (error) {
//       console.error('Delete failed:', error);
//       // setError(`An error occurred while deleting the notification: ${error.message}`);
//     }
//   };
  
  

  return (
    <div>
    
 

    <div className="grid grid-cols-12 gap-3 pr-8 pl-8">
      {/* Header */}
      <header className="col-span-12 bg-gradient-to-r from-[#2c3e50] to-[#34495e] text-white p-4 flex justify-between items-center  shadow-md">
        
        <nav className="flex space-x-4 ">
  <Link href="/Manager/Manager">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Home
    </div>
  </Link>
  <Link href="/Manager/ManagerDashboard">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Products
    </div>
  </Link>
  <Link href="/Manager/LandPost">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Land Posts
    </div>
  </Link>
  <Link href="/Manager/SellerDashboard">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Sellers
    </div>
  </Link>
  <Link href="/Manager/SendEmail">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Send Email 
    </div>
  </Link>
  <Link href="/Manager/SellerDashboard">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Edit Website
    </div>
  </Link>
  <Link href="/">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Website
    </div>
  </Link>
  <Link href="/Auth/Login">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer ml-80">
    
      Logout
    </div>
  </Link>
  
  

  

 
</nav>

      </header>

        
      </div>
      
      

    </div>


  );
};


export default UserNav;
