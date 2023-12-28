import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import Image from 'next/image';
import { useRouter } from 'next/router';
import axios from 'axios';




const AdminDashboard = () => {

  useEffect(() => {
      
  });

  return (
    <div>

  <div className="grid grid-cols-12 pr-8 pl-8 mb-2 mt-0">
  <div className="col-span-12 bg-[#dfe4ea] text-[#192a56]  shadow-md">
    <h1 className="text-3xl font-bold mb-4 text-center">Admin Dashboard</h1>
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 w-full justify-center pr-4 pl-4 items-center">
      {/* Card 1 - Total Seller */}
      <div className='bg-[#0abde3] text-white w-full h-40 p-4 shadow-md flex flex-col justify-center items-center rounded-md'>
       
      </div>

      {/* Card 2 - Total Product */}
      <div className='bg-[#f78fb3] text-white w-full h-40 p-4 shadow-md flex flex-col justify-center items-center rounded-md'>
       
      </div>

      {/* Card 3 - Total Users */}
      <div className='bg-[#45aaf2] text-white w-full h-40 p-4 shadow-md flex flex-col justify-center items-center rounded-md'>
        
      </div>

      <div className='bg-[#0fb9b1] text-white w-full h-40 p-4 shadow-md flex flex-col justify-center items-center rounded-md'>
        
      </div>
    </div>

   
    
    
  </div>
</div>

</div>

  );
};


export default AdminDashboard;
