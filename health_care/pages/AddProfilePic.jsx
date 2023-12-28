import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';

const AddProfilePic = () => {
  const router = useRouter();
  const [error, setError] = useState('');
  const [picture, setPicture] = useState(null);
  const [profileData, setProfileData] = useState(null);

  const handlePictureChange = (e) => {
    const file = e.target.files[0];
    setPicture(file);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      if (!picture) {
        setFormErrors({ picture: 'Please select a picture' });
        return;
      }

      const formData = new FormData();
      formData.append('FileName', picture);

      const response = await axios.post(
        'https://localhost:44307/api/UploadFile',
        formData,
        {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        }
      );

      console.log("Backend Response:", response.data);

      if (response.status === 200) {
        router.push('/');
      } else {
        setError('Failed to upload profile picture');
      }
    } catch (error) {
      console.error('Failed:', error);

      if (error.response) {
        console.log('Error Response Data:', error.response.data);
        console.log('Error Response Status:', error.response.status);
        setError(`Server error: ${error.response.status}`);
      } else {
        console.log('Error Message:', error.message);
        setError('Something went wrong.');
      }
    }
  };

  const GetProfile = async () => {
    try {
      const response = await axios.get(
        'https://localhost:44307/api/GetFile',
        {
          params: {
            Filename: "docav.jpg",
          },
        }
      );
  
      console.log(response.data);
  
      if (response.data.success) {
        // Assuming the server returns base64-encoded image data
        setProfileData(response.data.data);
      } else {
        console.log('No profile picture available');
        setError('No profile picture available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch profile picture: ${error.message}`);
    }
  };

  return (
    <div>
      <div className='col-span-12 bg-[#dfe4ea] text-[#192a56] p-8 shadow-md'>
        <div className="flex justify-center items-center h-screen bg-gray-100 mt-1">
          <div className="bg-white p-8 rounded shadow-md w-96">
            <h2 className="text-2xl font-bold mb-6">Add Profile Picture</h2>
            <form onSubmit={handleSubmit} encType="multipart/form-data">
              <div className="mb-2">
                <label htmlFor="picture" className="block text-sm font-semibold text-gray-600 mb-1">
                  Profile Picture:
                </label>
                <input
                  type="file"
                  id="picture"
                  name="picture"
                  onChange={handlePictureChange}
                  className="w-full p-3 border rounded-md focus:outline-none"
                />
                
              </div>
              <button
                type="submit"
                className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
              >
                ADD
              </button>
            </form>
            {error && <p className="text-red-500 mt-4">{error}</p>}
          </div>
          <div className="absolute left-1 bg-gradient-to-r from-[#55606b] to-[#424f5b] text-white ml-20 p-2 mt-1 w-64 mr-7 rounded-md">
            <div className="flex flex-col items-center justify-between font-bold mb-2">
              <div className="mb-6">
                <img
                  src={`data:image/jpeg;base64,${profileData}`}
                  alt={'abc'}
                  className="w-44 h-44 rounded-md"
                />
              </div>
              <button onClick={GetProfile}>
                Get Profile
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddProfilePic;
