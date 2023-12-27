import React from 'react'
import Image from 'next/image';

const About = () => {
  return (
    <div className="max-w-[1100px]  mx-auto my-8 p-8 bg-gradient-to-r from-[#f1f2f6] to-[#ffffff] rounded-md shadow-lg text-black flex items-center">
      <div className="flex-shrink-0 w-1/2 overflow-hidden rounded-md mt-16">
      <Image
          src="/home1.jpeg" // Adjust the path based on your project structure
          alt="Manager"
          className="w-full h-full object-cover transition-transform transform hover:scale-105"
          width={300} // Set your desired width
          height={300} // Set your desired height
        />
      </div>
      <div className="w-1/2 pl-8">
        <h1 className="text-4xl font-bold mb-6">About Us</h1>
        <p className="text-lg mb-4">
  Welcome to FarmConnect, your premier destination for all things agriculture and 
  farming. Our commitment is to elevate your farming experience, transforming it into 
  a journey of growth and abundance.
</p>
<p className="text-lg mb-4">
  At FarmConnect, innovation and sustainability are at the core of what we do. 
  Our intuitive platform ensures seamless access to resources
   empowering.
</p>
<p className="text-lg mb-4">
  We are dedicated to ensuring your success in farming. Your needs and aspirations
   are our priority, and our passionate team is here to support you at every stage
    of your farming journey.
</p>

       
      </div>
    </div>
  );
};


export default About