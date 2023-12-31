import React, { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
import Link from 'next/link';

const RegistrationForm = () => {
  const [formData, setFormData] = useState({
    FirstName: '',
    Email: '',
    DateOfBirth: '',
    Password: '',
    BloodGroup: '',
    AdminId: '',
  });

  const [emailError, setEmailError] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post(
        'https://localhost:44307/api/User/add',
        {
          FirstName: formData.FirstName,
          Email: formData.Email,
          DateOfBirth: formData.DateOfBirth,
          Password: formData.Password,
          BloodGroup: formData.BloodGroup,
          AdminId: formData.AdminId,
        },
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );

      console.log('Backend Response:', response);

      if (response.data) {
        console.log(response.data);
        router.push('/AdminDashboard');
        setEmailError('Email already exists. Please use a different email.');
      } else {
        setEmailError('');
        setFormData({
          FirstName: '',
          Email: '',
          DateOfBirth: '',
          Password: '',
          BloodGroup: '',
          AdminId: '',
        });
        router.push('/AdminDashboard');
      }
    } catch (error) {
      console.error('Failed:', error);

      if (error.response) {
        console.log('Error Response Data:', error.response.data);
        console.log('Error Response Status:', error.response.status);
        console.log('Error Response Headers:', error.response.headers);
        setError(`Server error: ${error.response.status}`);
      } else if (error.request) {
        console.log('Error Request:', error.request);
        setError('Request to the server failed.');
      } else {
        console.log('Error Message:', error.message);
        setError('Something went wrong.');
      }
    }
  };

  return (
    <div>
    <form onSubmit={handleSubmit} className="max-w-md mx-auto my-8 p-6 bg-white shadow-md rounded-md">
      <div className="mb-4">
        <label htmlFor="FirstName" className="block text-sm font-medium text-gray-600">
          First Name:
        </label>
        <input
          type="text"
          id="FirstName"
          name="FirstName"
          value={formData.FirstName}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="mb-4">
        <label htmlFor="Email" className="block text-sm font-medium text-gray-600">
          Email:
        </label>
        <input
          type="email"
          id="Email"
          name="Email"
          value={formData.Email}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="mb-4">
        <label htmlFor="DateOfBirth" className="block text-sm font-medium text-gray-600">
          Date of Birth:
        </label>
        <input
          type="date"
          id="DateOfBirth"
          name="DateOfBirth"
          value={formData.DateOfBirth}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="mb-4">
        <label htmlFor="Password" className="block text-sm font-medium text-gray-600">
          Password:
        </label>
        <input
          type="password"
          id="Password"
          name="Password"
          value={formData.Password}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="mb-4">
        <label htmlFor="BloodGroup" className="block text-sm font-medium text-gray-600">
          Blood Group:
        </label>
        <input
          type="text"
          id="BloodGroup"
          name="BloodGroup"
          value={formData.BloodGroup}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="mb-4">
        <label htmlFor="AdminId" className="block text-sm font-medium text-gray-600">
          Admin ID:
        </label>
        <input
          type="text"
          id="AdminId"
          name="AdminId"
          value={formData.AdminId}
          onChange={handleChange}
          required
          className="mt-1 p-2 w-full border rounded-md"
        />
      </div>
      <div className="text-red-500">{emailError}</div>
      <div className="text-red-500">{error}</div>
      <div>
        <button type="submit" className="bg-blue-500 text-white py-2 px-4 rounded-md">
          Submit
        </button>
      </div>
    </form>
    <Link href="/Login"><h6 className="text-blue-500 text-center ">Already have an account? Login here.</h6></Link>
    </div>
    
  );
};

export default RegistrationForm;
