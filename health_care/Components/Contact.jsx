// ContactUsPage.jsx
import React, { useState } from "react";

const Contact = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    message: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your logic here to handle the form submission, such as sending an email or saving to a database
    console.log("Form submitted:", formData);
    // You can also reset the form fields if needed
    setFormData({
      name: "",
      email: "",
      message: "",
    });
  };

  return (
    <div className="bg-[#f1f2f6] min-h-screen flex flex-col justify-center items-center">
      <div className="w-full max-w-[1100px] p-8 bg-white rounded-md shadow-lg mt-5">
        <h1 className="text-4xl font-extrabold mb-6 text-green-800">
          Contact Us
        </h1>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div>
            <p className="text-lg mb-4 text-gray-800">
              Have questions or need assistance? Feel free to reach out to us
              using the contact form or the information below:
            </p>
            <p className="text-lg text-gray-800">
              <strong>Email:</strong> info@bustracker.com
            </p>
            <p className="text-lg text-gray-800">
              <strong>Phone:</strong> (123) 456-7890
            </p>
            <p className="text-lg text-gray-800">
              <strong>Address:</strong> 123 Bus Lane, Cityville, State
            </p>
            <div className="mt-4">
              <p className="text-lg mb-2 text-gray-800">
                Connect with us on social media:
              </p>
              <div className="flex">
                <a
                  href="#"
                  className="text-green-500 hover:text-green-700 mr-4"
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  Facebook
                </a>
                <a
                  href="#"
                  className="text-green-500 hover:text-green-700"
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  Twitter
                </a>
              </div>
            </div>
          </div>
          <div>
            <form onSubmit={handleSubmit}>
              <div className="mb-4">
                <label
                  htmlFor="name"
                  className="block text-lg font-semibold mb-2 text-gray-800"
                >
                  Name:
                </label>
                <input
                  type="text"
                  id="name"
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-green-500"
                  required
                />
              </div>
              <div className="mb-4">
                <label
                  htmlFor="email"
                  className="block text-lg font-semibold mb-2 text-gray-800"
                >
                  Email:
                </label>
                <input
                  type="email"
                  id="email"
                  name="email"
                  value={formData.email}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-green-500"
                  required
                />
              </div>
              <div className="mb-4">
                <label
                  htmlFor="message"
                  className="block text-lg font-semibold mb-2 text-gray-800"
                >
                  Message:
                </label>
                <textarea
                  id="message"
                  name="message"
                  value={formData.message}
                  onChange={handleChange}
                  className="w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:border-green-500 resize-none"
                  rows="4"
                  required
                />
              </div>
              <button
                type="submit"
                className="bg-green-500 text-white px-4 py-2 rounded-full hover:bg-green-600 transition duration-300"
              >
                Submit
              </button>
            </form>
          </div>
        </div>
        
      </div>
    </div>
  );
};

export default Contact;
