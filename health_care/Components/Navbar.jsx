import Link from 'next/link';
import Image from 'next/image';


const Navbar = () => {
  return (
    <div className="bg-[#222f3e] text-[#fafafa] p-3
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
        <h4 className="text-2xl font-bold font-lobster">HealthCare</h4>
      </div>
    </div>
        </div>
        <div className="flex-grow">
          <ul className="flex justify-center font-semibold text-xl cursor-pointer">
            <li className="mr-4">
              <Link href="/">Home</Link>
            </li>
            <li className="mr-4">
              <Link href="/About">About</Link>
            </li>
            <li className="mr-4">
              <Link href="/Contact">Contact</Link>
            </li>
            <li className="mr-4">
              <Link href="/Shop">Shop</Link>
            </li>
            <li className="mr-4">
              <Link href="/Service">Service</Link>
            </li>
            <li className="mr-4">
              <Link href="/News">News</Link>
            </li>
          </ul>
        </div>
        <div className="text-center flex mr-10">
          
          <Link href="/Registration" className='text-[#ffffff] text-lg font-Poppins font-bold'>Signup</Link>
          
        </div>
      </div>
    </div>
  );
};

export default Navbar;
