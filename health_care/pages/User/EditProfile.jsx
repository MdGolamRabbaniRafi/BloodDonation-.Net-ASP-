// EditProfile.jsx
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
import UserNav from "./UserNav";



const EditProfile = () => {
  const router = useRouter();
  const { id, firstName, phoneNumber, profilePic } = router.query;
  const [profileFirstName, setProfileFirstName] = useState(firstName || "");
  const [profilephone, setProfilephone] = useState(phoneNumber || "");
  const [profilePicture, setProfilPicture] = useState(profilePic || "");
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});
  

  useEffect(() => {
    const fetchProfileDetails = async () => {
      try {
        const response = await axios.get('http://localhost:7000/manager/profile', {
          withCredentials: true,
        });
    
        console.log('Full Response:', response.data);
    
        if (response.data) {
          console.log('Profile:', response.data);
          const profiledata = response.data;
          console.log("firstname ",profiledata.firstname);
          setProfileFirstName(profiledata.firstName);
          
          setProfilephone(profiledata.phoneNumber);

        } else {
          console.log('No profile available');
          setError('No profile available');
        }
      } catch (error) {
        console.error('Failed:', error);
        // setError(`An error occurred trying to fetch profile: ${error.message}`);
      }
    };
    console.log("id" +id);

    fetchProfileDetails();
  }, [id]);

  const handleNameChange = (e) => {
    setProfileFirstName(e.target.value);
  };

  const handlePhoneChange = (e) => {
    setProfilephone(e.target.value);
  };

  const handlePictureChange = (e) => {
    const file = e.target.files[0];
    setProfilPicture(file);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    if (!profileFirstName || !profilephone || !profilePicture) {
      setFormErrors({
        profileFirstName: 'Please enter a name',
        profilephone: 'Please enter a phone number',
        profilePicture: 'Please select a profile picture',
      });
    } else {
      try {
        const formData = new FormData();
        formData.append('firstName', profileFirstName);
        formData.append('phoneNumber', profilephone);
        formData.append('profilepic', profilePicture);
  
        const response = await axios.put(
          `http://localhost:7000/manager/update/${id}`,
          formData,
          {
            withCredentials: true,
            headers: {
              'Content-Type': 'multipart/form-data',
            },
          }
        );
  
        console.log('Response:', response);
  
        if (response.data.success) {
          console.log('Profile updated successfully');
          router.push('/Manager/Manager');
        } else {
          setError('Failed to update profile');
        }
      } catch (error) {
        console.error('Update failed:', error);
        if (error.response) {
          console.log('Response data:', error.response.data);
          console.log('Response status:', error.response.status);
          console.log('Response headers:', error.response.headers);
        }
        setError(`An error occurred while updating the profile: ${error.message}`);
      }
    }
  };
  
  
  

  return (
    <div>
      <SessionCheck></SessionCheck>
      <UserNav />
      <div className="flex justify-center items-center h-screen bg-gray-100">
        <div className="bg-white p-8 rounded shadow-md w-96">
          <h2 className="text-2xl font-bold mb-6">EDIT PROFILE</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-6">
              <label htmlFor="profileFirstName" className="block text-sm font-semibold text-gray-600 mb-1">
                Name:
              </label>
              <input
                type="text"
                id="profileFirstName"
                name="profileFirstName"
                value={profileFirstName}
                onChange={handleNameChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.profileFirstName ? 'border-red-500' : 'border-gray-300'
                }`}
              />
              {formErrors.profileFirstName && <p className="text-red-500 text-sm mt-1">{formErrors.profileFirstName}</p>}
            </div>
            <div className="mb-6">
              <label htmlFor="profilephone" className="block text-sm font-semibold text-gray-600 mb-1">
                Phone:
              </label>
              <input
                type="text"
                id="profilephone"
                name="profilephone"
                value={profilephone}
                onChange={handlePhoneChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.profilephone ? 'border-red-500' : 'border-gray-300'
                }`}
              />
              {formErrors.profilephone && (
                <p className="text-red-500 text-sm mt-1">{formErrors.profilephone}</p>
              )}
            </div>
            <div className="mb-2">
              <label htmlFor="profilePicture" className="block text-sm font-semibold text-gray-600 mb-1">
                Profile Picture:
              </label>
              <input
                type="file"
                id="profilePicture"
                name="profilePicture"
                onChange={handlePictureChange}
                className={`w-full p-3 border rounded-md focus:outline-none ${
                  formErrors.profilePicture ? "border-red-500" : "border-gray-300"
                }`}
              />
              {formErrors.profilePicture && (
                <p className="text-red-500 text-sm mt-1">{formErrors.profilePicture}</p>
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
    </div>
  );
};

export default EditProfile;
