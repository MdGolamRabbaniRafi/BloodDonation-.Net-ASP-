import React, { useState } from "react";
import axios from "axios";
import { useRouter } from 'next/router';
// import { useAuth } from "./authcontext";


const Login = () => {
//   const { login } = useAuth(); 
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [generalError, setGeneralError] = useState("");
  const router = useRouter();
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const [formErrors, setFormErrors] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });

    setFormErrors({
      ...formErrors,
      [e.target.name]: "", // Clear any previous errors when the user starts typing
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    // Perform form validation
    let isValid = true;
    const newFormErrors = { ...formErrors };
  
    if (formData.email.trim() === "") {
      newFormErrors.email = "Email is required";
      isValid = false;
    }
  
    if (formData.password.trim() === "") {
      newFormErrors.password = "Password is required";
      isValid = false;
    }
  
    if (!isValid) {
      setFormErrors(newFormErrors);
      return;
    }
  
    try {
      const response = await axios.post(
        'https://localhost:44307/api/login',
        {
            Email: formData.email,
          Password: formData.password,
        },
        {
          headers: {
            'Content-Type': 'application/json',
          },
          withCredentials: true,
        }
      );
  
      if (response.data.error === "PasswordMismatchError") {
        setPasswordError("Incorrect password. Please try again.");
        setEmailError("");
      } else if (response.data.error === "EmailMismatchError") {
        setEmailError("Email and password do not match. Please try again.");
        setPasswordError("");
      } else {
        console.log("Login success:", response);
        console.log("cookies" + document.cookie);
        login(formData.email, document.cookie); // Pass the email to the login function
        router.push('/AdminDashboard');
      }
    } catch (error) {
      console.log("Error:", error);
      setGeneralError("There was an error logging you in. Please try again.");
    }
  };
  
  return (
    
    <div className="flex justify-center items-center h-screen bg-gray-100">
      
      <div className="bg-white p-8 rounded shadow-md w-96">
        <h2 className="text-2xl font-bold mb-6">Login</h2>
        
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="username" className="block text-sm font-semibold text-gray-600 mb-1">
              Email:
            </label>
            <input
              type="text"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.email ? "border-red-500" : "border-gray-300"
              }`}
              
            />
            {formErrors.email && (
              <p className="text-red-500 text-sm mt-1">{formErrors.email}</p>
            )}
          </div>
          <div className="mb-6">
            <label htmlFor="password" className="block text-sm font-semibold text-gray-600 mb-1">
              Password:
            </label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.password ? "border-red-500" : "border-gray-300"
              }`}
              
             
            />
           
            {formErrors.password && (
              <p className="text-red-500 text-sm mt-1">{formErrors.password}</p>
            )}
             {emailError && (
            <p className="text-red-500 text-sm mt-1">{emailError}</p>
          )}
          {passwordError && (
            <p className="text-red-500 text-sm mt-1">{passwordError}</p>
          )}
          {generalError && (
            <p className="text-red-500 text-sm mt-1">{generalError}</p>
          )}
          </div>
          <button
            type="submit"
            className="bg-blue-500 text-white px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
          >
            Login
          </button>
        </form>
      </div>
    </div>
  );
};

export default Login;
