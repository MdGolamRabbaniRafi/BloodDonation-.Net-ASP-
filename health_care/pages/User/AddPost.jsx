import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
import UserNav from "./UserNav";


const AddPost = () => {
  const router = useRouter();
  const [name, setname] = useState('');
  const [bloodgroup, setbloodgroup] = useState('');
  const [phone, setphone] = useState('');
  const [location, setlocation] = useState(null);
  const [problems, setproblems] = useState(null);
  const [userid, setuserid] = useState(null);
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});
  

  const handleNameChange = (e) => {
    setname(e.target.value);
  };

  const handleBloodGroupChange = (e) => {
    setbloodgroup(e.target.value);
  };

  const handlePhoneChange = (e) => {
    setphone(e.target.value);
  };
  const handleLocationChange = (e) => {
    setlocation(e.target.value);
  };
  const handleProblemsChange = (e) => {
    setproblems(e.target.value);
  };
  const handleUserIdChange = (e) => {
    setuserid(e.target.value);
  };


  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name) {
      setFormErrors({ product: 'Please enter  name' });
    } else if(!phone){
      setFormErrors({ product_price: 'Please enter phone number' });
    } else {
      setFormErrors({});

      try {
        const formData = new FormData();
        formData.append('Name', name);
        formData.append('BloodGroup', bloodgroup);
        formData.append('Phone', phone);
        formData.append('Location', location);
        formData.append('Problems', problems);
        formData.append('UserId', userid);

        const response = await axios.post(
          'https://localhost:44307/api/post/add',
          formData,
          {
            headers: {
                'Content-Type': 'application/json',
            },
          }
        );

        console.log("Backend Response:", response);

        if (response.data === "Invalid product") {
          setError('Product is invalid');
        } else {
          router.push('/User/UserPost');
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
    }
  };
  return (
    <div>
           
    <UserNav />
    <div className='col-span-12 bg-[#dfe4ea] text-[#192a56] p-8 shadow-md'>
    <div className="flex justify-center items-center h-screen bg-gray-100 mt-1">
      <div className="bg-white p-8 rounded shadow-md w-96">
        <h2 className="text-2xl font-bold mb-6">ADD POST</h2>
        <form onSubmit={handleSubmit} encType="multipart/form-data">
          <div className="mb-2">
            <label htmlFor="product" className="block text-sm font-semibold text-gray-600 mb-1">
               Name:
            </label>
            <input
              type="text"
              id="name"
              name="name"
              value={name}
              onChange={handleNameChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.name ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.name && (
              <p className="text-red-500 text-sm mt-1">{formErrors.name}</p>
            )}
          </div>
          <div className="mb-2">
            <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
              Blood Group:
            </label>
            <input
              type="text"
              id="bloodgroup"
              name="bloodgroup"
              value={bloodgroup}
              onChange={handleBloodGroupChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.bloodgroup ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.bloodgroup && (
              <p className="text-red-500 text-sm mt-1">{formErrors.bloodgroup}</p>
            )}
          </div>
          <div className="mb-2">
            <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
              Phone:
            </label>
            <input
              type="text"
              id="phone"
              name="phone"
              value={phone}
              onChange={handlePhoneChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.phone ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.phone && (
              <p className="text-red-500 text-sm mt-1">{formErrors.phone}</p>
            )}
          </div>

          <div className="mb-2">
            <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
              Problems:
            </label>
            <input
  type="text"
  id="problems"
  name="problems"
  onChange={handleProblemsChange}
  className={`w-full p-3 border rounded-md focus:outline-none ${
    formErrors.problems ? "border-red-500" : "border-gray-300"
  }`}
/>
            {formErrors.problems && (
              <p className="text-red-500 text-sm mt-1">{formErrors.problems}</p>
            )}
          </div>
          <div className="mb-2">
            <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
              User Id:
            </label>
            <input
              type="text"
              id="userid"
              name="userid"
              value={userid}
              onChange={handleUserIdChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.userid ? "border-red-500" : "border-gray-300"
              }`}
            />
            {formErrors.userid && (
              <p className="text-red-500 text-sm mt-1">{formErrors.userid}</p>
            )}
          </div>
          <button
            type="submit"
            className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
          >
            ADD POST
          </button>
        </form>
        {error && <p className="text-red-500 mt-4">{error}</p>}
      </div>
    </div>
    </div>
    </div>
  );
};

export default AddPost;




