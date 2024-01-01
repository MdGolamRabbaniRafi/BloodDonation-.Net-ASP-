import Link from 'next/link';
import Image from 'next/image';


const Navbar = () => {
  return (
    <div className="bg-[#ECFAF8] text-gray-500 p-3
     text-sm font-Poppins">
      <div className="container mx-auto flex items-center justify-center">
        <div className="mr-6 text-center flex ml-10">
        <div className="flex items-center">

      {/* <div className="">
      <Image
          src="/Assets/logo.png" // Adjust the path based on your project structure
          alt="Manager"
          className="w-12 h-12 mt-2"
          width={500} // Set your desired width
          height={500} // Set your desired height
        />
      </div> */}
      <div>
        <h4 className="text-xl font-bold font-lobster ml-8"><span className='text-[#05497ee0]'>Health</span><span className='text-[#00b894]'>Care</span> </h4>
      </div>
    </div>
        </div>
        <div className="flex-grow">
          <ul className="flex justify-center font-semibold text-xl cursor-pointer">
            <li className="mr-6">
              <Link href="/">Home</Link>
            </li>
            <li className="mr-6">
              <Link href="/Website/About">About</Link>
            </li>
            <li className="mr-6">
              <Link href="/Website/Contact">Contact</Link>
            </li>
            <li className="mr-6">
              <Link href="/Website/Team">Team</Link>
            </li>
            <li className="mr-6">
              <Link href="/Service">Service</Link>
            </li>
            
          </ul>
        </div>
        <div className="text-center flex mr-10">
          <button className='bg-blue'>
          <Link href="/Auth/Registration" className='text-gray-600 text-lg font-Poppins font-bold mr-8'>Signup</Link>
          </button>
          
        </div>
      </div>
    </div>
  );
};

export default Navbar;
