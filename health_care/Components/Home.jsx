// Importing images in Next.js
import DisplayImage from "../public/home2.jpg";
const Home1 = () => {
  return (
    <div className="relative flex items-center">
      <div
        className="flex-shrink-0 w-full h-[90vh] bg-cover bg-center"
        style={{ backgroundImage: `url(${DisplayImage.src})` }}></div>

      <div className="absolute inset-0 flex items-center ml-36">
        <div className="p-8 text-[#0c2461] text-left ">
          <h6 className="text-3xl font-bold mb-2">
            Save a Life
          </h6>
          <h1 className="text-5xl font-bold mb-4">
            Donate Blood <br />
            Healthier Way <br />
            of Life
          </h1>
          <button className="bg-[#006266] hover:bg-blue-600 text-white px-4 py-2 rounded flex items-center">
  Explore <span className="ml-2">→</span>
</button>
        </div>
      </div>
    </div>
  );
};

export default Home1;
