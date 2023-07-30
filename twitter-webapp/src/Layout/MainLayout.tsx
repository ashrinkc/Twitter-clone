import RightBox from "../components/RightBox";
import Sidebar from "../components/Sidebar";
import Home from "../pages/Home";

const Layout = () => {
  return (
    <div className="w-[90%] pt-4 flex pb-5">
      <div className="flex flex-col w-[20%]">
        <Sidebar />
      </div>
      <div className="w-[60%]">
        <Home />
      </div>
      <div className="w-[20%]">
        <RightBox />
      </div>
    </div>
  );
};

export default Layout;
