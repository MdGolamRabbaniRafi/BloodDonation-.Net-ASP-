// Importing images in Next.js
import DisplayImage from "../public/home2.jpg";
import Image from 'next/image';
const Home1 = () => {
  return (
    <div className="relative flex items-center">
      <div
        className="flex-shrink-0 w-full h-[87vh] bg-cover bg-center   bg-gradient-to-r from-[#43869c] to-[#52bbde]"
        ></div>

      <div className="absolute inset-0 flex items-center ml-36">
        <div className="p-8 text-[#FFFFFF] text-left ">
          <h6 className="text-3xl font-bold mb-2">
            Save a Life
          </h6>
          <h1 className="text-5xl font-bold mb-4">
            Donate Blood <br />
            Healthier Way <br />
            of Life
          </h1>
          <button className="bg-[#73b5b7] hover:bg-blue-600 text-white px-4 py-2 rounded flex items-center">
  Explore <span className="ml-2">→</span>
</button>
        </div>

        <div className="flex-shrink-0 w-[700px] overflow-hidden ">
      <Image
          src="/home.png" // Adjust the path based on your project structure
          alt="Manager"
          className="w-full h-full object-cover "
          width={400} // Set your desired width
          height={400} // Set your desired height
        />
      </div>
      </div>
    </div>
  );
};

export default Home1;
