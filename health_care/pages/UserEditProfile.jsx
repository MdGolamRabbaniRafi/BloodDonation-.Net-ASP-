import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';

const UserEditProfile = () => {
  const router = useRouter();
  const { UserId, FirstName, Email } = router.query;
  const [userFristName, setUserFristName] = useState(FirstName || '');
  const [userEmail, setUserEmail] = useState(Email || '');
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});

  useEffect(() => {
    const fetchProfileDetails = async () => {
      try {
        const response = await axios.get(`http://localhost:7000/manager/getProduct/${UserId}`);

        if (response.data.success) {
          const userDetails = response.data.data;
          setUserFristName(userDetails.FirstName);
          setUserEmail(userDetails.Email);
        } else {
          setError('Failed to fetch profile details');
        }
      } catch (error) {
        
      }
    };

    fetchProfileDetails();
  }, [UserId]);

  const handleFirstNameChange = (e) => {
    setUserFristName(e.target.value);
  };

  const handleEmailChange = (e) => {
    setUserEmail(e.target.value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!userFristName || !userEmail) {
      setError('Please enter both product name and price');
    } else {
      try {
        const response = await axios.put(
          `http://localhost:7000/manager/updateProduct/${UserId}`,
          {
            name: userFristName,
            price: userEmail,
          },
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );

        if (response.data.success) {
          console.log('Profile updated successfully');
         
        } else {
            router.push('/UserDashboard');
          setError('Failed to update profile');
        }
      } catch (error) {
        console.error('Update failed:', error);
        setError(`An error occurred while updating the profile: ${error.message}`);
      }
    }
  };

  return (
    <div className="flex justify-center items-center h-screen bg-gray-100">
      <div className="bg-white p-8 rounded shadow-md w-96">
        <h2 className="text-2xl font-bold mb-6">EDIT PROFILE</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-6">
            <label htmlFor="fullname" className="block text-sm font-semibold text-gray-600 mb-1">
              FullName:
            </label>
            <input
              type="text"
              id="userFirstName"
              name="userFirstName"
              value={userFristName}
              onChange={handleFirstNameChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.userFristName ? 'border-red-500' : 'border-gray-300'
              }`}
            />
            {formErrors.userFristName && <p className="text-red-500 text-sm mt-1">{formErrors.userFristName}</p>}
          </div>
          <div className="mb-6">
            <label htmlFor="email" className="block text-sm font-semibold text-gray-600 mb-1">
              Email:
            </label>
            <input
              type="text"
              id="userEmail"
              name="product_price"
              value={userEmail}
              onChange={handleEmailChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.userEmail ? 'border-red-500' : 'border-gray-300'
              }`}
            />
            {formErrors.userEmail && (
              <p className="text-red-500 text-sm mt-1">{formErrors.userEmail}</p>
            )}
          </div>
          <button
            type="submit"
            className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
          >
            EDIT
          </button>
        </form>
        {error && <p className="text-red-500 mt-4">{error}</p>}
      </div>
    </div>
  );
};

export default UserEditProfile;
