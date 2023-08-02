import { Outlet } from "react-router-dom";
import RightBox from "../components/RightBox";
import Sidebar from "../components/Sidebar";
import Explore from "../pages/Explore";
import Home from "../pages/Home";
import Profile from "../pages/Profile";

const Layout = () => {
  return (
    <div className="w-full flex justify-center">
      <div className="w-[90%] pt-4 flex gap-2 pb-5">
        <div className=" w-[20%]">
          <div className="fixed flex flex-col w-[17%]">
            <Sidebar />
          </div>
        </div>
        <div className="w-[60%] border border-gray-200 p-2">
          <Outlet />
        </div>
        <div className="w-[20%]">
          <div className="fixed">
            <RightBox />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Layout;
